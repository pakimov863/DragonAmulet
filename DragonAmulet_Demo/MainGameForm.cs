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
    public partial class MainGameForm : Form
    {
        public MainGameForm()
        {
            InitializeComponent();
        }

        _gameworld GW;
        string mainplayer = "user.admin";

        private void Form1_Load(object sender, EventArgs e)
        {
            

            pan_Game.Visible = false;
            pan_Game.Location = new Point(-999, 12);
            pan_MainMenu.Location = new Point(12, 12);
            pan_MainMenu.Visible = true;


        }

        private void btn_NewGame_Click(object sender, EventArgs e)
        {

        }

        private void btn_ForceGame_Click(object sender, EventArgs e)
        {
            GW = new _gameworld("world.World", "World");
            if (GW.locations_player == null) GW.locations_player = new Dictionary<string, _player>();
            if(!GW.locations_player.ContainsKey(mainplayer))
            {
                GW.locations_player.Add(mainplayer, new _player());
                GW.locations_player[mainplayer].location = "loc.0";
                GW.locations_player[mainplayer].title = "Admin";
                GW.locations_player[mainplayer].skills = new __skills("1|1|1|0|2|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0");
                GW.locations_player[mainplayer].ghost = false;
                GW.locations_player[mainplayer].crim = false;
                GW.locations_player[mainplayer].equip = new __equipdata();
                GW.locations_player[mainplayer].items = new List<_thing>();
                GW.locations_player[mainplayer].items.Add(new _item("item.misc.money", "монеты", 400, 1));
                GW.locations_player[mainplayer].items.Add(new _item("item.note", "записка", 1, 0));
                ((_item)GW.locations_player[mainplayer].items[1]).Description = "Здравствуй, мой юный друг! Зная, что тебе нелегко придется в первое время, я снабдил тебя 400 монетами, потрать их на обучение и, в первую очередь, на поднятие силы и ловкости. Обо всем остальном тебе расскажет привратник Уин. Удачи и береги себя!\n\rподпись: БОГ";
                GW.locations_player[mainplayer].items.Add(new _item("item.scroll.createfood", "свиток Создать еду", 1, 20));
                GW.locations_player[mainplayer].items.Add(new _item("item.scroll.war.arrow", "свиток Магическая стрела", 3, 30));
                GW.locations_player[mainplayer].items.Add(new _item("item.scroll.summon.wolf", "свиток Призвать волка", 2, 45));
                GW.locations_player[mainplayer].magic = new List<string>();
                //GW.locations_player[mainplayer].calcparam();
            }
            RedrawMainWindow();

            pan_MainMenu.Visible = false;
            pan_MainMenu.Location = new Point(-999, 12);
            pan_Game.Location = new Point(12, 12);
            pan_Game.Visible = true;
        }

        void RedrawMainWindow()
        {
            _player _pl = GW.locations_player[mainplayer];
#if DEBUG
            debug_location.Text = GW.locations_info[_pl.location].Id;
#endif
            text_LocDescription.Text =
                "Вы сейчас в: " + GW.locations_info[_pl.location].Title +
                "\r\nЗащита: " + (GW.locations_info[_pl.location].Guard ? "Да" : "Нет") +
                "\r\nОписание: " + GW.locations_info[_pl.location].Description;

            list_LocObjects.Items.Clear();
            foreach (_entity item in GW.locations_data[_pl.location].entitys)
            {
                list_LocObjects.Items.Add(item.Title);
            }
            foreach (_itemlocdata item in GW.locations_data[_pl.location].items)
            {
                list_LocObjects.Items.Add(((_item)item.item).Title);
            }
        }
    }
}
