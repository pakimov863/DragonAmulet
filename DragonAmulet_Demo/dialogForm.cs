using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragonAmulet_Demo
{
    public partial class dialogForm : Form
    {
        // Переменные
        private _entity person1;
        private _entity person2;
        private Dictionary<string, _dialoginfo> npcreplies;

        private string _currentrepl;
        private string _lastrepl;
        private DialogState _state;

        public bool iserror;

        private const int POINTS_LIMIT_ATTR = 5;
        private Random rnd = new Random();

        #region Конструкторы
        public dialogForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создание диалога с NPC
        /// </summary>
        /// <param name="pers1">Игрок-отправитель</param>
        /// <param name="pers2">Персонаж-приемник</param>
        /// <param name="replies">Реплики персонажа</param>
        public dialogForm(ref _player pers1, ref _npc pers2, Dictionary<string, _dialoginfo> replies)
        {
            this.iserror = false;
            if (pers2.owner == pers1.id)
            {
                this.npcreplies.Add("begin", new _dialoginfo("[Диалог с вашим животным]"));
                this.npcreplies["begin"].replies.Add("battle", "Насчет боя...");
                this.npcreplies["begin"].replies.Add("move", "Насчет движения...");
                this.npcreplies["begin"].replies.Add("lask", "Приласкать");
                this.npcreplies["begin"].replies.Add("info", "Состояние");
                this.npcreplies["begin"].replies.Add("end", "Закончить диалог");
                this.npcreplies.Add("battle",new _dialoginfo("[Параметры боя]"));
                this.npcreplies["battle"].replies.Add("guardme", "Защищай меня");
                this.npcreplies["battle"].replies.Add("nelez", "Не лезь в драку");
                this.npcreplies["battle"].replies.Add("attacklist", "Атакуй...");
                this.npcreplies["battle"].replies.Add("guardlist", "Защищай...");
                this.npcreplies["battle"].replies.Add("begin", "Назад");
                this.npcreplies.Add("move",new _dialoginfo("[Параметры движения]"));
                this.npcreplies["move"].replies.Add("move", "Следуй за мной");
                this.npcreplies["move"].replies.Add("stay", "Стой здесь");
                this.npcreplies["move"].replies.Add("followlist", "Следуй за...");
                this.npcreplies["move"].replies.Add("begin", "Назад");
                this.npcreplies.Add("end", new _dialoginfo("[Диалог завершен]"));
            }
            if (pers1 == null || pers2 == null || replies == null)
            { MessageBox.Show("Нет данных для разговора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); this.iserror = true; return; }
            if (!pers2.id.StartsWith("user.") && !pers2.id.StartsWith("npc."))
            { MessageBox.Show("Говорить можно только с игроками и NPC", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); this.iserror = true; return; }
            if (pers1.ghost)
            { MessageBox.Show("Вы призрак и поэтому не можете ни с кем говорить. Найдите лекаря или камень воскрешения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); this.iserror = true; return; }
            if (pers2.attack == pers1.id)
            { MessageBox.Show("Вы не можете разговаривать с персонажем, т.к. он вас атакует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); this.iserror = true; return; }
            pers1.attack = "";
            this.person1 = pers1;
            this.person2 = pers2;
            this.npcreplies = replies;

            InitializeComponent();
            if (pers2.owner == pers1.id) createOwnerDialog();
            else createNPCDialog();
        }

        /// <summary>
        /// Создать диалог с другим игроком
        /// </summary>
        /// <param name="pers1">Игрок-отправитель</param>
        /// <param name="pers2">Игрок-приемник</param>
        public dialogForm(ref _player pers1, ref _player pers2)
        {
            this.iserror = false;
            if (pers1 == null || pers2 == null)
            { MessageBox.Show("Нет данных для разговора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); this.iserror = true; return; }
            if (!pers2.id.StartsWith("user.") || !pers2.id.StartsWith("npc."))
            { MessageBox.Show("Говорить можно только с игроками и NPC", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); this.iserror = true; return; }
            if (pers1.ghost)
            { MessageBox.Show("Вы призрак и поэтому не можете ни с кем говорить. Найдите лекаря или камень воскрешения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); this.iserror = true; return; }
            if (pers2.attack == pers1.id)
            { MessageBox.Show("Вы не можете разговаривать с персонажем, т.к. он вас атакует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); this.iserror = true; return; }
            pers1.attack = ""; 
            this.person1 = pers1;
            this.person2 = pers2;
            this.npcreplies = null;
            createUserDialog();
            InitializeComponent();
        }

        #endregion

        #region Функции-создатели
        /// <summary>
        /// Создать диалог с другим пользователем
        /// </summary>
        private void createUserDialog()
        {
            _currentrepl = "";
            _lastrepl = "";
            _state = DialogState.Userdialog;
            this.Text = String.Format("Диалог: {0} с игроком {1}", person1.title, person2.title);
            lbl_DialogWith.Text = this.Text;
            tb_History.Clear();
            clist_DialogVariants.Items.Clear();
            btn_End.Enabled = true; btn_Say.Enabled = false;
            throw new NotImplementedException("dialogForm -> createUserDialog");
        }

        /// <summary>
        /// Создать диалог с NPC
        /// </summary>
        private void createNPCDialog()
        {
            _currentrepl = "begin";
            _lastrepl = "begin";
            _state = DialogState.Dialog;
            this.Text = String.Format("Диалог: {0} с {1}", person1.title, person2.title);
            lbl_DialogWith.Text = this.Text;
            tb_History.Clear();
            clist_DialogVariants.Items.Clear();
            btn_End.Enabled = true; btn_Say.Enabled = false;
            speakNext();
        }

        /// <summary>
        /// Создать диалог с NPC, которым вы владеете
        /// </summary>
        private void createOwnerDialog()
        {
            _currentrepl = "";
            _lastrepl = "";
            _state = DialogState.Ownerdialog;
            this.Text = String.Format("Диалог: {0} с {1}", person1.title, person2.title);
            lbl_DialogWith.Text = this.Text;
            tb_History.Clear();
            clist_DialogVariants.Items.Clear();
            btn_End.Enabled = true; btn_Say.Enabled = false;
            throw new NotImplementedException("dialogForm -> createOwnerDialog");
        }

        #endregion

        #region Функции диалога
        private void speakNext(int replynumber = -1)
        {
            if (String.IsNullOrWhiteSpace(_currentrepl) || replynumber < -1)
            { _currentrepl = "begin"; _lastrepl = "begin"; replynumber = -1; }

            // Игрок ответил что-либо
            if (replynumber > -1)
            {
                switch (_state)
                {
                    case DialogState.Dialog:
                    default:
                        tb_History.AppendText(String.Format("{0}: {1}\r\n", person1.Title, npcreplies[_currentrepl].replies.ElementAt(replynumber).Value));
                        _lastrepl = _currentrepl;
                        _currentrepl = npcreplies[_currentrepl].replies.ElementAt(replynumber).Key;
                        break;
                    case DialogState.Sell:
                        eventSell(replynumber);
                        break;
                    case DialogState.Buy:
                        eventBuy(replynumber);
                        break;
                    case DialogState.Tobank:
                        eventToBank(replynumber);
                        break;
                    case DialogState.Frombank:
                        eventFromBank(replynumber);
                        break;
                    case DialogState.Ownerdialog:
                        eventOwner(replynumber);
                        break;
                    case DialogState.Userdialog:
                        throw new NotImplementedException();
                }
            }

            clist_DialogVariants.Items.Clear();
            // Проверяем реплики-ключи
            if(_state == DialogState.Ownerdialog)
            {
                speakOwner();
            }
            else if(_currentrepl.EndsWith("now"))
            {
                if (npcreplies[_currentrepl].Title.StartsWith("skill")) speakSkillup(npcreplies[_currentrepl].Title);
                else if (npcreplies[_currentrepl].Title.StartsWith("magic")) speakMagic(npcreplies[_currentrepl].Title);
                else { throw new Exception("dialogForm -> speakNext: error_#"); }
                _currentrepl = _lastrepl;
                speakNext();
            }
            else if(_currentrepl == "buy")
            {
                speakBuy();
            }
            else if (_currentrepl == "sell")
            {
                speakSell();
            }
            else if (_currentrepl == "tobank")
            {
                speakToBank();
            }
            else if (_currentrepl == "frombank")
            {
                speakFromBank();
            }
            else // Если реплика не ключевая - выводим в обычном режиме
            {
                if (!npcreplies.ContainsKey(_currentrepl))
                { throw new Exception("dialogForm -> speakNext: error_#"); }

                tb_History.AppendText(String.Format("{0}: {1}\r\n", person2.Title, npcreplies[_currentrepl].Title.Replace("<name>", person1.Title)));
                for (int i = 0; i < npcreplies[_currentrepl].replies.Count; i++)
                    clist_DialogVariants.Items.Add(npcreplies[_currentrepl].replies.ElementAt(i).Value);
            }
        }

        /// <summary>
        /// Диалог покупки
        /// Часть: отображение текстов
        /// </summary>
        private void speakBuy()
        {
            _state = DialogState.Buy;
            if (person2.trader == null) MessageBox.Show("Это не продавец");
            if (person2.bank.Count == 0) MessageBox.Show("У меня нет товаров");
            // проверим время обновления товаров
            if(DateTime.Now > person2.trader.Trader_time)
            {
                foreach (__itembankdata item in person2.bank)
                {
                    if (rnd.Next(0, 100) > item.Ver) ((_item)item.item).Count = 0;
                    else ((_item)item.item).Count = rnd.Next(item.Min, item.Max);
                }
                person2.trader.Trader_time = DateTime.Now + person2.trader.Period;
            }
            // список
            tb_History.AppendText(String.Format("{0}: На продажу:\r\n", person2.Title));
            int ind = -1;
            foreach (__itembankdata item in person2.bank)
            {
                ind++;
                if (((_item)item.item).Count == 0 || ((_item)item.item).Id == "item.misc.money") continue; // товары с кол-вом 0 и деньги пропускаем
                string s = String.Format("{0} ({1})", ((_item)item.item).Title, ((_item)item.item).Count);
                tb_History.AppendText("> " + s + "\r\n");
                clist_DialogVariants.Items.Add(new __datainclist(ind,s));
            }
            clist_DialogVariants.Items.Add(new __datainclist(++ind, "Я передумал"));
        }

        /// <summary>
        /// Диалог покупки
        /// Часть: обработка сделки
        /// </summary>
        /// <param name="to">id предмета или реплики из списка (person2.bank)</param>
        private void eventBuy(int to)
        {
            if (to < 0 || to > person2.bank.Count) MessageBox.Show("Этого предмета нет");
            if(to == person2.bank.Count)
            {
                MessageBox.Show(String.Format("{0}: Я передумал\r\n", person1.Title));
                _state = DialogState.Dialog;
                _currentrepl = _lastrepl;
                return;
            }
            _thing selItem = (_item)person2.bank.ElementAt(to).item;
            // проверим кол-во
            if (((_item)selItem).Count == 0) MessageBox.Show("Этот предмет кончился, зайдите в другой раз");
            int num = 1;
            if (((_item)selItem).Count > 1)
            {
                // запросим кол-во
                countSelector csel = new countSelector(((_item)selItem), person2.trader.Price_buy);
                if (csel.ShowDialog() != DialogResult.OK)
                {
                    tb_History.AppendText(String.Format("{0}: Я передумал\r\n", person1.Title));
                    _state = DialogState.Dialog;
                    _currentrepl = _lastrepl;
                    return;
                }
                else num = csel.selectedCount;
                csel.Dispose();
            }
            if (num < 1) num = 1;
            if (num > ((_item)selItem).Count) num = ((_item)selItem).Count;
            // считаем стоимость всех предметов с учетом коэфф продавца
            int price = Convert.ToInt32(Math.Round(((_item)selItem).Cost * num * person2.trader.Price_buy));
            // проверяем, хватит ли денег
            _thing moneyItem = null;
            _thing invItem = null;
            foreach (_thing item in person1.items)
            {
                if (((_item)item).Id == "item.misc.money")
                {
                    if (((_item)item).Count >= price) moneyItem = item;
                }
                if (((_item)item).Id == ((_item)selItem).Id)
                {
                    invItem = item;
                }
                if (moneyItem != null && invItem != null) break;
            }
            if (moneyItem == null)
            {
                MessageBox.Show(String.Format("Недостаточно денег (надо {0} монет)", price));
                _state = DialogState.Dialog;
                _currentrepl = _lastrepl;
                return;
            }
            // забираем деньги
            ((_item)moneyItem).Count -= price;
            if (((_item)moneyItem).Count == 0) person1.items.Remove(moneyItem);
            // удаляем из банка продавца
            ((_item)selItem).Count -= num;
            if (((_item)selItem).Count < 0) ((_item)selItem).Count = 0;
            // добавляем игроку в items
            if (invItem != null) ((_item)invItem).Count += num;
            else
            {
                if (selItem is _note) person1.items.Add(new _note((_note)selItem));
                else if (selItem is _weapon) person1.items.Add(new _weapon((_weapon)selItem));
                else if (selItem is _armor) person1.items.Add(new _armor((_armor)selItem));
                else if (selItem is _food) person1.items.Add(new _food((_food)selItem));
                else if (selItem is _item) person1.items.Add(new _item((_item)selItem));
                else if (selItem is _thing) person1.items.Add(new _thing((_thing)selItem));
                else { throw new Exception("dialogForm -> eventBuy: error_#"); }
                ((_item)person1.items.Last()).Count = num;
            }
            MessageBox.Show(String.Format("Вы купили {0} {1} за {2} монет", num, ((_item)selItem).Title, price));
        }

        /// <summary>
        /// Диалог продажи
        /// Часть: отображение текстов
        /// </summary>
        private void speakSell()
        {
            _state = DialogState.Sell;
            if (person2.trader == null) MessageBox.Show("Это не продавец");
            // список
            tb_History.AppendText(String.Format("{0}: Я могу купить:\r\n", person2.Title));
            int ind = -1;
            if (person1.items.Count == 0) MessageBox.Show("У вас нет товаров на продажу");
            foreach (_thing item in person1.items)
            {
                ind++;
                // проверим фильтр товаров
                bool b = true;
                if(person2.trader.trader_filter!=null)
                {
                    b = false;
                    foreach (string filter in person2.trader.trader_filter)
                    {
                        if(((_item)item).Title.Contains(filter))
                        {
                            b = true;
                            break;
                        }
                    }
                }
                // деньги не покупаем
                if (((_item)item).Title.Substring(0, 15) == "item.misc.money") b = false;
                // покупаем только товары, которые есть в фильтре
                if (!b) continue;
                int price = Convert.ToInt32(Math.Round(((_item)item).Cost * person2.trader.Price_sell));
                // за 0 монет не покупаем
                if (price == 0) continue;
                string s = String.Format("{0} ({1})", ((_item)item).Title, ((_item)item).Count);
                tb_History.AppendText("> " + s + "\r\n");
                clist_DialogVariants.Items.Add(new __datainclist(ind, s));
            }
            clist_DialogVariants.Items.Add(new __datainclist(++ind, "Я передумал"));
        }

        /// <summary>
        /// Диалог продажи
        /// Часть: обработка сделки
        /// </summary>
        /// <param name="to">id предмета или реплики из списка (person1.items)</param>
        private void eventSell(int to)
        {
            if (to < 0 || to > person1.items.Count) MessageBox.Show("Этого предмета нет");
            if (to == person1.items.Count)
            {
                MessageBox.Show(String.Format("{0}: Я передумал\r\n", person1.Title));
                _state = DialogState.Dialog;
                _currentrepl = _lastrepl;
                return;
            }
            _thing selItem = (_item)person1.items.ElementAt(to);
            // проверим кол-во
            int num = 1;
            if(((_item)selItem).Count > 1)
            {
                // запросим кол-во
                countSelector csel = new countSelector(((_item)selItem), person2.trader.Price_sell);
                if (csel.ShowDialog() != DialogResult.OK)
                {
                    tb_History.AppendText(String.Format("{0}: Я передумал\r\n", person1.Title));
                    _state = DialogState.Dialog;
                    _currentrepl = _lastrepl;
                    return;
                }
                else num = csel.selectedCount;
                csel.Dispose();
            }
            if (num < 1) num = 1;
            if (num > ((_item)selItem).Count) num = ((_item)selItem).Count;
            // считаем стоимость всех предметов с учетом коэфф продавца
            int price = Convert.ToInt32(Math.Round(((_item)selItem).Cost * num * person2.trader.Price_sell));
            // добавляем деньги
            _thing moneyItem = null;
            foreach (_thing item in person1.items)
            {
                if (((_item)item).Id == "item.misc.money")
                {
                    if (((_item)item).Count >= price) moneyItem = item;
                }
                if (moneyItem != null) break;
            }
            if (moneyItem != null) ((_item)moneyItem).Count += price;
            else person1.items.Add(new _item("item.misc.money", "монеты", price, 1));
            // удаляем из items игрока
            ((_item)selItem).Count -= num;
            if (((_item)selItem).Count < 1)
            {
                person1.items.RemoveAt(to);
                ((_player)person1).calcparam();
            }
            MessageBox.Show(String.Format("Вы продали {0} {1} за {2} монет", num, ((_item)selItem).Title, price));
        }

        /// <summary>
        /// Диалог отправки предмета в банк из инвентаря
        /// Часть: отображение текстов
        /// </summary>
        private void speakToBank()
        {
            _state = DialogState.Tobank;
            if (!person2.bankir) MessageBox.Show("Это не банкир");
            // список
            tb_History.AppendText(String.Format("{0}: Предметы:\r\n", person2.Title));
            if (person1.items.Count == 0) MessageBox.Show("У вас нет ни одного предмета");
            int ind = -1;
            foreach (_thing item in person1.items)
            {
                ind++;
                string s = String.Format("{0} ({1})", ((_item)item).Title, ((_item)item).Count);
                if (person1.equip.IsEquipped(((_item)item).Id)) s += " [одето]";
                tb_History.AppendText("> " + s + "\r\n");
                clist_DialogVariants.Items.Add(new __datainclist(ind, s));
            }
            clist_DialogVariants.Items.Add(new __datainclist(++ind, "Я передумал"));
        }

        /// <summary>
        /// Диалог отправки предмета в банк из инвентаря
        /// Часть: обработка сделки
        /// </summary>
        /// <param name="to">id предмета или реплики из списка (person1.items)</param>
        private void eventToBank(int to)
        {
            if (to < 0 || to > person1.items.Count) MessageBox.Show("Этого предмета нет");
            if (to == person1.items.Count)
            {
                MessageBox.Show(String.Format("{0}: Я передумал\r\n", person1.Title));
                _state = DialogState.Dialog;
                _currentrepl = _lastrepl;
                return;
            }
            _thing selItem = (_item)person1.items.ElementAt(to);
            // проверим кол-во
            int num = 1;
            if (((_item)selItem).Count > 1)
            {
                // запросим кол-во
                countSelector csel = new countSelector(((_item)selItem));
                if (csel.ShowDialog() != DialogResult.OK)
                {
                    tb_History.AppendText(String.Format("{0}: Я передумал\r\n", person1.Title));
                    _state = DialogState.Dialog;
                    _currentrepl = _lastrepl;
                    return;
                }
                else num = csel.selectedCount;
                csel.Dispose();
            }
            if (num < 1) num = 1;
            if (num > ((_item)selItem).Count) num = ((_item)selItem).Count;
            // добавляем игроку в банк
            _thing invItem = null;
            foreach (__itembankdata item in person1.bank)
            {
                if (((_item)item.item).Id == ((_item)selItem).Id)
                {
                    invItem = item.item;
                    break;
                }
            }
            if (invItem != null) ((_item)invItem).Count += num;
            else
            {
                if (selItem is _note) person1.bank.Add(new __itembankdata(0,0,0, new _note((_note)selItem)));
                else if (selItem is _weapon) person1.bank.Add(new __itembankdata(0,0,0, new _weapon((_weapon)selItem)));
                else if (selItem is _armor) person1.bank.Add(new __itembankdata(0,0,0, new _armor((_armor)selItem)));
                else if (selItem is _food) person1.bank.Add(new __itembankdata(0,0,0, new _food((_food)selItem)));
                else if (selItem is _item) person1.bank.Add(new __itembankdata(0,0,0, new _item((_item)selItem)));
                else if (selItem is _thing) person1.bank.Add(new __itembankdata(0,0,0, new _thing((_thing)selItem)));
                else { throw new Exception("dialogForm -> eventToBank: error_#"); }
                ((_item)person1.bank.Last().item).Count = num;
            }
            // удаляем из игрока
            ((_item)selItem).Count -= num;
            if (((_item)selItem).Count <= 0)
            {
                person1.items.RemoveAt(to);
                ((_player)person1).calcparam();
            }
            MessageBox.Show(String.Format("Вы положили в банк {0} {1}", num, ((_item)selItem).Title));
        }

        /// <summary>
        /// Диалог отправки предмета в инвентарь из банка
        /// Часть: отображение текстов
        /// </summary>
        private void speakFromBank()
        {
            _state = DialogState.Frombank;
            if (!person2.bankir) MessageBox.Show("Это не банкир");
            // список
            tb_History.AppendText(String.Format("{0}: Предметы:\r\n", person2.Title));
            if (person1.bank.Count == 0) MessageBox.Show("У вас нет в банке ни одного предмета");
            int ind = -1;
            foreach (__itembankdata item in person1.bank)
            {
                ind++;
                string s = String.Format("{0} ({1})", ((_item)item.item).Title, ((_item)item.item).Count);
                tb_History.AppendText("> " + s + "\r\n");
                clist_DialogVariants.Items.Add(new __datainclist(ind, s));
            }
            clist_DialogVariants.Items.Add(new __datainclist(++ind, "Я передумал"));
        }

        /// <summary>
        /// Диалог отправки предмета в инвентарь из банка
        /// Часть: обработка сделки
        /// </summary>
        /// <param name="to">id предмета или реплики из списка (person1.bank)</param>
        private void eventFromBank(int to)
        {
            if (to < 0 || to > person1.items.Count) MessageBox.Show("В банке нет этого предмета");
            if (to == person1.bank.Count)
            {
                MessageBox.Show(String.Format("{0}: Я передумал\r\n", person1.Title));
                _state = DialogState.Dialog;
                _currentrepl = _lastrepl;
                return;
            }
            _thing selItem = (_item)person1.bank.ElementAt(to).item;
            // проверим кол-во
            int num = 1;
            if (((_item)selItem).Count > 1)
            {
                // запросим кол-во
                countSelector csel = new countSelector(((_item)selItem));
                if (csel.ShowDialog() != DialogResult.OK)
                {
                    tb_History.AppendText(String.Format("{0}: Я передумал\r\n", person1.Title));
                    _state = DialogState.Dialog;
                    _currentrepl = _lastrepl;
                    return;
                }
                else num = csel.selectedCount;
                csel.Dispose();
            }
            if (num < 1) num = 1;
            if (num > ((_item)selItem).Count) num = ((_item)selItem).Count;
            // добавляем игроку в items
            _thing invItem = null;
            foreach (_thing item in person1.items)
            {
                if (((_item)item).Id == ((_item)selItem).Id)
                {
                    invItem = item;
                    break;
                }
            }
            if (invItem != null) ((_item)invItem).Count += num;
            else
            {
                if (selItem is _note) person1.items.Add(new _note((_note)selItem));
                else if (selItem is _weapon) person1.items.Add(new _weapon((_weapon)selItem));
                else if (selItem is _armor) person1.items.Add(new _armor((_armor)selItem));
                else if (selItem is _food) person1.items.Add(new _food((_food)selItem));
                else if (selItem is _item) person1.items.Add(new _item((_item)selItem));
                else if (selItem is _thing) person1.items.Add(new _thing((_thing)selItem));
                else { throw new Exception("dialogForm -> eventToBank: error_#"); }
                ((_item)person1.items.Last()).Count = num;
            }
            // удаляем из банка
            ((_item)selItem).Count -= num;
            if (((_item)selItem).Count <= 0)
            {
                person1.bank.RemoveAt(to);
            }
            MessageBox.Show(String.Format("Вы забрали из банка {0} {1}", num, ((_item)selItem).Title));
        }

        /// <summary>
        /// Диалог с питомцем
        /// Часть: отображение текстов
        /// </summary>
        private void speakOwner()
        {
            this.npcreplies.Add("begin", new _dialoginfo("[Диалог с вашим животным]"));
            this.npcreplies["begin"].replies.Add("battle", "Насчет боя...");
            this.npcreplies["begin"].replies.Add("move", "Насчет движения...");
            this.npcreplies["begin"].replies.Add("lask", "Приласкать");
            this.npcreplies["begin"].replies.Add("info", "Состояние");
            this.npcreplies["begin"].replies.Add("end", "Закончить диалог");
            this.npcreplies.Add("battle", new _dialoginfo("[Параметры боя]"));
            this.npcreplies["battle"].replies.Add("guardme", "Защищай меня");
            this.npcreplies["battle"].replies.Add("nelez", "Не лезь в драку");
            this.npcreplies["battle"].replies.Add("attacklist", "Атакуй...");
            this.npcreplies["battle"].replies.Add("guardlist", "Защищай...");
            this.npcreplies["battle"].replies.Add("begin", "Назад");
            this.npcreplies.Add("move", new _dialoginfo("[Параметры движения]"));
            this.npcreplies["move"].replies.Add("move", "Следуй за мной");
            this.npcreplies["move"].replies.Add("stay", "Стой здесь");
            this.npcreplies["move"].replies.Add("followlist", "Следуй за...");
            this.npcreplies["move"].replies.Add("begin", "Назад");
            this.npcreplies.Add("end", new _dialoginfo("[Диалог завершен]"));
            /////////////////////////////////////////////

        }

        /// <summary>
        /// Диалог с питомцем
        /// Часть: обработка ответа
        /// </summary>
        /// <param name="to">id реплики из списка команд</param>
        private void eventOwner(int to)
        {
            
        }

        /// <summary>
        /// Ветвь диалога - добавление магии
        /// </summary>
        /// <param name="data">Данные о магии в формате: magic|ID|COST|MINLVL</param>
        private void speakMagic(string data)
        {
            if(String.IsNullOrWhiteSpace(data))
            { throw new Exception("dialogForm -> speakMagic: error_#"); }

            string[] dialog = data.Split('|');
            if (person1.magic.Contains(dialog[0])) // Проверим, есть ли такое заклинание
            { MessageBox.Show("У вас уже есть это заклинание", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (person1.skills.Magic < Convert.ToInt32(dialog[3])) // Проверим минимальный уровень
            { MessageBox.Show(String.Format("У вас недостаточный навык магии (надо минимум {0})", dialog[3]), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            bool ok = false; // Проверим, хватает ли денег
            foreach (_thing item in person1.items)
            {
                if (((_item)item).Id == "item.misc.money")
                {
                    if (((_item)item).Count >= Convert.ToInt32(dialog[2]))
                    { ((_item)item).Count -= Convert.ToInt32(dialog[2]); ok = true; }
                    break;
                }
            }
            if(!ok)
            { MessageBox.Show(String.Format("У вас недостаточно денег (надо {0} монет)", dialog[2]), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            // Если денег хватило - добавим заклинание
            person1.magic.Add(dialog[1]);
            MessageBox.Show("Вы выучили новое заклинание!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Ветвь диалога - повышение навыка на 1
        /// </summary>
        /// <param name="data">Данные о навыке в формате: skill|ID|COST|MINLVL|MAXLVL</param>
        private void speakSkillup(string data)
        {
            if (String.IsNullOrWhiteSpace(data))
            { throw new Exception("dialogForm -> speakSkillup: error_#"); }

            string[] dialog = data.Split('|');
            // Проверим, есть ли очки опыта
            if(person1.skills.Points < 1)
            { MessageBox.Show("Недостаточно очков опыта", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            // Проверим минимальный и макс. уровень
            if(person1.skills.GetSkillByName(dialog[1])<Convert.ToInt32(dialog[3]))
            { MessageBox.Show(String.Format("Вы должны иметь уровень навыка не ниже {0}",dialog[3]), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (person1.skills.GetSkillByName(dialog[1]) < Convert.ToInt32(dialog[4]))
            { MessageBox.Show(String.Format("Вы и так достаточно опытны, я учу только до уровня {0}", dialog[4]), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (person1.skills.GetSkillByName(dialog[1]) + 1 > POINTS_LIMIT_ATTR)
            { MessageBox.Show(String.Format("Невозможно повысить, т.к. аттрибут уже на максимальном уровне {0}", POINTS_LIMIT_ATTR), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            bool ok = false; // Проверим, хватает ли денег
            foreach (_thing item in person1.items)
            {
                if (((_item)item).Id == "item.misc.money")
                {
                    if (((_item)item).Count >= Convert.ToInt32(dialog[2]))
                    { ((_item)item).Count -= Convert.ToInt32(dialog[2]); ok = true; }
                    break;
                }
            }
            if (!ok)
            { MessageBox.Show(String.Format("У вас недостаточно денег (надо {0} монет)", dialog[2]), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            // Если денег хватило - добавим навык +1
            person1.skills.SetSkillByName(dialog[1],person1.skills.GetSkillByName(dialog[1])+1);
            // Уменьшим очки опыта
            person1.skills.Points --;
            // Пересчитаем основные параметры
            ((_player)person1).calcparam();
            MessageBox.Show("Вы увеличили навык на 1!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region События формы
        private void btn_Say_Click(object sender, EventArgs e)
        {
            if (clist_DialogVariants.CheckedItems.Count != 1) return;
            int selected = -1;
            for (int i = 0; i < clist_DialogVariants.Items.Count; i++)
            {
                if (clist_DialogVariants.GetItemChecked(i))
                {
                    if (clist_DialogVariants.Items[i] is __datainclist)
                        selected = ((__datainclist)clist_DialogVariants.Items[i]).index;
                    else selected = i;
                    btn_Say.Enabled = false;
                    break;
                }
            }
            speakNext(selected);
        }

        private void clist_DialogVariants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clist_DialogVariants.CheckedItems.Count > 1)
            {
                for (int i = 0; i < clist_DialogVariants.Items.Count; i++)
                    clist_DialogVariants.SetItemChecked(i, false);
                clist_DialogVariants.SetItemChecked(clist_DialogVariants.SelectedIndex, true);
            }

            btn_Say.Enabled = (clist_DialogVariants.CheckedItems.Count == 1);
        }

        private void btn_End_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// Стадия диалога - задает режим общения
        /// </summary>
        private enum DialogState
        {
            Dialog,
            Sell,
            Buy,
            Tobank,
            Frombank,
            Ownerdialog,
            Userdialog,
        }

        private class __datainclist
        {
            public int index;
            public string text;

            public __datainclist(int index, string text)
            {
                this.index = index;
                this.text = text;
            }

            public string ToString()
            {
                return this.text;
            }
        }
    }
}
