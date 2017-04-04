using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonAmulet_Demo
{
    static class utilites
    {
        public static Random rnd = new Random();

        public static string getRandomName()
        {
            string[] arr_rndnames = { "cor", "ur", "ae", "li", "sim", "na", "vax", "vin", "lib", "er", "mac", "cam", "is", "ta", "gor", "i", "ca", "um", "mu", "og", "os", "na", "tru", "ver", "vay", "an", "as", "prin", "su", "oc", "dor", "a", "mor", "ia", "gon", "ar", "nor", "ang", "dai", "mar", "grace", "van", "dir", "am", "va", "ber", "em", "je", "tar", "she", "eru", "ilu", "rat", "gil", "do", "ge", "lad", "le", "go", "bins", "las", "gim", "li", "fro", "tor", "tol", "mab", "den", "va", "dag", "tir", "na", "nogt", "es", "ka", "bur", "du", "ran", "dal", "ken", "vap", "dlo", "negn", "mur", "kok", "mel", "rul", "sa", "ru", "gan", "uuk", "map", "blo", "son", "eva", "nul", "eng", "zah", "vat", "obi", "no", "rip", "bi", "car", "ma", "lan", "be", "ril", "log", "raf", "hill", "nart", "bosk", "ir", "gard", "is", "en", "ged", "gob", "cri", "sa", "ru", "man", "shna", "god", "re", "vur", "ar", "tur", "el", "eri", "ker", "shed", "gae", "bol", "der", "desh", "nol", "nek", "dur", "vek", "nang", "zug", "cup", "ida", "lum", "ir", "si", "jai", "kon", "nel", "jer", "lorn", "gan", "fax", "ber", "sa", "got", "vald", "lance", "der", "feld", "kay", "had", "ja", "gun", "tal", "nai", "ven", "det", "nog", "aro", "kle", "vam", "dam", "sic", "erg", "unk", "ils", "dol", "dul", "gu", "arc", "jin", "shel", "chri", "chra", "gec", "apr", "anu", "al", "van", "a", "e", "si", "an", "na", "u", "ol", "it", "du", "uv", "ai", "go", "she", "zu" };
            string stmp = "";
            while (stmp.Length <= rnd.Next(5, 7)) stmp += arr_rndnames[rnd.Next(0, arr_rndnames.Length)];
            stmp = stmp[0].ToString().ToUpper() + stmp.Substring(1);
            return stmp;
        }

    }


    #region Мир и локации

    public class _gameworld
    {
        private string id;
        private string title;
        private int lastai;

        public Dictionary<string, _locationinfo> locations_info;
        public Dictionary<string, _locationdata> locations_data;
        public Dictionary<string, _player> locations_player;

        public Dictionary<string, _thing> const_items;
        public Dictionary<string, _magic> const_magics;
        public Dictionary<string, _entity> const_entitys;
        public Dictionary<string, Dictionary<string, _dialoginfo>> const_dialogs;

        public _gameworld()
        {
            this.id = "";
            this.title = "";
            this.lastai = 0;

            this.const_items = new Dictionary<string, _thing>();
            this.const_magics = new Dictionary<string, _magic>();
            this.const_entitys = new Dictionary<string, _entity>();
            this.const_dialogs = new Dictionary<string, Dictionary<string, _dialoginfo>>();

            this.locations_data = new Dictionary<string, _locationdata>();
            this.locations_info = new Dictionary<string, _locationinfo>();
            this.locations_player = new Dictionary<string, _player>();
        }

        public _gameworld(string id, string title, bool additems_flag = true, bool addentitys_flag = true)
        {
            this.id = id;
            this.title = title;
            this.lastai = 0;

            this.const_items = new Dictionary<string, _thing>();
            create_const_items();
            this.const_magics = new Dictionary<string, _magic>();
            create_const_magic();
            this.const_entitys = new Dictionary<string, _entity>();
            create_const_entitys();
            this.const_dialogs = new Dictionary<string, Dictionary<string, _dialoginfo>>();
            create_const_dialogs();

            this.locations_info = new Dictionary<string, _locationinfo>();
            create_locationsinfos();
            this.locations_data = new Dictionary<string, _locationdata>();
            create_locationdatas(additems_flag, addentitys_flag);
            this.locations_player = new Dictionary<string, _player>();
        }

        public string Id { get { return this.id; } set { this.id = value; } }

        public string Title { get { return this.title; } set { this.title = value; } }

        public int Lastai { get { return this.lastai; } set { this.lastai = value; } }

        private void create_const_entitys()
        {
            const_entitys.Add("npc.summon.wolf", new _animal("npc.summon.wolf","волк",20,20,new __wardata("70|4|11|5|0|0|5|0|0|0|0|0|зубами|0||")));
            const_entitys.Add("npc.summon.skeleton", new _animal("npc.summon.skeleton","скелет",30,30,new __wardata("65|5|12|6|0|0|10|0|0|0|0|0||0||")));
            const_entitys.Add("npc.summon.golem", new _animal("npc.summon.golem","голем",50,50,new __wardata("90|8|14|7|0|5|10|0|0|30|50|4||0||")));
            const_entitys.Add("npc.summon.demon", new _animal("npc.summon.demon","демон",80,80,new __wardata("95|9|18|7|0|3|10|0|0|20|70|8||0||")));
            const_entitys.Add("npc.animal.deer", new _animal("npc.animal.deer","олень",20,20,new __wardata("70|2|6|4|0|0|5|0|0|0|0|0|рогами|6||")));
            ((_animal)const_entitys["npc.animal.deer"]).Tame = 1;
            const_entitys["npc.animal.deer"].osvej.Add(new _item("item.food.meat", "мясо", 3, 10));
            const_entitys["npc.animal.deer"].osvej.Add(new _item("item.hunter.skin.deer", "шкура оленя", 1, 7));
            const_entitys["npc.animal.deer"].osvej.Add(new _item("item.hunter.horn", "рога", 1, 10));
            const_entitys.Add("npc.animal.sheep", new _animal("npc.animal.sheep","овца",7,7,new __wardata("60|0|3|6|0|0|5|0|0|0|0|0|копытами|2||")));
            ((_animal)const_entitys["npc.animal.sheep"]).Tame = 1;
            const_entitys["npc.animal.sheep"].osvej.Add(new _item("item.food.meat", "мясо", 1, 10));
            const_entitys["npc.animal.sheep"].osvej.Add(new _item("item.hunter.skin.sheep", "шкура овцы", 1, 6));
            const_entitys["npc.animal.sheep"].osvej.Add(new _item("item.hunter.kop", "копыта", 1, 8));
            const_entitys.Add("npc.animal.cow", new _animal("npc.animal.cow","корова",7,7,new __wardata("70|0|6|8|0|0|5|0|0|0|0|0||5||")));
            ((_animal)const_entitys["npc.animal.cow"]).Tame = 1;
            const_entitys["npc.animal.cow"].osvej.Add(new _item("item.food.meat", "мясо", 4, 10));
            const_entitys["npc.animal.cow"].osvej.Add(new _item("item.hunter.kop", "копыта", 1, 8));
            const_entitys.Add("npc.animal.hen", new _animal("npc.animal.hen","курица",2,2,new __wardata("60|0|3|4|0|0|5|0|0|0|0|0|клювом|1||")));
            ((_animal)const_entitys["npc.animal.hen"]).Tame = 1;
            const_entitys["npc.animal.hen"].osvej.Add(new _item("item.food.meat", "мясо", 1, 10));
            const_entitys["npc.animal.hen"].osvej.Add(new _item("item.hunter.feather", "перо", 4, 2));
            const_entitys.Add("npc.animal.pig", new _animal("npc.animal.pig","свинья",4,4,new __wardata("40|1|5|4|0|0|5|0|0|0|0|0||2||")));
            ((_animal)const_entitys["npc.animal.pig"]).Tame = 1;
            const_entitys["npc.animal.pig"].osvej.Add(new _item("item.food.meat", "мясо", 2, 10));
            const_entitys.Add("npc.animal.wildboar", new _animal("npc.animal.wildboar","кабан",12,12,new __wardata("80|4|6|6|0|0|5|0|0|0|0|0||4||")));
            ((_animal)const_entitys["npc.animal.wildboar"]).Tame = 2;
            const_entitys["npc.animal.wildboar"].osvej.Add(new _item("item.food.meat", "мясо", 1, 10));
            const_entitys["npc.animal.wildboar"].osvej.Add(new _item("item.hunter.skin", "шкура", 1, 5));
            const_entitys.Add("npc.animal.dove", new _animal("npc.animal.dove","голубь",1,1,new __wardata("20|1|5|4|0|0|5|0|0|0|0|0|клювом|1||")));
            const_entitys["npc.animal.dove"].osvej.Add(new _item("item.hunter.feather", "перо", 2, 2));
            const_entitys.Add("npc.animal.crow", new _animal("npc.animal.crow","ворона",4,4,new __wardata("80|0|3|4|0|0|5|0|0|0|0|0|клювом|2||")));
            const_entitys["npc.animal.crow"].osvej.Add(new _item("item.hunter.feather", "перо", 3, 2));
            const_entitys.Add("npc.animal.hare", new _animal("npc.animal.hare","заяц",5,5,new __wardata("50|0|1|4|0|0|5|0|0|0|0|0||2||")));
            ((_animal)const_entitys["npc.animal.hare"]).Tame = 1;
            const_entitys["npc.animal.hare"].osvej.Add(new _item("item.food.meat", "мясо", 2, 10));
            const_entitys.Add("npc.animal.fox", new _animal("npc.animal.fox","лиса",15,15,new __wardata("50|3|5|4|0|0|5|0|0|0|0|0||5||")));
            ((_animal)const_entitys["npc.animal.fox"]).Tame = 2;
            const_entitys["npc.animal.fox"].osvej.Add(new _item("item.food.meat", "мясо", 1, 10));
            const_entitys["npc.animal.fox"].osvej.Add(new _item("item.hunter.skin", "шкура", 1, 5));
            const_entitys["npc.animal.fox"].osvej.Add(new _item("item.hunter.claw", "когти", 1, 5));
            const_entitys.Add("npc.animal.dog", new _animal("npc.animal.dog","собака",28,28,new __wardata("80|6|9|4|0|0|20|0|0|0|0|0|зубами|8||")));
            ((_animal)const_entitys["npc.animal.dog"]).Tame = 1;
            const_entitys["npc.animal.dog"].osvej.Add(new _item("item.food.meat", "мясо", 1, 10));
            const_entitys["npc.animal.dog"].osvej.Add(new _item("item.hunter.skin", "шкура", 1, 5));
            const_entitys["npc.animal.dog"].osvej.Add(new _item("item.hunter.teeths", "клыки", 1, 8));
            const_entitys.Add("npc.crim.rat", new _animal("npc.crim.rat","крыса",6,6,new __wardata("80|0|4|6|0|0|5|0|0|0|0|0||4||")));
            const_entitys.Add("npc.crim.snake", new _animal("npc.crim.snake","змея",18,18,new __wardata("90|4|8|5|0|0|5|0|0|0|0|0||12||")));
            const_entitys.Add("npc.crim.wolf", new _animal("npc.crim.wolf","волк",25,25,new __wardata("70|4|11|5|0|0|5|0|0|0|0|0|зубами|16||")));
            ((_animal)const_entitys["npc.crim.wolf"]).Tame = 1;
            const_entitys["npc.crim.wolf"].osvej.Add(new _item("item.food.meat", "мясо", 1, 10));
            const_entitys["npc.crim.wolf"].osvej.Add(new _item("item.hunter.skin.wolf", "шкура волка", 1, 10));
            const_entitys["npc.crim.wolf"].osvej.Add(new _item("item.hunter.teeths", "клыки", 1, 8));
            const_entitys.Add("npc.crim.bear", new _animal("npc.crim.bear","медведь",45,45,new __wardata("70|8|18|10|0|0|5|0|0|0|0|0|зубами|22||")));
            ((_animal)const_entitys["npc.crim.bear"]).Tame = 3;
            const_entitys["npc.crim.bear"].osvej.Add(new _item("item.food.meat", "мясо", 2, 10));
            const_entitys["npc.crim.bear"].osvej.Add(new _item("item.hunter.skin", "шкура", 1, 5));
            const_entitys["npc.crim.bear"].osvej.Add(new _item("item.hunter.claw", "когти", 1, 5));
            const_entitys.Add("npc.crim.zombie", new _animal("_item.crim.zombie","зомби",14,14,new __wardata("65|2|6|8|0|0|5|0|0|0|0|0||12||")));
            const_entitys["npc.crim.zombie"].items.Add(new _item("item.misc.money","монеты",8,1));
            const_entitys.Add("npc.crim.skeleton", new _animal("npc.crim.skeleton","скелет",20,20,new __wardata("65|4|12|6|0|0|10|0|0|0|0|0||21||")));
            const_entitys["npc.crim.skeleton"].osvej.Add(new _item("item.hunter.bone", "кость", 1, 5));
            const_entitys["npc.crim.skeleton"].items.Add(new _item("item.misc.money","монеты",12,1));
            const_entitys.Add("npc.crim.warriorskeleton", new _animal("npc.crim.warriorskeleton","воин-скелет",35,35,new __wardata("80|6|18|6|0|0|10|20|2|0|0|0|мечом|25||")));
            const_entitys["npc.crim.warriorskeleton"].osvej.Add(new _item("item.hunter.bone", "кость", 2, 5));
            const_entitys["npc.crim.warriorskeleton"].equip = new __equipdata("item.weapon.shortsword", "", "", "", "", "item.armor.shield.wood");
            const_entitys["npc.crim.warriorskeleton"].items.Add(new _item("item.misc.money","монеты",14,1));
            const_entitys["npc.crim.warriorskeleton"].items.Add(new _armor("item.armor.shield.wood","деревянный щит",1,80,1));
            const_entitys["npc.crim.warriorskeleton"].items.Add(new _weapon("item.weapon.shortsword","короткий меч",1,30,3,4,0,5,"мечом","",""));
            const_entitys.Add("npc.crim.vampire", new _animal("npc.crim.vampire","вампир",70,70,new __wardata("80|9|18|7|0|0|30|0|0|0|0|0||35||")));
            const_entitys["npc.crim.vampire"].osvej.Add(new _item("item.hunter.teeths", "клыки", 1, 8));
            const_entitys["npc.crim.vampire"].items.Add(new _item("item.misc.money","монеты",22,1));
            const_entitys.Add("npc.crim.shadow", new _animal("npc.crim.shadow","тень",16,16,new __wardata("70|3|14|5|0|0|20|0|0|0|0|0||26||")));
            const_entitys["npc.crim.shadow"].items.Add(new _item("item.misc.money","монеты",18,1));
            const_entitys.Add("npc.crim.witch", new _animal("npc.crim.witch","ведьма",12,12,new __wardata("70|2|8|6|0|0|10|0|0|20|0|0||12||")));
            const_entitys["npc.crim.witch"].items.Add(new _item("item.misc.money","монеты",14,1));
            const_entitys.Add("npc.crim.orc", new _animal("npc.crim.orc","орк",28,28,new __wardata("80|4|12|7|0|1|10|0|0|0|0|0||18||")));
            const_entitys["npc.crim.orc"].items.Add(new _item("item.misc.money","монеты",25,1));
            const_entitys.Add("npc.crim.orcwarrior", new _animal("npc.crim.orcwarrior","орк-воин",40,40,new __wardata("80|8|18|7|0|3|10|10|4|0|0|0|мечом|30||")));
            const_entitys["npc.crim.orcwarrior"].items.Add(new _item("item.misc.money","монеты",30,1));
            const_entitys["npc.crim.orcwarrior"].items.Add(new _weapon("item.weapon.halfsword","полуторный меч",1,40,4,5,2,5,"мечом","",""));
            const_entitys["npc.crim.orcwarrior"].equip = new __equipdata("item.weapon.halfsword","","","","","");
            const_entitys.Add("npc.crim.ogr", new _animal("npc.crim.ogr","огр",90,90,new __wardata("80|12|22|8|0|2|5|0|0|10|0|0||40||")));
            const_entitys["npc.crim.ogr"].items.Add(new _item("item.misc.money","монеты",30,1));
            const_entitys["npc.crim.ogr"].osvej.Add(new _item("item.hunter.skin.ogr", "шкура огра", 1, 50));
            const_entitys.Add("npc.crim.ogrwarrior", new _animal("npc.crim.ogrwarrior","огр-воин",100,100,new __wardata("80|16|24|8|0|2|5|0|0|10|0|0|дубиной|40||")));
            const_entitys["npc.crim.ogrwarrior"].items.Add(new _item("item.misc.money","монеты",50,1));
            const_entitys["npc.crim.ogrwarrior"].items.Add(new _weapon("item.weapon.crookedsword","кривой меч",1,60,4,7,2,6,"мечом","",""));
            const_entitys["npc.crim.ogrwarrior"].equip = new __equipdata("item.weapon.crookedsword", "", "", "", "", "");
            const_entitys["npc.crim.ogrwarrior"].osvej.Add(new _item("item.hunter.skin.ogr", "шкура огра", 1, 50));
            const_entitys.Add("npc.crim.troll", new _animal("npc.crim.troll","тролль",120,120,new __wardata("75|15|25|9|0|6|5|0|0|0|40|4||60||")));
            const_entitys["npc.crim.troll"].osvej.Add(new _item("item.hunter.skin.troll", "шкура тролля", 1, 70));
            const_entitys["npc.crim.troll"].items.Add(new _item("item.misc.money","монеты",75,1));
            //humans
            const_entitys.Add("npc.guard", new _npc("npc.guard","Стража",1000,1000,"npc.guard",new __wardata(100,100,100,4,0,100,100,0,0,100,0,0,"алебардой",0,"","")));
            const_entitys.Add("npc.healer", new _npc("npc.healer","Джозеф [лекарь]",1000,1000,"npc.healer", new __wardata("80|3|6|4|0|0|10|0|0|0|0|0|врукопашную|0||")));
            ((_npc)const_entitys["npc.healer"]).Bankir = true;
            const_entitys.Add("npc.trader", new _npc("npc.trader","Торговец",40,40,"npc.trader",new __wardata("60|4|8|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.bankir", new _npc("npc.bankir","Лукас [банкир]",1000,1000,"npc.bankir",new __wardata("60|3|6|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            ((_npc)const_entitys["npc.bankir"]).Bankir = true;
            const_entitys.Add("npc.beginner", new _npc("npc.beginner","Привратник Уин",1000,1000,"npc.beginner",new __wardata("100|100|100|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Gant", new _npc("npc.Gant","Гант",1000,1000,"npc.Gant",new __wardata("80|12|15|4|0|0|10|30|4|0|0|0|мечом|0||")));
            const_entitys.Add("npc.LordHagen", new _npc("npc.LordHagen","Лорд Хаген",1000,1000,"npc.LordHagen",new __wardata("80|14|18|4|0|0|30|0|0|0|0|0|мечом|0||")));
            const_entitys.Add("npc.Rene", new _npc("npc.Rene","Рене",1000,1000,"npc.Rene" ,new __wardata("80|8|10|4|0|0|20|0|0|0|0|0|мечом|0||")));
            const_entitys.Add("npc.Silvestr", new _npc("npc.Silvestr","Сильвестр",1000,1000,"npc.Silvestr" ,new __wardata("60|2|4|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Stouns", new _npc("npc.Stouns","Стоунс",1000,1000,"npc.Stouns" ,new __wardata("70|4|7|4|0|0|10|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.KantaresNovobranec", new _npc("npc.KantaresNovobranec","Ученик",1000,1000,"npc.KantaresNovobranec" ,new __wardata("65|5|7|4|0|0|5|0|0|0|0|0|мечом|0||")));
            const_entitys.Add("npc.Kantares", new _npc("npc.Kantares","Кантарес",1000,1000,"npc.Kantares" ,new __wardata("95|8|12|4|0|0|30|0|0|0|0|0|мечом|0||")));
            const_entitys.Add("npc.Hans", new _npc("npc.Hans","Ханс",1000,1000, "npc.Hans",new __wardata("70|4|18|4|0|0|30|0|0|0|0|0|луком|0||")));
            const_entitys.Add("npc.Ded", new _npc("npc.Ded","Старый дед",1000,1000, "npc.Ded",new __wardata("50|0|3|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Malchugan", new _npc("npc.Malchugan","Мальчуган",1000,1000,"npc.Malchugan" ,new __wardata("70|0|4|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Mahmet", new _npc("npc.Mahmet","Махмет [торговец]",1000,1000,"npc.Mahmet" ,new __wardata("60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Julien", new _npc("npc.Julien","Жульен [торговец]",1000,1000,"npc.Julien" ,new __wardata("60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Goston", new _npc("npc.Goston","Гостон [торговец]",1000,1000, "npc.Goston",new __wardata("60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Raksha", new _npc("npc.Raksha","Ракша [торговка]",1000,1000,"npc.Raksha" ,new __wardata("60|1|3|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Arant", new _npc("npc.Arant","Арант [торговец]",1000,1000, "npc.Arant",new __wardata("60|6|9|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Milta", new _npc("npc.Milta","Милта [торговец]",1000,1000, "npc.Milta",new __wardata("60|6|9|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Frederik", new _npc("npc.Frederik","Фредерик [торговец]",1000,1000,"npc.Frederik" ,new __wardata("60|2|4|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Surri", new _npc("npc.Surri" ,"Сурри",1000,1000,"npc.Surri",new __wardata("60|1|4|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Sirs", new _npc("npc.Sirs","Сирс",1000,1000,"npc.Sirs" ,new __wardata("60|1|4|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Markus", new _npc("npc.Markus","Маркус",1000,1000, "npc.Markus",new __wardata("90|7|9|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Sloven", new _npc("npc.Sloven" ,"Словен [торговец]",1000,1000,"npc.Sloven",new __wardata("60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Yan", new _npc("npc.Yan","Ян [охотник]",1000,1000, "npc.Yan",new __wardata("60|4|13|4|0|0|5|0|0|0|0|0|луком|0||")));
            const_entitys.Add("npc.Leksli", new _npc("npc.Leksli","Лексли",1000,1000,"npc.Leksli" ,new __wardata("80|4|7|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Batist", new _npc("npc.Batist","Батист",1000,1000,"npc.Batist" ,new __wardata("70|3|6|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Djon", new _npc("npc.Djon","Джон",1000,1000,"npc.Djon" ,new __wardata("60|0|4|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Gregg", new _npc("npc.Gregg","Грегг",1000,1000,"npc.Gregg" ,new __wardata("60|4|6|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Stoun", new _npc("npc.Stoun","Стоун",1000,1000,"npc.Stoun" ,new __wardata("60|3|4|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Silvio", new _npc("npc.Silvio","Сильвио [торговец]",1000,1000,"npc.Silvio" ,new __wardata("60|3|9|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Franchesko", new _npc("npc.Franchesko","Франческо",1000,1000, "npc.Franchesko",new __wardata("60|3|9|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Djoshua", new _npc("npc.Djoshua","Джошуа [торговец]",1000,1000,"npc.Djoshua" ,new __wardata("40|1|4|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Klavdius", new _npc("npc.Klavdius","Клавдиус",1000,1000,"npc.Klavdius" ,new __wardata("40|1|4|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Antonio", new _npc("npc.Antonio","Антонио",1000,1000,"npc.Antonio" ,new __wardata("60|4|9|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Serpent", new _npc("npc.Serpent","Серпент",1000,1000,"npc.Serpent" ,new __wardata("60|4|9|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Milton", new _npc("npc.Milton" ,"Мильтон",1000,1000,"npc.Milton",new __wardata("60|4|9|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Raks", new _npc("npc.Raks" ,"Ракс [кузнец]",1000,1000,"npc.Raks",new __wardata("80|8|11|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Silt", new _npc("npc.Silt","Силт [торговец]",1000,1000, "npc.Silt",new __wardata("80|5|6|4|0|0|5|0|0|0|0|0|врукопашную|0||")));
            const_entitys.Add("npc.Plant", new _npc("npc.Plant","Плант [торговец]",1000,1000, "npc.Plant",new __wardata("80|9|13|4|0|0|5|0|0|0|0|0|мечом|0||")));
        }

        private void create_const_dialogs()
        {
            const_dialogs.Add("npc.guard", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.guard"].Add("begin", new _dialoginfo("Что ты хочешь узнать?"));
            const_dialogs["npc.guard"]["begin"].replies.Add("who", "Кто вы?");
            const_dialogs["npc.guard"]["begin"].replies.Add("what", "Что вы здесь делаете?");
            const_dialogs["npc.guard"]["begin"].replies.Add("where", "А где тут...");
            const_dialogs["npc.guard"]["begin"].replies.Add("end", "Нет, ничего, я ошибся");
            const_dialogs["npc.guard"].Add("who", new _dialoginfo("Мы городская стража, разве не это не заметно?"));
            const_dialogs["npc.guard"]["who"].replies.Add("what", "И чем вы занимаетесь?");
            const_dialogs["npc.guard"]["who"].replies.Add("who2", "Городская стража?");
            const_dialogs["npc.guard"]["who"].replies.Add("end", "Понятно, ну, мне пора...");
            const_dialogs["npc.guard"].Add("what", new _dialoginfo("Мы защищаем мирных граждан от преступников и всякой нечисти, что прет из окрестных лесов."));
            const_dialogs["npc.guard"]["what"].replies.Add("help", "Ух-ты! А можно мне с вами?");
            const_dialogs["npc.guard"]["what"].replies.Add("prest", "Каких преступников?");
            const_dialogs["npc.guard"]["what"].replies.Add("begin", "Ясно");
            const_dialogs["npc.guard"].Add("where", new _dialoginfo("Эй, я же на службе и в мои обязанности не входит работать путеводителем."));
            const_dialogs["npc.guard"]["where"].replies.Add("begin", "Ок, сменим тему");
            const_dialogs["npc.guard"]["where"].replies.Add("what", "А что входит?");
            const_dialogs["npc.guard"]["where"].replies.Add("end", "Тогда не буду мешать");
            const_dialogs["npc.guard"].Add("who2", new _dialoginfo("Ну да, отборные войска, лучшие из лучших и все такое. Вот будет заварушка, убедишься сам."));
            const_dialogs["npc.guard"]["who2"].replies.Add("can", "Я тоже хочу стать стражником!");
            const_dialogs["npc.guard"]["who2"].replies.Add("end", "Хм.. много чести разговаривать с таким хвастуном...");
            const_dialogs["npc.guard"].Add("can", new _dialoginfo("Вряд ли у тебя получится, чтобы стать городским стражником, надо быть действительно лучшим, а кроме того, примерным горожанином. Поживи здесь, познакомься с людьми и тогда посмотрим..."));
            const_dialogs["npc.guard"]["can"].replies.Add("imp", "Так все-таки, как стать стражником?");
            const_dialogs["npc.guard"]["can"].replies.Add("begin", "Эээ... Я передумал...");
            const_dialogs["npc.guard"].Add("imp", new _dialoginfo("[сердится] Как да как, вот пристал. Как только так сразу! Не задавай дурацких вопросов!"));
            const_dialogs["npc.guard"]["imp"].replies.Add("begin", "Хорошо, не буду");
            const_dialogs["npc.guard"].Add("prest", new _dialoginfo("Ну, воришек там всяких, убийц и тому подобной дряни. А также тех кто им помогает."));
            const_dialogs["npc.guard"]["prest"].replies.Add("help", "Хорошее дело, а помощь вам нужна?");
            const_dialogs["npc.guard"]["prest"].replies.Add("end", "Эээ... я, пожалуй, пойду отсюда, что-то мне здесь разонравилось...");
            const_dialogs["npc.guard"].Add("help", new _dialoginfo("Хочешь помочь? Вытаскивай меч и помогай, если нападешь на преступника в охраняемой зоне, тебе ничего не будет. [ухмыляется] Ну кроме разве что благодарности от жителей города... [опять ухмыляется] Хотя в крайнем случае мы и сами справимся..."));
            const_dialogs["npc.guard"]["help"].replies.Add("can", "Нет, я имел ввиду, как к вам присоединиться?");
            const_dialogs["npc.guard"]["help"].replies.Add("end", "Да ну вас к черту, разбирайтесь сами!");
            const_dialogs["npc.guard"].Add("end", new _dialoginfo("Как знаешь, удачи! [многозначительно] Надеюсь, мы и впредь будем встречаться исключительно для беседы..."));

            const_dialogs.Add("npc.healer", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.healer"].Add("begin", new _dialoginfo("Здравствуй, <name>! Как твои дела, как здоровье?"));
            const_dialogs["npc.healer"]["begin"].replies.Add("who", "Спасибо, хорошо. Кто вы?");
            const_dialogs["npc.healer"]["begin"].replies.Add("heal", "Вы можете меня вылечить?");
            const_dialogs["npc.healer"]["begin"].replies.Add("end", "Я занят, до свидания");
            const_dialogs["npc.healer"].Add("who", new _dialoginfo("Я лекарь, помогаю людям, попавшим в беду. Кроме того, я могу возвращать к жизни призраков."));
            const_dialogs["npc.healer"]["who"].replies.Add("how", "Как это?");
            const_dialogs["npc.healer"]["who"].replies.Add("heal", "Вы можете меня вылечить?");
            const_dialogs["npc.healer"]["who"].replies.Add("end", "Понятно, мне пора...");
            const_dialogs["npc.healer"].Add("heal", new _dialoginfo("В принципе, могу, но я занят более важными делами - помогаю тем, от кого в этом мире осталась лишь бледное подобие тени. А об обычных ранах и порезах, уверен, ты позаботишься и сам."));
            const_dialogs["npc.healer"]["heal"].replies.Add("how", "Поподробнее про тень, пожалуйста");
            const_dialogs["npc.healer"]["heal"].replies.Add("end", "Завидую вашей уверенности, в таком случае мне пора...");
            const_dialogs["npc.healer"].Add("how", new _dialoginfo("После физической смерти, душа человека продолжает бродить по свету, но ее еще можно при некотором желании вернуть в мир живых."));
            const_dialogs["npc.healer"]["how"].replies.Add("res", "И что для этого надо сделать?");
            const_dialogs["npc.healer"]["how"].replies.Add("end", "А, я это и так знал, счастливо!");
            const_dialogs["npc.healer"].Add("res", new _dialoginfo("Для этого надо просто постоять рядом со мной и я все сделаю сам. Либо найти камень воскрешения и дотронуться до него. Впрочем, опытный маг тоже может воскресить призрака."));
            const_dialogs["npc.healer"]["res"].replies.Add("end", "Спасибо за объяснение, мне пора");
            const_dialogs["npc.healer"].Add("end", new _dialoginfo("Удачи, береги себя!"));

            const_dialogs.Add("npc.trader", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.trader"].Add("begin", new _dialoginfo("Здравствуй, <name>! Желаешь что-нибудь продать или купить?"));
            const_dialogs["npc.trader"]["begin"].replies.Add("buyinfo", "Да, я хочу купить");
            const_dialogs["npc.trader"]["begin"].replies.Add("sellinfo", "Я хочу кое-что продать");
            const_dialogs["npc.trader"]["begin"].replies.Add("end", "В другой раз, до свидания");
            const_dialogs["npc.trader"].Add("buyinfo", new _dialoginfo("Хорошо, для этого в любой момент просто позови меня и я покажу тебе список своих товаров."));
            const_dialogs["npc.trader"]["buyinfo"].replies.Add("buy", "Я хочу посмотреть список товаров");
            const_dialogs["npc.trader"]["buyinfo"].replies.Add("upd", "Как часто обновляется ассортимент?");
            const_dialogs["npc.trader"]["buyinfo"].replies.Add("price", "Интересно, а цены у всех продавцов одинаковы?");
            const_dialogs["npc.trader"].Add("upd", new _dialoginfo("Это зависит от продавца, у некоторых раз в день, у других раз в неделю. Одни товары появляются чаще, другие реже. Это зависит от многих факторов, просто почаще заглядывай и не пропустишь что тебе нужно."));
            const_dialogs["npc.trader"]["upd"].replies.Add("buy", "Ок, можно посмотреть ваши товары?");
            const_dialogs["npc.trader"].Add("sellinfo", new _dialoginfo("Отлично, покажи свои товары и я назову свою цену."));
            const_dialogs["npc.trader"]["sellinfo"].replies.Add("price", "Цены у всех продавцов одинаковы?");
            const_dialogs["npc.trader"]["sellinfo"].replies.Add("sell", "Ясно, тогда перейдем к делу");
            const_dialogs["npc.trader"].Add("price", new _dialoginfo("Хм... Нет, конечно, каждый торговец может назначить свою цену, у кого-то дороже, у кого-то дешевле."));
            const_dialogs["npc.trader"]["price"].replies.Add("buy", "Ясно, покажите мне ваши товары");
            const_dialogs["npc.trader"].Add("end", new _dialoginfo("Всегда к вашим услугам"));

            const_dialogs.Add("npc.bankir", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.bankir"].Add("begin", new _dialoginfo("Здравствуй, <name>! Хочешь что-нибудь положить в банк или, наоборот, забрать?"));
            const_dialogs["npc.bankir"]["begin"].replies.Add("who", "Кто вы?");
            const_dialogs["npc.bankir"]["begin"].replies.Add("tobank", "Я хочу положить в банк");
            const_dialogs["npc.bankir"]["begin"].replies.Add("frombank", "Я хочу забрать из банка");
            const_dialogs["npc.bankir"]["begin"].replies.Add("tobankinfo", "Как мне положить предмет в банк?");
            const_dialogs["npc.bankir"]["begin"].replies.Add("frombankinfo", "Как мне забрать что-нибудь из банка?");
            const_dialogs["npc.bankir"]["begin"].replies.Add("end", "Не в этот раз, до встречи!");
            const_dialogs["npc.bankir"].Add("who", new _dialoginfo("Я банкир, и я могу положить твои вещи в надежное хранилище, а потом по первому требованию выдать их обратно."));
            const_dialogs["npc.bankir"]["who"].replies.Add("die", "А если я погибну, что будет с моими вещами?");
            const_dialogs["npc.bankir"]["who"].replies.Add("cost", "И сколько это удовольствие будет мне стоить?");
            const_dialogs["npc.bankir"]["who"].replies.Add("place", "Забрать свои вещи я могу только у вас?");
            const_dialogs["npc.bankir"]["who"].replies.Add("tobankinfo", "Как мне положить предмет в банк?");
            const_dialogs["npc.bankir"]["who"].replies.Add("frombankinfo", "Как мне забрать что-нибудь из банка?");
            const_dialogs["npc.bankir"]["who"].replies.Add("end", "На сегодня все, спасибо");
            const_dialogs["npc.bankir"].Add("die", new _dialoginfo("Они по прежнему будут храниться в надежном сейфе, и как только вы их потребуете, будут вам возвращены."));
            const_dialogs["npc.bankir"]["die"].replies.Add("who", "Неплохо, еще пара вопросов...");
            const_dialogs["npc.bankir"].Add("cost", new _dialoginfo("Абсолютно нисколько, наш сервис работает совершенно бесплатно."));
            const_dialogs["npc.bankir"]["cost"].replies.Add("who", "Гм...у меня есть еще вопросы");
            const_dialogs["npc.bankir"].Add("place", new _dialoginfo("Не обязательно, положить в банк вещи и забрать их оттуда можно у любого представителя нашей профессии, а не только у меня. Наши банки есть в любом крупном городе."));
            const_dialogs["npc.bankir"]["place"].replies.Add("who", "Ясно, еще пара вопросов...");
            const_dialogs["npc.bankir"].Add("tobankinfo", new _dialoginfo("Для этого просто передай любой предмет мне и он будет помещен в банк в надежное хранилище."));
            const_dialogs["npc.bankir"]["tobankinfo"].replies.Add("who", "Вот оно что...");
            const_dialogs["npc.bankir"]["tobankinfo"].replies.Add("tobank", "Я хочу положить в банк");
            const_dialogs["npc.bankir"]["tobankinfo"].replies.Add("frombank", "Я хочу забрать из банка");
            const_dialogs["npc.bankir"]["tobankinfo"].replies.Add("end", "Это все что я хотел узнать, счастливо!");
            const_dialogs["npc.bankir"].Add("frombankinfo", new _dialoginfo("Просто поговори со мной, и я покажу список твоих вещей в банке."));
            //const_dialogs["npc.bankir"]["frombankinfo"].replies.Add("getnow", "Я хочу забрать из банка прямо сейчас");
            const_dialogs["npc.bankir"]["frombankinfo"].replies.Add("frombank", "Я хочу забрать из банка прямо сейчас");
            const_dialogs["npc.bankir"]["frombankinfo"].replies.Add("who", "Понятно");
            const_dialogs["npc.bankir"]["frombankinfo"].replies.Add("end", "Это все что я хотел узнать, до свидания");
            const_dialogs["npc.bankir"].Add("end", new _dialoginfo("Всегда к вашим услугам"));

            const_dialogs.Add("npc.beginner", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.beginner"].Add("begin", new _dialoginfo("Приветствую тебя, <name>! Меня зовут Уин и я помогу тебе сделать первые шаги в этом мире. Кроме того, у меня ты всегда можешь узнать последние новости или спросить о чем-нибудь, если забудешь."));
            const_dialogs["npc.beginner"]["begin"].replies.Add("news", "Какие новости?");
            const_dialogs["npc.beginner"]["begin"].replies.Add("do", "Расскажи мне обо всем");
            const_dialogs["npc.beginner"]["begin"].replies.Add("list", "Расскажи мне о...");
            const_dialogs["npc.beginner"]["begin"].replies.Add("find", "Как мне найти...");
            const_dialogs["npc.beginner"]["begin"].replies.Add("end", "До свиданья");
            const_dialogs["npc.beginner"].Add("news", new _dialoginfo("Пожалуй, пока никаких, жизнь идет свои чередом"));
            const_dialogs["npc.beginner"]["news"].replies.Add("begin", "Назад");
            const_dialogs["npc.beginner"]["news"].replies.Add("end", "Тогда до встречи!");
            const_dialogs["npc.beginner"].Add("find", new _dialoginfo("Что именно тебя интересует?"));
            const_dialogs["npc.beginner"]["find"].replies.Add("lek", "Лекарь");
            const_dialogs["npc.beginner"]["find"].replies.Add("tobank", "Банк");
            const_dialogs["npc.beginner"]["find"].replies.Add("mag", "Магазины");
            const_dialogs["npc.beginner"]["find"].replies.Add("ak", "Академия");
            const_dialogs["npc.beginner"]["find"].replies.Add("dvr", "Двор рыцарей");
            const_dialogs["npc.beginner"]["find"].replies.Add("exit", "Выходы из города");
            const_dialogs["npc.beginner"]["find"].replies.Add("begin", "Ничего, я передумал");
            const_dialogs["npc.beginner"].Add("lek", new _dialoginfo("Просто иди отсюда на север и зайди в первый встретившийся дом, не ошибешься."));
            const_dialogs["npc.beginner"]["lek"].replies.Add("find", "А как найти...");
            const_dialogs["npc.beginner"]["lek"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("tobank", new _dialoginfo("Иди отсюда на север и сразу поверни на запад, увидишь здание банка."));
            const_dialogs["npc.beginner"]["tobank"].replies.Add("find", "А как найти...");
            const_dialogs["npc.beginner"]["tobank"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("mag", new _dialoginfo("Он где-то там..."));
            const_dialogs["npc.beginner"]["mag"].replies.Add("find", "А как найти...");
            const_dialogs["npc.beginner"]["mag"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("ak", new _dialoginfo("Иди отсюда на север и поверни на северо-восток и попадешь прямо к парадному крыльцу Академии."));
            const_dialogs["npc.beginner"]["ak"].replies.Add("find", "А как найти...");
            const_dialogs["npc.beginner"]["ak"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("dvr", new _dialoginfo("Это немного сложнее, сейчас иди на север, потом мимо банка на центральную площадь, а уже там будет вход во двор."));
            const_dialogs["npc.beginner"]["dvr"].replies.Add("find", "А как найти...");
            const_dialogs["npc.beginner"]["dvr"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("exit", new _dialoginfo("Южные ворота: иди на юг и поверни на запад, Восточные ворота: иди на север, мимо Академии на восток и выйдешь к воротам. Северные ворота: около двора рыцарей сверни на север и около магазина снаряжения увидишь ворота."));
            const_dialogs["npc.beginner"]["exit"].replies.Add("find", "А как найти...");
            const_dialogs["npc.beginner"]["exit"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("list", new _dialoginfo("О чем тебе рассказать?"));
            const_dialogs["npc.beginner"]["list"].replies.Add("do", "Что я могу делать");
            const_dialogs["npc.beginner"]["list"].replies.Add("place", "Об этом месте");
            const_dialogs["npc.beginner"]["list"].replies.Add("crim", "О страже");
            const_dialogs["npc.beginner"]["list"].replies.Add("die", "Что если я умру");
            const_dialogs["npc.beginner"]["list"].replies.Add("bank", "О банке");
            const_dialogs["npc.beginner"]["list"].replies.Add("skills", "О навыках");
            const_dialogs["npc.beginner"]["list"].replies.Add("magic", "О магии");
            const_dialogs["npc.beginner"]["list"].replies.Add("fight", "О сражениях");
            const_dialogs["npc.beginner"]["list"].replies.Add("trade", "О торговле");
            const_dialogs["npc.beginner"]["list"].replies.Add("job", "Как заработать");
            const_dialogs["npc.beginner"]["list"].replies.Add("tame", "О приручении животных");
            const_dialogs["npc.beginner"]["list"].replies.Add("contact", "О контактах");
            const_dialogs["npc.beginner"]["list"].replies.Add("macros", "О макросах");
            const_dialogs["npc.beginner"]["list"].replies.Add("begin", "Ни о чем, я передумал");
            const_dialogs["npc.beginner"].Add("do", new _dialoginfo("Для начала ты должен знать, что любой диалог можно прервать и вернуться в игру, а разговор закончить позже. Обычно никто на такие вещи не обижается. Итак, в игре ты можешь делать практически все что угодно: охотиться, путешествовать, разговаривать, выполнять квесты, использовать предметы, изучать магию, применять и развивать свои навыки, и многое, многое другое..."));
            const_dialogs["npc.beginner"]["do"].replies.Add("place", "Дальше");
            const_dialogs["npc.beginner"]["do"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["do"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("place", new _dialoginfo("Город довольно большой и в нем есть все что надо для жизни - магазины, библиотека, места для тренировок, банк, таверна и так далее. С юга город омывается рекой, там же находится порт, со всех остальных сторон город окружен лесами."));
            const_dialogs["npc.beginner"]["place"].replies.Add("place2", "Дальше");
            const_dialogs["npc.beginner"]["place"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["place"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("place2", new _dialoginfo("На северо-востоке есть большое кладбище, куда обычно ходят охотиться на нежить, хотя и в лесах тварей хватает. Походи по городу, почитай указатели и вывески, поговори с жителями. Ориентироваться за пределами стен очень легко - просто выйди на любую дорогу и иди по ней, куда-нибудь да придешь."));
            const_dialogs["npc.beginner"]["place2"].replies.Add("crim", "Дальше");
            const_dialogs["npc.beginner"]["place2"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["place2"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("crim", new _dialoginfo("Другая важная вещь, которую ты должен знать - это преступники и городская стража. Любой человек, совершивший преступление, объявляется вне закона и на него сразу же нападает стража. К преступлениям относятся: нападение на невиновного, воровство, мародерство, натравливание своих животных на других людей."));
            const_dialogs["npc.beginner"]["crim"].replies.Add("crim2", "Дальше");
            const_dialogs["npc.beginner"]["crim"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["crim"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("crim2", new _dialoginfo("Также к преступлению приравнивается любая помощь преступнику: лечение и т.д. А вот по отношению к преступникам эти правила не распространяются! То есть, на преступника можно нападать в любой момент, также можно безнаказанно забирать предметы с его трупа и т.д. Учти только, что стража есть лишь в пределах города, а за городскими стенами каждый предоставлен лишь самому себе. Впрочем, через какое-то время все забывается и даже преступники перестают быть таковыми и могут заходить в город. Так что если ты стал преступником, просто отсидись где-нибудь в лесах."));
            const_dialogs["npc.beginner"]["crim2"].replies.Add("die", "Дальше");
            const_dialogs["npc.beginner"]["crim2"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["crim2"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("die", new _dialoginfo("В случае смерти все предметы, что ты нес с собой, остаются на трупе, а сам ты становишься призраком. Ты можешь свободно ходить, но тебя почти никто не будет видеть, ты не сможешь использовать магию или предметы. А если попытаешься что-нибудь сказать, то все, за исключением имеющих навык спиритизма, услышат вместо слов лишь потустороннее завывание... Ну а чтобы не терять важные предметы, храни их в банке."));
            const_dialogs["npc.beginner"]["die"].replies.Add("bank", "Дальше");
            const_dialogs["npc.beginner"]["die"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["die"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("bank", new _dialoginfo("Предметы в банке храняться сколько угодно времени, забрать их оттуда можешь только ты. Чтобы положить предмет в свой банк или забрать что-нибудь из банка, просто поговори с банкиром. В банке можно хранить любые предметы и неограниченное число."));
            const_dialogs["npc.beginner"]["bank"].replies.Add("skills", "Дальше");
            const_dialogs["npc.beginner"]["bank"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["bank"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("skills", new _dialoginfo("Свои параметры ты можешь посмотреть, выбрав 'Навыки' в основном меню. Главные из них - сила, ловкость и интеллект. Они учитываются почти во всех твоих действиях. Все остальные навыки тоже важны, но они учитываются только в специфических ситуациях, например, навык 'Воровство' определяет твои шансы что-нибудь утащить у соседа и так далее."));
            const_dialogs["npc.beginner"]["skills"].replies.Add("skills2", "Дальше");
            const_dialogs["npc.beginner"]["skills"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["skills"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("skills2", new _dialoginfo("Все навыки изменяются в пределах 0..5, чем больше, тем лучше. Только учти, что есть предел для суммы очков всех навыков, так что стать профессионалом во всех областях сразу тебе не удастся. Теперь о том, как улучшать свои навыки. За победу над врагом ты получаешь опыт, причем чем сильнее враг (неважно, зверь или человек), тем больше за него получишь опыта."));
            const_dialogs["npc.beginner"]["skills2"].replies.Add("skills3", "Дальше");
            const_dialogs["npc.beginner"]["skills2"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["skills2"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("skills3", new _dialoginfo("Когда твой опыт достигнет определенного предела, ты получаешь новый уровень и вместе с ним одно очко опыта, которое можешь потратить на увеличение любого навыка. Для этого тебе надо найти наставника, который согласится обучить тебя выбранному ремеслу, например, рукопашному бою. Просто разговаривай со всеми и спрашивай, не могут ли они тебя чему-нибудь научить. Обычно это происходит за деньги, хотя иногда могут попросить что-то для них сделать, все зависит от наставника."));
            const_dialogs["npc.beginner"]["skills3"].replies.Add("skills4", "Дальше");
            const_dialogs["npc.beginner"]["skills3"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["skills3"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("skills4", new _dialoginfo("Многие могут научить тебя чему-нибудь, некоторые это делают дешевле или дороже, некоторые учат только до определенного уровня, а некоторые, наоборот, только если ты уже достиг необходимого уровня... Но есть один нюанс - с каждым новым уровнем получить следующий будет все труднее и труднее, поэтому желательно сразу развивать те навыки, которые тебе больше нравятся. Впрочем, даже при максимальном уровне можно развивать навыки, просто взамен поднятия одного, тебя попросят опустить какой-нибудь другой. Так что даже из эксперта мага можно со временем переквалифицироваться в воина. И наоборот."));
            const_dialogs["npc.beginner"]["skills4"].replies.Add("skills5", "Дальше");
            const_dialogs["npc.beginner"]["skills4"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["skills4"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("skills5", new _dialoginfo("Вообще, большинство боевых навыков развивают во дворе рыцарей, а магических - в Академии, так что сходи в эти места и поговори с кем-нибудь там. Хотя учителя встречаются и в других местах, даже за пределами города."));
            const_dialogs["npc.beginner"]["skills5"].replies.Add("magic", "Дальше");
            const_dialogs["npc.beginner"]["skills5"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["skills5"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("magic", new _dialoginfo("Чтобы узнать подробней о магии, сходи в Академию, там тебе все расскажут, я же лишь покажу, как ей пользоваться. Твои способности к волшебству определяются навыком 'Магия', чем он больше, тем лучше. Некоторые заклинания даются легче, некоторые труднее. Для использования особо мощных ты должен быть магом уровня не ниже тертьего или даже четвертого. Для использвания магии есть три пути: из своей книги заклинаний, в таком случае тратится мана и магические реагенты, со свитков - тогда тратится только мана и исчезает свиток или с руны, тогда тратится только мана."));
            const_dialogs["npc.beginner"]["magic"].replies.Add("magic2", "Дальше");
            const_dialogs["npc.beginner"]["magic"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["magic"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("magic2", new _dialoginfo("Очевидно, что удобней всего пользоваться рунами, т.к. нет необходимости покупать дорогие реагенты, то в случае твоей гибели, руна останется лежать на трупе, ее могут похитить разбойники. Или она может просто пропасть, так как со временем трупы исчезают. Есть очень полезные заклинания 'Пометить' и 'Возвращение', позволяющие тебе телепортироватьтся в любое место! А еще есть 'Воскрешение', позволяющее оживлять погибших товарищей в бою. Сходи в Академию, там все узнаешь."));
            const_dialogs["npc.beginner"]["magic2"].replies.Add("fight", "Дальше");
            const_dialogs["npc.beginner"]["magic2"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["magic2"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("fight", new _dialoginfo("Чтобы узнать все о сражениях, сходи в двор рыцарей. Атаковать можно врукопашную или с помощью оружия (или магией). Правда в городе лучше ни на кого, кроме преступников, не нападать, иначе сам станешь преступником. При использовании практически любого вида оружия учитывается твоя сила и ловкость. Так, более сильный лучник сильнее натянет тетиву и соответственно, нанесет больший урон. Так же как и более сильный удар мечом причинит больше вреда."));
            const_dialogs["npc.beginner"]["fight"].replies.Add("fight2", "Дальше");
            const_dialogs["npc.beginner"]["fight"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["fight"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("fight2", new _dialoginfo("Впрочем, в некоторых видах оружия сила не учитывается, например, при стрельбе из самстрелов. Ловкость же определяет твою меткость и скорость нанесения ударов. Кроме того, для каждого вида оружия есть свой навык, от которого зависит, насколько ты профессионально обращаешься с этим оружием. Если у тебя в руках щит, то некоторые удары ты можешь отбить им (зависит от навыка 'Парирование'). Еще один момент: броня защищает от обычного оружия, а от магии нет! Для защиты от магии есть специальные навыки."));
            const_dialogs["npc.beginner"]["fight2"].replies.Add("trade", "Дальше");
            const_dialogs["npc.beginner"]["fight2"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["fight2"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("trade", new _dialoginfo("Для того, чтобы купить или продать любой предмет, просто поговори с торговцем. У разных продавцов цены разные, кроме того, некоторые из них принимают только определенные виды товаров. И еще: ассортимент время от времени обновляется - могут появиться новые товары и т.д., все зависит от продавца."));
            const_dialogs["npc.beginner"]["trade"].replies.Add("job", "Дальше");
            const_dialogs["npc.beginner"]["trade"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["trade"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("job", new _dialoginfo("Фактически, есть 5 способов заработать денег: самый простой - просто пойти за пределы города и собирать все что найдешь - грибы, магические реагенты и т.д. В первое время чтобы не погибнуть можешь просто услышав подозрительыне звуки, бежать со всех ног в сторону города. Второй способ: стать охотником, освещевывать туши убитых зверей и продавать шкуры, клыки, когти и т.д., поговори об этом с охотниками у северных ворот. Третий - идти на кладбище или искать монстров в лесах, у монстров попадаются монеты прямо на трупах."));
            const_dialogs["npc.beginner"]["job"].replies.Add("job2", "Дальше");
            const_dialogs["npc.beginner"]["job"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["job"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("job2", new _dialoginfo("Четвертый, не совсем честный, я бы даже сказал совсем нечестный способ  -воровать деньги и предметы у других игроков. Можно еще стать разбойником и нападать на прохожих за пределами городских стен. Путь в город, как ты понимаешь, в таком случае тебе будет закрыт, пока люди не забудут, что ты был бандитом. Можно еще самому делать предметы на продажу, но с этим пока не все ясно..."));
            const_dialogs["npc.beginner"]["job2"].replies.Add("tame", "Дальше");
            const_dialogs["npc.beginner"]["job2"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["job2"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("tame", new _dialoginfo("Чтобы узнать о приручении животных, найди кого-нибудь, кто этим занимается и расспроси его. Я бы посоветовал поговорить с охотниками у северных ворот, они должны знать. Сейчас лишь скажу, что некоторых животных можно приручить. В случае успеха, они будут ходить за тобой по пятам и защищать тебя. Еще они будут выполнять твои команды, можешь их натравить на кого-нибудь или сказать охранять того-то... Прирученные могут со временем уйти от вас, поэтмоу обращайтесь с ними ласково и тогда они привяжутся к вам надолго."));
            const_dialogs["npc.beginner"]["tame"].replies.Add("contact", "Дальше");
            const_dialogs["npc.beginner"]["tame"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["tame"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("contact", new _dialoginfo("В контактах (команда в главном меню) ты можешь оправлять и получать письма от друзей, где бы они не находились. При этом еще показывается, кто из твоих друзей играет в данный момент вместе с тобой. А даже если и нет, можешь им отправить письмо и они получат его, как только войдут в игру. Если тебе что-нибудь говорит слово ICQ, то ты уже понимаешь, о чем речь :-). Да, кстати, если придет новое сообщение, об этом будет написано в главном экране игры, так что не надо постоянно проверять контакты."));
            const_dialogs["npc.beginner"]["contact"].replies.Add("macros", "Дальше");
            const_dialogs["npc.beginner"]["contact"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["contact"].replies.Add("end", "Ясно, пока");
            const_dialogs["npc.beginner"].Add("macros", new _dialoginfo("Еще ты можешь создавать свои макросы, например: повторить последнее действие, атаковать последнюю цель, использовать заклинание 'Лечение' на себя и т.д. Все макросы доступны из главного меню (в большинстве телефонов для этого достаточно нажать горячую кнопку). Поздравляю, на этом твое начальное обучение закончено, ты готов вступить в этот чудесный, волшебный мир. Об остальном узнаешь в своих приключениях, удачи тебе!"));
            const_dialogs["npc.beginner"]["macros"].replies.Add("begin", "У, а я только приготовился слушать...");
            const_dialogs["npc.beginner"]["macros"].replies.Add("list", "А что насчет...");
            const_dialogs["npc.beginner"]["macros"].replies.Add("end", "Спасибо, еще увидимся!");
            const_dialogs["npc.beginner"].Add("end", new _dialoginfo("Хорошо, я всегда буду здесь, если что-то понадобится, приходи в любое время."));

            const_dialogs.Add("npc.Gant", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Gant"].Add("begin", new _dialoginfo("Здравствуй, незнакомец. Это двор рыцарей, могу я чем-нибудь тебе помочь?"));
            const_dialogs["npc.Gant"]["begin"].replies.Add("what", "Что за двор рыцарей?");
            const_dialogs["npc.Gant"]["begin"].replies.Add("go", "Я хочу пройти");
            const_dialogs["npc.Gant"].Add("what", new _dialoginfo("Здесь живут палладины его Величества во главе с Лордом Хагеном, он находится в здании прямо через двор."));
            const_dialogs["npc.Gant"]["what"].replies.Add("do", "И чем вы тут занимаетесь?");
            const_dialogs["npc.Gant"]["what"].replies.Add("go", "Я хочу пройти");
            const_dialogs["npc.Gant"].Add("do", new _dialoginfo("Мы здесь по приказу короля, прибыли с миссией защиты города от возможного вторжения орков. А пока что, на временной дислокации, тренируем новобранцев и обеспечиваем порядок в городе."));
            const_dialogs["npc.Gant"]["do"].replies.Add("vtorj", "Первый раз слышу о каком-то вторжении");
            const_dialogs["npc.Gant"]["do"].replies.Add("go", "Я хочу пройти");
            const_dialogs["npc.Gant"].Add("vtorj", new _dialoginfo("Поговори об этом лучше с Лордом Хагеном или его помощником, Рено, они тебе все объяснят. Или с главой города Сильвестро, он в доме в северной части двора"));
            const_dialogs["npc.Gant"]["vtorj"].replies.Add("go", "Ок, счастливо");
            const_dialogs["npc.Gant"].Add("go", new _dialoginfo("Постой, это конечно, не мое дело, но все-таки, ты случайно не из Академии?"));
            const_dialogs["npc.Gant"]["go"].replies.Add("ak", "Да, я из Академии, а что?");
            const_dialogs["npc.Gant"]["go"].replies.Add("no", "Нет");
            const_dialogs["npc.Gant"].Add("ak", new _dialoginfo("Я так и подумал. Знаешь, ты не очень похож на этих умников в рясах, я бы даже сказал, ты выглядишь вполне благоразумным человеком. Поэтому хочу дать тебе совет - держись подальше от всей этой братии."));
            const_dialogs["npc.Gant"]["ak"].replies.Add("ak2", "Что-то не так с Академией?");
            const_dialogs["npc.Gant"]["ak"].replies.Add("end", "Я сам знаю что мне делать и как");
            const_dialogs["npc.Gant"].Add("ak2", new _dialoginfo("Никогда не стоит доверять магам. Это самонадеянные, заносчивые, считающие себя выше других. Эти магики себе на уме, лучше с ними не связываться. Хороший клинок, да добрый щит - вот что нужно настоящему мужчине, а не декларировать фразы нараспев, размахивая руками. Ты меня понимаешь?"));
            const_dialogs["npc.Gant"]["ak2"].replies.Add("ak3", "Понимаю, полностью с тобой согласен!");
            const_dialogs["npc.Gant"]["ak2"].replies.Add("end", "Хорошо, учту твое мнение");
            const_dialogs["npc.Gant"].Add("ak3", new _dialoginfo("Вот и славно! Приятно осознавать, что не дал человеку встать на зыбкий путь. Держить рыцарей и будешь всегда уверен - спина у тебя надежно прикрыта."));
            const_dialogs["npc.Gant"]["ak3"].replies.Add("end", "Счастливо, удачи");
            const_dialogs["npc.Gant"].Add("no", new _dialoginfo("И правильно, нечего соваться к этим книгочеям. Так же как и водиться с охотниками. Скажу тебе по секрету, большинство из них бывшие каторжники или наемники. Если ты предпочитаешь честную сталь, двор рыцарей к твоим услугам!"));
            const_dialogs["npc.Gant"]["no"].replies.Add("ura", "Да здравствует двор рыцарей!");
            const_dialogs["npc.Gant"]["no"].replies.Add("end", "Ладно-ладно, я понял");
            const_dialogs["npc.Gant"].Add("ura", new _dialoginfo("Ну-ну, не так пылко :-). Я вижу, в нашем полку прибыло и у нас скоро будет новый ноборанец? Поговори с Лордом Хагеном, в потом к Катаресу, он сделает из тебя настоящего мужчину!"));
            const_dialogs["npc.Gant"]["ura"].replies.Add("end", "Так и сделаем, спсибо за совет");
            const_dialogs["npc.Gant"]["ura"].replies.Add("man", "Я и так настоящий мужчина");
            const_dialogs["npc.Gant"].Add("man", new _dialoginfo("Ха! Вот нападут орки, тогда и посмотрим, кто чего стоит. Не обижайся, я ведь тебя не не знаю, может ты мастер меча, просто виду тебя не ахти, ну да ничего, это дело поправимое, верно?"));
            const_dialogs["npc.Gant"]["man"].replies.Add("end", "Верно, я пойду");
            const_dialogs["npc.Gant"].Add("end", new _dialoginfo("Ну бывай, еще свидимся"));

            const_dialogs.Add("npc.LordHagen", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.LordHagen"].Add("begin", new _dialoginfo("Как твое имя, незнакомец?"));
            const_dialogs["npc.LordHagen"]["begin"].replies.Add("name", "Меня зовут <name>");
            const_dialogs["npc.LordHagen"]["begin"].replies.Add("wr", "Мое имя Ричард");
            const_dialogs["npc.LordHagen"]["begin"].replies.Add("vopr", "Гм... Мое имя тебе ничего не скажет, давай лучше сразу перейдем к делу.");
            const_dialogs["npc.LordHagen"].Add("name", new _dialoginfo("Ну что ж, честность красит человека, я думаю мы поладим."));
            const_dialogs["npc.LordHagen"]["name"].replies.Add("vopr", "Я тоже так думаю");
            const_dialogs["npc.LordHagen"].Add("wr", new _dialoginfo("Ты в этом уверен? Учти, что лжецам или жуликам не место во дворе рыцарей! Впрочем, ладно, время покажет кто ты такой."));
            const_dialogs["npc.LordHagen"]["wr"].replies.Add("pal", "Конечно, уверен, так же как и в том, что у меня на одной руке шесть пальцев!");
            const_dialogs["npc.LordHagen"]["wr"].replies.Add("vopr", "Я учту это...");
            const_dialogs["npc.LordHagen"].Add("pal", new _dialoginfo("[издевательски] Твое остроумие меня просто поразило до глубины души. Давай не будем тратить время попусту, зачем ты пришел?"));
            const_dialogs["npc.LordHagen"]["pal"].replies.Add("vopr", "Хорошо, для начала - кто вы?");
            const_dialogs["npc.LordHagen"].Add("vopr", new _dialoginfo("Я Лорд Хаген, в данное время я являюсь командиром отряда палладинов в этом городе."));
            const_dialogs["npc.LordHagen"]["vopr"].replies.Add("why", "Зачем вы приехали в город?");
            const_dialogs["npc.LordHagen"]["vopr"].replies.Add("rene", "Я хочу стать рыцарем");
            const_dialogs["npc.LordHagen"]["vopr"].replies.Add("mag", "А магии у вас научиться можно?");
            const_dialogs["npc.LordHagen"]["vopr"].replies.Add("end", "Мне пора");
            const_dialogs["npc.LordHagen"].Add("why", new _dialoginfo("На город может быть совершено массированное нападение орков, чьи полчища собираются на севере и западе. Это достаточная причина? Больше ничего по этому поводу тебе сказать не могу."));
            const_dialogs["npc.LordHagen"]["why"].replies.Add("vopr", "Гм...");
            const_dialogs["npc.LordHagen"].Add("rene", new _dialoginfo("Всеми делами, связанными с обучением и новобранцами, заведует мой помощник Рене, вот он стоит рядом, поговори с ним."));
            const_dialogs["npc.LordHagen"]["rene"].replies.Add("end", "Ладно");
            const_dialogs["npc.LordHagen"]["rene"].replies.Add("vopr", "У меня есть еще вопросы");
            const_dialogs["npc.LordHagen"].Add("mag", new _dialoginfo("Да, можно. Наша магия очень сильна, так как мы на службе добра и справедливости, поэтому высшие силы помогают нам. Стоунс в северном здании расскажет тебе подробности. Я же могу научить тебя заклинанию 'Гнев богов'."));
            const_dialogs["npc.LordHagen"]["mag"].replies.Add("gnev", "Я хочу выучить это заклинание");
            const_dialogs["npc.LordHagen"]["mag"].replies.Add("cost", "И сколько это будет стоить?");
            const_dialogs["npc.LordHagen"]["mag"].replies.Add("vopr", "В другой раз");
            const_dialogs["npc.LordHagen"].Add("cost", new _dialoginfo("[широко улыбается] Нисколько, это заклинание относится к тем, которые можно доверять любому."));
            const_dialogs["npc.LordHagen"]["cost"].replies.Add("gnev2", "В смысле?");
            const_dialogs["npc.LordHagen"]["cost"].replies.Add("vopr", "Звучит подозрительно, я передумал");
            const_dialogs["npc.LordHagen"].Add("gnev2", new _dialoginfo("Видишь ли, это очень мощное боевое заклинание, но оно действует только на преступников. Так ты хочешь его выучить?"));
            const_dialogs["npc.LordHagen"]["gnev2"].replies.Add("gnev", "Да, я согласен");
            const_dialogs["npc.LordHagen"]["gnev2"].replies.Add("vopr", "Хм... это не по мне");
            const_dialogs["npc.LordHagen"].Add("gnev", new _dialoginfo("magic|magic.all.godanger|0|4"));
            const_dialogs["npc.LordHagen"].Add("end", new _dialoginfo("Хорошо, береги себя"));

            const_dialogs.Add("npc.Rene", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Rene"].Add("begin", new _dialoginfo("Я Рене, помощник Лорда Хагена. Что ты хочешь узнать?"));
            const_dialogs["npc.Rene"]["begin"].replies.Add("tren", "Где я могу потренироваться?");
            const_dialogs["npc.Rene"]["begin"].replies.Add("mag", "Я хочу изучить магию");
            const_dialogs["npc.Rene"]["begin"].replies.Add("gl", "Где мне найти главу города?");
            const_dialogs["npc.Rene"]["begin"].replies.Add("end", "Ничего, мне пора");
            const_dialogs["npc.Rene"].Add("tren", new _dialoginfo("Иди к ристалищу, там Кантарес тренирует новобранцев. И там же есть где пострелять из лука, если тебя это интересует, спроси про Ханса."));
            const_dialogs["npc.Rene"]["tren"].replies.Add("begin", "У меня есть другие вопросы");
            const_dialogs["npc.Rene"]["tren"].replies.Add("end", "Хорошо, пока");
            const_dialogs["npc.Rene"].Add("mag", new _dialoginfo("Поговори со Стоунсом в северном здании, у него же ты можешь купить магические товары."));
            const_dialogs["npc.Rene"]["mag"].replies.Add("begin", "У меня есть другие вопросы");
            const_dialogs["npc.Rene"]["mag"].replies.Add("end", "Хорошо, пока");
            const_dialogs["npc.Rene"].Add("gl", new _dialoginfo("Сильвестра? Он тоже в северном здании вместе со Стоунсом."));
            const_dialogs["npc.Rene"]["gl"].replies.Add("begin", "У меня есть другие вопросы");
            const_dialogs["npc.Rene"]["gl"].replies.Add("end", "Хорошо, пока");
            const_dialogs["npc.Rene"].Add("end", new _dialoginfo("Пока"));

            const_dialogs.Add("npc.Silvestr", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Silvestr"].Add("begin", new _dialoginfo("Что тебе надо, я занят"));
            const_dialogs["npc.Silvestr"]["begin"].replies.Add("gl", "Вы глава этого города?");
            const_dialogs["npc.Silvestr"]["begin"].replies.Add("end", "Да собственно, ничего");
            const_dialogs["npc.Silvestr"].Add("gl", new _dialoginfo("Я, но что толку? С тех пор как появились палладины, я тут вообще ничего не решаю, всем заведует Лорд Хаген!"));
            const_dialogs["npc.Silvestr"]["gl"].replies.Add("why", "Зачем палладины в городе?");
            const_dialogs["npc.Silvestr"].Add("why", new _dialoginfo("А я знаю? Приказ короля и все тут. Для защиты от орков, так было сказано. Только вот я и на своих солдат не жаловался, а теперь где они? В южной части города, в каких-то трущобах! Лучше оставь меня в покое, и так не до тебя :-("));
            const_dialogs["npc.Silvestr"]["why"].replies.Add("end", "Ладно, не буду мешать");
            const_dialogs["npc.Silvestr"].Add("end", new _dialoginfo("[отвернулся и занялся своими делами]"));

            const_dialogs.Add("npc.Stouns", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Stouns"].Add("begin", new _dialoginfo("Привет, <name>, как дела?"));
            const_dialogs["npc.Stouns"]["begin"].replies.Add("mag", "Нормально, ты можешь научить меня магии?");
            const_dialogs["npc.Stouns"]["begin"].replies.Add("buy", "Я хотел бы кое-что купить");
            const_dialogs["npc.Stouns"]["begin"].replies.Add("sell", "Я хочу продать...");
            const_dialogs["npc.Stouns"]["begin"].replies.Add("sellinfo", "Ты покупаешь товары?");
            const_dialogs["npc.Stouns"]["begin"].replies.Add("more", "А кто еще учит магии?");
            const_dialogs["npc.Stouns"]["begin"].replies.Add("end", "Могло бы быть и лучше, мне пора");
            const_dialogs["npc.Stouns"].Add("more", new _dialoginfo("У меня только палладинские заклинания, как ты мог уже заметить. Все остальное практикуют в Академии. Ну и еще Лорд Хаген может научить тебя очень мощному заклинаию 'Гнев Богов', но он учит далеко не всех, впрочем, поговори с ним сам."));
            const_dialogs["npc.Stouns"]["more"].replies.Add("begin", "Ясно");
            const_dialogs["npc.Stouns"].Add("sellinfo", new _dialoginfo("Нет, у нас во дворе рыцарей и так все есть, я только продаю магические принадлежности, ну и обучаю некоторым заклинаниям."));
            const_dialogs["npc.Stouns"]["sellinfo"].replies.Add("begin", "Ясно");
            const_dialogs["npc.Stouns"].Add("mag", new _dialoginfo("Я могу научить тебя заклинаниям 'Лечение' и 'Святая стрела', что ты хочешь узнать?"));
            const_dialogs["npc.Stouns"]["mag"].replies.Add("heal", "Лечение");
            const_dialogs["npc.Stouns"]["mag"].replies.Add("arrow", "Святая стрела");
            const_dialogs["npc.Stouns"]["mag"].replies.Add("end", "Я лучше пойду");
            const_dialogs["npc.Stouns"].Add("heal", new _dialoginfo("Это очень полезное заклинание, оно восстанавливает твою жизнь, если ты ранен. Обучение обойдется в 300 монет."));
            const_dialogs["npc.Stouns"]["heal"].replies.Add("healnow", "Согласен, вот деньги");
            const_dialogs["npc.Stouns"]["heal"].replies.Add("mag", "Ого! Да за такую сумму я скорей съем свой язык!");
            const_dialogs["npc.Stouns"]["heal"].replies.Add("end", "Я лучше пойду");
            const_dialogs["npc.Stouns"].Add("arrow", new _dialoginfo("Заклинание 'Святая стрела' действует только на злых существ, но зато наносит довольно сильный урон, а маны требует совсем немного. Обучение стоит 200 монет."));
            const_dialogs["npc.Stouns"]["arrow"].replies.Add("arrownow", "Согласен, вот деньги");
            const_dialogs["npc.Stouns"]["arrow"].replies.Add("mag", "Хм... для меня дороговато пока...");
            const_dialogs["npc.Stouns"]["arrow"].replies.Add("end", "Я лучше пойду");
            const_dialogs["npc.Stouns"].Add("healnow", new _dialoginfo("magic|magic.heal|300"));
            const_dialogs["npc.Stouns"].Add("arrownow", new _dialoginfo("magic|magic.war.holyarrow|200"));
            const_dialogs["npc.Stouns"].Add("end", new _dialoginfo("Счастливо, да хранят тебя боги!"));

            const_dialogs.Add("npc.KantaresNovobranec", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.KantaresNovobranec"].Add("begin", new _dialoginfo("[вытирает пот со лба] Уфф, этот Кантарес сущий дьявол, но как учитель по холодному оружию, ему нет равных!"));

            const_dialogs.Add("npc.Kantares", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Kantares"].Add("begin", new _dialoginfo("Здравствуй, <name>, решил немного размяться?"));
            const_dialogs["npc.Kantares"]["begin"].replies.Add("tren", "Говорят, ты тренируешь бойцов?");
            const_dialogs["npc.Kantares"]["begin"].replies.Add("end", "На самом деле я просто шел мимо");
            const_dialogs["npc.Kantares"].Add("tren", new _dialoginfo("Верно говорят, я инструктор по холодному оружию."));
            const_dialogs["npc.Kantares"]["tren"].replies.Add("str", "Как мне стать сильнее?");
            const_dialogs["npc.Kantares"]["tren"].replies.Add("draka", "Я хочу научиться драться!");
            const_dialogs["npc.Kantares"]["tren"].replies.Add("end", "Поздравляю! Это все что я хотел сказать");
            const_dialogs["npc.Kantares"].Add("str", new _dialoginfo("Нет проблем, это идеальное место для тренировки. Не бесплатно, конечно, тебе это обойдется в 150 монет."));
            const_dialogs["npc.Kantares"]["str"].replies.Add("strnow", "Ок, я хочу увеличить свою силу.");
            const_dialogs["npc.Kantares"]["str"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Kantares"].Add("strnow", new _dialoginfo("skill|str|150|0|5"));
            const_dialogs["npc.Kantares"].Add("draka", new _dialoginfo("Я могу научить тебя обращаться с мечом, уклоняться от ударов и правильно использовать щит."));
            const_dialogs["npc.Kantares"]["draka"].replies.Add("cold", "Научи меня обращению с холодным оружием");
            const_dialogs["npc.Kantares"]["draka"].replies.Add("uklon", "Научи меня уклоняться");
            const_dialogs["npc.Kantares"]["draka"].replies.Add("parr", "Научи меня обращению со щитом");
            const_dialogs["npc.Kantares"]["draka"].replies.Add("hand", "А драться врукопашную?");
            const_dialogs["npc.Kantares"]["draka"].replies.Add("luk", "Что насчет стрельбы из лука?");
            const_dialogs["npc.Kantares"]["draka"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Kantares"].Add("cold", new _dialoginfo("Меч - это главное оружие рыцаря. Быстрый и смертоносный клинок, вот чем палладин отстаивает свою честь или честь невиновных! Здесь надо помнить всего две вещи: первое: чем ты сильнее, тем страшнее твой удар, и второе: надо уметь собственно правильно держать меч в руках и знать приемы. Кроме того, помни, что если ты слаб, а оружие тяжелое, то тебе будет сложней с ним обращаться. Всего за 200 монет я покажу тебе как владеть мечом."));
            const_dialogs["npc.Kantares"]["cold"].replies.Add("coldnow", "Я согласен");
            const_dialogs["npc.Kantares"]["cold"].replies.Add("str", "Лучше научи как увеличить силу");
            const_dialogs["npc.Kantares"]["cold"].replies.Add("luk", "А как насчет стрельбы из лука?");
            const_dialogs["npc.Kantares"]["cold"].replies.Add("tren", "Гм.. а как насчет других навыков");
            const_dialogs["npc.Kantares"].Add("coldnow", new _dialoginfo("skill|coldweapon|200|0|5"));
            const_dialogs["npc.Kantares"].Add("hand", new _dialoginfo("Ха! Не дело это рыцаря кулаками махать. если хочешь, иди к этим недотепам - солдатам, они любят устраивать кулачные забавы. Простолюдины, что с них взять."));
            const_dialogs["npc.Kantares"]["hand"].replies.Add("hand2", "Где мне найти солдат?");
            const_dialogs["npc.Kantares"].Add("hand2", new _dialoginfo("Иди к южным воротам, в около них поверни на запад и выйдешь к казармам. Впрочем, можешь обойти наш двор с задней стороны, так даже ближе."));
            const_dialogs["npc.Kantares"]["hand2"].replies.Add("tren", "Понятно");
            const_dialogs["npc.Kantares"].Add("luk", new _dialoginfo("Видишь вон в том углу ристалища Ханса? Он владеет стрелковым оружием."));
            const_dialogs["npc.Kantares"]["luk"].replies.Add("tren", "Ясно");
            const_dialogs["npc.Kantares"].Add("uklon", new _dialoginfo("Если тебе удалось увернуться от удара, то считай что тебе повезло. За 200 монет я могу сделать так, чтобы тебе 'везло' почаще. Хотя от магии просто так не увернешься, но в обычном бою это очень полезное умение."));
            const_dialogs["npc.Kantares"]["uklon"].replies.Add("uklonnow", "Я согласен");
            const_dialogs["npc.Kantares"]["uklon"].replies.Add("tren", "Гм.. а как насчет других навыков");
            const_dialogs["npc.Kantares"].Add("uklonnow", new _dialoginfo("skill|uklon|200|0|5"));
            const_dialogs["npc.Kantares"].Add("parr", new _dialoginfo("Настоящий воин должен уметь обращаться со щитом. Если ты умеешь им владеть, то урон уменьшается на броню щита, так что чем крепче щит, тем лучше. Но даже самый лучший щит в твоих руках, елси ты не умеешь им правильно закрываться, окажется бесполезным грузом, стесняющим движения. Если хочешь, я научу тебя владешь щитом за 200 монет."));
            const_dialogs["npc.Kantares"]["parr"].replies.Add("parrnow", "Я согласен");
            const_dialogs["npc.Kantares"]["parr"].replies.Add("tren", "Гм.. а как насчет других навыков");
            const_dialogs["npc.Kantares"].Add("parrnow", new _dialoginfo("skill|parring|200|0|5"));
            const_dialogs["npc.Kantares"].Add("end", new _dialoginfo("Бывай"));

            const_dialogs.Add("npc.Hans", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Hans"].Add("begin", new _dialoginfo("Я Ханс, тренер по стрелковому оружию."));
            const_dialogs["npc.Hans"]["begin"].replies.Add("tren", "Чему ты можешь меня научить?");
            const_dialogs["npc.Hans"]["begin"].replies.Add("uch", "Что-то у тебя не видно учеников...");
            const_dialogs["npc.Hans"]["begin"].replies.Add("buyinfo", "Где мне купить стрел?");
            const_dialogs["npc.Hans"]["begin"].replies.Add("end", "Мне пора");
            const_dialogs["npc.Hans"].Add("buyinfo", new _dialoginfo("Сходи в торговый квартал на юге города. Или поспрашивай у охотников, они обычно крутятся около северных ворот."));
            const_dialogs["npc.Hans"]["buyinfo"].replies.Add("begin", "Ясно");
            const_dialogs["npc.Hans"].Add("uch", new _dialoginfo("Это верно, среди рыцарей стрелковое опужие не очень-то в почете. Это, по их мнению, противоречит понятиям чести. Да и где это видано, чтобы палладин, к примеру, кидался камнями?"));
            const_dialogs["npc.Hans"]["uch"].replies.Add("uch2", "Тогда почему ты здесь?");
            const_dialogs["npc.Hans"]["uch"].replies.Add("begin", "Ладно, забудем об этом");
            const_dialogs["npc.Hans"].Add("uch2", new _dialoginfo("А кто сказал, что лук со стрелами бесполезен? Во многих случаях он даже эффективней. Здесь мне хорошо платят, я могу учить людей, а какая разница где это делать? Сюда часто приходят местные охотники, им умение стрелять нужно как воздух."));
            const_dialogs["npc.Hans"]["uch2"].replies.Add("tren", "Научи тогда и меня!");
            const_dialogs["npc.Hans"]["uch2"].replies.Add("begin", "Верно говоришь");
            const_dialogs["npc.Hans"]["uch2"].replies.Add("end", "Пожалуй, я предпочитаю сталь клинка, извини");
            const_dialogs["npc.Hans"].Add("tren", new _dialoginfo("Я могу научить тебя стрелять, быть проворней, а также быть осторожней."));
            const_dialogs["npc.Hans"]["tren"].replies.Add("dex", "Я хочу повысить ловкость");
            const_dialogs["npc.Hans"]["tren"].replies.Add("luk", "Я хочу научиться стрелять");
            const_dialogs["npc.Hans"]["tren"].replies.Add("look", "Осторожней?");
            const_dialogs["npc.Hans"]["tren"].replies.Add("sword", "А как насчет мечей?");
            const_dialogs["npc.Hans"]["tren"].replies.Add("end", "Мне пора");
            const_dialogs["npc.Hans"].Add("sword", new _dialoginfo("Для этого сходи к Кантаресу. Иди на звон мечей, не ошибешься."));
            const_dialogs["npc.Hans"]["sword"].replies.Add("tren", "Понятно");
            const_dialogs["npc.Hans"].Add("dex", new _dialoginfo("Ловкость определяет твою меткость и скорость стрельбы. Для лучника это очень важный параметр. Я могу помочь тебе развить ловкость за 150 монет."));
            const_dialogs["npc.Hans"]["dex"].replies.Add("dexnow", "Я согласен");
            const_dialogs["npc.Hans"]["dex"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Hans"].Add("dexnow", new _dialoginfo("skill|dex|150|0|5"));
            const_dialogs["npc.Hans"].Add("luk", new _dialoginfo("Ну что ж, во-впервых, для стрельбы из лука или метания нужна сила, т.к. от нее зависит наносимый урон. Кроме арбалетов, конечно. Во-вторых, нужна хорошая ловкость, чтобы попадать в цель. Учти, что попасть из лука намного сложней, чем мечом или кулаком! И в-третьих, надо уметь обращаться со стрелковым оружием. За 200 монет я могу научить тебя стрелять лучше."));
            const_dialogs["npc.Hans"]["luk"].replies.Add("luknow", "Научи, вот деньги");
            const_dialogs["npc.Hans"]["luk"].replies.Add("dex", "Лучше научи как увеличить ловкость");
            const_dialogs["npc.Hans"]["luk"].replies.Add("tren", "Гм.. а как насчет других навыков");
            const_dialogs["npc.Hans"].Add("luknow", new _dialoginfo("skill|ranged|200|0|5"));
            const_dialogs["npc.Hans"].Add("end", new _dialoginfo("Удачи, пусть твоя рука не дрогнет в нужный момент"));

            const_dialogs.Add("npc.Ded", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Ded"].Add("begin", new _dialoginfo("И тебе привет, юноша."));
            const_dialogs["npc.Ded"]["begin"].replies.Add("do", "Что ты здесь делаешь?");
            const_dialogs["npc.Ded"]["begin"].replies.Add("end", "Пока");
            const_dialogs["npc.Ded"].Add("do", new _dialoginfo("Ловлю рыбку на ужин. Надеюсь, этим твое любопытство исчерпало себя?"));
            const_dialogs["npc.Ded"]["do"].replies.Add("mal", "Неа, а кто тот мальчуган на другой стороне пристани?");
            const_dialogs["npc.Ded"]["do"].replies.Add("kor", "Дед, ты видел здесь когда-нибудь корабль?");
            const_dialogs["npc.Ded"]["do"].replies.Add("end", "Твоя правда, старик, исчепало");
            const_dialogs["npc.Ded"].Add("mal", new _dialoginfo("А, этот босоногий стервец? Да внучок, ишь ты, тоже рыбу ловит. Пугает больше..."));
            const_dialogs["npc.Ded"]["mal"].replies.Add("bol", "Однако он наловил больше тебя!");
            const_dialogs["npc.Ded"]["mal"].replies.Add("begin", "Ясно, славный малыш");
            const_dialogs["npc.Ded"].Add("kor", new _dialoginfo("[ворчит] Видел, видел, а то как же, приплыл тут весной по половодью, высадил десятка три дармоедов, да и убрался восвояси."));
            const_dialogs["npc.Ded"]["kor"].replies.Add("kor2", "А зачем они приплыли?");
            const_dialogs["npc.Ded"]["kor"].replies.Add("end", "Недосуг мне сейчас баловаться разговорами, будь здоров");
            const_dialogs["npc.Ded"].Add("kor2", new _dialoginfo("А хто ж их знает? Говорят для защиты города, орки вроде что-то затевают, вон по лесам сколько их щастает..."));
            const_dialogs["npc.Ded"]["kor2"].replies.Add("kor3", "А стража на что?");
            const_dialogs["npc.Ded"]["kor2"].replies.Add("end", "Ладно неважно");
            const_dialogs["npc.Ded"].Add("kor3", new _dialoginfo("Стража только в городе, а рыцари и в лес могут отряд послать, да и организованы не в пример лучше. Вот только и волки-то в город не захаживают, не то чтобы орки, так и просиживают тут эти рыцари свои высокородные штаны. Заняли к тому же лучший двор, а солдаты прозябаяют в како-то дыре..."));
            const_dialogs["npc.Ded"]["kor3"].replies.Add("kor5", "Как мне найти солдат?");
            const_dialogs["npc.Ded"]["kor3"].replies.Add("kor6", "А мальчуган ваш о рыцарях лучше отзывается");
            const_dialogs["npc.Ded"]["kor3"].replies.Add("kor7", "Говоришь, в лесу есть волки?");
            const_dialogs["npc.Ded"]["kor3"].replies.Add("end", "Все ясно, бывай, дед");
            const_dialogs["npc.Ded"].Add("kor6", new _dialoginfo("Да что он может знать, еще лапти первые не сносил, паршивец!"));
            const_dialogs["npc.Ded"]["kor6"].replies.Add("bol", "Гм.. а может дело в том, что у рыба лучше ловится? ;-)");
            const_dialogs["npc.Ded"]["kor6"].replies.Add("kor3", "Вернемся к рыцарям");
            const_dialogs["npc.Ded"]["kor6"].replies.Add("end", "Ладно, пойду я...");
            const_dialogs["npc.Ded"].Add("kor5", new _dialoginfo("Зайди в южные ворота и поверни на запад, там недалеко."));
            const_dialogs["npc.Ded"]["kor5"].replies.Add("kor3", "Вернемся к рыцарям");
            const_dialogs["npc.Ded"]["kor5"].replies.Add("end", "Спасибо, пока");
            const_dialogs["npc.Ded"].Add("kor7", new _dialoginfo("И не только волки, тут на востоке в болотах говорят, даже громадный огр шастает..."));
            const_dialogs["npc.Ded"]["kor7"].replies.Add("end", "Спасибо за науку, будь здоров дед");
            const_dialogs["npc.Ded"].Add("bol", new _dialoginfo("И ты туда же! Ух, молодешь, ремней на вас не напасешься! Хотя чего на вас, неразумных сердиться? Все равно оболдуи-оболдуями так и останетесь..."));
            const_dialogs["npc.Ded"]["bol"].replies.Add("begin", "Не серчай дед, я ж не со зла");
            const_dialogs["npc.Ded"]["bol"].replies.Add("end", "Сам ты старый пердун, вот что!");
            const_dialogs["npc.Ded"].Add("end", new _dialoginfo("Иди-иди, всю рыбу распугал!"));

            const_dialogs.Add("npc.Malchugan", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Malchugan"].Add("begin", new _dialoginfo("О! Ты видел палладинов? Правда, здорово? А какая блестящая броня, в такой ни один волк не страшен! Я когда вырасту тоже стану рыцарем!"));

            const_dialogs.Add("npc.Mahmet", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Mahmet"].Add("begin", new _dialoginfo("Здавствуй, <name>. Я Махмет, торговец драгоценностями. Покупаю кольца, бусы, ожерелья и драгоценные камни. У меня лучшие цены в городе!"));
            const_dialogs["npc.Mahmet"]["begin"].replies.Add("sell", "Я хочу продать кое-что");
            const_dialogs["npc.Mahmet"]["begin"].replies.Add("buy", "Покажи мне твои товары");
            const_dialogs["npc.Mahmet"]["begin"].replies.Add("get", "Где же мне достать драгоценности?");
            const_dialogs["npc.Mahmet"]["begin"].replies.Add("end", "Пока");
            const_dialogs["npc.Mahmet"].Add("get", new _dialoginfo("Лучше всего искать их около гор, в рудниках и шахтах. Хотя иногда драгоценные камни попадаются у монстров. Особенного гоблины любят таскать всякие безделушки."));
            const_dialogs["npc.Mahmet"].Add("end", new _dialoginfo("Я всегда здесь"));

            const_dialogs.Add("npc.Julien", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Julien"].Add("begin", new _dialoginfo("Рад тебя видеть, <name>. У меня ты можешь купить или продать магические реагенты, а также руны перемещения. Правда покупаю я исключительно реагенты"));
            const_dialogs["npc.Julien"]["begin"].replies.Add("sell", "Я хочу продать кое-что");
            const_dialogs["npc.Julien"]["begin"].replies.Add("buy", "Покажи мне твои товары");
            const_dialogs["npc.Julien"]["begin"].replies.Add("get", "Где я могу найти реагенты?");
            const_dialogs["npc.Julien"]["begin"].replies.Add("ak", "В Академии тоже продают реагенты!");
            const_dialogs["npc.Julien"]["begin"].replies.Add("end", "Пока");
            const_dialogs["npc.Julien"].Add("get", new _dialoginfo("Гм... Ну, большинство из них ты можешь найти в лесу, некоторые у гор или в болотах. Можешь попробовать также пройтись вдоль реки, там иногда попадается жемчуг - очень редкий и дорогой реагент."));
            const_dialogs["npc.Julien"].Add("ak", new _dialoginfo("[задумчиво] Академия.. Да.., раньше только в Академии и продавали, а кто еще пробовал, того сразу... ну неважно, сейчас стало гораздо лучше. Если ты этого еще не сделал, сравни цены и все поймешь."));
            const_dialogs["npc.Julien"].Add("end", new _dialoginfo("Всегда рад тебя видеть"));

            const_dialogs.Add("npc.Goston", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Goston"].Add("begin", new _dialoginfo("Добро пожаловать! Для тебя, <name>, у меня всегда что-нибудь найдется."));
            const_dialogs["npc.Goston"]["begin"].replies.Add("sellinfo", "Чем ты торгуешь?");
            const_dialogs["npc.Goston"]["begin"].replies.Add("buy", "Покажи мне твои товары");
            const_dialogs["npc.Goston"]["begin"].replies.Add("sell", "Я хочу кое-что продать");
            const_dialogs["npc.Goston"]["begin"].replies.Add("end", "Мне пора");
            const_dialogs["npc.Goston"].Add("sellinfo", new _dialoginfo("Всем помаленьку, что может пригодиться путешественнику или охотнику. Да и покупаю я все, что ни принесешь, только бы оно хоть что-то стоило... Если покажешь мне предмет, я назову свою цену"));
            const_dialogs["npc.Goston"]["sellinfo"].replies.Add("buy", "Ясно, покажи мне твои товары");
            const_dialogs["npc.Goston"]["sellinfo"].replies.Add("sell", "Я хочу продать");
            const_dialogs["npc.Goston"].Add("end", new _dialoginfo("Приходи еще"));

            const_dialogs.Add("npc.Raksha", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Raksha"].Add("begin", new _dialoginfo("Кого я вижу, сам <name> пожаловал! Решил просто так навестить старую Ракшу или хочешь что-то купить?"));
            const_dialogs["npc.Raksha"]["begin"].replies.Add("sellinfo", "Чем ты торгуешь?");
            const_dialogs["npc.Raksha"]["begin"].replies.Add("buy", "Хочу купить");
            const_dialogs["npc.Raksha"]["begin"].replies.Add("sell", "Хочу подать");
            const_dialogs["npc.Raksha"]["begin"].replies.Add("end", "Нет, ничего, в другой раз");
            const_dialogs["npc.Raksha"].Add("sellinfo", new _dialoginfo("Ты не знаешь, чем торгует Ракша? [сокрушенно] Куда катится мир... Торгую я, сынок, снадобьями целебными, да повышающими ману."));
            const_dialogs["npc.Raksha"]["sellinfo"].replies.Add("buy", "Неплохо, покажи какие именно");
            const_dialogs["npc.Raksha"]["sellinfo"].replies.Add("teach", "Ты можешь научить меня делать напитки?");
            const_dialogs["npc.Raksha"].Add("teach", new _dialoginfo("Ух, шустер, ничего не скажешь! Ты думаешь, я вот так раз, взяла, да и рассказа тебе секреты целебных трав, передающиеся поколениями от бабки к внучке? Мал ты еще видать, коль столь наивен..."));
            const_dialogs["npc.Raksha"]["teach"].replies.Add("begin", "Хм...");
            const_dialogs["npc.Raksha"].Add("end", new _dialoginfo("Береги себя, сынок"));

            const_dialogs.Add("npc.Arant", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Arant"].Add("begin", new _dialoginfo("Здравствуй, <name>. Я торгую стрелковым оружием и припасами к нему."));
            const_dialogs["npc.Arant"]["begin"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Arant"]["begin"].replies.Add("sell", "У меня есть товары на продажу");
            const_dialogs["npc.Arant"]["begin"].replies.Add("sellinfo", "А ты покупаешь оружие?");
            const_dialogs["npc.Arant"]["begin"].replies.Add("tell", "Расскажи мне о стрельбе");
            const_dialogs["npc.Arant"]["begin"].replies.Add("end", "Нет, ничего, в другой раз");
            const_dialogs["npc.Arant"].Add("sellinfo", new _dialoginfo("Да, конечно"));
            const_dialogs["npc.Arant"]["sellinfo"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Arant"].Add("tell", new _dialoginfo("Ну, стрелковое оружие разным бывает. Это луки, арбалеты, сюда же относится все что можно кинуть во врага: ножи, копья и многое другое, даже камни. Общее у них одно - им можно достать врага, который довольно далеко от тебя, в отличие от холодного оружия, которое действует только вблизи."));
            const_dialogs["npc.Arant"]["tell"].replies.Add("arb", "Расскажи об арбалетах");
            const_dialogs["npc.Arant"]["tell"].replies.Add("luk", "Расскажи о луках");
            const_dialogs["npc.Arant"]["tell"].replies.Add("bum", "Есть что-нибудь особенное?");
            const_dialogs["npc.Arant"]["tell"].replies.Add("teach", "ты можешь меня чему-нибудь научить?");
            const_dialogs["npc.Arant"]["tell"].replies.Add("end", "Я должен идти");
            const_dialogs["npc.Arant"].Add("arb", new _dialoginfo("Арбалеты - очень хорошее оружие, хоть и дорогое. Главное достоинство арбалетов - то что они самострелы, т.е. бьют без помощи физической силы человека. Даже, извини, хлюпик и тот всадит болт так, что всадник в броне испустит дух раньше чем коснется земли. Помни только о том, что для арбалетов нужны не стрелы, а болты."));
            const_dialogs["npc.Arant"]["arb"].replies.Add("tell", "Ясно");
            const_dialogs["npc.Arant"].Add("luk", new _dialoginfo("Лук - основное оружие охотника, потому что позволяет подстрелить убегающую добычу. Луки проще в изготовлении, чем арбалеты, луков бывает больше разновидностей. А по мощности они почти догоняют арбалеты. Хотя это дело вкуса. В общем случае, сильный человек даже из плохого лука будет стрелять улчше, чем слабый из хорошего."));
            const_dialogs["npc.Arant"]["luk"].replies.Add("tell", "Ясно");
            const_dialogs["npc.Arant"].Add("bum", new _dialoginfo("Хм... пожалуй, есть. Посмотри на бумеранг. Он относится к стрелковому оружию, но не тратит боеприпасов, так как возвращается к владельцу. Еще обрати внимание на пращу, ей можно метать камни сильней, чем просто бросать их руками."));
            const_dialogs["npc.Arant"]["bum"].replies.Add("tell", "Ясно, спасибо");
            const_dialogs["npc.Arant"].Add("teach", new _dialoginfo("Я могу научить тебя стрелять из лука за 150 монет, а также развить ловкость за 100 монет."));
            const_dialogs["npc.Arant"]["teach"].replies.Add("luknow", "Научи меня стрелять из лука");
            const_dialogs["npc.Arant"]["teach"].replies.Add("dexnow", "Научи меня ловкости");
            const_dialogs["npc.Arant"]["teach"].replies.Add("tell", "Я передумал");
            const_dialogs["npc.Arant"].Add("luknow", new _dialoginfo("skill|ranged|150|0|3"));
            const_dialogs["npc.Arant"].Add("dexnow", new _dialoginfo("skill|dex|100|0|3"));
            const_dialogs["npc.Arant"].Add("end", new _dialoginfo("Приходи еще"));

            const_dialogs.Add("npc.Milta", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Milta"].Add("begin", new _dialoginfo("Здесь продаются домашние животные. Ты можешь купить себе, например, собаку. Правда сейчас в продаже ничего нет, так что приходи как-нибудь в другой раз..."));

            const_dialogs.Add("npc.Frederik", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Frederik"].Add("begin", new _dialoginfo("Здравствуй. Тебя зовут <name>, верно?"));
            const_dialogs["npc.Frederik"]["begin"].replies.Add("who", "Верно, кто ты?");
            const_dialogs["npc.Frederik"]["begin"].replies.Add("end", "Я должен идти");
            const_dialogs["npc.Frederik"].Add("who", new _dialoginfo("Меня зовут Фредерик и я владецец этой таверны. Здесь ты можешь что-нибудь перекусить или отдохнуть наверху в одной из комнат."));
            const_dialogs["npc.Frederik"]["who"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Frederik"]["who"].replies.Add("sellinfo", "Ты что-нибудь покупаешь?");
            const_dialogs["npc.Frederik"]["who"].replies.Add("end", "Я должен идти");
            const_dialogs["npc.Frederik"].Add("sellinfo", new _dialoginfo("Нет, это ведь не магазин, а таверна. Люди приходят сюда выпить и перекусить, а не торговаться."));
            const_dialogs["npc.Frederik"]["sellinfo"].replies.Add("who", "Ясно");
            const_dialogs["npc.Frederik"].Add("end", new _dialoginfo("Пока"));

            const_dialogs.Add("npc.Surri", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Surri"].Add("begin", new _dialoginfo("Что тебе здесь надо?"));
            const_dialogs["npc.Surri"]["begin"].replies.Add("who", "Меня зовут <name>, а ты кто?");
            const_dialogs["npc.Surri"]["begin"].replies.Add("end", "Гм., вернусь когда станешь повежливей");
            const_dialogs["npc.Surri"].Add("who", new _dialoginfo("Я Сурри. Так все-таки, зачем явился, это место не из самых посещаемых."));
            const_dialogs["npc.Surri"]["who"].replies.Add("who2", "Почему это место не охраяется стражей?");
            const_dialogs["npc.Surri"]["who"].replies.Add("end", "Я должен идти");
            const_dialogs["npc.Surri"].Add("who2", new _dialoginfo("Ну да, не охраняется, да тут и охранять нечего, посмотри вокруг."));
            const_dialogs["npc.Surri"]["who2"].replies.Add("who3", "Так чего же ты здесь живешь?");
            const_dialogs["npc.Surri"]["who2"].replies.Add("end", "Я должен идти");
            const_dialogs["npc.Surri"].Add("who3", new _dialoginfo("Гм.., значит на то есть причины. Возможно, меня жители не очень-то любят, тебе какое дело?"));
            const_dialogs["npc.Surri"]["who3"].replies.Add("who4", "Да никакого, разве ты можешь кого обидеть?");
            const_dialogs["npc.Surri"]["who3"].replies.Add("end", "Похоже, список тех кто тебя недолюбливает, пополнился на одного.");
            const_dialogs["npc.Surri"].Add("who4", new _dialoginfo("[странно улыбается и что-то бормочет себе под нос] Необязательно причинять боль, чтобы не понравится людям..."));
            const_dialogs["npc.Surri"]["who4"].replies.Add("who5", "А что например?");
            const_dialogs["npc.Surri"]["who4"].replies.Add("end", "Мне надоели твои намеки");
            const_dialogs["npc.Surri"].Add("who5", new _dialoginfo("Ну, например, ты можешь у них что-нибудь украсть..."));
            const_dialogs["npc.Surri"]["who5"].replies.Add("who6", "Ты вор???");
            const_dialogs["npc.Surri"]["who5"].replies.Add("end", "Хех, что-то я захотел на улицу");
            const_dialogs["npc.Surri"].Add("who6", new _dialoginfo("Сейчас я уже ничем таким не занимаюсь, а вот молодость провел очень даже бурно, если ты понимаешь, о чем я..."));
            const_dialogs["npc.Surri"]["who6"].replies.Add("who7", "Тогда почему не возвращаешься в город?");
            const_dialogs["npc.Surri"]["who6"].replies.Add("end", "И знать не хочу, о чем ты!");
            const_dialogs["npc.Surri"].Add("who7", new _dialoginfo("Хе-хе, а мы и так в городе, если ты этого не заметил."));
            const_dialogs["npc.Surri"]["who7"].replies.Add("who8", "Я не о том");
            const_dialogs["npc.Surri"]["who7"].replies.Add("end", "Мне пора");
            const_dialogs["npc.Surri"].Add("who8", new _dialoginfo("Ну, дело не во мне, а в моем сыне. Он, как бы это сказать, пошел по стопам отца. Я его, понятное дело, не одобряю, но ведь один он у меня, куда уж я без него, вот так и жевем вместе, у черта на куличках...[неожиданно улыбнулся] А ведь знаешь, более шцстрого малого, чем мой сын, и во всем городе не сыскать!"));
            const_dialogs["npc.Surri"]["who8"].replies.Add("who9", "Он может меня чему-нибудь научить?");
            const_dialogs["npc.Surri"]["who8"].replies.Add("end", "Мне пора");
            const_dialogs["npc.Surri"].Add("who9", new _dialoginfo("Что ты у меня спрашиваешь, поговори с ним, он в соседней комнате. Воры хоть и работают порой на заказ, но никому не служат, [презрительно скривился] в отличие от палладинов."));
            const_dialogs["npc.Surri"]["who9"].replies.Add("who10", "А что с палладинами?");
            const_dialogs["npc.Surri"]["who9"].replies.Add("end", "Мне пора");
            const_dialogs["npc.Surri"].Add("who10", new _dialoginfo("Да ничего, старые счеты. Терпеть не могу этих ныпыщенных ублюдков, рассуждающих о чести, а даже ради спасения близких людей не могущие ударить врага в спину. Чертова благородность. [грубо] И хватит с тебя рассказов, лучше не суй нос в чужую жизнь, некоторым это может не понравиться."));
            const_dialogs["npc.Surri"]["who10"].replies.Add("who11", "Но ты же сам начал...");
            const_dialogs["npc.Surri"]["who10"].replies.Add("end", "Мне пора");
            const_dialogs["npc.Surri"].Add("who11", new _dialoginfo("Как начал, так и кончил, проваливай."));
            const_dialogs["npc.Surri"]["who11"].replies.Add("end", "Как знаешь, твои проблемы");
            const_dialogs["npc.Surri"].Add("end", new _dialoginfo("[что-то ворчит себе под нос]"));

            const_dialogs.Add("npc.Sirs", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Sirs"].Add("begin", new _dialoginfo("Привет, каким судьбами?"));
            const_dialogs["npc.Sirs"]["begin"].replies.Add("tren", "Я говорил с твоим отцом, он утверждает что ты ловкий парень");
            const_dialogs["npc.Sirs"]["begin"].replies.Add("end", "Такими же, какими я сейчас уйду");
            const_dialogs["npc.Sirs"].Add("tren", new _dialoginfo("Я так и знал, ну и чему ты хочешь научиться?"));
            const_dialogs["npc.Sirs"]["tren"].replies.Add("dex", "Ловкости");
            const_dialogs["npc.Sirs"]["tren"].replies.Add("look", "Осторожности");
            const_dialogs["npc.Sirs"]["tren"].replies.Add("steallook", "Подглядыванию");
            const_dialogs["npc.Sirs"]["tren"].replies.Add("steal", "Воровству");
            const_dialogs["npc.Sirs"]["tren"].replies.Add("hide", "Скрытности");
            const_dialogs["npc.Sirs"]["tren"].replies.Add("story", "Что-то ты не похож на учителя");
            const_dialogs["npc.Sirs"]["tren"].replies.Add("end", "Нет, ничего");
            const_dialogs["npc.Sirs"].Add("story", new _dialoginfo("Это смотря чему учить. Да если хочешь, знать, я тут у одного богача свистнул дорогущее ожерелье, да так ловко провернул дельце, что все подумали на его сына, тому как раз нужны были деньги. Что теперь думаешь?"));
            const_dialogs["npc.Sirs"]["story"].replies.Add("fak", "Ты по прежнему не похож на учителя, ты теперь похож не придурка!");
            const_dialogs["npc.Sirs"]["story"].replies.Add("tren", "Ладно, давай о чем нибудь другом");
            const_dialogs["npc.Sirs"]["story"].replies.Add("end", "С ворами у меня пути расходятся");
            const_dialogs["npc.Sirs"].Add("fak", new _dialoginfo("Сам ты придурок! Не забыл еще, что сюда стража носа не сует, будешь много о себе ставить, мигом твой же нос пообломаю!"));
            const_dialogs["npc.Sirs"].Add("dex", new _dialoginfo("Ловкость - главная характеристика для вора, от нее зависит, сумеешь ли вообще заглянуть в чужой карман, не говоря уж о том, чтобы что-то спереть! Это будет стоить 100 монет"));
            const_dialogs["npc.Sirs"]["dex"].replies.Add("dexnow", "Согласен");
            const_dialogs["npc.Sirs"]["dex"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Sirs"].Add("dexnow", new _dialoginfo("skill|dex|100|2|5"));
            const_dialogs["npc.Sirs"].Add("look", new _dialoginfo("Просто не забывай смотреть по сторонам. Нет ничего глупей, чем позволить себя обокрасть среди бела дня... За 200 монет я могу научить тебя, как не позволять всяким... гм... любителям шарить по твоим карманам."));
            const_dialogs["npc.Sirs"]["look"].replies.Add("looknow", "Отличная идея!");
            const_dialogs["npc.Sirs"]["look"].replies.Add("tren", "Нет, извини, денег жалко...");
            const_dialogs["npc.Sirs"].Add("looknow", new _dialoginfo("skill|look|200|0|5"));
            const_dialogs["npc.Sirs"].Add("steallook", new _dialoginfo("Согласись, прежде чем воровать, неплохо бы знать, что у богатея в сумке, верно? Тем более заглянуть туда намного проще, чем собственно что-то оттуда утянуть. Я могу рассказать о некоторых хитростях за 100 монет"));
            const_dialogs["npc.Sirs"]["steallook"].replies.Add("steallooknow", "Согласен");
            const_dialogs["npc.Sirs"]["steallook"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Sirs"].Add("steallooknow", new _dialoginfo("skill|steallook|100|0|5"));
            const_dialogs["npc.Sirs"].Add("steal", new _dialoginfo("Главное - не быть замеченным. Если все провернуть чисто, то даже стража ничего не заподозрит. Но это трудное и опасное ремесло, к тому же если твой 'объект' осторожен, то обворовать его становится еще сложней! Это будет стоить 200 монет"));
            const_dialogs["npc.Sirs"]["steal"].replies.Add("stealnow", "Давай, учи, вместо того чтобы болтать");
            const_dialogs["npc.Sirs"]["steal"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Sirs"].Add("stealnow", new _dialoginfo("skill|steal|200|0|5"));
            const_dialogs["npc.Sirs"].Add("hide", new _dialoginfo("Навык незаметности может пригодиться при удирании от погони. Если грамотно скрываться, то любая стража потеряет тебя из виду уже через несколько шагов. Когда цена - твоя жизнь, что говорить о жалких 200 монетах, согласен?"));
            const_dialogs["npc.Sirs"]["hide"].replies.Add("hidenow", "Угу");
            const_dialogs["npc.Sirs"]["hide"].replies.Add("tren", "Нет, не согласен, 200 монет дороже");
            const_dialogs["npc.Sirs"].Add("hidenow", new _dialoginfo("skill|hiding|200|0|5"));
            const_dialogs["npc.Sirs"].Add("end", new _dialoginfo("[с усмешкой] Не пропадай"));

            const_dialogs.Add("npc.Markus", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Markus"].Add("begin", new _dialoginfo("Как дела, старина <name>? Я Маркус, тренирую здешних ребят, что сейчас дрыхнут в казарме. Не желаешь размяться?"));
            const_dialogs["npc.Markus"]["begin"].replies.Add("tren", "С удовольствием, старина Маркус!");
            const_dialogs["npc.Markus"]["begin"].replies.Add("end", "Вы ошиблись, я просто шел мимо");
            const_dialogs["npc.Markus"].Add("tren", new _dialoginfo("Вот это дело! Закатывай рукава. Я, конечно, не такой мастер, как Кантарес из двора рыцарей, но в кулачном бою мне нет равных. Да и считай учу задаром"));
            const_dialogs["npc.Markus"]["tren"].replies.Add("str", "Вначале помоги мне стать сильнее");
            const_dialogs["npc.Markus"]["tren"].replies.Add("hand", "Можешь научить рукопашной схватке?");
            const_dialogs["npc.Markus"]["tren"].replies.Add("cold", "А как насчет меча?");
            const_dialogs["npc.Markus"]["tren"].replies.Add("end", "В другой раз");
            const_dialogs["npc.Markus"].Add("str", new _dialoginfo("Нет проблем, для человека, каждый день показывающего пример зеленым салагам, это раз плюнуть. Хм... 80 монет найдется?"));
            const_dialogs["npc.Markus"]["str"].replies.Add("strnow", "Найдется!");
            const_dialogs["npc.Markus"]["str"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Markus"].Add("strnow", new _dialoginfo("skill|str|80|0|3"));
            const_dialogs["npc.Markus"].Add("hand", new _dialoginfo("Все очень просто: сила и навык. И то и то влияет на мощь удара, и не забывай про ловкость, иначе твой кулак скользнет мимо наглой рожи твоего врага. [улыбается] Хотя, если честно, кулаком промазать сложно. Это ведь тебе не меч, и тем более не лук. Гони сотню монет.йй"));
            const_dialogs["npc.Markus"]["hand"].replies.Add("handnow", "Держи сотню монет");
            const_dialogs["npc.Markus"]["hand"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Markus"].Add("handnow", new _dialoginfo("skill|hand|100|0|5"));
            const_dialogs["npc.Markus"].Add("cold", new _dialoginfo("C этим сложней. Конечно, я не лопух, но вряд ли смогу показать что-то, чего не смог бы Кантарес. Хотя для начала сойдет, [зубоскалит] чтоб ты сам не сошел на завтрак какому-нибудь орку. Хей, не забудь 80 монет!"));
            const_dialogs["npc.Markus"]["cold"].replies.Add("coldnow", "Ближе к делу!");
            const_dialogs["npc.Markus"]["cold"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Markus"].Add("coldnow", new _dialoginfo("skill|coldweapon|80|0|2"));
            const_dialogs["npc.Markus"].Add("end", new _dialoginfo("[дружески хлопает вас спине] Заходи в любое время, <name>!"));

            const_dialogs.Add("npc.Sloven", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Sloven"].Add("begin", new _dialoginfo("Приветствую в моем магазине снаряжения, <name>. Я продаю и покупаю почти все. Ценами тоже не обижаю."));
            const_dialogs["npc.Sloven"]["begin"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Sloven"]["begin"].replies.Add("sell", "Я хочу продать");
            const_dialogs["npc.Sloven"]["begin"].replies.Add("oh", "Где мне найти охотников?");
            const_dialogs["npc.Sloven"]["begin"].replies.Add("end", "Нет, ничего, в другой раз");
            const_dialogs["npc.Sloven"].Add("oh", new _dialoginfo("Ха! Глянь у ворот или за ними, кто-нибудь обязательно там торчит. Этот народ так и снует туда-сюда."));
            const_dialogs["npc.Sloven"]["oh"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Sloven"]["oh"].replies.Add("sell", "Я хочу продать");
            const_dialogs["npc.Sloven"].Add("end", new _dialoginfo("Будь осторожен в лесу"));

            const_dialogs.Add("npc.Yan", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Yan"].Add("begin", new _dialoginfo("Привет"));
            const_dialogs["npc.Yan"]["begin"].replies.Add("hunt", "Расскажи мне об охоте");
            const_dialogs["npc.Yan"]["begin"].replies.Add("tren", "Ты можешь меня чему-нибудь научить?");
            const_dialogs["npc.Yan"]["begin"].replies.Add("end", "Мне пора");
            const_dialogs["npc.Yan"].Add("hunt", new _dialoginfo("Хм.. а что там рассказывать? Подстрели зверюгу, разделай тушу любым ножом (мечи и кинжалы не годятся!), а что с нее снимешь тащи в город и продавай. Весьма неплохой бизнес, да и относительно спокойный. Если не считать, что иногда в лесах стречаются монстры. Но эnо уже как повезет... Больше всего зверья в западном лесу, туда мы в основном и ходим. Но будь осторожен, не давно там видели настоящего тролля!"));
            const_dialogs["npc.Yan"]["hunt"].replies.Add("tren", "Ясно, можешь меня потренировать?");
            const_dialogs["npc.Yan"].Add("tren", new _dialoginfo("Каждый, кто способен выжить в лесу, может многому научить. Что тебя интересует?"));
            const_dialogs["npc.Yan"]["tren"].replies.Add("dex", "Как повысить ловкость");
            const_dialogs["npc.Yan"]["tren"].replies.Add("luk", "Стрельба из лука");
            const_dialogs["npc.Yan"]["tren"].replies.Add("hide", "Незаметность");
            const_dialogs["npc.Yan"]["tren"].replies.Add("look", "Осторожность");
            const_dialogs["npc.Yan"]["tren"].replies.Add("lore", "Изучение животных");
            const_dialogs["npc.Yan"]["tren"].replies.Add("heal", "Лечение ран");
            const_dialogs["npc.Yan"]["tren"].replies.Add("begin", "Ничего, я передумал");
            const_dialogs["npc.Yan"].Add("dex", new _dialoginfo("Ловкость очень важна дял стрелка. И не надо улыбаться, я имел ввиду меткость, а не умение драпать от первого же зайца, оскалившего зубы :-) Готов расстаться с 90 монетами?"));
            const_dialogs["npc.Yan"]["dex"].replies.Add("dexnow", "Готов");
            const_dialogs["npc.Yan"]["dex"].replies.Add("tren", "Неа");
            const_dialogs["npc.Yan"].Add("dexnow", new _dialoginfo("skill|dex|90|0|4"));
            const_dialogs["npc.Yan"].Add("luk", new _dialoginfo("Просто целься лучше, да сильней оттягивай тетиву. Или возьми арбалет, там сила нужна лишь чтобы его таскать, весит эта бандура ого-го! Давай 120 монет."));
            const_dialogs["npc.Yan"]["luk"].replies.Add("luknow", "Держи");
            const_dialogs["npc.Yan"]["luk"].replies.Add("tren", "Обойдешься");
            const_dialogs["npc.Yan"].Add("luknow", new _dialoginfo("skill|ranged|120|0|4"));
            const_dialogs["npc.Yan"].Add("hide", new _dialoginfo("Скрытность позволяет незаметно подкрасться к врагу, да и потихоньку отойти, если он слишком для тебя силен тоже. Вполне удобный навык для рискованного охотника. И всего за 150 монет."));
            const_dialogs["npc.Yan"]["hide"].replies.Add("hidenow", "Ок, согласен");
            const_dialogs["npc.Yan"]["hide"].replies.Add("tren", "Извини, в другой раз");
            const_dialogs["npc.Yan"].Add("hidenow", new _dialoginfo("skill|hiding|150|0|4"));
            const_dialogs["npc.Yan"].Add("look", new _dialoginfo("Да, для выслеживания дичи навык что надо - ты должен быть не только незаметным, но и не пропускать мелких деталей, чтобы выскочивший из чащи медведь не стал для тебя неожиданностью. К тому же и в городе поможет быть начеку, чтобы тебя не очистили воры. Стоит это 180 монет"));
            const_dialogs["npc.Yan"]["look"].replies.Add("looknow", "Готов");
            const_dialogs["npc.Yan"]["look"].replies.Add("tren", "Неа");
            const_dialogs["npc.Yan"].Add("looknow", new _dialoginfo("skill|look|180|0|4"));
            const_dialogs["npc.Yan"].Add("lore", new _dialoginfo("Хочешь уметь обращаться с животными? Я могу помочь, правда сам не много знаю. А вот на севере отсюда есть каменый дом, в нем Лексли, вот кто разбирается в животных, они у него лучшие друзья и слушаются его с полуслова. Я могу научить тебя азам изучения животных за 150 монет."));
            const_dialogs["npc.Yan"]["lore"].replies.Add("lorenow", "Давай");
            const_dialogs["npc.Yan"]["lore"].replies.Add("tren", "Нет");
            const_dialogs["npc.Yan"].Add("lorenow", new _dialoginfo("skill|animallore|150|0|3"));
            const_dialogs["npc.Yan"].Add("heal", new _dialoginfo("Раны заживают со скоростью, которая зависит от особенностей организма, но я знаю пару трюков, которые позволят тебе дотянуть до города в таких пердрягах, из которой бы не вышел никто другой! За 180 монет."));
            const_dialogs["npc.Yan"]["heal"].replies.Add("healnow", "Давай");
            const_dialogs["npc.Yan"]["heal"].replies.Add("tren", "Нет");
            const_dialogs["npc.Yan"].Add("healnow", new _dialoginfo("skill|regeneration|180|0|2"));
            const_dialogs["npc.Yan"].Add("end", new _dialoginfo("Будь осторожен в лесу"));

            const_dialogs.Add("npc.Leksli", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Leksli"].Add("begin", new _dialoginfo("Здавствуй, <name>, что тебя сюда привело?"));
            const_dialogs["npc.Leksli"]["begin"].replies.Add("tren", "Ты можешь меня чему-нибудь научить?");
            const_dialogs["npc.Leksli"]["begin"].replies.Add("trade", "Ты чем-нибудь торгуешь?");
            const_dialogs["npc.Leksli"]["begin"].replies.Add("tell", "Расскажи о здешних местах");
            const_dialogs["npc.Leksli"]["begin"].replies.Add("end", "Случайность");
            const_dialogs["npc.Leksli"].Add("trade", new _dialoginfo("Да, я покупаю шкуры животных, да и продаю помаленьку что есть"));
            const_dialogs["npc.Leksli"]["trade"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Leksli"]["trade"].replies.Add("sell", "У меня есть что продать");
            const_dialogs["npc.Leksli"]["trade"].replies.Add("begin", "Ясно");
            const_dialogs["npc.Leksli"].Add("tell", new _dialoginfo("Ну, в западном лесу полно дичи, в северном тоже, но там места какие-то гиблые, да и восточное кладбище близко, еще напорешься на какую-нибудь нежить. А в остальном нчиего особенного, места здесь глухие..."));
            const_dialogs["npc.Leksli"]["tell"].replies.Add("begin", "Ясно");
            const_dialogs["npc.Leksli"].Add("tren", new _dialoginfo("Я могу научить тебя обращению с животными."));
            const_dialogs["npc.Leksli"]["tren"].replies.Add("lore", "Что насчет Изучения животных?");
            const_dialogs["npc.Leksli"]["tren"].replies.Add("tame", "Как приручать животных?");
            const_dialogs["npc.Leksli"]["tren"].replies.Add("begin", "В другой раз");
            const_dialogs["npc.Leksli"].Add("lore", new _dialoginfo("Секрет прост - надо быть с ними вежливым. Звери понимают куда больше, чем принято считать. В основном, правда они судят по эмоциям, поэтому говори уверенно и спокойно, правильным тоном можно остановить даже разъяренного волка. Только действует это исключительно на животных, а на монстров нет. 200 монет тебя не затруднят?"));
            const_dialogs["npc.Leksli"]["lore"].replies.Add("lorenow", "Я согласен");
            const_dialogs["npc.Leksli"]["lore"].replies.Add("tren", "К сожалению, затруднят");
            const_dialogs["npc.Leksli"].Add("lorenow", new _dialoginfo("skill|animallore|200|1|5"));
            const_dialogs["npc.Leksli"].Add("tame", new _dialoginfo("С приручением используются почти то же, что и с изучением - надо дать понять звурю, что ты не желаешь ему зла. Все остальное - просто сведения о повадках тех или иных животных. 200 монет и я расскажу какие именно."));
            const_dialogs["npc.Leksli"]["tame"].replies.Add("tamenow", "Всего-то? Я готов слушать");
            const_dialogs["npc.Leksli"]["tame"].replies.Add("tren", "Упс, в другой раз");
            const_dialogs["npc.Leksli"].Add("tamenow", new _dialoginfo("skill|animaltaming|200|0|5"));
            const_dialogs["npc.Leksli"].Add("end", new _dialoginfo("Будь здоров"));

            const_dialogs.Add("npc.Batist", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Batist"].Add("begin", new _dialoginfo("Кого тут еще черти носят?"));
            const_dialogs["npc.Batist"]["begin"].replies.Add("who", "Кто ты?");
            const_dialogs["npc.Batist"]["begin"].replies.Add("end", "Будь вежливей, говорят, помогает");
            const_dialogs["npc.Batist"].Add("who", new _dialoginfo("Я просто живу здесь и хотел бы, чтобы меня никто не беспокоил."));
            const_dialogs["npc.Batist"]["who"].replies.Add("who2", "Как же ты выжил в лесу?");
            const_dialogs["npc.Batist"].Add("who2", new _dialoginfo("Ничего сложного, уметь надо. Никогда не любил города - шум и гам сплошной. То ли дело здесь - красота, никто небя не тревожит..."));
            const_dialogs["npc.Batist"]["who2"].replies.Add("tren", "Что именно надо уметь?");
            const_dialogs["npc.Batist"]["who2"].replies.Add("danger", "Разве здесь не опасно?");
            const_dialogs["npc.Batist"]["who2"].replies.Add("end", "Тогда и я тебя не буду тревожить, пока");
            const_dialogs["npc.Batist"].Add("tren", new _dialoginfo("Ну, понимаешь, есть навыки, когда раны заживают сами собой, причем раны любой сложности. А уж еду всегда найдешь в лесу. Если хочешь, я научу тебя как без ничего заживлять раны. Но не задаром, за 250 монет."));
            const_dialogs["npc.Batist"]["tren"].replies.Add("trennow", "Держи деньги, учи");
            const_dialogs["npc.Batist"]["tren"].replies.Add("who2", "В другой раз");
            const_dialogs["npc.Batist"].Add("trennow", new _dialoginfo("skill|regeneration|250|0|5"));
            const_dialogs["npc.Batist"].Add("danger", new _dialoginfo("Ну, бывают и сложности. Порой выйдут чудища какие из леса, переворошат дом. Но окромя съестного, ничего не трогают, да и уйдут обратно в лес. Как ни странно, приходят в основном с запада, хотя там глушь вроде сплошная."));
            const_dialogs["npc.Batist"].Add("end", new _dialoginfo("Счастливо, не суйся на запад"));

            const_dialogs.Add("npc.Djon", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Djon"].Add("begin", new _dialoginfo("Дяденька, вы не от Фредерика случайно?"));
            const_dialogs["npc.Djon"]["begin"].replies.Add("no", "Нет, кто такой Фредерик");
            const_dialogs["npc.Djon"]["begin"].replies.Add("yes", "Может и от него...");
            const_dialogs["npc.Djon"]["begin"].replies.Add("end", "Не путайся под ногами, малыш");
            const_dialogs["npc.Djon"].Add("yes", new _dialoginfo("Вот здорово, значит вы разберетесь с этими тварями на складе? Спасибо!"));
            const_dialogs["npc.Djon"].Add("no", new _dialoginfo("Жаль, эти крысы меня совсем замучили... Не дают войти на склад и все тут..."));
            const_dialogs["npc.Djon"]["no"].replies.Add("no2", "Тебя испугали крысы???");
            const_dialogs["npc.Djon"]["no"].replies.Add("dom", "Сиди дома, если боишься крыс. И носи юбку.");
            const_dialogs["npc.Djon"]["no"].replies.Add("end", "Ух, такая страшная беда, пойду-ка я отсюда подальше");
            const_dialogs["npc.Djon"].Add("no2", new _dialoginfo("А где это видано, чтобы крысы бросались на человека? А эти бросаются! Как хотите, а я туда ни ногой!"));
            const_dialogs["npc.Djon"]["no2"].replies.Add("end", "Ладно, разберемся");
            const_dialogs["npc.Djon"].Add("dom", new _dialoginfo("[обиженно сопит] Как обзываться, так все мастера, а вот как бы вас самих оттуда не пришлось крюками вытаскивать..."));
            const_dialogs["npc.Djon"]["dom"].replies.Add("no2", "Что там с этими крысами?");
            const_dialogs["npc.Djon"]["dom"].replies.Add("end", "Сопляк ты еще со мной так разговаривать!");
            const_dialogs["npc.Djon"].Add("end", new _dialoginfo("Будьте осторожней там, дяденька!"));

            const_dialogs.Add("npc.Gregg", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Gregg"].Add("begin", new _dialoginfo("Что тебе надо, чуждестранец? Лучше убирайся подобру-поздорову, иначе у тебя должны быть очень, повторяю, очень веские причины сюда войти!"));
            const_dialogs["npc.Gregg"]["begin"].replies.Add("st", "Не очень-то вежливо");
            const_dialogs["npc.Gregg"]["begin"].replies.Add("end", "Иди сам к черту!");
            const_dialogs["npc.Gregg"].Add("st", new _dialoginfo("Можешь засунуть свою вежливость себе в задницу, понял? Это мой дом и я здесь хозяин! [Cтоун в стороне робко: но отец...] [обращается к Стоуну] а ты не лезь, когда я разговариваю с 'гостями'!"));
            const_dialogs["npc.Gregg"]["st"].replies.Add("st2", "А чем парень тебе не угодил, или может просто ты оттоптал левую ногу, когда вставал с кровати?");
            const_dialogs["npc.Gregg"]["st"].replies.Add("end", "Занесло же меня к психу...");
            const_dialogs["npc.Gregg"].Add("st2", new _dialoginfo("Не твое дело! С этим ничтожеством я сам разберусь без твоего не в меру любознательного носа!"));
            const_dialogs["npc.Gregg"]["st2"].replies.Add("st3", "И все-таки, это парень не похож на лентяя или прохвоста");
            const_dialogs["npc.Gregg"]["st2"].replies.Add("end", "Ты меня достал");
            const_dialogs["npc.Gregg"].Add("st3", new _dialoginfo("Он не лентяй и не прохвост, а намного хуже - вор! Только потому что он мой сын, я не позвал стражу."));
            const_dialogs["npc.Gregg"]["st3"].replies.Add("st4", "[язвительно] Хотите, я позову?");
            const_dialogs["npc.Gregg"]["st3"].replies.Add("st5", "Вор? Это меняет дело");
            const_dialogs["npc.Gregg"]["st3"].replies.Add("end", "Ты меня достал");
            const_dialogs["npc.Gregg"].Add("st4", new _dialoginfo("Гхм.. [смутился] Не стоит, я погорячился и наговорил лишнего."));
            const_dialogs["npc.Gregg"]["st4"].replies.Add("st5", "То-то же, впредь не горячись");
            const_dialogs["npc.Gregg"]["st4"].replies.Add("end", "Ладно, мне пора");
            const_dialogs["npc.Gregg"].Add("st5", new _dialoginfo("Ну, обычная история, парень влюбился, но собственного заработка у него нет, вот и позарился на отцовское ожерелье. [Cтоун: да не брал я его!] Как же, признается он..."));
            const_dialogs["npc.Gregg"]["st5"].replies.Add("st6", "Но он правда не брал!");
            const_dialogs["npc.Gregg"]["st5"].replies.Add("end", "Ремень по твоему сыну плачет, вот что");
            const_dialogs["npc.Gregg"].Add("st6", new _dialoginfo("А ты откуда это можешь знать? Дружок этого ... или может это ты взял?"));
            const_dialogs["npc.Gregg"]["st6"].replies.Add("end", "Может и я, да доказательств у тебя нет");
            const_dialogs["npc.Gregg"]["st6"].replies.Add("st7", "Ну, скажем так, это может быть, например, сын бывшего вора или что-то в этом роде...");
            const_dialogs["npc.Gregg"].Add("st7", new _dialoginfo("Как же, так я и поверил, я знаю в городе только одного человека, способного на это - Сурри, что живет на западе города в заброшенном доме, но чтобы его отпрыск пошел по стопам отца, это вряд ли. Мой вот не пошел ведь, не стал честным человеком!"));
            const_dialogs["npc.Gregg"]["st7"].replies.Add("end", "Яблоко от яблони недалеко падает");
            const_dialogs["npc.Gregg"].Add("end", new _dialoginfo("Проваливай, а? И без тебя забот хватает."));

            const_dialogs.Add("npc.Stoun", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Stoun"].Add("begin", new _dialoginfo("Сейчас не лучшее время для разговоров, видишь в каком состоянии [косится на Грегга] мой отец?"));
            const_dialogs["npc.Stoun"]["begin"].replies.Add("st", "Я знаю, что ты невиновен");
            const_dialogs["npc.Stoun"]["begin"].replies.Add("end", "Ты пошто ожерелье спер, негодяй?");
            const_dialogs["npc.Stoun"].Add("st", new _dialoginfo("Правда? Я тоже это знаю, но доказать ничего не могу. Думаю, ожерелье само найдется или обнаружат вора и все уладится."));
            const_dialogs["npc.Stoun"].Add("end", new _dialoginfo("[задыхаясь от гнева] Да.. Как ты.. [вдруг смолкает, глянув на Грэгга] А, иди ты к черту, вот что. Не твое это дело."));

            const_dialogs.Add("npc.Silvio", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Silvio"].Add("begin", new _dialoginfo("Привет, я Сильвио, продаю и покупаю магические реагенты. Еще я покупаю кости скелетов, если найдешь, принеси мне."));
            const_dialogs["npc.Silvio"]["begin"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Silvio"]["begin"].replies.Add("sell", "Я хочу продавать");
            const_dialogs["npc.Silvio"]["begin"].replies.Add("find", "Где мне достать реагенты?");
            const_dialogs["npc.Silvio"]["begin"].replies.Add("bone", "Кости?");
            const_dialogs["npc.Silvio"]["begin"].replies.Add("end", "Я спешу");
            const_dialogs["npc.Silvio"].Add("find", new _dialoginfo("Поищи в округе, по лесам, на болотах. Может что и на кладбище найдешь. Это твои трудности, если бы это было так легко, я бы сам насобирал."));
            const_dialogs["npc.Silvio"]["find"].replies.Add("begin", "Ясно");
            const_dialogs["npc.Silvio"].Add("bone", new _dialoginfo("Ну да, кости, они используются в некоторых магических ритуалах..."));
            const_dialogs["npc.Silvio"]["bone"].replies.Add("bone2", "Например, в некромантии?");
            const_dialogs["npc.Silvio"]["bone"].replies.Add("begin", "Забудем об этом");
            const_dialogs["npc.Silvio"].Add("bone2", new _dialoginfo("Что ты, какая некромантия, она вообще запрещена законом, я.. ну.. просто... ну..,  в принципе, это тебя не касается, просто если будут кости, то я их у тебя куплю, ок?"));
            const_dialogs["npc.Silvio"]["bone2"].replies.Add("bone3", "Видимо эта причина мешает тебе торговать в городе?");
            const_dialogs["npc.Silvio"]["bone2"].replies.Add("begin", "Забудем об этом");
            const_dialogs["npc.Silvio"].Add("bone3", new _dialoginfo("Ты на что намекаешь? Я ведь живу в городе, значит я не преступник, так ведь? Слушай, в конце концов, разве кто-то еще у тебя хочет купить кости? Нет, только я, так что давай если хочешь продавай, иначе не трать мое время. А если ты от этих..этих..бумагомарателей из Академии, то можешь им передать, что ничего они от меня не получат. Я чист, ясно тебе?"));
            const_dialogs["npc.Silvio"]["bone3"].replies.Add("end2", "Хм... Дело твое. Каждый имеет право быть придурком.");
            const_dialogs["npc.Silvio"]["bone3"].replies.Add("end", "Хм... Дело твое. Каждый имеет право на тайну.");
            const_dialogs["npc.Silvio"].Add("end2", new _dialoginfo("Пошел ты к черту!"));
            const_dialogs["npc.Silvio"].Add("end", new _dialoginfo("Тогда пока"));

            const_dialogs.Add("npc.Franchesko", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Franchesko"].Add("begin", new _dialoginfo("Здавствуй, <name>. Академия приветствует тебя!"));
            const_dialogs["npc.Franchesko"]["begin"].replies.Add("who", "Ты глава Академии?");
            const_dialogs["npc.Franchesko"]["begin"].replies.Add("shop", "Я хочу пополнить припасы");
            const_dialogs["npc.Franchesko"]["begin"].replies.Add("who2", "Что тут интересного?");
            const_dialogs["npc.Franchesko"]["begin"].replies.Add("end", "Извини, я спешу");
            const_dialogs["npc.Franchesko"].Add("who", new _dialoginfo("[смеется] Что ты, я даже не прошел Круг Посвящения, просто в мои обязанности входит встречать гостей и рассказывать им об Академии."));
            const_dialogs["npc.Franchesko"]["who"].replies.Add("who2", "Ну раз так, расскажи и мне");
            const_dialogs["npc.Franchesko"]["who"].replies.Add("begin", "Хм, я и так достаточно знаю");
            const_dialogs["npc.Franchesko"].Add("who2", new _dialoginfo("Академия - это сосредоточие всех наук, здесь обучаются магии и хранятся знания поколений. Вон там библиотека, где ты можешь узнать историю города, рядом дверь в зал монстрологии, Серпент расскажет тебе об удивительных созданиях, направо наш волшебный магазин, а на втором этаже аколиты тренируются в магии под руководством Антонио и Мильтона."));
            const_dialogs["npc.Franchesko"]["who2"].replies.Add("end", "Молодец, ставлю пять за экскурсию");
            const_dialogs["npc.Franchesko"].Add("shop", new _dialoginfo("Тогда сразу иди в волшебный магазин, первая дверь направо. Только в Академии такой широкий выбор товаров. Цены пусть тебя не смущают, здесь только первосортный товар, проверенный и надежный."));
            const_dialogs["npc.Franchesko"]["shop"].replies.Add("end", "Спасибо, ты очень добр");
            const_dialogs["npc.Franchesko"].Add("end", new _dialoginfo("[смущенно] До свидания, желаю успехов"));

            const_dialogs.Add("npc.Djoshua", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Djoshua"].Add("begin", new _dialoginfo("Добро пожаловать! Мы продаем и покупаем магические товары, если хочешь что-то продать, передай мне предмет и я назову его цену."));
            const_dialogs["npc.Djoshua"]["begin"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Djoshua"]["begin"].replies.Add("sell", "Я хочу кое-что продать");
            const_dialogs["npc.Djoshua"]["begin"].replies.Add("end", "Мне пора");
            const_dialogs["npc.Djoshua"].Add("end", new _dialoginfo("Двери магазина Академии всегда открыты"));

            const_dialogs.Add("npc.Klavdius", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Klavdius"].Add("begin", new _dialoginfo("Приветствую тебя в этих мудрых стенах библиотеки, мой юный друг! Ты хотел бы что-то узнать о нашем городе?"));
            const_dialogs["npc.Klavdius"]["begin"].replies.Add("tell", "Расскажи об этом городе");
            const_dialogs["npc.Klavdius"]["begin"].replies.Add("end", "Нет. В самом деле нет. Не хочу. Совершенно.");
            const_dialogs["npc.Klavdius"].Add("tell", new _dialoginfo("Город был основан триста лет назад северянами, в те годы у них на родине прошли небывалые морозы. Не только люди, даже звери бежали! А после морозов пришла другая беда: разупокаивались кладбища, мертвяки поперли на, в общем-то незащищенные города, т.к. в тех безлюдных местах не с кем было особо воевать и жили преимущественно охотники да животноводы. Именно способности к охоте и спасли их, многие смогли подняться и уйти, после чего ообосноваться здесь."));
            const_dialogs["npc.Klavdius"]["tell"].replies.Add("tell2", "Что было дальше?");
            const_dialogs["npc.Klavdius"]["tell"].replies.Add("end", "Это слишком длинная история для меня");
            const_dialogs["npc.Klavdius"].Add("tell2", new _dialoginfo("Тогда здесь были сплошные леса, и город, само собой, вырос у реки. Это уже потом приходили другие народы, кровь смешалась и сейчас кто только не живет в городе. Да и вокруг уже не непролазные чащобы, все дальше и дальше осваивается лес, строятся дома, прокладываются дороги. Хочешь об этом месте?"));
            const_dialogs["npc.Klavdius"]["tell2"].replies.Add("tell3", "Да, хочу");
            const_dialogs["npc.Klavdius"]["tell2"].replies.Add("end", "Нет, с меня хватит, спасибо");
            const_dialogs["npc.Klavdius"].Add("tell3", new _dialoginfo("С юга город омывается рекой, на востоке лес простирается вплоть до самих Скалистых гор, на севере тоже леса, правда подвластныя нечисти: разным духам и призракам, на западе Столетний лес, там много всякого зверья и сплошная глушь, ничего интересноего. А вот на северо-востоке расположено беспокойное старое кладбище, туда идет весь рискованный народ, им подавай настоящий смертельный бой, славу да почет. Городу это, конечно, на руку - все да меньше будет мертвечины разгуливать."));
            const_dialogs["npc.Klavdius"]["tell3"].replies.Add("tell4", "Откуда взялись мертвяки?");
            const_dialogs["npc.Klavdius"]["tell3"].replies.Add("end", "Я все понял");
            const_dialogs["npc.Klavdius"].Add("tell4", new _dialoginfo("С юга город омывается рекой, на востоке лес простирается вплоть до самих Скалистых гор, на севере тоже леса, правда подвластныя нечисти: разным духам и призракам, на западе Столетний лес, там много всякого зверья и сплошная глушь, ничего интересноего. А вот на северо-востоке расположено беспокойное старое кладбище, туда идет весь рискованный народ, им подавай настоящий смертельный бой, славу да почет. Городу это, конечно, на руку - все да меньше будет мертвечины разгуливать."));
            const_dialogs["npc.Klavdius"]["tell4"].replies.Add("tell5", "Откуда берутся мертвяки?");
            const_dialogs["npc.Klavdius"]["tell4"].replies.Add("end", "Я все понял");
            const_dialogs["npc.Klavdius"].Add("tell5", new _dialoginfo("Никто не знает, может быть в одном из склепов есть тайный вход в подземелья, а может ветер магии иногда меняет течение и будоражит тех, у кого в костях еще осталлась капелька жизни. В последние годы вообще много странного происходит..."));
            const_dialogs["npc.Klavdius"]["tell5"].replies.Add("tell6", "Что именно?");
            const_dialogs["npc.Klavdius"]["tell5"].replies.Add("end", "Ясно");
            const_dialogs["npc.Klavdius"].Add("tell6", new _dialoginfo("[испытующе смотрит на вас, потом качает головой, видимо приняв какое-то решение] Нет, не время еще тебе об этом знать, извини. Может как-нибудь в другой раз расскажу..."));
            const_dialogs["npc.Klavdius"]["tell6"].replies.Add("end", "Больно нужны мне твои тайны, прощай");
            const_dialogs["npc.Klavdius"].Add("end", new _dialoginfo("Ну что ж, приходи еще как-нибудь"));

            const_dialogs.Add("npc.Antonio", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Antonio"].Add("begin", new _dialoginfo("Здравствуй, <name>, хочешь узнать больше о магии?"));
            const_dialogs["npc.Antonio"]["begin"].replies.Add("mag", "Да, расскажи о магии");
            const_dialogs["npc.Antonio"]["begin"].replies.Add("tren", "Ты можешь меня чему-нибудь научить?");
            const_dialogs["npc.Antonio"]["begin"].replies.Add("end", "Нет, пока");
            const_dialogs["npc.Antonio"].Add("mag", new _dialoginfo("Хорошо, главное что тебе надо знать - чем опытней ты как маг, тем легче тебе будут удаваться сложные заклинания. А уж как их кастовать - из книги магии, используя магические реагенты, с одноразовых свитков или из рун, решать тебе."));
            const_dialogs["npc.Antonio"]["mag"].replies.Add("run", "Расскажи о рунах");
            const_dialogs["npc.Antonio"]["mag"].replies.Add("more", "Где я еще могу изучать магию?");
            const_dialogs["npc.Antonio"]["mag"].replies.Add("begin", "Ясно");
            const_dialogs["npc.Antonio"].Add("run", new _dialoginfo("Руны - это такие камни с символами, если ты используешь руну, то записанное на ней заклинание тратит только твою ману, а реагенты не нужны. Это очень удобно, так как мана со временем растет сама. И именно поэтому руны такие дорогие, так как позволяют сколько угодно колдовать, не платя за свитки или реагенты."));
            const_dialogs["npc.Antonio"]["run"].replies.Add("mag", "Ясно");
            const_dialogs["npc.Antonio"].Add("more", new _dialoginfo("О боевой магии тебе расскажет Мильтон, о Вызове животных - Серпент на первом этаже. Кроме того, Лорд Хаген во дворе рыцарей владеет палладинской магией, можешь сходить и туда. Ну и я тоже могу тебя кое-чему научить..."));
            const_dialogs["npc.Antonio"]["more"].replies.Add("tren", "Я хочу учиться");
            const_dialogs["npc.Antonio"]["more"].replies.Add("mag", "Ясно");
            const_dialogs["npc.Antonio"].Add("tren", new _dialoginfo("Выбери, что тебя интересует"));
            const_dialogs["npc.Antonio"]["tren"].replies.Add("int", "Я хочу повысить интеллект");
            const_dialogs["npc.Antonio"]["tren"].replies.Add("med", "Медитация");
            const_dialogs["npc.Antonio"]["tren"].replies.Add("spell", "Я хочу выучить заклинания");
            const_dialogs["npc.Antonio"]["tren"].replies.Add("begin", "Нет, ничего");
            const_dialogs["npc.Antonio"].Add("spell", new _dialoginfo("Я могу научить тебя следующим заклинаниям:"));
            const_dialogs["npc.Antonio"]["spell"].replies.Add("create", "Создать еду");
            const_dialogs["npc.Antonio"]["spell"].replies.Add("heal", "Лечение");
            const_dialogs["npc.Antonio"]["spell"].replies.Add("healgr", "Исцеление");
            const_dialogs["npc.Antonio"]["spell"].replies.Add("res", "Воскрешение");
            const_dialogs["npc.Antonio"]["spell"].replies.Add("mark", "Пометить");
            const_dialogs["npc.Antonio"]["spell"].replies.Add("recall", "Возвращение");
            const_dialogs["npc.Antonio"]["spell"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Antonio"].Add("int", new _dialoginfo("Интеллект очень важен дял мага, так как он определяет твой запас маны. Я помогу развить твой интеллект за 150 монет"));
            const_dialogs["npc.Antonio"]["int"].replies.Add("intnow", "Согласен");
            const_dialogs["npc.Antonio"]["int"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Antonio"].Add("intnow", new _dialoginfo("skill|int|150|0|5"));
            const_dialogs["npc.Antonio"].Add("med", new _dialoginfo("Навык медитации тоже очень важен для мага, он определяет, насколько выстро восстанавливается твоя мана. А кроме того, ты можешь использовать этот навык напрямую, тогда мана восстановится еще быстрее. Но учти, что у тебя должно быть время и никто не должен нарушать твоей концентрации, иначе ничего не получится... Я научу тебя за 300 монет"));
            const_dialogs["npc.Antonio"]["med"].replies.Add("mednow", "Согласен");
            const_dialogs["npc.Antonio"]["med"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Antonio"].Add("mednow", new _dialoginfo("skill|meditation|300|0|5"));
            const_dialogs["npc.Antonio"].Add("create", new _dialoginfo("Это заклинание позволяет создать еду. [улыбается ]Очень удобно, если тебе нужно подкрепиться. Да и не сложное оно, идеально подходит для тренировки. Стоит 100 монет"));
            const_dialogs["npc.Antonio"]["create"].replies.Add("createnow", "Согласен");
            const_dialogs["npc.Antonio"]["create"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Antonio"].Add("createnow", new _dialoginfo("magic|magic.createfood|100"));
            const_dialogs["npc.Antonio"].Add("heal", new _dialoginfo("Немного залечивает раны. Стоит 200 монет"));
            const_dialogs["npc.Antonio"]["heal"].replies.Add("healnow", "Согласен");
            const_dialogs["npc.Antonio"]["heal"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Antonio"].Add("healnow", new _dialoginfo("magic|magic.heal|200"));
            const_dialogs["npc.Antonio"].Add("healgr", new _dialoginfo("Залечивает сильные раны. Сложней, чем простое лечение. Стоит 400 монет"));
            const_dialogs["npc.Antonio"]["healgr"].replies.Add("healgrnow", "Согласен");
            const_dialogs["npc.Antonio"]["healgr"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Antonio"].Add("healgrnow", new _dialoginfo("magic|magic.heal.great|400"));
            const_dialogs["npc.Antonio"].Add("res", new _dialoginfo("Позволяет оживить призрака. Очень сложное заклинание. Стоит 1000 монет"));
            const_dialogs["npc.Antonio"]["res"].replies.Add("resnow", "Согласен");
            const_dialogs["npc.Antonio"]["res"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Antonio"].Add("resnow", new _dialoginfo("magic|magic.ressurect|1000|3"));
            const_dialogs["npc.Antonio"].Add("mark", new _dialoginfo("Позволяет пометить руну перемещения, если потом использовать на нее заклинание Возвращение, то будешь мгновенно перенесен в это место. Стоит 500 монет"));
            const_dialogs["npc.Antonio"]["mark"].replies.Add("marknow", "Согласен");
            const_dialogs["npc.Antonio"]["mark"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Antonio"].Add("marknow", new _dialoginfo("magic|magic.mark|500"));
            const_dialogs["npc.Antonio"].Add("recall", new _dialoginfo("Это заклинание нужно использовать на руну перемещения (неважно, твою или кто ее тебе даст), и ты будешь тут же перенесен в это место! Стоит 500 монет"));
            const_dialogs["npc.Antonio"]["recall"].replies.Add("recallnow", "Согласен");
            const_dialogs["npc.Antonio"]["recall"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Antonio"].Add("recallnow", new _dialoginfo("magic|magic.recall|500"));
            const_dialogs["npc.Antonio"].Add("end", new _dialoginfo("Ступай с миром"));

            const_dialogs.Add("npc.Serpent", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Serpent"].Add("begin", new _dialoginfo("Добро пожаловать в зал монстрологии, уважаемый <name>. Здесь ты можешь узнать о волшебных существах, развить некотоыре свои навыки и выучить новые заклинания."));
            const_dialogs["npc.Serpent"]["begin"].replies.Add("mag", "Что за волшебные животные?");
            const_dialogs["npc.Serpent"]["begin"].replies.Add("tren", "Я хочу пройти обучение");
            const_dialogs["npc.Serpent"]["begin"].replies.Add("end", "Нет, пока");
            const_dialogs["npc.Serpent"].Add("mag", new _dialoginfo("Хм.. На свете много чудес, оглянись вокруг, видишь эти чучела и картины? Это лишь малая толика того, что есть в этом мире. Но тебя наверно интересуют более приземленные вещи, я прав?"));
            const_dialogs["npc.Serpent"]["mag"].replies.Add("run", "Расскажи о призываемых");
            const_dialogs["npc.Serpent"]["mag"].replies.Add("more", "Какие монстры есть в окрестностях?");
            const_dialogs["npc.Serpent"]["mag"].replies.Add("begin", "Рад бы поболтать, но дела не ждут");
            const_dialogs["npc.Serpent"].Add("run", new _dialoginfo("Те животные, которых ты можешь призвать, отличаются от обычных. Их нельзя освежевать после их гибели, они исчезают когда истечет их срок в жтом мире и тому подобное. Хоть их названия как и у зверей или монстров, встречаемых на свободе, характеристики вызываемых могут сильно отличаться."));
            const_dialogs["npc.Serpent"]["run"].replies.Add("mag", "Ясно");
            const_dialogs["npc.Serpent"].Add("more", new _dialoginfo("В окрестных лесах много чего ходит... Обычное зверье на тебя не нападет первым, кроме хищшиков, конечно. А вот если повстречает чудовище или нежить, тут даже и не пробуй договориться. [улыбается ]Ну разве только с помощью магии."));
            const_dialogs["npc.Serpent"]["more"].replies.Add("mag", "Ясно");
            const_dialogs["npc.Serpent"].Add("tren", new _dialoginfo("Выбери, что тебя интересует"));
            const_dialogs["npc.Serpent"]["tren"].replies.Add("spir", "Я хочу узнать о спиритизме");
            const_dialogs["npc.Serpent"]["tren"].replies.Add("spell", "Я хочу выучить заклинания");
            const_dialogs["npc.Serpent"]["tren"].replies.Add("begin", "Нет, ничего");
            const_dialogs["npc.Serpent"].Add("spell", new _dialoginfo("Я могу научить тебя следующим заклинаниям:"));
            const_dialogs["npc.Serpent"]["spell"].replies.Add("wolf", "Призвать Волка");
            const_dialogs["npc.Serpent"]["spell"].replies.Add("skel", "Призвать Скелета");
            const_dialogs["npc.Serpent"]["spell"].replies.Add("gol", "Призвать Голема");
            const_dialogs["npc.Serpent"]["spell"].replies.Add("dem", "Призвать Демона");
            const_dialogs["npc.Serpent"]["spell"].replies.Add("charm", "Зачаровать");
            const_dialogs["npc.Serpent"]["spell"].replies.Add("charme", "Привлечь");
            const_dialogs["npc.Serpent"]["spell"].replies.Add("peace", "Усмирить");
            const_dialogs["npc.Serpent"]["spell"].replies.Add("pall", "Тишина");
            const_dialogs["npc.Serpent"]["spell"].replies.Add("sil", "Безумие");
            const_dialogs["npc.Serpent"]["spell"].replies.Add("tren", "Я передумал");
            const_dialogs["npc.Serpent"].Add("spir", new _dialoginfo("Как ты знаешь, человек после смерти становится призраком. Чтобы он ни сказал, никто его не поймет. Но если развить свой навык спиритизма, то на высшем уровне ты сможешь понять абсолютно любого призрака! Я научу тебя как это делать за 70 монет"));
            const_dialogs["npc.Serpent"]["spir"].replies.Add("spirnow", "Согласен");
            const_dialogs["npc.Serpent"]["spir"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("spirnow", new _dialoginfo("skill|spirit|70|0|5"));
            const_dialogs["npc.Serpent"].Add("wolf", new _dialoginfo("Это заклинание стоит 200 монет"));
            const_dialogs["npc.Serpent"]["wolf"].replies.Add("wolfnow", "Согласен");
            const_dialogs["npc.Serpent"]["wolf"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("wolfnow", new _dialoginfo("magic|magic.summon.wolf|200"));
            const_dialogs["npc.Serpent"].Add("skel", new _dialoginfo("Это заклинание стоит 300 монет"));
            const_dialogs["npc.Serpent"]["skel"].replies.Add("skelnow", "Согласен");
            const_dialogs["npc.Serpent"]["skel"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("skelnow", new _dialoginfo("magic|magic.summon.skeleton|300"));
            const_dialogs["npc.Serpent"].Add("gol", new _dialoginfo("Это заклинание стоит 400 монет"));
            const_dialogs["npc.Serpent"]["gol"].replies.Add("golnow", "Согласен");
            const_dialogs["npc.Serpent"]["gol"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("golnow", new _dialoginfo("magic|magic.summon.golem|400"));
            const_dialogs["npc.Serpent"].Add("dem", new _dialoginfo("Это заклинание стоит 500 монет. Если призовешь демона в городе, на тебя набросится стража."));
            const_dialogs["npc.Serpent"]["dem"].replies.Add("demnow", "Согласен");
            const_dialogs["npc.Serpent"]["dem"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("demnow", new _dialoginfo("magic|magic.summon.demon|500"));
            const_dialogs["npc.Serpent"].Add("charm", new _dialoginfo("Позволяет зачаровать ненадолго животное, оно будет повсюду следовать за вами. Стоит 300 монет"));
            const_dialogs["npc.Serpent"]["charm"].replies.Add("charmnow", "Согласен");
            const_dialogs["npc.Serpent"]["charm"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("charmnow", new _dialoginfo("magic|magic.charm|300"));
            const_dialogs["npc.Serpent"].Add("charme", new _dialoginfo("Позволяет привлечь на свою сторону одного врага. Стоит 400 монет"));
            const_dialogs["npc.Serpent"]["charme"].replies.Add("charmenow", "Согласен");
            const_dialogs["npc.Serpent"]["charme"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("charmenow", new _dialoginfo("magic|magic.charm.enemy|400"));
            const_dialogs["npc.Serpent"].Add("peace", new _dialoginfo("Один враг на время забывает о тебе. Стоит 300 монет"));
            const_dialogs["npc.Serpent"]["peace"].replies.Add("peacenow", "Согласен");
            const_dialogs["npc.Serpent"]["peace"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("peacenow", new _dialoginfo("magic|magic.peace|300"));
            const_dialogs["npc.Serpent"].Add("pall", new _dialoginfo("На время успокаиваются все враждующие стороны. Стоит 500 монет"));
            const_dialogs["npc.Serpent"]["pall"].replies.Add("pallnow", "Согласен");
            const_dialogs["npc.Serpent"]["pall"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("pallnow", new _dialoginfo("magic|magic.silence|500"));
            const_dialogs["npc.Serpent"].Add("mad", new _dialoginfo("Кто-то из присутствующих впадает в безумие и набрасывается на другого, неважно, зверь то или человек. Стоит 1000 монет"));
            const_dialogs["npc.Serpent"]["mad"].replies.Add("madnow", "Согласен");
            const_dialogs["npc.Serpent"]["mad"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Serpent"].Add("madnow", new _dialoginfo("magic|magic.maddnes|1000"));
            const_dialogs["npc.Serpent"].Add("end", new _dialoginfo("Ступай с миром"));

            const_dialogs.Add("npc.Milton", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Milton"].Add("begin", new _dialoginfo("Рад тебя видеть, <name>. Хочешь развить свою магию или выучить новые боевые заклинания?"));
            const_dialogs["npc.Milton"]["begin"].replies.Add("tren", "Я хочу развить навыки");
            const_dialogs["npc.Milton"]["begin"].replies.Add("spell", "Я хочу выучить заклинания");
            const_dialogs["npc.Milton"]["begin"].replies.Add("end", "Нет, пока");
            const_dialogs["npc.Milton"].Add("tren", new _dialoginfo("Хорошо, вот магические навыки, которым я могу тебя обучить:"));
            const_dialogs["npc.Milton"]["tren"].replies.Add("mag", "Магия");
            const_dialogs["npc.Milton"]["tren"].replies.Add("ukl", "Уклонение от магии");
            const_dialogs["npc.Milton"]["tren"].replies.Add("resist", "Сопротивление магии");
            const_dialogs["npc.Milton"]["tren"].replies.Add("spell", "Я лучше изучу заклинания");
            const_dialogs["npc.Milton"]["tren"].replies.Add("end", "Спасибо, мне пора");
            const_dialogs["npc.Milton"].Add("mag", new _dialoginfo("Навык магии определяет вероятность успешного заклинания. Кроме того, от навыка магии зависит, какой сложности заклинания доступны магу. Так, с низким уровнем, маг вообще не сможет использовать сложные заклинания. По сути, этот навык и интеллект - главные параметры мага. Я научу тебя за 200 монет."));
            const_dialogs["npc.Milton"]["mag"].replies.Add("magnow", "Согласен");
            const_dialogs["npc.Milton"]["mag"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("magnow", new _dialoginfo("skill|magic|200|0|5"));
            const_dialogs["npc.Milton"].Add("ukl", new _dialoginfo("В случае успеха маг может вообще избежать урона от магической атаки. И хоть это бывает редко, но стоит 200 монет, как думаешь?"));
            const_dialogs["npc.Milton"]["ukl"].replies.Add("uklnow", "Верно");
            const_dialogs["npc.Milton"]["ukl"].replies.Add("tren", "Я так не думаю");
            const_dialogs["npc.Milton"].Add("uklnow", new _dialoginfo("skill|magic_uklon|200|0|5"));
            const_dialogs["npc.Milton"].Add("resist", new _dialoginfo("Сопротивление магии не так эффективно, как уклонение, но зато получается гораздо чаще. В случае успеха урон от магической атаки уменьшается. Стоимость обучени 200 монет."));
            const_dialogs["npc.Milton"]["resist"].replies.Add("resistnow", "Хорошо");
            const_dialogs["npc.Milton"]["resist"].replies.Add("tren", "Нет, не пойдет");
            const_dialogs["npc.Milton"].Add("resistnow", new _dialoginfo("skill|magic_resist|200|0|5"));
            const_dialogs["npc.Milton"].Add("spell", new _dialoginfo("Выбери, какое заклинание тебя интересует"));
            const_dialogs["npc.Milton"]["spell"].replies.Add("mar", "Магическая стрела");
            const_dialogs["npc.Milton"]["spell"].replies.Add("far", "Огненная стрела");
            const_dialogs["npc.Milton"]["spell"].replies.Add("lk", "Ледяной кулак");
            const_dialogs["npc.Milton"]["spell"].replies.Add("fb", "Огненный столб");
            const_dialogs["npc.Milton"]["spell"].replies.Add("ll", "Ледяной луч");
            const_dialogs["npc.Milton"]["spell"].replies.Add("fs", "Струя пламени");
            const_dialogs["npc.Milton"]["spell"].replies.Add("li", "Молния");
            const_dialogs["npc.Milton"]["spell"].replies.Add("lv", "Водяной вал");
            const_dialogs["npc.Milton"]["spell"].replies.Add("zt", "Землетрясение");
            const_dialogs["npc.Milton"]["spell"].replies.Add("tren", "Что насчет навыков?");
            const_dialogs["npc.Milton"]["spell"].replies.Add("end", "Спасибо, мне пора");
            const_dialogs["npc.Milton"].Add("mar", new _dialoginfo("Самое слабое боевое заклинание. Стоит 50 монет"));
            const_dialogs["npc.Milton"]["mar"].replies.Add("marnow", "Согласен");
            const_dialogs["npc.Milton"]["mar"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("marnow", new _dialoginfo("magic|magic.war.arrow|50"));
            const_dialogs["npc.Milton"].Add("far", new _dialoginfo("Стоит 100 монет"));
            const_dialogs["npc.Milton"]["far"].replies.Add("farnow", "Согласен");
            const_dialogs["npc.Milton"]["far"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("farnow", new _dialoginfo("magic|magic.war.firearrow|100"));
            const_dialogs["npc.Milton"].Add("lk", new _dialoginfo("Это заклинание может причить уже существенный урон. Стоит 150 монет"));
            const_dialogs["npc.Milton"]["lk"].replies.Add("lknow", "Согласен");
            const_dialogs["npc.Milton"]["lk"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("lknow", new _dialoginfo("magic|magic.war.icefirst|150"));
            const_dialogs["npc.Milton"].Add("fb", new _dialoginfo("Среднее боевое заклинание. Стоит 250 монет"));
            const_dialogs["npc.Milton"]["fb"].replies.Add("fbnow", "Согласен");
            const_dialogs["npc.Milton"]["fb"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("fbnow", new _dialoginfo("magic|magic.war.firebolt|200"));
            const_dialogs["npc.Milton"].Add("ll", new _dialoginfo("Одно из самых мощных боевых заклинаний. Стоит 350 монет"));
            const_dialogs["npc.Milton"]["ll"].replies.Add("llnow", "Согласен");
            const_dialogs["npc.Milton"]["ll"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("llnow", new _dialoginfo("magic|magic.war.iceray|350"));
            const_dialogs["npc.Milton"].Add("fs", new _dialoginfo("Лучшее из боевых заклинания на одну цель. Стоит 500 монет"));
            const_dialogs["npc.Milton"]["fs"].replies.Add("fsnow", "Согласен");
            const_dialogs["npc.Milton"]["fs"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("fsnow", new _dialoginfo("magic|magic.war.firestreem|500"));
            const_dialogs["npc.Milton"].Add("lv", new _dialoginfo("Ледяной вал наносит урон всем, кроме кастующего. Стоит 400 монет"));
            const_dialogs["npc.Milton"]["lv"].replies.Add("lvnow", "Согласен");
            const_dialogs["npc.Milton"]["lv"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("lvnow", new _dialoginfo("magic|magic.all.watergross|400"));
            const_dialogs["npc.Milton"].Add("li", new _dialoginfo("Молния может как не нанести урон, так и сжечь на месте. Стоит 300 монет"));
            const_dialogs["npc.Milton"]["li"].replies.Add("linow", "Согласен");
            const_dialogs["npc.Milton"]["li"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("linow", new _dialoginfo("magic|magic.war.lighting|300"));
            const_dialogs["npc.Milton"].Add("zt", new _dialoginfo("Наносит большой урон всем, включая кастующего. Стоит 700 монет"));
            const_dialogs["npc.Milton"]["zt"].replies.Add("ztnow", "Согласен");
            const_dialogs["npc.Milton"]["zt"].replies.Add("tren", "Не надо");
            const_dialogs["npc.Milton"].Add("ztnow", new _dialoginfo("magic|magic.all.earthquake|700"));
            const_dialogs["npc.Milton"].Add("end", new _dialoginfo("Ступай с миром"));

            const_dialogs.Add("npc.Raks", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Raks"].Add("begin", new _dialoginfo("Что тебе надо?"));
            const_dialogs["npc.Raks"]["begin"].replies.Add("tren", "Я тоже хочу стать сильным, как ты!");
            const_dialogs["npc.Raks"]["begin"].replies.Add("ask", "Ты чем-нибудь торгуешь?");
            const_dialogs["npc.Raks"]["begin"].replies.Add("end", "Ничего, до встречи!");
            const_dialogs["npc.Raks"].Add("ask", new _dialoginfo("Я что, похож на торговца? Я делаю оружие и броню, а продают другие. Видишь вход на севере? Там бронник Силт, продает отличную броню, а на юге вход в магазин оружейника Планта."));
            const_dialogs["npc.Raks"]["ask"].replies.Add("end", "Ясно, бывай");
            const_dialogs["npc.Raks"].Add("tren", new _dialoginfo("Ха! Потягай с мое, станешь не хуже. Впрочем, за две сотни монет я тебе покажу пару трюков, как прокачать мышцы."));
            const_dialogs["npc.Raks"]["tren"].replies.Add("trennow", "Согласен, вот деньги");
            const_dialogs["npc.Raks"]["tren"].replies.Add("end", "Дорого берешь, мастер, в другой раз");
            const_dialogs["npc.Raks"].Add("trennow", new _dialoginfo("skill|str|200|0|5"));
            const_dialogs["npc.Raks"].Add("end", new _dialoginfo("Ну и ты бывай!"));

            const_dialogs.Add("npc.Silt", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Silt"].Add("begin", new _dialoginfo("Проходи, <name>, выбирай что нравится. У меня лучшая бронь во всем городе. Впрочем, я не только продаю, но и покупаю броню"));
            const_dialogs["npc.Silt"]["begin"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Silt"]["begin"].replies.Add("sell", "Я хочу продать");
            const_dialogs["npc.Silt"]["begin"].replies.Add("end", "Хм.. мне не нужна броня");
            const_dialogs["npc.Silt"].Add("end", new _dialoginfo("Понадобится надежная броня, приходи"));

            const_dialogs.Add("npc.Plant", new Dictionary<string, _dialoginfo>());
            const_dialogs["npc.Plant"].Add("begin", new _dialoginfo("Добро пожаловать, <name>. У меня все виды оружия, лучший выбор! А если хочешь что-нибудь продать, передай мне предмет, о цене сговоримся!"));
            const_dialogs["npc.Plant"]["begin"].replies.Add("tren", "Ты можешь меня научить сражаться?");
            const_dialogs["npc.Plant"]["begin"].replies.Add("buy", "Покажи свои товары");
            const_dialogs["npc.Plant"]["begin"].replies.Add("sell", "Я хочу продать оружие");
            const_dialogs["npc.Plant"]["begin"].replies.Add("end", "Зайду в другой раз");
            const_dialogs["npc.Plant"].Add("tren", new _dialoginfo("Если хочешь, научу владеть мечом. Не так здорово, как учат во дворе рыцарей, но и так уж никудышно, как у этих охотников [улыбается]. Это будет стоить тебе 180 монет."));
            const_dialogs["npc.Plant"]["tren"].replies.Add("trennow", "Согласен, вот деньги");
            const_dialogs["npc.Plant"]["tren"].replies.Add("end", "Я подумаю...");
            const_dialogs["npc.Plant"].Add("trennow", new _dialoginfo("skill|coldweapon|180|0|4"));
            const_dialogs["npc.Plant"].Add("end", new _dialoginfo("Пока, заглядывай почаще"));
        }

        private void create_const_magic()
        {
            const_magics.Add("magic.war.arrow", new _magic("magic.war.arrow", "Магическая стрела", 5, 1, "In Ost", 4, 10, true, false, 2));
            const_magics["magic.war.arrow"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.war.arrow"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics.Add("magic.war.holyarrow", new _magic("magic.war.holyarrow", "Святая стрела", 3, 1, "Blast Kosta Nor", 5, 8, true, true, 2));
            const_magics["magic.war.holyarrow"].need.Add(new __magicneeds("item.magic.wormwood", 2, "полынь"));
            const_magics.Add("magic.war.firearrow", new _magic("magic.war.firearrow", "Огненная стрела", 8, 2, "Sist Ar", 7, 12, true, false, 2));
            const_magics["magic.war.firearrow"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.war.firearrow"].need.Add(new __magicneeds("item.magic.sulphur", 1, "сера"));
            const_magics["magic.war.firearrow"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics.Add("magic.war.icefirst", new _magic("magic.war.icefirst", "Ледяной кулак", 10, 2, "Mar Irn Las", 10, 15, true, false, 3));
            const_magics["magic.war.icefirst"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.war.icefirst"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics["magic.war.icefirst"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics.Add("magic.war.firebolt", new _magic("magic.war.firebolt", "Огненный столб", 13, 3, "Ort Fa Las", 12, 16, true, false, 4));
            const_magics["magic.war.firebolt"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.war.firebolt"].need.Add(new __magicneeds("item.magic.sulphur", 1, "сера"));
            const_magics["magic.war.firebolt"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics.Add("magic.war.iceray", new _magic("magic.war.iceray", "Ледяной луч", 18, 4, "Mista Blast", 16, 25, true, false, 4));
            const_magics["magic.war.iceray"].need.Add(new __magicneeds("item.magic.pearl", 1, "жемчуг"));
            const_magics["magic.war.iceray"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics["magic.war.iceray"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics.Add("magic.war.firestreem", new _magic("magic.war.firestreem", "Струя пламени", 22, 4, "Farta Luz Senn", 22, 32, true, false, 5));
            const_magics["magic.war.firestreem"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.war.firestreem"].need.Add(new __magicneeds("item.magic.sulphur", 1, "сера"));
            const_magics.Add("magic.war.lighting", new _magic("magic.war.lighting", "Молния", 11, 3, "Las Ka Sant", 1, 28, true, false, 3));
            const_magics["magic.war.lighting"].need.Add(new __magicneeds("item.magic.pearl", 1, "жемчуг"));
            const_magics["magic.war.lighting"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.war.lighting"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics.Add("magic.all.watergross", new _magic("magic.all.watergross", "Водяной вал", 24, 4, "Vlinta Suento Borta", 8, 22, false, false, 5));
            const_magics["magic.all.watergross"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.all.watergross"].need.Add(new __magicneeds("item.magic.moss", 2, "мох"));
            const_magics.Add("magic.all.godanger", new _magic("magic.all.godanger", "Гнев богов", 18, 5, "Kal Rans Bet", 16, 26, false, false, 6));
            const_magics["magic.all.godanger"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.all.godanger"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics["magic.all.godanger"].need.Add(new __magicneeds("item.magic.sulphur", 1, "сера"));
            const_magics.Add("magic.all.earthquake", new _magic("magic.all.earthquake", "Землетрясение", 32, 5, "Swar Di Otr", 18, 28, false, false, 6));
            const_magics["magic.all.earthquake"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.all.earthquake"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics["magic.all.earthquake"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics["magic.all.earthquake"].need.Add(new __magicneeds("item.magic.sulphur", 1, "сера"));
            const_magics.Add("magic.createfood", new _magic("magic.createfood", "Создать еду", 12, 1, "Manm Kris", 0, 0, false, false, 2));
            const_magics["magic.createfood"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.createfood"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics.Add("magic.charm", new _magic("magic.charm", "Зачаровать", 8, 2, "Silwa Ruun", 0, 0, true, false, 3));
            const_magics["magic.charm"].need.Add(new __magicneeds("item.magic.pearl", 1, "жемчуг"));
            const_magics["magic.charm"].need.Add(new __magicneeds("item.magic.silk", 2, "паутина"));
            const_magics.Add("magic.charmenemy", new _magic("magic.charmenemy", "Привлечь", 18, 3, "Diswal Ruun", 0, 0, true, false, 4));
            const_magics["magic.charmenemy"].need.Add(new __magicneeds("item.magic.silk", 2, "паутина"));
            const_magics["magic.charmenemy"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics.Add("magic.peace", new _magic("magic.peace", "Усмирить", 14, 2, "Sunwa Marr", 0, 0, true, false, 3));
            const_magics["magic.peace"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.peace"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.peace"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics.Add("magic.silence", new _magic("magic.silence", "Тишина", 22, 4, "Maer Dis Wu An", 0, 0, false, false, 5));
            const_magics["magic.silence"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.silence"].need.Add(new __magicneeds("item.magic.moss", 2, "мох"));
            const_magics.Add("magic.maddnes", new _magic("magic.maddnes", "Безумие", 28, 5, "Baar Ganta Kar", 0, 0, false, false, 5));
            const_magics["magic.maddnes"].need.Add(new __magicneeds("item.magic.sulphur", 2, "сера"));
            const_magics["magic.maddnes"].need.Add(new __magicneeds("item.magic.moss", 2, "мох"));
            const_magics["magic.maddnes"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics.Add("magic.summon.wolf", new _magic("magic.summon.wolf", "Призвать волка", 10, 1, "Suent Via", 0, 0, false, false, 3));
            const_magics["magic.summon.wolf"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.summon.wolf"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics["magic.summon.wolf"].need.Add(new __magicneeds("item.magic.pearl", 1, "жемчуг"));
            const_magics["magic.summon.wolf"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics.Add("magic.summon.skeleton", new _magic("magic.summon.skeleton", "Призвать скелета", 12, 1, "Suent Mart", 0, 0, false, false, 3));
            const_magics["magic.summon.skeleton"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.summon.skeleton"].need.Add(new __magicneeds("item.magic.moss", 2, "мох"));
            const_magics["magic.summon.skeleton"].need.Add(new __magicneeds("item.magic.pearl", 1, "жемчуг"));
            const_magics.Add("magic.summon.golem", new _magic("magic.summon.golem", "Призвать голема", 14, 2, "Suent Dal Wan", 0, 0, false, false, 4));
            const_magics["magic.summon.golem"].need.Add(new __magicneeds("item.magic.pearl", 1, "жемчуг"));
            const_magics["magic.summon.golem"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics["magic.summon.golem"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.summon.golem"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics.Add("magic.summon.demon", new _magic("magic.summon.demon", "Призвать демона", 16, 3, "Suelt Kas Valla", 0, 0, false, false, 4));
            const_magics["magic.summon.demon"].need.Add(new __magicneeds("item.magic.pearl", 1, "жемчуг"));
            const_magics["magic.summon.demon"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics["magic.summon.demon"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.summon.demon"].need.Add(new __magicneeds("item.magic.sulphur", 2, "сера"));
            const_magics.Add("magic.heal", new _magic("magic.heal", "Лечение", 8, 1, "Suelt Kas Valla", 6, 16, true, false, 2));
            const_magics["magic.heal"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics["magic.heal"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics.Add("magic.heal.great", new _magic("magic.heal.great", "Исцеление", 12, 3, "Suelt Kas Valla", 12, 24, true, false, 3));
            const_magics["magic.heal.great"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics["magic.heal.great"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics["magic.heal.great"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics.Add("magic.ressurect", new _magic("magic.ressurect", "Воскрешение", 22, 6, "Suelt Kas Valla", 0, 0, true, false, 5));
            const_magics["magic.ressurect"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.ressurect"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics["magic.ressurect"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.ressurect"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
            const_magics["magic.ressurect"].need.Add(new __magicneeds("item.magic.sulphur", 1, "сера"));
            const_magics["magic.ressurect"].need.Add(new __magicneeds("item.magic.pearl", 1, "жемчуг"));
            const_magics.Add("magic.mark", new _magic("magic.mark", "Пометить", 16, 3, "Ir Sin Mar", 0, 0, true, false, 4));
            const_magics["magic.mark"].need.Add(new __magicneeds("item.magic.pearl", 1, "жемчуг"));
            const_magics["magic.mark"].need.Add(new __magicneeds("item.magic.moss", 1, "мох"));
            const_magics["magic.mark"].need.Add(new __magicneeds("item.magic.sulphur", 1, "сера"));
            const_magics.Add("magic.recall", new _magic("magic.recall", "Возвращение", 6, 1, "Ir As", 0, 0, true, false, 2));
            const_magics["magic.recall"].need.Add(new __magicneeds("item.magic.coal", 1, "уголь"));
            const_magics["magic.recall"].need.Add(new __magicneeds("item.magic.silk", 1, "паутина"));
            const_magics["magic.recall"].need.Add(new __magicneeds("item.magic.wormwood", 1, "полынь"));
        }

        private void create_const_items()
        {
            // item.*
            const_items.Add("item.misc.money", new _item("item.misc.money", "монеты", 1, 1));
            const_items.Add("item.misc.arrow", new _item("item.misc.arrow", "стрелы", 1, 1));
            const_items.Add("item.misc.bolt", new _item("item.misc.bolt", "болты", 1, 1));
            const_items.Add("item.hunter.bone", new _item("item.hunter.bone", "кость", 1, 5));
            const_items.Add("item.hunter.skin", new _item("item.hunter.skin", "шкура", 1, 5));
            const_items.Add("item.hunter.skin.wolf", new _item("item.hunter.skin.wolf", "шкура волка", 1, 10));
            const_items.Add("item.hunter.skin.deer", new _item("item.hunter.skin.deer", "шкура оленя", 1, 7));
            const_items.Add("item.hunter.skin.sheep", new _item("item.hunter.skin.sheep", "шкура овцы", 1, 6));
            const_items.Add("item.hunter.skin.troll", new _item("item.hunter.skin.troll", "шкура тролля", 1, 70));
            const_items.Add("item.hunter.skin.ogr", new _item("item.hunter.skin.ogr", "шкура огра", 1, 50));
            const_items.Add("item.hunter.feather", new _item("item.hunter.feather", "перо", 1, 2));
            const_items.Add("item.hunter.horn", new _item("item.hunter.horn", "рога", 1, 10));
            const_items.Add("item.hunter.kop", new _item("item.hunter.kop", "копыта", 1, 8));
            const_items.Add("item.hunter.claw", new _item("item.hunter.claw", "когти", 1, 5));
            const_items.Add("item.hunter.teeths", new _item("item.hunter.teeths", "клыки", 1, 8));
            const_items.Add("item.crystal.adamant", new _item("item.crystal.adamant", "алмаз", 1, 300));
            const_items.Add("item.crystal.emerald", new _item("item.crystal.emerald", "изумруд", 1, 200));
            const_items.Add("item.crystal.ruby", new _item("item.crystal.ruby", "рубин", 1, 150));
            const_items.Add("item.crystal.amber", new _item("item.crystal.amber", "янтарь", 1, 100));
            const_items.Add("item.ring.gold", new _item("item.ring.gold", "золотое кольцо", 1, 70));
            const_items.Add("item.ring.silver", new _item("item.ring.silver", "серебрянное кольцо", 1, 50));
            const_items.Add("item.ring.bronze", new _item("item.ring.bronze", "бронзовое кольцо", 1, 30));
            const_items.Add("item.ressurect", new _item("item.ressurect", "камень воскрешения", 1, 0));
            const_items.Add("item.scroll.war.arrow", new _item("item.scroll.war.arrow", "свиток Магическая стрела", 1, 30));
            const_items.Add("item.scroll.war.holyarrow", new _item("item.scroll.war.holyarrow", "свиток Святая стрела", 1, 45));
            const_items.Add("item.scroll.war.firearrow", new _item("item.scroll.war.firearrow", "свиток Огненная стрела", 1, 0));
            const_items.Add("item.scroll.war.icefirst", new _item("item.scroll.war.icefirst", "свиток Ледяной кулак", 1, 50));
            const_items.Add("item.scroll.war.firebolt", new _item("item.scroll.war.firebolt", "свиток Огненный столб", 1, 55));
            const_items.Add("item.scroll.war.iceray", new _item("item.scroll.war.iceray", "свиток Ледяной луч", 1, 60));
            const_items.Add("item.scroll.war.firestreem", new _item("item.scroll.war.firestreem", "свиток Струя пламени", 1, 70));
            const_items.Add("item.scroll.war.lighting", new _item("item.scroll.war.lighting", "свиток Молния", 1, 35));
            const_items.Add("item.scroll.all.watergross", new _item("item.scroll.all.watergross", "свиток Водяной вал", 1, 60));
            const_items.Add("item.scroll.all.godanger", new _item("item.scroll.all.godanger", "свиток Гнев богов", 1, 80));
            const_items.Add("item.scroll.all.earthquake", new _item("item.scroll.all.earthquake", "свиток Землетрясение", 1, 80));
            const_items.Add("item.scroll.createfood", new _item("item.scroll.createfood", "свиток Создать еду", 1, 20));
            const_items.Add("item.scroll.charm", new _item("item.scroll.charm", "свиток Зачаровать", 1, 45));
            const_items.Add("item.scroll.charmenemy", new _item("item.scroll.charmenemy", "свиток Привлечь", 1, 70));
            const_items.Add("item.scroll.peace", new _item("item.scroll.peace", "свиток Усмирить", 1, 60));
            const_items.Add("item.scroll.silence", new _item("item.scroll.silence", "свиток Тишина", 1, 100));
            const_items.Add("item.scroll.maddnes", new _item("item.scroll.maddnes", "свиток Безумие", 1, 150));
            const_items.Add("item.scroll.summon.wolf", new _item("item.scroll.summon.wolf", "свиток Призвать волка", 1, 45));
            const_items.Add("item.scroll.summon.skeleton", new _item("item.scroll.summon.skeleton", "свиток Призвать скелета", 1, 55));
            const_items.Add("item.scroll.summon.golem", new _item("item.scroll.summon.golem", "свиток Призвать голема", 1, 60));
            const_items.Add("item.scroll.summon.demon", new _item("item.scroll.summon.demon", "свиток Призвать демона", 1, 80));
            const_items.Add("item.scroll.heal", new _item("item.scroll.heal", "свиток Лечение", 1, 20));
            const_items.Add("item.scroll.heal.great", new _item("item.scroll.heal.great", "свиток Исцеление", 1, 40));
            const_items.Add("item.scroll.ressurect", new _item("item.scroll.ressurect", "свиток Воскрешение", 1, 200));
            const_items.Add("item.scroll.mark", new _item("item.scroll.mark", "свиток Пометить", 1, 35));
            const_items.Add("item.scroll.recall", new _item("item.scroll.recall", "свиток Возвращение", 1, 25));
            const_items.Add("item.rune.war.arrow", new _item("item.rune.war.arrow", "руна Магическая стрела", 1, 200));
            const_items.Add("item.rune.war.holyarrow", new _item("item.rune.war.holyarrow", "руна Святая стрела", 1, 250));
            const_items.Add("item.rune.war.firearrow", new _item("item.rune.war.firearrow", "руна Огненная стрела", 1, 300));
            const_items.Add("item.rune.war.icefirst", new _item("item.rune.war.icefirst", "руна Ледяной кулак", 1, 350));
            const_items.Add("item.rune.war.firebolt", new _item("item.rune.war.firebolt", "руна Огненный столб", 1, 400));
            const_items.Add("item.rune.war.iceray", new _item("item.rune.war.iceray", "руна Ледяной луч", 1, 450));
            const_items.Add("item.rune.war.firestreem", new _item("item.rune.war.firestreem", "руна Струя пламени", 1, 500));
            const_items.Add("item.rune.war.lighting", new _item("item.rune.war.lighting", "руна Молния", 1, 300));
            const_items.Add("item.rune.all.watergross", new _item("item.rune.all.watergross", "руна Водяной вал", 1, 500));
            const_items.Add("item.rune.all.godanger", new _item("item.rune.all.godanger", "руна Гнев богов", 1, 600));
            const_items.Add("item.rune.all.earthquake", new _item("item.rune.all.earthquake", "руна Землетрясение", 1, 650));
            const_items.Add("item.rune.createfood", new _item("item.rune.createfood", "руна Создать еду", 1, 400));
            const_items.Add("item.rune.charm", new _item("item.rune.charm", "руна Зачаровать", 1, 300));
            const_items.Add("item.rune.charmenemy", new _item("item.rune.charmenemy", "руна Привлечь", 1, 500));
            const_items.Add("item.rune.peace", new _item("item.rune.peace", "руна Усмирить", 1, 400));
            const_items.Add("item.rune.silence", new _item("item.rune.silence", "руна Тишина", 1, 450));
            const_items.Add("item.rune.maddnes", new _item("item.rune.maddnes", "руна Безумие", 1, 800));
            const_items.Add("item.rune.summon.wolf", new _item("item.rune.summon.wolf", "руна Призвать волка", 1, 700));
            const_items.Add("item.rune.summon.skeleton", new _item("item.rune.summon.skeleton", "руна Призвать скелета", 1, 800));
            const_items.Add("item.rune.summon.golem", new _item("item.rune.summon.golem", "руна Призвать голема", 1, 900));
            const_items.Add("item.rune.summon.demon", new _item("item.rune.summon.demon", "руна Призвать демона", 1, 1000));
            const_items.Add("item.rune.heal", new _item("item.rune.heal", "руна Лечение", 1, 600));
            const_items.Add("item.rune.heal.great", new _item("item.rune.heal.great", "руна Исцеление", 1, 800));
            const_items.Add("item.rune.ressurect", new _item("item.rune.ressurect", "руна Воскрешение", 1, 800));
            const_items.Add("item.rune.mark", new _item("item.rune.mark", "руна Пометить", 1, 600));
            const_items.Add("item.rune.recall", new _item("item.rune.recall", "руна Возвращение", 1, 500));
            const_items.Add("item.recallrune.empty", new _item("item.recallrune.empty", "руна перемещения", 1, 100));
            const_items.Add("item.magic.sulphur", new _item("item.magic.sulphur", "сера", 1, 4));
            const_items.Add("item.magic.coal", new _item("item.magic.coal", "уголь", 1, 2));
            const_items.Add("item.magic.silk", new _item("item.magic.silk", "паутина", 1, 4));
            const_items.Add("item.magic.pearl", new _item("item.magic.pearl", "жемчуг", 1, 10));
            const_items.Add("item.magic.wormwood", new _item("item.magic.wormwood", "полынь", 1, 2));
            const_items.Add("item.magic.moss", new _item("item.magic.moss", "мох", 1, 2));
            // item.food.* | item.bottle.*
            const_items.Add("item.bottle.empty", new _food("item.bottle.empty", "бутылка", 1, 5, 0, 0));
            const_items.Add("item.bottle.life", new _food("item.bottle.life", "напиток жизни", 1, 30, 15, 0));
            const_items.Add("item.bottle.life.great", new _food("item.bottle.life.great", "напиток великой жизни", 1, 150, 25, 0));
            const_items.Add("item.bottle.mana", new _food("item.bottle.mana", "напиток маны", 1, 40, 0, 10));
            const_items.Add("item.bottle.mana.great", new _food("item.bottle.mana.great", "напиток великой маны", 1, 150, 0, 25));
            const_items.Add("item.bottle.health", new _food("item.bottle.health", "напиток исцеления", 1, 100, 15, 10));
            const_items.Add("item.food.meat", new _food("item.food.meat", "мясо", 1, 10, 4, 0));
            const_items.Add("item.food.meat.fried", new _food("item.food.meat.fried", "жаренное мясо", 1, 25, 8, 0));
            const_items.Add("item.food.apple", new _food("item.food.apple", "яблоко", 1, 4, 2, 0));
            const_items.Add("item.food.sandwich", new _food("item.food.sandwich", "бутерброд", 1, 15, 5, 0));
            const_items.Add("item.food.sausage", new _food("item.food.sausage", "колбаса", 1, 20, 9, 0));
            const_items.Add("item.food.cabbage", new _food("item.food.cabbage", "капуста", 1, 10, 1, 0));
            const_items.Add("item.food.ham", new _food("item.food.ham", "окорок", 1, 30, 13, 0));
            const_items.Add("item.food.bread", new _food("item.food.bread", "хлеб", 1, 16, 6, 0));
            const_items.Add("item.food.mushroom", new _food("item.food.mushroom", "гриб", 1, 10, 2, 2));
            const_items.Add("item.food.mushroom.dark", new _food("item.food.mushroom.dark", "темный гриб", 1, 40, 5, 5));
            const_items.Add("item.food.healherb", new _food("item.food.healherb", "лечебная трава", 1, 130, 22, 0));
            const_items.Add("item.food.fireroot", new _food("item.food.fireroot", "огненный корень", 1, 160, 0, 18));
            // item.armor.*
            const_items.Add("item.armor.body.leather", new _armor("item.armor.body.leather", "кожаная броня", 1, 150, 2));
            const_items.Add("item.armor.hand.leather", new _armor("item.armor.hand.leather", "кожаные поручи", 1, 70, 1));
            const_items.Add("item.armor.leg.leather", new _armor("item.armor.leg.leather", "кожаные поножи", 1, 80, 1));
            const_items.Add("item.armor.head.leather", new _armor("item.armor.head.leather", "кожаный шлем", 1, 70, 1));
            const_items.Add("item.armor.body.bone", new _armor("item.armor.body.bone", "костяная броня", 1, 250, 3));
            const_items.Add("item.armor.hand.bone", new _armor("item.armor.hand.bone", "костяные поручи", 1, 90, 1));
            const_items.Add("item.armor.body.mail", new _armor("item.armor.body.mail", "кольчуга", 1, 450, 4));
            const_items.Add("item.armor.body.full", new _armor("item.armor.body.full", "латный доспех", 1, 600, 5));
            const_items.Add("item.armor.body.plate", new _armor("item.armor.body.plate", "пластинчатый доспех", 1, 1000, 6));
            const_items.Add("item.armor.shield.wood", new _armor("item.armor.shield.wood", "деревянный щит", 1, 80, 1));
            const_items.Add("item.armor.shield.copperwood", new _armor("item.armor.shield.copperwood", "обитый щит", 1, 150, 2));
            const_items.Add("item.armor.shield.bronze", new _armor("item.armor.shield.bronze", "бронзовый щит", 1, 250, 3));
            const_items.Add("item.armor.shield.heavy", new _armor("item.armor.shield.heavy", "большой щит", 1, 400, 4));
            // item.weapon.*
            const_items.Add("item.weapon.knife", new _weapon("item.weapon.knife", "нож", 1, 10, 1, 3, 0, 4, "ножом", "", ""));
            const_items.Add("item.weapon.knife.hunter", new _weapon("item.weapon.knife.hunter", "охотничий нож", 1, 15, 1, 5, 0, 4, "ножом", "", ""));
            const_items.Add("item.weapon.knife.boot", new _weapon("item.weapon.knife.boot", "нож-засапожник", 1, 20, 2, 4, 0, 4, "ножом", "", ""));
            const_items.Add("item.weapon.knife.butcher", new _weapon("item.weapon.knife.butcher", "нож мясника", 1, 25, 2, 5, 0, 5, "ножом", "", ""));
            const_items.Add("item.weapon.knife.cutlass", new _weapon("item.weapon.knife.cutlass", "тесак", 1, 18, 2, 5, 2, 5, "тесаком", "", ""));
            const_items.Add("item.weapon.dagger", new _weapon("item.weapon.dagger", "кинжал", 1, 22, 1, 6, 0, 4, "кинжалом", "", ""));
            const_items.Add("item.weapon.kortik", new _weapon("item.weapon.kortik", "кортик", 1, 20, 1, 5, 0, 4, "кортиком", "", ""));
            const_items.Add("item.weapon.shortsword", new _weapon("item.weapon.shortsword", "короткий меч", 1, 30, 3, 4, 0, 5, "мечом", "", ""));
            const_items.Add("item.weapon.broadsword", new _weapon("item.weapon.broadsword", "широкий меч", 1, 35, 3, 5, 0, 5, "мечом", "", ""));
            const_items.Add("item.weapon.halfsword", new _weapon("item.weapon.halfsword", "полуторный меч", 1, 40, 4, 5, 2, 5, "мечом", "", ""));
            const_items.Add("item.weapon.longsword", new _weapon("item.weapon.longsword", "длинный меч", 1, 50, 5, 7, 3, 5, "мечом", "", ""));
            const_items.Add("item.weapon.twohandsword", new _weapon("item.weapon.twohandsword", "двуручный меч", 1, 150, 5, 12, 4, 7, "мечом", "", ""));
            const_items.Add("item.weapon.sabre", new _weapon("item.weapon.sabre", "сабля", 1, 70, 3, 8, 2, 5, "саблей", "", ""));
            const_items.Add("item.weapon.crookedsword", new _weapon("item.weapon.crookedsword", "кривой меч", 1, 60, 4, 7, 2, 6, "мечом", "", ""));
            const_items.Add("item.weapon.yatagan", new _weapon("item.weapon.yatagan", "ятаган", 1, 50, 2, 6, 3, 6, "ятаганом", "", ""));
            const_items.Add("item.weapon.samuraysword", new _weapon("item.weapon.samuraysword", "самурайский меч", 1, 200, 3, 10, 0, 5, "мечом", "", ""));
            const_items.Add("item.weapon.glade", new _weapon("item.weapon.glade", "шпага", 1, 40, 1, 4, 0, 5, "шпагой", "", ""));
            const_items.Add("item.weapon.flamberg", new _weapon("item.weapon.flamberg", "фламберг", 1, 170, 12, 15, 5, 9, "фламбергом", "", ""));
            const_items.Add("item.weapon.spear", new _weapon("item.weapon.spear", "копье", 1, 180, 6, 11, 3, 6, "копьем", "", ""));
            const_items.Add("item.weapon.halberd", new _weapon("item.weapon.halberd", "алебарда", 1, 250, 11, 17, 4, 9, "алебардой", "", ""));
            const_items.Add("item.weapon.axe", new _weapon("item.weapon.axe", "топор", 1, 90, 6, 7, 3, 7, "топором", "", ""));
            const_items.Add("item.weapon.poleaxe", new _weapon("item.weapon.poleaxe", "секира", 1, 210, 9, 15, 4, 8, "секирой", "", ""));
            const_items.Add("item.weapon.blackjack", new _weapon("item.weapon.blackjack", "дубина", 1, 15, 2, 3, 2, 6, "дубиной", "", ""));
            const_items.Add("item.weapon.moningstar", new _weapon("item.weapon.moningstar", "утренняя звезда", 1, 120, 5, 8, 3, 8, "утренней звездой", "", ""));
            const_items.Add("item.weapon.glefa", new _weapon("item.weapon.glefa", "глефа", 1, 250, 7, 11, 2, 6, "глефой", "", ""));
            const_items.Add("item.weapon.ranged.stone", new _weapon("item.weapon.ranged.stone", "камень", 1, 2, 0, 1, 0, 5, "камнем", "item.weapon.stone", "камень"));
            const_items.Add("item.weapon.ranged.surricen", new _weapon("item.weapon.ranged.surricen", "сюррикен", 1, 5, 0, 1, 0, 4, "сюррикеном", "item.weapon.surricen", "сюррикен"));
            const_items.Add("item.weapon.ranged.bumerang", new _weapon("item.weapon.ranged.bumerang", "бумеранг", 1, 30, 1, 4, 0, 5, "бумерангом", "", ""));
            const_items.Add("item.weapon.ranged.tomahawk", new _weapon("item.weapon.ranged.tomahawk", "томагавк", 1, 15, 2, 3, 2, 5, "сюррикеном", "item.weapon.tomahawk", "томагавк"));
            const_items.Add("item.weapon.ranged.dropknife", new _weapon("item.weapon.ranged.dropknife", "метательный нож", 1, 10, 1, 3, 2, 4, "метательным ножом", "item.weapon.dropknife", "метательный нож"));
            const_items.Add("item.weapon.ranged.dropspear", new _weapon("item.weapon.ranged.dropspear", "метательное копье", 1, 100, 7, 17, 3, 7, "метательным копьем", "item.weapon.dropspear", "метательное копье"));
            const_items.Add("item.weapon.ranged.javelin", new _weapon("item.weapon.ranged.javelin", "дротик", 1, 15, 1, 5, 0, 4, "дротиком", "item.weapon.javelin", "дротик"));
            const_items.Add("item.weapon.ranged.sling", new _weapon("item.weapon.ranged.sling", "праща", 1, 30, 1, 8, 0, 6, "пращой", "item.weapon.stone", "камень"));
            const_items.Add("item.weapon.ranged.bow", new _weapon("item.weapon.ranged.bow", "лук", 1, 30, 1, 6, 0, 5, "луком", "item.misc.arrow", "стрелы"));
            const_items.Add("item.weapon.ranged.shortbow", new _weapon("item.weapon.ranged.shortbow", "короткий лук", 1, 30, 1, 5, 0, 5, "луком", "item.misc.arrow", "стрелы"));
            const_items.Add("item.weapon.ranged.longbow", new _weapon("item.weapon.ranged.longbow", "длинный лук", 1, 50, 3, 6, 2, 5, "луком", "item.misc.arrow", "стрелы"));
            const_items.Add("item.weapon.ranged.willowbow", new _weapon("item.weapon.ranged.willowbow", "ивовый лук", 1, 60, 4, 6, 2, 5, "луком", "item.misc.arrow", "стрелы"));
            const_items.Add("item.weapon.ranged.birchbow", new _weapon("item.weapon.ranged.birchbow", "березовый лук", 1, 90, 5, 8, 3, 6, "луком", "item.misc.arrow", "стрелы"));
            const_items.Add("item.weapon.ranged.hunterbow", new _weapon("item.weapon.ranged.hunterbow", "охотничий лук", 1, 150, 5, 10, 3, 6, "луком", "item.misc.arrow", "стрелы"));
            const_items.Add("item.weapon.ranged.compoundbow", new _weapon("item.weapon.ranged.compoundbow", "соcтавной лук", 1, 250, 8, 13, 4, 6, "луком", "item.misc.arrow", "стрелы"));
            const_items.Add("item.weapon.ranged.crossbow.light", new _weapon("item.weapon.ranged.crossbow.light", "легкий арбалет", 1, 150, 7, 10, 0, 7, "арбалетом", "item.misc.bolt", "болты"));
            const_items.Add("item.weapon.ranged.crossbow.middle", new _weapon("item.weapon.ranged.crossbow.middle", "средний арбалет", 1, 230, 10, 16, 3, 6, "арбалетом", "item.misc.bolt", "болты"));
            const_items.Add("item.weapon.ranged.crossbow.hard", new _weapon("item.weapon.ranged.crossbow.hard", "тяжелый арбалет", 1, 280, 14, 17, 4, 9, "арбалетом", "item.misc.bolt", "болты"));
        }

        private void create_locationsinfos()
        {
            locations_info.Add("loc.0", new _locationinfo("loc.0", "Welcome", true));
            locations_info["loc.0"].Description = "Вы стоите на мощенной камнем улице между добротными домами. Человек в нескольких шагах от вас явно хочет с вами поговорить.";
            locations_info["loc.0"].ways.Add("loc.lek1", "к лекарю");
            locations_info["loc.0"].ways.Add("loc.drag1", "к магазину драгоценностей");
            locations_info["loc.0"].ways.Add("loc.sklad1", "по дороге на юг");
            locations_info.Add("loc.lek1", new _locationinfo("loc.lek1", "Двор лекаря", true));
            locations_info["loc.lek1"].Description = "Небольшой дворик, огороженный аккуратным невысоким забором, вокруг раскинулись кусты сирени и жасмина. Прямо перед вами дверь в дом лекаря, на востоке проход к Академии, на западе выход к банку, а на юг пролегла неширокая мощенная камнем дорога.";
            locations_info["loc.lek1"].ways.Add("loc.lek", "войти в дом");
            locations_info["loc.lek1"].ways.Add("loc.ak1", "к Академии");
            locations_info["loc.lek1"].ways.Add("loc.bank1", "к банку");
            locations_info["loc.lek1"].ways.Add("loc.0", "на юг");
            locations_info.Add("loc.lek", new _locationinfo("loc.lek", "Дом лекаря", true));
            locations_info["loc.lek"].Description = "Вы в доме лекаря, вдоль стен стоят две кушетки, а в центре один большой стол, на котором разложены инструменты.";
            locations_info["loc.lek"].ways.Add("loc.drag", "войти в дом");
            locations_info["loc.lek"].ways.Add("loc.tenal", "на восток");
            locations_info["loc.lek"].ways.Add("loc.0", "на запад");
            locations_info.Add("loc.drag1", new _locationinfo("loc.drag1", "Перед магазином драгоценностей", true));
            locations_info["loc.drag1"].Description = "Вы перед зданием из дорогих пород дерева, вход украшают две белоснежные колонны. На востоке виднеется дорожка, усыпанная гравием, а на западе мощенная камнем дорога.";
            locations_info["loc.drag1"].ways.Add("loc.lek1", "выйти на улицу");
            locations_info.Add("loc.drag", new _locationinfo("loc.drag", "Магазин драгоценностей", true));
            locations_info["loc.drag"].Description = "По бокам комнаты расположены стеклянные витрины с кольцами, ожерельями, драгоценными камнями и прочими безделушками. В центре стоит дубовый стол, за закоторым склонился, что-то разглядывая в увеличительное стекло, пожилой мужчина.";
            locations_info["loc.drag"].ways.Add("loc.drag1", "выйти на улицу");
            locations_info.Add("loc.sklad1", new _locationinfo("loc.sklad1", "Дорога к складу", true));
            locations_info["loc.sklad1"].Description = "Дорога идет с севера на юг и упирается в городскую стену, на востоке виден портовый склад и какой-то магазин, а на западе большие южные ворота.";
            locations_info["loc.sklad1"].ways.Add("loc.sklad2", "к складу");
            locations_info["loc.sklad1"].ways.Add("loc.uv", "к южным воротам");
            locations_info["loc.sklad1"].ways.Add("loc.0", "на север");
            locations_info.Add("loc.sklad2", new _locationinfo("loc.sklad2", "Около склада", true));
            locations_info["loc.sklad2"].Description = "Дорога идет с востока на запад, рядом расположены двери в портовый склад и какой-то небольшой магазин.";
            locations_info["loc.sklad2"].ways.Add("loc.sklad", "войти в склад");
            locations_info["loc.sklad2"].ways.Add("loc.reg", "войти в магазин");
            locations_info["loc.sklad2"].ways.Add("loc.jd3", "на восток");
            locations_info["loc.sklad2"].ways.Add("loc.sklad1", "на запад");
            locations_info.Add("loc.sklad", new _locationinfo("loc.sklad", "На складе", false));
            locations_info["loc.sklad"].Description = "Большое помещение портового склада, сплошь заставленное деревянными ящиками, по углам валяются кучи мусора.";
            locations_info["loc.sklad"].ways.Add("loc.sklad2", "выйти на улицу");
            locations_info.Add("loc.reg", new _locationinfo("loc.reg", "Магазин реагентов", true));
            locations_info["loc.reg"].Description = "Небольшое полутемное помещение, на столах разложены сушеные травы и какие-то колбочки с разноцветной жидкостью, в углу дымит масляная лампадка.";
            locations_info["loc.reg"].ways.Add("loc.sklad2", "выйти на улицу");
            locations_info.Add("loc.jd3", new _locationinfo("loc.jd3", "Жилые дома", true));
            locations_info["loc.jd3"].Description = "Вы среди похожих друг на друга небольших домов, не слишком многолюдная улица, некоторые окна и двери заколочены крест-накрест досками. Дорога уходит вглубь района на восток, на запад к портовым складам и на север к восточным воротам.";
            locations_info["loc.jd3"].ways.Add("loc.sklad2", "к складу");
            locations_info["loc.jd3"].ways.Add("loc.jd4", "на восток");
            locations_info["loc.jd3"].ways.Add("loc.jd1", "на север");
            locations_info.Add("loc.jd4", new _locationinfo("loc.jd4", "Трущобы", false));
            locations_info["loc.jd4"].Description = "Заброшенная часть жилого квартала, под ногами валяется мусор, а полуразрушенные покосившиеся дома смотрят на вас черными провалами выбитых окон. Однако на севере среди деревьев проступают контуры крупного особняка.";
            locations_info["loc.jd4"].ways.Add("loc.jd3", "на запад");
            locations_info["loc.jd4"].ways.Add("loc.jd2", "к особняку");
            locations_info.Add("loc.jd2", new _locationinfo("loc.jd2", "Около особняка", true));
            locations_info["loc.jd2"].Description = "Вы в самой восточной части города, на юге видны не слишком благополучные дома, на востоке калитка, ведущая к особняку с аккуратно подстриженным газоном. Чуть в стороне на западе начинаются жилые дома более менее зажиточных горожан, а на севере среди тенистых деревьев теряется дорожка, посыпанная гравием.";
            locations_info["loc.jd2"].ways.Add("loc.osobn", "к особняку");
            locations_info["loc.jd2"].ways.Add("loc.tenal", "на север");
            locations_info["loc.jd2"].ways.Add("loc.jd1", "на запад");
            locations_info["loc.jd2"].ways.Add("loc.jd4", "в трущобы на юге");
            locations_info.Add("loc.jd1", new _locationinfo("loc.jd1", "Жилые дома", true));
            locations_info["loc.jd1"].Description = "Вокруг стоят симпатичные домики, у многих на окнах цветут цветы или вьется зеленый плющ. На север начинается тенистая аллея, на юге тоже жилые дома, а на востоке на открытом пространстве стоит крупный особняк.";
            locations_info["loc.jd1"].ways.Add("loc.jd2", "к особняку");
            locations_info["loc.jd1"].ways.Add("loc.tenal", "к тенистой аллее");
            locations_info["loc.jd1"].ways.Add("loc.jd3", "на юг");
            locations_info.Add("loc.osobn", new _locationinfo("loc.osobn", "Особняк", true));
            locations_info["loc.osobn"].Description = "Внутри особняка очень просторно, широкая лестница с резными белясинами уходит на второй этаж, делая поворот и образуя небольшую площадку наверху. На окнах дорогие шторы, у стены стоит мягкий диван.";
            locations_info["loc.osobn"].ways.Add("loc.jd2", "выйти из особняка");
            locations_info.Add("loc.tenal", new _locationinfo("loc.tenal", "Тенистая аллея", true));
            locations_info["loc.tenal"].Description = "Излюбленное место отдыха влюбленных парочек и зажиточных горожан. Солнце искрится среди ветвей высоких стройных деревьев, по сторонам стоят длинные лавочки. Аллея тянется на север вплоть до восточных ворот, на запад отходит небольшая улочка к магазину драгоценностей, а на юге начинается жилой квартал.";
            locations_info["loc.tenal"].ways.Add("loc.vv", "восточные ворота");
            locations_info["loc.tenal"].ways.Add("loc.drag1", "к магазину");
            locations_info["loc.tenal"].ways.Add("loc.jd1", "в жилой район");
            locations_info["loc.tenal"].ways.Add("loc.jd2", "в жилой район на восток");
            locations_info.Add("loc.vv", new _locationinfo("loc.vv", "Восточные ворота", true));
            locations_info["loc.vv"].Description = "Вы у восточных ворот города, на севере раскинулась восточная торговая площадь, на западе стоит здание Академии, а на юг тянется тенистая аллея.";
            locations_info["loc.vv"].ways.Add("loc.zvv", "выйти из города");
            locations_info["loc.vv"].ways.Add("loc.vpl", "на площадь");
            locations_info["loc.vv"].ways.Add("loc.ak1", "к Академии");
            locations_info["loc.vv"].ways.Add("loc.tenal", "к тенистой аллее");
            locations_info.Add("loc.vpl", new _locationinfo("loc.vpl", "Восточная площадь", true));
            locations_info["loc.vpl"].Description = "Широкая мощенная камнем площадь, по краям стоят торговые палатки, большинство из них под разноцветными тентами, хотя есть и открытые. На юге находятся восточные ворота.";
            locations_info["loc.vpl"].ways.Add("loc.vv", "к восточным воротам");
            locations_info.Add("loc.ak1", new _locationinfo("loc.ak1", "Перед Академией", true));
            locations_info["loc.ak1"].Description = "Вы стоите перед Академией - огромным зданием, подъезд которого украшен белыми колоннами, а наверху под позолоченной крышей высечены из мрамора фигуры разных волшебных существ. Рядом притулилась длинная постройка конюшни. На востоке восточные ворота, к юго-западу расположен домик лекаря, а на западе стоит банк.";
            locations_info["loc.ak1"].ways.Add("loc.ak", "войти в Академию");
            locations_info["loc.ak1"].ways.Add("loc.kon1", "к конюшне");
            locations_info["loc.ak1"].ways.Add("loc.vv", "к восточным воротам");
            locations_info["loc.ak1"].ways.Add("loc.lek1", "к дому лекаря");
            locations_info["loc.ak1"].ways.Add("loc.bank1", "к банку");
            locations_info.Add("loc.bank1", new _locationinfo("loc.bank1", "Перед банком", true));
            locations_info["loc.bank1"].Description = "Здание банка, на окнах решетки, двери обиты медью. На востоке высится Академия, на юго-восток уходит дорожка к дому лекаря, на юг тянется широкая мощенная камнем дорога, а на западе начинается центральная площадь.";
            locations_info["loc.bank1"].ways.Add("loc.bank", "войти в банк");
            locations_info["loc.bank1"].ways.Add("loc.ak1", "к Академии");
            locations_info["loc.bank1"].ways.Add("loc.lek1", "к лекарю");
            locations_info["loc.bank1"].ways.Add("loc.centr1", "на юг");
            locations_info["loc.bank1"].ways.Add("loc.cpl", "на запад");
            locations_info.Add("loc.bank", new _locationinfo("loc.bank", "В банке", true));
            locations_info["loc.bank"].Description = "Вы в здании банка, здесь два выхода - на юге и западе.";
            locations_info["loc.bank"].ways.Add("loc.bank1", "южная дверь");
            locations_info["loc.bank"].ways.Add("loc.bank2", "западная дверь");
            locations_info.Add("loc.bank2", new _locationinfo("loc.bank2", "Около банка", true));
            locations_info["loc.bank2"].Description = "Вы у западного входа в банк. Дорога огибает здание банка с двух сторон: на севере видна конюшня, а на юге начинается центральная площадь. Дальше к северо-западу дорога выходит к северным воротам.";
            locations_info["loc.bank2"].ways.Add("loc.bank", "войти в банк");
            locations_info["loc.bank2"].ways.Add("loc.kon1", "к конюшне");
            locations_info["loc.bank2"].ways.Add("loc.cpl", "на площадь");
            locations_info["loc.bank2"].ways.Add("loc.sv", "к северным воротам");
            locations_info.Add("loc.kon1", new _locationinfo("loc.kon1", "Около конюшни", true));
            locations_info["loc.kon1"].Description = "Дорога проходит мимо конюшни, у входа стоит деревянная телега с сеном и несколько пустых бочек. На востоке площадь перед Академией, на западе здание банка.";
            locations_info["loc.kon1"].ways.Add("loc.kon", "войти в конюшню");
            locations_info["loc.kon1"].ways.Add("loc.ak1", "к Академии");
            locations_info["loc.kon1"].ways.Add("loc.bank2", "к банку");
            locations_info.Add("loc.kon", new _locationinfo("loc.kon", "В конюшне", true));
            locations_info["loc.kon"].Description = "Вы находитесь в конюшне, что расположена в самой северной части города. Вглубь здания тянутся ряды стойл, время от времени оттуда раздается ржание, под ногами валяется солома и... ну, то что кони иногда оставляют на полу...";
            locations_info["loc.kon"].ways.Add("loc.kon1", "выйти на улицу");
            locations_info.Add("loc.centr1", new _locationinfo("loc.centr1", "Центральная дорога", true));
            locations_info["loc.centr1"].Description = "Широкая мощенная камнем дорога тянется прямо к южным воротам, а на севере упирается в банк. На западе стоит здание, над дверью которого висит табличка 'Таверна', на востоке двойное здание, посередине которого на улице трудится кузнец.";
            locations_info["loc.centr1"].ways.Add("loc.bank1", "к банку");
            locations_info["loc.centr1"].ways.Add("loc.tav", "войти в таверну");
            locations_info["loc.centr1"].ways.Add("loc.kuzn", "подойти к кузнецу");
            locations_info["loc.centr1"].ways.Add("loc.br", "войти в двойное здание");
            locations_info["loc.centr1"].ways.Add("loc.centr2", "на юг");
            locations_info.Add("loc.tav", new _locationinfo("loc.tav", "Таверна", true));
            locations_info["loc.tav"].Description = "Вы в просторном главном зале таверны. Вокруг царит приятный полумрак, создаваемый десятком свечей и огромным камином, чувствуются манящие запахи со стороны барной стойки. В дальнем углу еще темнее, там немного обособленно стоят несколько столиков. У противоположной стены и у барной стойки лестница на второй этаж.";
            locations_info["loc.tav"].ways.Add("loc.centr1", "выйти из таверны");
            locations_info["loc.tav"].ways.Add("loc.tav1", "подойти к барной стойке");
            locations_info["loc.tav"].ways.Add("loc.tav2", "в дальний угол");
            locations_info.Add("loc.tav1", new _locationinfo("loc.tav1", "Таверна", true));
            locations_info["loc.tav1"].Description = "Барная стойка из дорогого темно-красного дерева отполирована до блеска, за стойкой в серванте искрятся в неверном свете камина графины и бутылки с различными напитками. Рядом лестница с резными белясинами на второй этаж.";
            locations_info["loc.tav1"].ways.Add("loc.tav3", "на второй этаж");
            locations_info["loc.tav1"].ways.Add("loc.tav2", "в дальний угол");
            locations_info["loc.tav1"].ways.Add("loc.tav", "к выходу из таверны");
            locations_info.Add("loc.tav2", new _locationinfo("loc.tav2", "Таверна", true));
            locations_info["loc.tav2"].Description = "Здесь еще темнее, так как свет от камина сюда почти не доходит. У стены видна лестница на второй этаж.";
            locations_info["loc.tav2"].ways.Add("loc.tav3", "на второй этаж");
            locations_info["loc.tav2"].ways.Add("loc.tav1", "подойти к барной стойке");
            locations_info["loc.tav2"].ways.Add("loc.tav", "к выходу из таверны");
            locations_info.Add("loc.tav3", new _locationinfo("loc.tav3", "Таверна", true));
            locations_info["loc.tav3"].Description = "Вы стоите на втором этаже таверны, здесь есть две двери в комнаты и лестницы на первый этаж в концах коридора.";
            locations_info["loc.tav3"].ways.Add("loc.tav4", "войти в первую дверь");
            locations_info["loc.tav3"].ways.Add("loc.tav5", "войти во вторую дверь");
            locations_info["loc.tav3"].ways.Add("loc.tav1", "южная лестница на первый этаж");
            locations_info["loc.tav3"].ways.Add("loc.tav2", "северная лестница на первый этаж");
            locations_info.Add("loc.tav4", new _locationinfo("loc.tav4", "Таверна", true));
            locations_info["loc.tav4"].Description = "Первая комната на втором этаже таверны, ничего особенного - старая кровать у стены и сундук, заменяющий тумбочку.";
            locations_info["loc.tav4"].ways.Add("loc.tav3", "выйти в корридор");
            locations_info.Add("loc.tav5", new _locationinfo("loc.tav5", "Таверна", true));
            locations_info["loc.tav5"].Description = "Вторая комната на втором этаже таверны, ничего особенного - старая кровать у стены и сундук, заменяющий тумбочку.";
            locations_info["loc.tav5"].ways.Add("loc.tav3", "выйти в корридор");
            locations_info.Add("loc.br", new _locationinfo("loc.br", "Магазин брони", true));
            locations_info["loc.br"].Description = "Вы в здании магазина брони, по стенам развешаны кольчуги и разнообразные щиты всех видов. На юге дверь во вторую часть здания, а на западе выход на улицу.";
            locations_info["loc.br"].ways.Add("loc.centr1", "выйти на улицу");
            locations_info["loc.br"].ways.Add("loc.or", "перейти в дверь на юге");
            locations_info.Add("loc.or", new _locationinfo("loc.or", "Магазин оружия", true));
            locations_info["loc.or"].Description = "Вы в здании магазина оружия, на стенах развешаны копья и гобелены, изображающие великие сражения, на полках разложены мечи и другое оружие. На севере дверь в другую часть здания, а на западе выход на улицу.";
            locations_info["loc.or"].ways.Add("loc.centr2", "выйти на улицу");
            locations_info["loc.or"].ways.Add("loc.br", "перейти в дверь на севере");
            locations_info.Add("loc.centr2", new _locationinfo("loc.centr2", "Центральная улица", true));
            locations_info["loc.centr2"].Description = "Широкая мощенная камнем улица тянется с юга на север, с одной стороны заканчиваясь южными воротами, а с другой упираясь в банк. Прямо перед вами вход в южную часть двойного здания, а чуть ближе к северу на улице работает кузнец.";
            locations_info["loc.centr2"].ways.Add("loc.kuzn", "подойти к кузнецу");
            locations_info["loc.centr2"].ways.Add("loc.or", "войти в двойное здание");
            locations_info["loc.centr2"].ways.Add("loc.uv", "к южным воротам");
            locations_info["loc.centr2"].ways.Add("loc.centr1", "на север");
            locations_info.Add("loc.kuzn", new _locationinfo("loc.kuzn", "Кузница", true));
            locations_info["loc.kuzn"].Description = "Между двумя половинками двойного здания на наковальне работает кузнец, а рядом помощник крутит точило, обтачивая какую-то деталь и рассыпая искры. По сторонам расположены двери в двойное здание.";
            locations_info["loc.kuzn"].ways.Add("loc.br", "войти в северную дверь");
            locations_info["loc.kuzn"].ways.Add("loc.or", "войти в южную дверь");
            locations_info["loc.kuzn"].ways.Add("loc.centr1", "на север");
            locations_info["loc.kuzn"].ways.Add("loc.centr2", "на юг");
            locations_info.Add("loc.uv", new _locationinfo("loc.uv", "Южные ворота", true));
            locations_info["loc.uv"].Description = "Вы у южных ворот города, на север идет центральная дорога, на востоке расположены портовые склады, а на западе несколько магазинов и казармы. Прямо за воротами на юге видна река и пристань.";
            locations_info["loc.uv"].ways.Add("loc.centr2", "на север");
            locations_info["loc.uv"].ways.Add("loc.sklad1", "на восток");
            locations_info["loc.uv"].ways.Add("loc.uz2", "на запад");
            locations_info["loc.uv"].ways.Add("loc.pristan", "выйти за город");
            locations_info.Add("loc.uz2", new _locationinfo("loc.uz2", "Торговый квартал", true));
            locations_info["loc.uz2"].Description = "Вы в южной части города, дорога идет с востока на запад, на севере вход в магазин припасов, на юге здание с вывеской, на которой нарисован лук и стрелы.";
            locations_info["loc.uz2"].ways.Add("loc.prip", "войти в магазин припасов");
            locations_info["loc.uz2"].ways.Add("loc.luk", "войти в магазин на юге");
            locations_info["loc.uz2"].ways.Add("loc.uv", "на восток к южным воротам");
            locations_info["loc.uz2"].ways.Add("loc.uz1", "на запад");
            locations_info.Add("loc.prip", new _locationinfo("loc.prip", "Магазин припасов", true));
            locations_info["loc.prip"].Description = "В этом магине есть все что нужно для путешествия - одежда, факелы, продовольствие и тому подобное.";
            locations_info["loc.prip"].ways.Add("loc.uz2", "выйти на улицу");
            locations_info.Add("loc.luk", new _locationinfo("loc.luk", "Магазин для лучников", true));
            locations_info["loc.luk"].Description = "Прямо на стене висит мишень для стрельбы из лука, вдоль стен лежат пучки прутьев, в комнате царит запах лака и свежего можжевельника.";
            locations_info["loc.luk"].ways.Add("loc.uz2", "выйти на улицу");
            locations_info.Add("loc.uz1", new _locationinfo("loc.uz1", "Торговый квартал", true));
            locations_info["loc.uz1"].Description = "Вы в южной части города, дорога идет с востока на запад, из магазина на севере доносится лай, мычание и еще какие-то невнятные звуки, а домик на юге весь зарос плющом и диковинными цветами с большими лепестками. На западе стоят несколько длинных одноэтежных деревянных зданий.";
            locations_info["loc.uz1"].ways.Add("loc.jiv", "войти в магазин на севере");
            locations_info["loc.uz1"].ways.Add("loc.but", "войти в магазин на юге");
            locations_info["loc.uz1"].ways.Add("loc.kaz1", "на запад");
            locations_info["loc.uz1"].ways.Add("loc.uz2", "на восток");
            locations_info.Add("loc.jiv", new _locationinfo("loc.jiv", "Магазин Животные", true));
            locations_info["loc.jiv"].Description = "Вы оказались в настоящем хлеву, на полу грязная солома, слышен визг свиней, кудахтанье кур, лай псов, про запах можно и не говорить...";
            locations_info["loc.jiv"].ways.Add("loc.uz1", "выйти на улицу");
            locations_info.Add("loc.but", new _locationinfo("loc.but", "Магазин напитков", true));
            locations_info["loc.but"].Description = "Темное помещение, из задней двери слышно бульканье, шипение, в воздухе пахнет терпкими травами.";
            locations_info["loc.but"].ways.Add("loc.uz1", "выйти на улицу");
            locations_info.Add("loc.kaz1", new _locationinfo("loc.kaz1", "Перед казармами", true));
            locations_info["loc.kaz1"].Description = "Прямо перед вами не слишком ухоженное одноэтажное длинное здание, на севере начинается небольшая березованя рощица, а дальше на западе стоит темный полуразвалившийся дом.";
            locations_info["loc.kaz1"].ways.Add("loc.kaz", "войти в казарму");
            locations_info["loc.kaz1"].ways.Add("loc.br3", "к березовой роще");
            locations_info["loc.kaz1"].ways.Add("loc.dv1", "на запад");
            locations_info["loc.kaz1"].ways.Add("loc.uz1", "на восток");
            locations_info.Add("loc.kaz", new _locationinfo("loc.kaz", "Казармы", true));
            locations_info["loc.kaz"].Description = "Сквозь щели в стенах солнечные лучи тают в пыли, по строению гуляет сквозняк, вдоль обшарпанных стен стоят ровные ряды коек, около изголовья каждой стоит небольшая тумбочка.";
            locations_info["loc.kaz"].ways.Add("loc.kaz1", "выйти на улицу");
            locations_info.Add("loc.dv1", new _locationinfo("loc.dv1", "Около старого дома", true));
            locations_info["loc.dv1"].Description = "Вы оказались около полуразрушенного дома на западе города. Потемневшие стены, давно не ремонтировавшаяся крыша, покосившаяся дверь...  На севере белеют стволы берез.";
            locations_info["loc.dv1"].ways.Add("loc.dv", "войти в старый дом");
            locations_info["loc.dv1"].ways.Add("loc.br3", "к березовой роще");
            locations_info["loc.dv1"].ways.Add("loc.kaz1", "на восток");
            locations_info.Add("loc.dv", new _locationinfo("loc.dv", "Старый дом", false));
            locations_info["loc.dv"].Description = "В полумраке видна старая и обшарпанная, очень старинная мебель. Тяжелые меховые шторы почти полностью закрывают окна. В углу комнаты есть небольшая дверь.";
            locations_info["loc.dv"].ways.Add("loc.dv1", "выйти на улицу");
            locations_info["loc.dv"].ways.Add("loc.dv2", "дверь в углу");
            locations_info.Add("loc.dv2", new _locationinfo("loc.dv2", "Старый дом", false));
            locations_info["loc.dv2"].Description = "Вы в небольшой комнате, больше похожей на каморку, чем на жилое помещение, хотя у стены стоит кровать, а на письменном столе лежат исписанные листы бумаги и разные безделушки.";
            locations_info["loc.dv2"].ways.Add("loc.dv", "выйти из комнаты");
            locations_info.Add("loc.br3", new _locationinfo("loc.br3", "Березовая роща", false));
            locations_info["loc.br3"].Description = "Вы на краю березовой рощи, молодые деревца жадно тянутся к солнцу, под ногами мягкая трава. Вокруг очень красиво, но кажется, жители города не часто сюда заходят...";
            locations_info["loc.br3"].ways.Add("loc.dv1", "к старому дому");
            locations_info["loc.br3"].ways.Add("loc.kaz1", "к казармам");
            locations_info["loc.br3"].ways.Add("loc.br4", "на запад");
            locations_info["loc.br3"].ways.Add("loc.br1", "на север");
            locations_info.Add("loc.br4", new _locationinfo("loc.br4", "Березовая роща", false));
            locations_info["loc.br4"].Description = "Вы в самой западной части города, вглубине березовой рощи. Эти места кажутся совершенно безлюдными и непосещаемыми, если не считать небольших тропинок в густой траве. Правда кто их проложил - люди или нет, остается загадкой... На западе лес упирается в городскую стену.";
            locations_info["loc.br4"].ways.Add("loc.br3", "на восток");
            locations_info["loc.br4"].ways.Add("loc.br2", "на север");
            locations_info.Add("loc.br2", new _locationinfo("loc.br2", "Березовая роща", false));
            locations_info["loc.br2"].Description = "Здесь деревья подступают вплотную к городской стене. В тенистом углу, где стена немного изгибается, на траве из больших серых камней выложен ровный круг в несколько шагов диаметром.";
            locations_info["loc.br2"].ways.Add("loc.br1", "на восток");
            locations_info["loc.br2"].ways.Add("loc.br4", "на юг");
            locations_info.Add("loc.br1", new _locationinfo("loc.br1", "Березовая роща", true));
            locations_info["loc.br1"].Description = "Вы в старой части березовой рощи на западе города, огромные раскидистые березы частично закрывают солнце. Узкие нехоженные тропинки тянутся вглубь леса на запад и по краю рощи на юг. Более ухоженная дорожка ведет к северным воротам.";
            locations_info["loc.br1"].ways.Add("loc.sv", "к северным воротам");
            locations_info["loc.br1"].ways.Add("loc.br2", "тропинка на запад");
            locations_info["loc.br1"].ways.Add("loc.br3", "тропинка на юг");
            locations_info.Add("loc.sv", new _locationinfo("loc.sv", "Северные ворота", true));
            locations_info["loc.sv"].Description = "За огромными воротами на севере видна широкая дорога, уходящая вглубь леса. На востоке стоит здание банка, а на западе на небольшой площади двухэтажное каменное строение. Небольшая дорожка ведет между этим зданием и забором двора рыцарей в березовую рощу.";
            locations_info["loc.sv"].ways.Add("loc.zsv", "выйти из города");
            locations_info["loc.sv"].ways.Add("loc.snar", "войти в здание");
            locations_info["loc.sv"].ways.Add("loc.bank2", "к банку");
            locations_info["loc.sv"].ways.Add("loc.br1", "к березовой роще");
            locations_info.Add("loc.snar", new _locationinfo("loc.snar", "Магазин снаряжения", true));
            locations_info["loc.snar"].Description = "Добротные каменне стены и узкие окна говорят о том, что раньше это здание было аванпостом, но сейчас в нем торгуют снаряжением и охотничьими принадлежностями.";
            locations_info["loc.snar"].ways.Add("loc.sv", "выйти из здания");
            locations_info.Add("loc.zvv", new _locationinfo("loc.zvv", "За восточными воротами", false));
            locations_info["loc.zvv"].Description = "Вы за пределами города, на западе находятся восточные ворота, дорога из них идет вдоль городской стены на север, а на востоке начинается лес.";
            locations_info["loc.zvv"].ways.Add("loc.vv", "войти в город");
            locations_info["loc.zvv"].ways.Add("loc.vd.1", "дорога на север");
            locations_info["loc.zvv"].ways.Add("loc.vl.18", "лес на востоке");
            locations_info.Add("loc.zsv", new _locationinfo("loc.zsv", "За северными воротами", false));
            locations_info["loc.zsv"].Description = "Вы за пределами города, на юге находятся северные ворота, дорога из них идет прямиком на север, на северо-востоке видно озеро, а на запад вдоль городской стены уходит небольшая тропинка.";
            locations_info["loc.zsv"].ways.Add("loc.sv", "войти в город");
            locations_info["loc.zsv"].ways.Add("loc.sd.1", "дорога на север");
            locations_info["loc.zsv"].ways.Add("loc.zb.1", "тропинка на запад");
            locations_info.Add("loc.zb.1", new _locationinfo("loc.zb.1", "Западный берег", false));
            locations_info["loc.zb.1"].Description = "Пропа ведет вдоль изгиба городской стены, на юго-западе видна река, а на севере сплошной стеной встает лес.";
            locations_info["loc.zb.1"].ways.Add("loc.zsv", "к северным воротам");
            locations_info["loc.zb.1"].ways.Add("loc.zl.3", "лес на север");
            locations_info["loc.zb.1"].ways.Add("loc.zb.2", "тропа на юг");
            locations_info.Add("loc.zb.2", new _locationinfo("loc.zb.2", "Западный берег", false));
            locations_info["loc.zb.2"].Description = "Река с запада поворачивает на юг, тропинка идет на север и на юг между городской стеной и рекой.";
            locations_info["loc.zb.2"].ways.Add("loc.zb.1", "тропа на север");
            locations_info["loc.zb.2"].ways.Add("loc.zb.3", "тропа на юг");
            locations_info.Add("loc.zb.3", new _locationinfo("loc.zb.3", "Западный берег", false));
            locations_info["loc.zb.3"].Description = "Тропа идет на север и юг, зажатая между городской стеной и рекой.";
            locations_info["loc.zb.3"].ways.Add("loc.zb.2", "тропа на севере");
            locations_info["loc.zb.3"].ways.Add("loc.zb.4", "тропа на юг");
            locations_info.Add("loc.zb.4", new _locationinfo("loc.zb.4", "Западный берег", false));
            locations_info["loc.zb.4"].Description = "Городская стена и река делают поворот на север и восток, тропинка огибает излучину реки.";
            locations_info["loc.zb.4"].ways.Add("loc.zb.3", "тропа на север");
            locations_info["loc.zb.4"].ways.Add("loc.zb.5", "тропа на восток");
            locations_info.Add("loc.zb.5", new _locationinfo("loc.zb.5", "Западный берег", false));
            locations_info["loc.zb.5"].Description = "Городская стена и река идут на запад и восток, поросшая травой тропинка, петляя, стелется вдоль берега и скрывается за поворотом. На востоке видна пристань и за ней южные ворота.";
            locations_info["loc.zb.5"].ways.Add("loc.zb.4", "тропа на запад");
            locations_info["loc.zb.5"].ways.Add("loc.pristan", "пристань на восток");
            locations_info.Add("loc.pristan", new _locationinfo("loc.pristan", "Пристань", true));
            locations_info["loc.pristan"].Description = "Пристань над рекой, на востоке расположен порт, а на запад вдоль городской стены вьется небольшая поросшая травой тропинка. На севере южные ворота в город.";
            locations_info["loc.pristan"].ways.Add("loc.uv", "войти в город");
            locations_info["loc.pristan"].ways.Add("loc.zb.5", "тропа на запад");
            locations_info["loc.pristan"].ways.Add("loc.port1", "в порт");
            locations_info.Add("loc.port1", new _locationinfo("loc.port1", "Порт", true));
            locations_info["loc.port1"].Description = "Портовая площадь завалена пустыми ящиками и мусором, и тянется на восток, на западе расположена пристань и южные ворота.";
            locations_info["loc.port1"].ways.Add("loc.pristan", "на пристань");
            locations_info["loc.port1"].ways.Add("loc.port2", "на восток");
            locations_info.Add("loc.port2", new _locationinfo("loc.port2", "Порт", false));
            locations_info["loc.port2"].Description = "Порт оканчивается у юго-восточной части города, дальше на востоке начинается болотистая местность, поросшая кустарником и кривыми низкими деревьями. На западе лежит пристань, а еще дальше южные городские ворота.";
            locations_info["loc.port2"].ways.Add("loc.bl.1", "в лес на востоке");
            locations_info["loc.port2"].ways.Add("loc.port1", "на запад");
            locations_info.Add("loc.ak", new _locationinfo("loc.ak", "Академия", true));
            locations_info["loc.ak"].Description = "Вы в парадном зале Академии, здесь очень светло благодаря сотням свечей в позолоченных канделябрах под потолком, вдоль стен стоят мраморные статуи волшебных существ в полный рост, в воздухе разлито неяркое голубое сияние, иногда вспыхивают целы рои зеленых и красных огоньков. На востоке видна дверь в волшебный магазин, в дальней части зала вход в библиотеку, в западной части в зал монстрологии, а у дальней стены видна лестница на второй этаж.";
            locations_info["loc.ak"].ways.Add("loc.ak1", "выйти на улицу");
            locations_info["loc.ak"].ways.Add("loc.ak4", "войти в магазин");
            locations_info["loc.ak"].ways.Add("loc.ak2", "в библиотеку");
            locations_info["loc.ak"].ways.Add("loc.ak5", "в зал монстрологии");
            locations_info["loc.ak"].ways.Add("loc.ak3", "на второй этаж");
            locations_info.Add("loc.ak4", new _locationinfo("loc.ak4", "Волшебный магазин", true));
            locations_info["loc.ak4"].Description = "Вы в волшебном магазине Академии, на столах разложены колбы с красными, зелеными и синими напитками, в воздухе пахнет экзотическими сушеными травами, а на главной стойке в неясном свете масляной лампадки тускло поблескивают амулеты и обереги.";
            locations_info["loc.ak4"].ways.Add("loc.ak", "выйти в парадный зал");
            locations_info.Add("loc.ak2", new _locationinfo("loc.ak2", "Библиотека", true));
            locations_info["loc.ak2"].Description = "Библиотека Академии не зря славится на весь мир: тысячи книг на сотнях полок в тесно заставленных рядах шкафов. Здесь есть как новейшие, только что из-под пера, так и древние тома, готовые рассыпаться прахом при одном прикосновении.";
            locations_info["loc.ak2"].ways.Add("loc.ak", "выйти в парадный зал");
            locations_info.Add("loc.ak5", new _locationinfo("loc.ak5", "Зал монстрологии", true));
            locations_info["loc.ak5"].Description = "В просторном помещении вдоль стены расставлены чучела странных существ, а на самих стенах весят красочные гобелены с изображениями далеких стран и необычных животных.";
            locations_info["loc.ak5"].ways.Add("loc.ak", "выйти в парадный зал");
            locations_info.Add("loc.ak3", new _locationinfo("loc.ak3", "Академия", true));
            locations_info["loc.ak3"].Description = "На втором этаже всего один зал, но зато огромный, с мраморным полом и хорошо освещенный. По всему залу рассыпались группы магов и учеников, стоит гул от произносимых заклинаний, временами раздаются хлопки, а цветные витражи на высоких окнах бликуют снопами разноцветных искр.";
            locations_info["loc.ak3"].ways.Add("loc.ak", "спуститься на первый этаж");
            locations_info.Add("loc.cpl", new _locationinfo("loc.cpl", "Центральная площадь", true));
            locations_info["loc.cpl"].Description = "Вы на центральной площади, на западе расположен двор рыцарей, на северо-востоке банк, который можно обойти с двух сторон - севера и востока.";
            locations_info["loc.cpl"].ways.Add("loc.bank2", "к банку на север");
            locations_info["loc.cpl"].ways.Add("loc.bank1", "к банку на восток");
            locations_info["loc.cpl"].ways.Add("loc.dvr", "во двор рыцарей");
            locations_info.Add("loc.dvr", new _locationinfo("loc.dvr", "Двор рыцарей", true));
            locations_info["loc.dvr"].Description = "Перед вами большой двор, огороженный забором, прямо стоит большое здание с широким крыльцом, на севере здание поменьше, а на юге видны очертания ристалища.";
            locations_info["loc.dvr"].ways.Add("loc.cpl", "выйти на площадь");
            locations_info["loc.dvr"].ways.Add("loc.dvr4", "войти в главное здание");
            locations_info["loc.dvr"].ways.Add("loc.dvr2", "войти в здание на севере");
            locations_info["loc.dvr"].ways.Add("loc.dvr1", "к ристалищу");
            locations_info.Add("loc.dvr2", new _locationinfo("loc.dvr2", "Двор рыцарей", true));
            locations_info["loc.dvr2"].Description = "Просторное помещение хорошо освещено, на столах разложены свитки, перья, чернильницы и тому подобные принадлежности.";
            locations_info["loc.dvr2"].ways.Add("loc.dvr", "выйти во двор");
            locations_info.Add("loc.dvr4", new _locationinfo("loc.dvr4", "Двор рыцарей", true));
            locations_info["loc.dvr4"].Description = "Обширное помещение освещается свечами в канделябрах, на окнах роскошные дорогие шторы, прямо посередине комнаты стоит огромный прямоугольный стол, а по краям несколько десятков деревянных стульев с высокой спинкой.";
            locations_info["loc.dvr4"].ways.Add("loc.dvr", "выйти во двор");
            locations_info.Add("loc.dvr1", new _locationinfo("loc.dvr1", "Ристалище", true));
            locations_info["loc.dvr1"].Description = "Ристалище представляет собой большую хорошо утоптанную овальную площадь, огороженную редким забором со скамьями для зрителей по бокам. Здесь проводят турниры и объезжают лошадей. В дальнем углу ристалища слышен звон мечей, похоже там тренируются воины. А в другом углу стоят мишени для стрельбы из лука.";
            locations_info["loc.dvr1"].ways.Add("loc.dvr", "выйти во двор");
            locations_info["loc.dvr1"].ways.Add("loc.dvr5", "подойти к мечникам");
            locations_info["loc.dvr1"].ways.Add("loc.dvr3", "подойти к мишеням");
            locations_info.Add("loc.dvr5", new _locationinfo("loc.dvr5", "Ристалище", true));
            locations_info["loc.dvr5"].Description = "В этом углу ристалища несколько человек, разбившись по парам, оттачивают воинское искусство. В другом углу виден ряд мишеней для стрельбы из лука.";
            locations_info["loc.dvr5"].ways.Add("loc.dvr1", "ко входу в ристалище");
            locations_info["loc.dvr5"].ways.Add("loc.dvr3", "подойти к мишеням");
            locations_info.Add("loc.dvr3", new _locationinfo("loc.dvr3", "Ристалище", true));
            locations_info["loc.dvr3"].Description = "Несколько мишеней для стрельбы из лука стоят в ряд, на земле под ногами валяются сломанные стрелы. Еще несколько торчат в бревнах забора. В другом углу ристалища слышен звон мечей тренирующихся воинов.";
            locations_info["loc.dvr3"].ways.Add("loc.dvr1", "ко входу в ристалище");
            locations_info["loc.dvr3"].ways.Add("loc.dvr5", "подойти к мечникам");
            locations_info.Add("loc.bl.1", new _locationinfo("loc.bl.1", "Болотный лес", false));
            locations_info["loc.bl.1"].Description = "Вы стоите за городскими стенами на юго-востоке от города. На запад идет дорога в порт. На юге течет река. На север и восток простирается болотный лес.";
            locations_info["loc.bl.1"].ways.Add("loc.bl.3", "север");
            locations_info["loc.bl.1"].ways.Add("loc.bl.2", "восток");
            locations_info["loc.bl.1"].ways.Add("loc.port2", "на запад в порт");
            locations_info.Add("loc.bl.2", new _locationinfo("loc.bl.2", "Болотный лес", false));
            locations_info["loc.bl.2"].Description = "Вы в болотном лесу, под ногами хлюпает жижа, квакают лягушки. На юге река, город на западе.";
            locations_info["loc.bl.2"].ways.Add("loc.bl.4", "север");
            locations_info["loc.bl.2"].ways.Add("loc.vl.1", "восток");
            locations_info["loc.bl.2"].ways.Add("loc.bl.1", "запад");
            locations_info.Add("loc.bl.3", new _locationinfo("loc.bl.3", "Болотный лес", false));
            locations_info["loc.bl.3"].Description = "Вы в болотном лесу, на западе лес вплотную подходит к городской стене.";
            locations_info["loc.bl.3"].ways.Add("loc.bl.5", "север");
            locations_info["loc.bl.3"].ways.Add("loc.bl.4", "восток");
            locations_info["loc.bl.3"].ways.Add("loc.bl.1", "юг");
            locations_info.Add("loc.bl.4", new _locationinfo("loc.bl.4", "Болотный лес", false));
            locations_info["loc.bl.4"].Description = "Вы в болотном лесу, под ногами хлюпает жижа, квакают лягушки. На северо-востоке виден темный овраг.";
            locations_info["loc.bl.4"].ways.Add("loc.bl.6", "север");
            locations_info["loc.bl.4"].ways.Add("loc.vl.4", "восток");
            locations_info["loc.bl.4"].ways.Add("loc.bl.2", "юг");
            locations_info["loc.bl.4"].ways.Add("loc.bl.3", "запад");
            locations_info.Add("loc.bl.5", new _locationinfo("loc.bl.5", "Болотный лес", false));
            locations_info["loc.bl.5"].Description = "Вы в болотном лесу за восточной стеной города.";
            locations_info["loc.bl.5"].ways.Add("loc.bl.7", "север");
            locations_info["loc.bl.5"].ways.Add("loc.bl.6", "восток");
            locations_info["loc.bl.5"].ways.Add("loc.bl.3", "юг");
            locations_info.Add("loc.bl.6", new _locationinfo("loc.bl.6", "Болотный лес", false));
            locations_info["loc.bl.6"].Description = "Вы на краю темного сырого оврага, за которым на востоке виден нормальный сухой лес. Овраг тянется на север.";
            locations_info["loc.bl.6"].ways.Add("loc.bl.8", "север");
            locations_info["loc.bl.6"].ways.Add("loc.vl.7", "перейти овраг восток");
            locations_info["loc.bl.6"].ways.Add("loc.bl.4", "юг");
            locations_info["loc.bl.6"].ways.Add("loc.bl.5", "на запад");
            locations_info.Add("loc.bl.7", new _locationinfo("loc.bl.7", "Болотный лес", false));
            locations_info["loc.bl.7"].Description = "Вы в болотном лесу за восточной стеной города.";
            locations_info["loc.bl.7"].ways.Add("loc.vl.13", "север");
            locations_info["loc.bl.7"].ways.Add("loc.bl.8", "восток");
            locations_info["loc.bl.7"].ways.Add("loc.bl.5", "юг");
            locations_info.Add("loc.bl.8", new _locationinfo("loc.bl.8", "Болотный лес", false));
            locations_info["loc.bl.8"].Description = "Вы на краю темного сырого оврага, за которым на востоке виден нормальный сухой лес. Овраг тянется на юг.";
            locations_info["loc.bl.8"].ways.Add("loc.vl.14", "север");
            locations_info["loc.bl.8"].ways.Add("loc.vl.10", "перейти овраг на восток");
            locations_info["loc.bl.8"].ways.Add("loc.bl.6", "юг");
            locations_info["loc.bl.8"].ways.Add("loc.bl.7", "запад");
            locations_info.Add("loc.kl.1", new _locationinfo("loc.kl.1", "Кладбище", false));
            locations_info["loc.kl.1"].Description = "Вы в начале кладбища, на юге калитка, выводящая на дорогу, на севере видно крупное серое каменное строение с небольшим двориком, огороженном решеткой с калиткой посередине. На востоке ряд могил.";
            locations_info["loc.kl.1"].ways.Add("loc.vd.2", "выйти на дорогу");
            locations_info["loc.kl.1"].ways.Add("loc.kl.8", "войти в калитку");
            locations_info["loc.kl.1"].ways.Add("loc.kl.2", "восток");
            locations_info["loc.kl.1"].ways.Add("loc.kl.15", "запад");
            locations_info.Add("loc.kl.2", new _locationinfo("loc.kl.2", "Кладбище", false));
            locations_info["loc.kl.2"].Description = "Вы идете среди полураскопанных могил вдоль южной ограды кладбища, на востоке стоит какое-то здание, на западе калитка на дорогу.";
            locations_info["loc.kl.2"].ways.Add("loc.kl.7", "север");
            locations_info["loc.kl.2"].ways.Add("loc.kl.3", "вдоль ограды на восток");
            locations_info["loc.kl.2"].ways.Add("loc.kl.1", "к калитке на запад");
            locations_info.Add("loc.kl.3", new _locationinfo("loc.kl.3", "Кладбище", false));
            locations_info["loc.kl.3"].Description = "На востоке темнеет черный провал входа в одноэтажную каменную усыпальницу, с юга вокруг вас ряды могил.";
            locations_info["loc.kl.3"].ways.Add("loc.kl.4", "войти в усыпальницу");
            locations_info["loc.kl.3"].ways.Add("loc.kl.2", "вдоль ограды на запад");
            locations_info["loc.kl.3"].ways.Add("loc.kl.6", "север");
            locations_info.Add("loc.kl.4", new _locationinfo("loc.kl.4", "Кладбище", false));
            locations_info["loc.kl.4"].Description = "Вы внутри усыпальницы на юго-востоке кладбища. Здесь ничего нет, кроме кучи пыли и нескольких полуистлевших костей на полу в углу.";
            locations_info["loc.kl.4"].ways.Add("loc.kl.3", "выйти");
            locations_info.Add("loc.kl.5", new _locationinfo("loc.kl.5", "Кладбище", false));
            locations_info["loc.kl.5"].Description = "Вы между двумя усыпальницами на востоке кладбища вплотную к ограде. Жесткая желтованая трава покрывает неровную изрытую почту.";
            locations_info["loc.kl.5"].ways.Add("loc.kl.6", "запад");
            locations_info.Add("loc.kl.6", new _locationinfo("loc.kl.6", "Кладбище", false));
            locations_info["loc.kl.6"].Description = "На северо-востоке и юго-востоке видны два одинаковых серых здания, на юге ровные ряды могил.";
            locations_info["loc.kl.6"].ways.Add("loc.kl.24", "север");
            locations_info["loc.kl.6"].ways.Add("loc.kl.5", "восток");
            locations_info["loc.kl.6"].ways.Add("loc.kl.3", "юг");
            locations_info["loc.kl.6"].ways.Add("loc.kl.7", "запад");
            locations_info.Add("loc.kl.7", new _locationinfo("loc.kl.7", "Кладбище", false));
            locations_info["loc.kl.7"].Description = "Вы с восточной стороны от дворика перед цельтральным зданием, огороженного решеткой из железных прутьев. На юге ряд могил.";
            locations_info["loc.kl.7"].ways.Add("loc.kl.23", "север");
            locations_info["loc.kl.7"].ways.Add("loc.kl.6", "восток");
            locations_info["loc.kl.7"].ways.Add("loc.kl.2", "юг");
            locations_info.Add("loc.kl.8", new _locationinfo("loc.kl.8", "Кладбище", false));
            locations_info["loc.kl.8"].Description = "Вы внутри дворика перед центральным каменным зданием, из черного провала дует ледяной сквозняк с подозрительным запахом.";
            locations_info["loc.kl.8"].ways.Add("loc.kl.20", "войти в здание");
            locations_info["loc.kl.8"].ways.Add("loc.kl.1", "выйти в калитку на юге");
            locations_info.Add("loc.kl.9", new _locationinfo("loc.kl.9", "Кладбище", false));
            locations_info["loc.kl.9"].Description = "Вы с западной части дворика перед центральным зданием. На западе видно неболшое болотце, заросшее камышом и кувшинками.";
            locations_info["loc.kl.9"].ways.Add("loc.kl.19", "север");
            locations_info["loc.kl.9"].ways.Add("loc.kl.15", "юг");
            locations_info["loc.kl.9"].ways.Add("loc.kl.10", "запад");
            locations_info.Add("loc.kl.10", new _locationinfo("loc.kl.10", "Кладбище", false));
            locations_info["loc.kl.10"].Description = "Вы на берегу небольшого болотца, почти полностью заросшего камышом, в черной зеркальной воде плавают цветут несколько кувшинок.";
            locations_info["loc.kl.10"].ways.Add("loc.kl.18", "север");
            locations_info["loc.kl.10"].ways.Add("loc.kl.9", "восток");
            locations_info["loc.kl.10"].ways.Add("loc.kl.14", "юг");
            locations_info.Add("loc.kl.11", new _locationinfo("loc.kl.11", "Кладбище", false));
            locations_info["loc.kl.11"].Description = "Вы между забором и болотцем на западной части кладбища, отсюда есть только путь к северу или югу.";
            locations_info["loc.kl.11"].ways.Add("loc.kl.16", "вдоль забора на север");
            locations_info["loc.kl.11"].ways.Add("loc.kl.12", "вдоль забора на юг");
            locations_info.Add("loc.kl.12", new _locationinfo("loc.kl.12", "Кладбище", false));
            locations_info["loc.kl.12"].Description = "Вы в юго-западном углу кладбища, черные наконечники железных пуртьев забора угрожающе торчат из листьев какого-то кустарника, растущего вдоль всего забора. На севере видно небольшое болотце.";
            locations_info["loc.kl.12"].ways.Add("loc.kl.11", "вдоль забора на север");
            locations_info["loc.kl.12"].ways.Add("loc.kl.13", "вдоль забора на восток");
            locations_info.Add("loc.kl.13", new _locationinfo("loc.kl.13", "Кладбище", false));
            locations_info["loc.kl.13"].Description = "Вы между забором на юге и болотцем на севере";
            locations_info["loc.kl.13"].ways.Add("loc.kl.14", "вдоль забора восток");
            locations_info["loc.kl.13"].ways.Add("loc.kl.12", "вдоль забора запад");
            locations_info.Add("loc.kl.14", new _locationinfo("loc.kl.14", "Кладбище", false));
            locations_info["loc.kl.14"].Description = "Вы у южной ограды кладбища, на востоке видна калитка на дорогу, а на северо-западе небольшое болотце.";
            locations_info["loc.kl.14"].ways.Add("loc.kl.10", "север");
            locations_info["loc.kl.14"].ways.Add("loc.kl.15", "восток");
            locations_info["loc.kl.14"].ways.Add("loc.kl.13", "запад");
            locations_info.Add("loc.kl.15", new _locationinfo("loc.kl.15", "Кладбище", false));
            locations_info["loc.kl.15"].Description = "Вы у южной ограды кладбища. На северо-востоке видно большое серое здание.";
            locations_info["loc.kl.15"].ways.Add("loc.kl.9", "север");
            locations_info["loc.kl.15"].ways.Add("loc.kl.1", "восток");
            locations_info["loc.kl.15"].ways.Add("loc.kl.14", "запад");
            locations_info.Add("loc.kl.16", new _locationinfo("loc.kl.16", "Кладбище", false));
            locations_info["loc.kl.16"].Description = "Вы у западного забора кладбища, на юге видно небольшое болотце.";
            locations_info["loc.kl.16"].ways.Add("loc.kl.33", "север");
            locations_info["loc.kl.16"].ways.Add("loc.kl.17", "восток");
            locations_info["loc.kl.16"].ways.Add("loc.kl.11", "юг");
            locations_info.Add("loc.kl.17", new _locationinfo("loc.kl.17", "Кладбище", false));
            locations_info["loc.kl.17"].Description = "Вы на северном берегу болотца, заросшего камышом и кувшинками.";
            locations_info["loc.kl.17"].ways.Add("loc.kl.32", "север");
            locations_info["loc.kl.17"].ways.Add("loc.kl.18", "восток");
            locations_info["loc.kl.17"].ways.Add("loc.kl.16", "запад");
            locations_info.Add("loc.kl.18", new _locationinfo("loc.kl.18", "Кладбище", false));
            locations_info["loc.kl.18"].Description = "На юго-западе виднеется болотце, на востоке стена каменного здания.";
            locations_info["loc.kl.18"].ways.Add("loc.kl.31", "север");
            locations_info["loc.kl.18"].ways.Add("loc.kl.19", "восток");
            locations_info["loc.kl.18"].ways.Add("loc.kl.10", "юг");
            locations_info["loc.kl.18"].ways.Add("loc.kl.17", "запад");
            locations_info.Add("loc.kl.19", new _locationinfo("loc.kl.19", "Кладбище", false));
            locations_info["loc.kl.19"].Description = "Вы около стены каменного серого здания, под самой стеной свалена куча проволоки и каких-то железок, все вместе сильно заросшее крапивой.";
            locations_info["loc.kl.19"].ways.Add("loc.kl.30", "север");
            locations_info["loc.kl.19"].ways.Add("loc.kl.9", "юг");
            locations_info["loc.kl.19"].ways.Add("loc.kl.18", "запад");
            locations_info.Add("loc.kl.20", new _locationinfo("loc.kl.20", "Кладбище", false));
            locations_info["loc.kl.20"].Description = "Вы во внутреннем помещении центрального здания. Здесь две двери. Повсюду лежат кучи пыли и царит затхлый воздух.";
            locations_info["loc.kl.20"].ways.Add("loc.kl.22", "войти в северную дверь");
            locations_info["loc.kl.20"].ways.Add("loc.kl.21", "войти в восточную дверь");
            locations_info["loc.kl.20"].ways.Add("loc.kl.8", "выйти на улицу");
            locations_info.Add("loc.kl.21", new _locationinfo("loc.kl.21", "Кладбище", false));
            locations_info["loc.kl.21"].Description = "Вы в небольшом грязном помещении с каменным полом и единственной дверью";
            locations_info["loc.kl.21"].ways.Add("loc.kl.20", "выйти");
            locations_info.Add("loc.kl.22", new _locationinfo("loc.kl.22", "Кладбище", false));
            locations_info["loc.kl.22"].Description = "Вы в небольшом грязном помещении с каменным полом и единственной дверью";
            locations_info["loc.kl.22"].ways.Add("loc.kl.20", "выйти");
            locations_info.Add("loc.kl.23", new _locationinfo("loc.kl.23", "Кладбище", false));
            locations_info["loc.kl.23"].Description = "Вы у восточной стены центрального здания, на востоке видно небольшое строение.";
            locations_info["loc.kl.23"].ways.Add("loc.kl.28", "север");
            locations_info["loc.kl.23"].ways.Add("loc.kl.24", "восток");
            locations_info["loc.kl.23"].ways.Add("loc.kl.7", "юг");
            locations_info.Add("loc.kl.24", new _locationinfo("loc.kl.24", "Кладбище", false));
            locations_info["loc.kl.24"].Description = "Вы у входа в одноэтажную усыпальницу на востоке, на земле видны отпечатки множества ног.";
            locations_info["loc.kl.24"].ways.Add("loc.kl.25", "войти в усыпальницу");
            locations_info["loc.kl.24"].ways.Add("loc.kl.27", "север");
            locations_info["loc.kl.24"].ways.Add("loc.kl.6", "юг");
            locations_info["loc.kl.24"].ways.Add("loc.kl.23", "запад");
            locations_info.Add("loc.kl.25", new _locationinfo("loc.kl.25", "Кладбище", false));
            locations_info["loc.kl.25"].Description = "Вы внутри каменной усыпальницы. Пол завален клочками бумаги и прошлогодними листьями.";
            locations_info["loc.kl.25"].ways.Add("loc.kl.24", "выйти на улицу");
            locations_info.Add("loc.kl.26", new _locationinfo("loc.kl.26", "Кладбище", false));
            locations_info["loc.kl.26"].Description = "Вы между двумя усыпальницами и восточным забором кладбища. Отсюда только один уть - на запад.";
            locations_info["loc.kl.26"].ways.Add("loc.kl.27", "запад");
            locations_info.Add("loc.kl.27", new _locationinfo("loc.kl.27", "Кладбище", false));
            locations_info["loc.kl.27"].Description = "Вы стоите около трех одинаково выглядящих каменных усыпальниц - на северо-западе, северо-востоке и юго-востоке. Между зданиями есть небольшие проходы.";
            locations_info["loc.kl.27"].ways.Add("loc.kl.42", "север");
            locations_info["loc.kl.27"].ways.Add("loc.kl.26", "восток");
            locations_info["loc.kl.27"].ways.Add("loc.kl.24", "юг");
            locations_info["loc.kl.27"].ways.Add("loc.kl.28", "запад");
            locations_info.Add("loc.kl.28", new _locationinfo("loc.kl.28", "Кладбище", false));
            locations_info["loc.kl.28"].Description = "Вы у входа в каменную усыпальницу на севере, с юго-запада видна задняя стена центрального здания.";
            locations_info["loc.kl.28"].ways.Add("loc.kl.40", "войти в усыпальницу");
            locations_info["loc.kl.28"].ways.Add("loc.kl.27", "восток");
            locations_info["loc.kl.28"].ways.Add("loc.kl.23", "юг");
            locations_info["loc.kl.28"].ways.Add("loc.kl.29", "запад");
            locations_info.Add("loc.kl.29", new _locationinfo("loc.kl.29", "Кладбище", false));
            locations_info["loc.kl.29"].Description = "Вы у северной стены центрального здания, на северо-западе и северо-востоке стоят похожие одноэтажные каменные здания, между которыми можно пройти.";
            locations_info["loc.kl.29"].ways.Add("loc.kl.39", "север");
            locations_info["loc.kl.29"].ways.Add("loc.kl.28", "восток");
            locations_info["loc.kl.29"].ways.Add("loc.kl.30", "запад");
            locations_info.Add("loc.kl.30", new _locationinfo("loc.kl.30", "Кладбище", false));
            locations_info["loc.kl.30"].Description = "Вы перед входом в каменное строение, похожее на гробницу, с юго-востока выступает угол центрального здания.";
            locations_info["loc.kl.30"].ways.Add("loc.kl.37", "войти в строение");
            locations_info["loc.kl.30"].ways.Add("loc.kl.29", "восток");
            locations_info["loc.kl.30"].ways.Add("loc.kl.19", "юг");
            locations_info["loc.kl.30"].ways.Add("loc.kl.31", "запад");
            locations_info.Add("loc.kl.31", new _locationinfo("loc.kl.31", "Кладбище", false));
            locations_info["loc.kl.31"].Description = "Вы в северо-западной части кладбища, на северо-востоке стоит каменное здание.";
            locations_info["loc.kl.31"].ways.Add("loc.kl.36", "север");
            locations_info["loc.kl.31"].ways.Add("loc.kl.30", "восток");
            locations_info["loc.kl.31"].ways.Add("loc.kl.18", "юг");
            locations_info["loc.kl.31"].ways.Add("loc.kl.32", "запад");
            locations_info.Add("loc.kl.32", new _locationinfo("loc.kl.32", "Кладбище", false));
            locations_info["loc.kl.32"].Description = "Вы в северо-западной части кладбища.";
            locations_info["loc.kl.32"].ways.Add("loc.kl.35", "север");
            locations_info["loc.kl.32"].ways.Add("loc.kl.31", "восток");
            locations_info["loc.kl.32"].ways.Add("loc.kl.17", "юг");
            locations_info["loc.kl.32"].ways.Add("loc.kl.33", "запад");
            locations_info.Add("loc.kl.33", new _locationinfo("loc.kl.33", "Кладбище", false));
            locations_info["loc.kl.33"].Description = "Вы у западной ограды кладбища. Рядом с забором лежит каменная надгробная плита внушительных размеров. У изголовья стоит обколотый обелиск в пол человеческого роста. Мраморная табличка разбита на две части, на той что осталась, выбиты какие-то руны.";
            locations_info["loc.kl.33"].ways.Add("loc.kl.34", "север");
            locations_info["loc.kl.33"].ways.Add("loc.kl.32", "восток");
            locations_info["loc.kl.33"].ways.Add("loc.kl.16", "юг");
            locations_info.Add("loc.kl.34", new _locationinfo("loc.kl.34", "Кладбище", false));
            locations_info["loc.kl.34"].Description = "Вы в самом северо-западном углу кладбища. За оградой начинается друмучий темный лес.";
            locations_info["loc.kl.34"].ways.Add("loc.kl.35", "вдоль ограды на восток");
            locations_info["loc.kl.34"].ways.Add("loc.kl.33", "вдоль ограды на юг");
            locations_info.Add("loc.kl.35", new _locationinfo("loc.kl.35", "Кладбище", false));
            locations_info["loc.kl.35"].Description = "Вы у северной ограды кладбища.";
            locations_info["loc.kl.35"].ways.Add("loc.kl.36", "восток");
            locations_info["loc.kl.35"].ways.Add("loc.kl.32", "юг");
            locations_info["loc.kl.35"].ways.Add("loc.kl.34", "запад");
            locations_info.Add("loc.kl.36", new _locationinfo("loc.kl.36", "Кладбище", false));
            locations_info["loc.kl.36"].Description = "На востоке стоит каменное сооружение, на севере ограда кладбища.";
            locations_info["loc.kl.36"].ways.Add("loc.kl.31", "юг");
            locations_info["loc.kl.36"].ways.Add("loc.kl.35", "запад");
            locations_info.Add("loc.kl.37", new _locationinfo("loc.kl.37", "Кладбище", false));
            locations_info["loc.kl.37"].Description = "Вы внутри строения, в полумраке у дальней стены видна темная деревянная дверь.";
            locations_info["loc.kl.37"].ways.Add("loc.kl.38", "войти в дверь");
            locations_info["loc.kl.37"].ways.Add("loc.kl.30", "выйти на улицу");
            locations_info.Add("loc.kl.38", new _locationinfo("loc.kl.38", "Кладбище", false));
            locations_info["loc.kl.38"].Description = "В углу виден круглый лаз, ведущий куда-то вниз в темноту. К сожалению, лаз придавлен неподъемной каменной плитой, так что сейчас в него не пролезть.";
            locations_info["loc.kl.38"].ways.Add("loc.kl.37", "выйти");
            locations_info.Add("loc.kl.39", new _locationinfo("loc.kl.39", "Кладбище", false));
            locations_info["loc.kl.39"].Description = "Вы между двумя зданиями и оградой на севере кладбища, отсюда можно выйти только на юг.";
            locations_info["loc.kl.39"].ways.Add("loc.kl.29", "юг");
            locations_info.Add("loc.kl.40", new _locationinfo("loc.kl.40", "Кладбище", false));
            locations_info["loc.kl.40"].Description = "Вы в полутемном помещении, кажется, солнечные лучи сюда таинственным  образом не проходят, хотя двери на входе нет. В дальней стене видны очертания двери.";
            locations_info["loc.kl.40"].ways.Add("loc.kl.41", "войти в дверь");
            locations_info["loc.kl.40"].ways.Add("loc.kl.28", "выйти на улицу");
            locations_info.Add("loc.kl.41", new _locationinfo("loc.kl.41", "Кладбище", false));
            locations_info["loc.kl.41"].Description = "Вы во внутреннем помещении склепа, каменный пол и полное отсутствие света.";
            locations_info["loc.kl.41"].ways.Add("loc.kl.40", "выйти");
            locations_info.Add("loc.kl.42", new _locationinfo("loc.kl.42", "Кладбище", false));
            locations_info["loc.kl.42"].Description = "Вы в северо-восточной части кладбища между двумя зданиями, на востоке от вас темнее черный провал входа в склеп, а на западе сплошная стена. На севере ограда кладбища.";
            locations_info["loc.kl.42"].ways.Add("loc.kl.43", "войти в склеп");
            locations_info["loc.kl.42"].ways.Add("loc.kl.27", "юг");
            locations_info.Add("loc.kl.43", new _locationinfo("loc.kl.43", "Кладбище", false));
            locations_info["loc.kl.43"].Description = "Склеп изнутри выложен камнем, на стенах видны странные иероглифы, а углы затянуты сплошной паутиной.";
            locations_info["loc.kl.43"].ways.Add("loc.kl.42", "выйти на улицу");
            locations_info.Add("loc.sd.1", new _locationinfo("loc.sd.1", "Северная дорога", false));
            locations_info["loc.sd.1"].Description = "Дорога идет на север, на юге расположены северные ворота, с запада подступает лес, а на востоке видно небольшое озеро.";
            locations_info["loc.sd.1"].ways.Add("loc.sl.1", "дорога на север");
            locations_info["loc.sd.1"].ways.Add("loc.zsv", "к северным воротам");
            locations_info["loc.sd.1"].ways.Add("loc.sd.2", "к озеру на восток");
            locations_info["loc.sd.1"].ways.Add("loc.zl.1", "лес на западе");
            locations_info.Add("loc.sd.2", new _locationinfo("loc.sd.2", "Северная дорога", false));
            locations_info["loc.sd.2"].Description = "Дорога идет на север и юг мимо большого каменного дома на востоке. На западе сплошной стеной стоит лес.";
            locations_info["loc.sd.2"].ways.Add("loc.kzd", "войти в дом");
            locations_info["loc.sd.2"].ways.Add("loc.sd.3", "дорога на север");
            locations_info["loc.sd.2"].ways.Add("loc.sd.1", "дорога на юг");
            locations_info["loc.sd.2"].ways.Add("loc.zl.10", "на запад");
            locations_info.Add("loc.sd.3", new _locationinfo("loc.sd.3", "Северная дорога", false));
            locations_info["loc.sd.3"].Description = "Дорога идет на юг и север, причем на севере немного поворачивает к западу, по сторонам расстилается лес.";
            locations_info["loc.sd.3"].ways.Add("loc.sd.4", "дорога на север");
            locations_info["loc.sd.3"].ways.Add("loc.sl.9", "лес на востоке");
            locations_info["loc.sd.3"].ways.Add("loc.sd.2", "дорога на юг");
            locations_info["loc.sd.3"].ways.Add("loc.zl.11", "лес на западе");
            locations_info.Add("loc.sd.4", new _locationinfo("loc.sd.4", "Северная дорога", false));
            locations_info["loc.sd.4"].Description = "Дорога делает небольшой поворот на запад. Странно, но дальше какая-то сила не дает пройти. Возможно, стоит вернуться сюда в другое время?";
            locations_info["loc.sd.4"].ways.Add("loc.sd.3", "дорога на юг");
            locations_info["loc.sd.4"].ways.Add("loc.zl.12", "лес на западе");
            locations_info.Add("loc.kzd", new _locationinfo("loc.kzd", "Дом у дороги", false));
            locations_info["loc.kzd"].Description = "Вы внутри просторного дома, по стенам развешаны шкуры животных, в воздухе пахнет жареным мясом и дубленой кожей.";
            locations_info["loc.kzd"].ways.Add("loc.sd.2", "выйти на улицу");
            locations_info.Add("loc.sl.1", new _locationinfo("loc.sl.1", "Северный лес", false));
            locations_info["loc.sl.1"].Description = "Редкий лес с преобладанием березок и осины, на западе видна дорога, на севере за деревьями какое-то каменное строение, а на востоке небольшое озеро можно обогнуть с двух сторон.";
            locations_info["loc.sl.1"].ways.Add("loc.sd.1", "дорога на севере");
            locations_info["loc.sl.1"].ways.Add("loc.sl.6", "обогнуть озеро с севера");
            locations_info["loc.sl.1"].ways.Add("loc.sl.2", "обогнуть озеро с юга");
            locations_info.Add("loc.sl.2", new _locationinfo("loc.sl.2", "Северный лес", false));
            locations_info["loc.sl.2"].Description = "Широкая полянка с мягкой низкой травой проходит между озером и северной городской стеной, на востоке виден небольшой пригорок.";
            locations_info["loc.sl.2"].ways.Add("loc.sl.3", "вдоль берега на восток");
            locations_info["loc.sl.2"].ways.Add("loc.sl.1", "лес на западе");
            locations_info.Add("loc.sl.3", new _locationinfo("loc.sl.3", "Северный лес", false));
            locations_info["loc.sl.3"].Description = "Вы находитесь на небольшом пригорке между озером и городской стеной, который ближе к западу сходит пологим спуском к самой воде. На востоке за лесом должны показаться восточные ворота.";
            locations_info["loc.sl.3"].ways.Add("loc.sl.2", "вдоль берега на запад");
            locations_info["loc.sl.3"].ways.Add("loc.sl.4", "на восток");
            locations_info.Add("loc.sl.4", new _locationinfo("loc.sl.4", "Северный лес", false));
            locations_info["loc.sl.4"].Description = "Светлое редколесье раскинулось между озером на западе и восточными воротами на востоке, здесь протоптана широкая тропа, очевидно, жители часто посещают этим места. Озеро на западе можно обогнуть с двух направлений. А на северо-востоке вздымаются каменные строения погоста.";
            locations_info["loc.sl.4"].ways.Add("loc.vd.1", "на дорогу к воротам");
            locations_info["loc.sl.4"].ways.Add("loc.vd.2", "на северо-восток");
            locations_info["loc.sl.4"].ways.Add("loc.sl.5", "обогнуть озеро с севера");
            locations_info["loc.sl.4"].ways.Add("loc.sl.3", "обогнуть озеро с юга");
            locations_info.Add("loc.sl.5", new _locationinfo("loc.sl.5", "Северный лес", false));
            locations_info["loc.sl.5"].Description = "Вы идете вдоль озера с северной стороны, здесь оно немного владется в берег, образуя небольшой залив. Ограда кладбища видна с востока и тянется на север. За ней проглядывает болотце, затянутое трясиной.";
            locations_info["loc.sl.5"].ways.Add("loc.sl.8", "на север вдоль забора");
            locations_info["loc.sl.5"].ways.Add("loc.sl.6", "вдоль берега на запад");
            locations_info["loc.sl.5"].ways.Add("loc.sl.4", "на юго-восток");
            locations_info.Add("loc.sl.6", new _locationinfo("loc.sl.6", "Северный лес", false));
            locations_info["loc.sl.6"].Description = "С этой части озеро заросло кустарником и камышами. Южные ворота находятся на юго-западе.";
            locations_info["loc.sl.6"].ways.Add("loc.sl.7", "в лес на севере");
            locations_info["loc.sl.6"].ways.Add("loc.sl.5", "вдоль берега на восток");
            locations_info["loc.sl.6"].ways.Add("loc.sl.1", "на юго-запад");
            locations_info.Add("loc.sl.7", new _locationinfo("loc.sl.7", "Северный лес", false));
            locations_info["loc.sl.7"].Description = "На западе сквозь деревья видна задняя стена какого-то здания, на юге находится озеро, а на север и восток тянется лес.";
            locations_info["loc.sl.7"].ways.Add("loc.sl.6", "к озеру");
            locations_info["loc.sl.7"].ways.Add("loc.sl.10", "север");
            locations_info["loc.sl.7"].ways.Add("loc.sl.8", "восток");
            locations_info.Add("loc.sl.8", new _locationinfo("loc.sl.8", "Северный лес", false));
            locations_info["loc.sl.8"].Description = "Вы рядом с оградой кладбища, поворачивающей с юга на восток. Из-за ограды доносится шорох, хотя из-за серых каменных плит ничего не разглядеть...";
            locations_info["loc.sl.8"].ways.Add("loc.sl.5", "на юг к озеру");
            locations_info["loc.sl.8"].ways.Add("loc.sl.11", "север");
            locations_info["loc.sl.8"].ways.Add("loc.sl.7", "запад");
            locations_info.Add("loc.sl.9", new _locationinfo("loc.sl.9", "Северный лес", false));
            locations_info["loc.sl.9"].Description = "Вы в северной части леса, на западе видна дорога. На юге стена какого-то каменнтого здания.";
            locations_info["loc.sl.9"].ways.Add("loc.sd.3", "дорога на западе");
            locations_info["loc.sl.9"].ways.Add("loc.sl.10", "на восток");
            locations_info.Add("loc.sl.10", new _locationinfo("loc.sl.10", "Северный лес", false));
            locations_info["loc.sl.10"].Description = "Кругом лес, сквозь который ничего не видно, но кажется на западе что-то есть...";
            locations_info["loc.sl.10"].ways.Add("loc.sl.11", "восток");
            locations_info["loc.sl.10"].ways.Add("loc.sl.7", "юг");
            locations_info["loc.sl.10"].ways.Add("loc.sl.9", "запад");
            locations_info.Add("loc.sl.11", new _locationinfo("loc.sl.11", "Северный лес", false));
            locations_info["loc.sl.11"].Description = "Кругом лес, сквозь который ничего не видно.";
            locations_info["loc.sl.11"].ways.Add("loc.sl.12", "восток");
            locations_info["loc.sl.11"].ways.Add("loc.sl.8", "юг");
            locations_info["loc.sl.11"].ways.Add("loc.sl.10", "запад");
            locations_info.Add("loc.sl.12", new _locationinfo("loc.sl.12", "Северный лес", false));
            locations_info["loc.sl.12"].Description = "Вы находитесь на северо-западном углу кладбища со стороны леса. За оградой видна одинокая могила с каким-то барельефом, отсюда не разобрать точно...";
            locations_info["loc.sl.12"].ways.Add("loc.sl.14", "восток");
            locations_info["loc.sl.12"].ways.Add("loc.sl.11", "запад");
            //locations.Add("loc.sl.13", new _locationinfo("loc.sl.13", "Северный лес", false));
            locations_info.Add("loc.sl.14", new _locationinfo("loc.sl.14", "Северный лес", false));
            locations_info["loc.sl.14"].Description = "Вы находитесь на северо-восточном углу кладбища, дальше на востоке видны вдалеке горы.";
            locations_info["loc.sl.14"].ways.Add("loc.sl.15", "восток");
            locations_info["loc.sl.14"].ways.Add("loc.sl.12", "запад");
            locations_info.Add("loc.sl.15", new _locationinfo("loc.sl.15", "Северный лес", false));
            locations_info["loc.sl.15"].Description = "Вы в северо-восточной части леса, на востоке желтеет наезженая дорога, а на западе сквозь ветки виден угол ограды кладбища";
            locations_info["loc.sl.15"].ways.Add("loc.vd.7", "дорога на востоке");
            locations_info["loc.sl.15"].ways.Add("loc.sl.16", "вдоль кладбища на юг");
            locations_info["loc.sl.15"].ways.Add("loc.sl.14", "вдоль кладбища на запад");
            locations_info.Add("loc.sl.16", new _locationinfo("loc.sl.16", "Северный лес", false));
            locations_info["loc.sl.16"].Description = "Вы идете перелесьем между дорогой на востоке и оградой кладбища на западе. Прямо за оградой высятся каменные погребальные сооружения, поэтому за их стенами нчиего не видно.";
            locations_info["loc.sl.16"].ways.Add("loc.vd.6", "дорога на востоке");
            locations_info["loc.sl.16"].ways.Add("loc.sl.15", "на север");
            locations_info["loc.sl.16"].ways.Add("loc.sl.17", "на юг");
            locations_info.Add("loc.sl.17", new _locationinfo("loc.sl.17", "Северный лес", false));
            locations_info["loc.sl.17"].Description = "Вы стоите на изгибе дороги, на западе от вас ограда кладбища.";
            locations_info["loc.sl.17"].ways.Add("loc.vd.5", "дорога на востоке");
            locations_info["loc.sl.17"].ways.Add("loc.vd.4", "дорога на юге");
            locations_info["loc.sl.17"].ways.Add("loc.sl.16", "на север");
            locations_info.Add("loc.vd.1", new _locationinfo("loc.vd.1", "Восточная дорога", false));
            locations_info["loc.vd.1"].Description = "Дорога идет на север и около кладбища поворачивает к востоку, обходя его вдоль ограды, на юге видны восточные ворота города, на востоке начинается лес, а на западе поблескивает небольшое озеро.";
            locations_info["loc.vd.1"].ways.Add("loc.vd.2", "дорога на севере");
            locations_info["loc.vd.1"].ways.Add("loc.vl.23", "лес на востоке");
            locations_info["loc.vd.1"].ways.Add("loc.zvv", "ворота на юге");
            locations_info["loc.vd.1"].ways.Add("loc.sl.4", "к озеру на западе");
            locations_info.Add("loc.vd.2", new _locationinfo("loc.vd.2", "Восточная дорога", false));
            locations_info["loc.vd.2"].Description = "Вы находитесь около входа на территорию кладбища. Из-за калитки доносятся какие-то завывания, вздохи и подозрительный скрежет. Дорога идет на юг и восток вдоль ограды.";
            locations_info["loc.vd.2"].ways.Add("loc.kl.1", "войти в калитку");
            locations_info["loc.vd.2"].ways.Add("loc.vd.3", "по дороге на восток");
            locations_info["loc.vd.2"].ways.Add("loc.vd.1", "по дороге на юг");
            locations_info["loc.vd.2"].ways.Add("loc.sl.4", "на запад");
            locations_info["loc.vd.2"].ways.Add("loc.vl.23", "в лес на юге");
            locations_info.Add("loc.vd.3", new _locationinfo("loc.vd.3", "Восточная дорога", false));
            locations_info["loc.vd.3"].Description = "Дорога идет на восток и запад вдоль ограды кладбища, из-за которой доносятся не внушающие особого оптимизма звуки. На юге начинается лес.";
            locations_info["loc.vd.3"].ways.Add("loc.vd.4", "дорога на восток");
            locations_info["loc.vd.3"].ways.Add("loc.vl.24", "лес на юге");
            locations_info["loc.vd.3"].ways.Add("loc.vd.2", "дорога на запад");
            locations_info.Add("loc.vd.4", new _locationinfo("loc.vd.4", "Восточная дорога", false));
            locations_info["loc.vd.4"].Description = "Дорога тянется на запад, а на востоке делает поворот к северу, кладбище на северо-западе, со всех остальных сторон начинается лес.";
            locations_info["loc.vd.4"].ways.Add("loc.sl.17", "север");
            locations_info["loc.vd.4"].ways.Add("loc.vd.5", "дорога на восток");
            locations_info["loc.vd.4"].ways.Add("loc.vl.25", "юг");
            locations_info["loc.vd.4"].ways.Add("loc.vd.3", "дорога на запад");
            locations_info.Add("loc.vd.5", new _locationinfo("loc.vd.5", "Восточная дорога", false));
            locations_info["loc.vd.5"].Description = "Дорога окружена лесом и идет на север в сторону гор, а на юге делает поворот к западу.";
            locations_info["loc.vd.5"].ways.Add("loc.vd.6", "дорога на север");
            locations_info["loc.vd.5"].ways.Add("loc.vl.28", "восток");
            locations_info["loc.vd.5"].ways.Add("loc.vd.4", "дорога на юг");
            locations_info["loc.vd.5"].ways.Add("loc.sl.17", "запад");
            locations_info.Add("loc.vd.6", new _locationinfo("loc.vd.6", "Восточная дорога", false));
            locations_info["loc.vd.6"].Description = "Дорога окружена со всех сторон лесом, на юге выступают горы.";
            locations_info["loc.vd.6"].ways.Add("loc.vd.7", "дорога на север");
            locations_info["loc.vd.6"].ways.Add("loc.vl.29", "восток");
            locations_info["loc.vd.6"].ways.Add("loc.vd.5", "дорога на юг");
            locations_info["loc.vd.6"].ways.Add("loc.sl.16", "запад");
            locations_info.Add("loc.vd.7", new _locationinfo("loc.vd.7", "Восточная дорога", false));
            locations_info["loc.vd.7"].Description = "Дорога упирается в пещеру, которая перегорожена грубой решеткой. Похоже, пока что туда не пройти...";
            locations_info["loc.vd.7"].ways.Add("loc.vl.30", "восток");
            locations_info["loc.vd.7"].ways.Add("loc.vd.6", "дорога на юг");
            locations_info["loc.vd.7"].ways.Add("loc.sl.15", "запад");
            locations_info.Add("loc.vl.1", new _locationinfo("loc.vl.1", "Восточный лес", false));
            locations_info["loc.vl.1"].Description = "Вы на границе болотного и восточного леса на востоке от города. Болотная трава постепенно сменяется более жесткой и низкой, а вдали среди подлеска уже вздымаются могучие дубы и ясени. На юге течет река.";
            locations_info["loc.vl.1"].ways.Add("loc.vl.4", "север");
            locations_info["loc.vl.1"].ways.Add("loc.vl.2", "восток");
            locations_info["loc.vl.1"].ways.Add("loc.bl.2", "запад");
            locations_info.Add("loc.vl.2", new _locationinfo("loc.vl.2", "Восточный лес", false));
            locations_info["loc.vl.2"].Description = "Вы в лесу на востоке от города. Вдали на востоке сереют скалы, а на западе лес спускается в болотистую низину. С южной стороны течет река.";
            locations_info["loc.vl.2"].ways.Add("loc.vl.5", "север");
            locations_info["loc.vl.2"].ways.Add("loc.vl.3", "восток");
            locations_info["loc.vl.2"].ways.Add("loc.vl.1", "запад");
            locations_info.Add("loc.vl.3", new _locationinfo("loc.vl.3", "Восточный лес", false));
            locations_info["loc.vl.3"].Description = "Лес подходит вплотную к скалам на востоке, цепкие молодые деревца упорно карабкаются по неприступному серому камню. С юга путь преграждает река.";
            locations_info["loc.vl.3"].ways.Add("loc.vl.6", "север");
            locations_info["loc.vl.3"].ways.Add("loc.vl.2", "запад");
            locations_info.Add("loc.vl.4", new _locationinfo("loc.vl.4", "Восточный лес", false));
            locations_info["loc.vl.4"].Description = "Вы на границе болотного леса, на северо-западе виден темный овраг.";
            locations_info["loc.vl.4"].ways.Add("loc.vl.7", "север");
            locations_info["loc.vl.4"].ways.Add("loc.vl.5", "восток");
            locations_info["loc.vl.4"].ways.Add("loc.vl.1", "юг");
            locations_info["loc.vl.4"].ways.Add("loc.bl.4", "запад");
            locations_info.Add("loc.vl.5", new _locationinfo("loc.vl.5", "Восточный лес", false));
            locations_info["loc.vl.5"].Description = "Вы в самой глубине леса на востоке от города.";
            locations_info["loc.vl.5"].ways.Add("loc.vl.8", "север");
            locations_info["loc.vl.5"].ways.Add("loc.vl.6", "восток");
            locations_info["loc.vl.5"].ways.Add("loc.vl.2", "юг");
            locations_info["loc.vl.5"].ways.Add("loc.vl.4", "запад");
            locations_info.Add("loc.vl.6", new _locationinfo("loc.vl.6", "Восточный лес", false));
            locations_info["loc.vl.6"].Description = "Вы в крайней части леса на востоке от города, дальше на востоке начинаются непроходимые скалы.";
            locations_info["loc.vl.6"].ways.Add("loc.vl.9", "север");
            locations_info["loc.vl.6"].ways.Add("loc.vl.3", "юг");
            locations_info["loc.vl.6"].ways.Add("loc.vl.5", "запад");
            locations_info.Add("loc.vl.7", new _locationinfo("loc.vl.7", "Восточный лес", false));
            locations_info["loc.vl.7"].Description = "Вы на краю темного сырого оврага, за которым на западе тянется болотистая местность. Овраг протянулся на север.";
            locations_info["loc.vl.7"].ways.Add("loc.vl.10", "север");
            locations_info["loc.vl.7"].ways.Add("loc.vl.8", "восток");
            locations_info["loc.vl.7"].ways.Add("loc.vl.4", "юг");
            locations_info["loc.vl.7"].ways.Add("loc.bl.6", "перейти овраг на запад");
            locations_info.Add("loc.vl.8", new _locationinfo("loc.vl.8", "Восточный лес", false));
            locations_info["loc.vl.8"].Description = "Вы глубине леса на востоке от города, на западе виден темный овраг, а на востоке скалы.";
            locations_info["loc.vl.8"].ways.Add("loc.vl.11", "север");
            locations_info["loc.vl.8"].ways.Add("loc.vl.9", "восток");
            locations_info["loc.vl.8"].ways.Add("loc.vl.5", "юг");
            locations_info["loc.vl.8"].ways.Add("loc.vl.7", "запад");
            locations_info.Add("loc.vl.9", new _locationinfo("loc.vl.9", "Восточный лес", false));
            locations_info["loc.vl.9"].Description = "Лес подходит вплотную к скалам на востоке, которые тянутся на север и юг.";
            locations_info["loc.vl.9"].ways.Add("loc.vl.12", "север");
            locations_info["loc.vl.9"].ways.Add("loc.vl.6", "юг");
            locations_info["loc.vl.9"].ways.Add("loc.vl.8", "запад");
            locations_info.Add("loc.vl.10", new _locationinfo("loc.vl.10", "Восточный лес", false));
            locations_info["loc.vl.10"].Description = "Вы на краяю темного сырого оврага, на западе за которым начинается низина, овраг тянется к югу.";
            locations_info["loc.vl.10"].ways.Add("loc.vl.15", "север");
            locations_info["loc.vl.10"].ways.Add("loc.vl.11", "восток");
            locations_info["loc.vl.10"].ways.Add("loc.vl.7", "юг");
            locations_info["loc.vl.10"].ways.Add("loc.bl.8", "перейти овраг на запад");
            locations_info.Add("loc.vl.11", new _locationinfo("loc.vl.11", "Восточный лес", false));
            locations_info["loc.vl.11"].Description = "Вы в глубине леса на востоке от города.";
            locations_info["loc.vl.11"].ways.Add("loc.vl.16", "север");
            locations_info["loc.vl.11"].ways.Add("loc.vl.12", "восток");
            locations_info["loc.vl.11"].ways.Add("loc.vl.8", "юг");
            locations_info["loc.vl.11"].ways.Add("loc.vl.10", "запад");
            locations_info.Add("loc.vl.12", new _locationinfo("loc.vl.12", "Восточный лес", false));
            locations_info["loc.vl.12"].Description = "На востоке скалы, город где-то на западе.";
            locations_info["loc.vl.12"].ways.Add("loc.vl.17", "север");
            locations_info["loc.vl.12"].ways.Add("loc.vl.9", "юг");
            locations_info["loc.vl.12"].ways.Add("loc.vl.11", "запад");
            locations_info.Add("loc.vl.13", new _locationinfo("loc.vl.13", "Восточный лес", false));
            locations_info["loc.vl.13"].Description = "Вы под городскими стенами на востоке от города. К югу почва снижается и растет болотная трава, на востоке виден какой-то овраг, а стена идет на юг и север.";
            locations_info["loc.vl.13"].ways.Add("loc.vl.18", "север");
            locations_info["loc.vl.13"].ways.Add("loc.vl.14", "восток");
            locations_info["loc.vl.13"].ways.Add("loc.bl.7", "юг");
            locations_info.Add("loc.vl.14", new _locationinfo("loc.vl.14", "Восточный лес", false));
            locations_info["loc.vl.14"].Description = "Вы в лесу на востоке от города. На юго-востоке темнеет овраг.";
            locations_info["loc.vl.14"].ways.Add("loc.vl.19", "север");
            locations_info["loc.vl.14"].ways.Add("loc.vl.15", "восток");
            locations_info["loc.vl.14"].ways.Add("loc.bl.8", "юг");
            locations_info["loc.vl.14"].ways.Add("loc.vl.13", "запад");
            locations_info.Add("loc.vl.15", new _locationinfo("loc.vl.15", "Восточный лес", false));
            locations_info["loc.vl.15"].Description = "Вы в лесу на востоке от города, на юго-западе темнеет овраг.";
            locations_info["loc.vl.15"].ways.Add("loc.vl.20", "север");
            locations_info["loc.vl.15"].ways.Add("loc.vl.16", "восток");
            locations_info["loc.vl.15"].ways.Add("loc.vl.10", "юг");
            locations_info["loc.vl.15"].ways.Add("loc.vl.14", "запад");
            locations_info.Add("loc.vl.16", new _locationinfo("loc.vl.16", "Восточный лес", false));
            locations_info["loc.vl.16"].Description = "Вы в лесу на востоке от города. Еще дальше на востоке над деревьями встают серые скалы.";
            locations_info["loc.vl.16"].ways.Add("loc.vl.21", "север");
            locations_info["loc.vl.16"].ways.Add("loc.vl.17", "восток");
            locations_info["loc.vl.16"].ways.Add("loc.vl.11", "юг");
            locations_info["loc.vl.16"].ways.Add("loc.vl.15", "запад");
            locations_info.Add("loc.vl.17", new _locationinfo("loc.vl.17", "Восточный лес", false));
            locations_info["loc.vl.17"].Description = "Вы в лесу на востоке от города, над вами на востоке нависают скалы, лес здесь редкий и невысокий из-за постоянной тени.";
            locations_info["loc.vl.17"].ways.Add("loc.vl.22", "север");
            locations_info["loc.vl.17"].ways.Add("loc.vl.12", "юг");
            locations_info["loc.vl.17"].ways.Add("loc.vl.16", "запад");
            locations_info.Add("loc.vl.18", new _locationinfo("loc.vl.18", "Восточный лес", false));
            locations_info["loc.vl.18"].Description = "Вы вышли в редколесье, на западе сквозь деревья просвечивает дорога и восточне ворота, а на востоке начинается дремучий лес.";
            locations_info["loc.vl.18"].ways.Add("loc.vl.23", "север");
            locations_info["loc.vl.18"].ways.Add("loc.vl.19", "восток");
            locations_info["loc.vl.18"].ways.Add("loc.vl.13", "юг");
            locations_info["loc.vl.18"].ways.Add("loc.zvv", "на дорогу");
            locations_info.Add("loc.vl.19", new _locationinfo("loc.vl.19", "Восточный лес", false));
            locations_info["loc.vl.19"].Description = "Вы в лесу на востоке от города.";
            locations_info["loc.vl.19"].ways.Add("loc.vl.24", "север");
            locations_info["loc.vl.19"].ways.Add("loc.vl.20", "восток");
            locations_info["loc.vl.19"].ways.Add("loc.vl.14", "юг");
            locations_info["loc.vl.19"].ways.Add("loc.vl.18", "запад");
            locations_info.Add("loc.vl.20", new _locationinfo("loc.vl.20", "Восточный лес", false));
            locations_info["loc.vl.20"].Description = "Вы в глухом лесу на востоке от города.";
            locations_info["loc.vl.20"].ways.Add("loc.vl.25", "север");
            locations_info["loc.vl.20"].ways.Add("loc.vl.21", "восток");
            locations_info["loc.vl.20"].ways.Add("loc.vl.15", "юг");
            locations_info["loc.vl.20"].ways.Add("loc.vl.19", "запад");
            locations_info.Add("loc.vl.21", new _locationinfo("loc.vl.21", "Восточный лес", false));
            locations_info["loc.vl.21"].Description = "Вы в лесу на востоке от города, еще восточней должны показаться скалы.";
            locations_info["loc.vl.21"].ways.Add("loc.vl.26", "север");
            locations_info["loc.vl.21"].ways.Add("loc.vl.22", "восток");
            locations_info["loc.vl.21"].ways.Add("loc.vl.16", "юг");
            locations_info["loc.vl.21"].ways.Add("loc.vl.20", "запад");
            locations_info.Add("loc.vl.22", new _locationinfo("loc.vl.22", "Восточный лес", false));
            locations_info["loc.vl.22"].Description = "Вы в лесу на востоке от города, путь на восток преграждают серые скалы.";
            locations_info["loc.vl.22"].ways.Add("loc.vl.27", "север");
            locations_info["loc.vl.22"].ways.Add("loc.vl.17", "юг");
            locations_info["loc.vl.22"].ways.Add("loc.vl.21", "запад");
            locations_info.Add("loc.vl.23", new _locationinfo("loc.vl.23", "Восточный лес", false));
            locations_info["loc.vl.23"].Description = "Вы на краю леса, с западе и севера его огибает дорога, которая отсюда отлично видна. Еще северней выступают каменные постройки кладбища.";
            locations_info["loc.vl.23"].ways.Add("loc.vd.2", "север");
            locations_info["loc.vl.23"].ways.Add("loc.vl.24", "восток");
            locations_info["loc.vl.23"].ways.Add("loc.vl.18", "юг");
            locations_info["loc.vl.23"].ways.Add("loc.vd.1", "запад");
            locations_info.Add("loc.vl.24", new _locationinfo("loc.vl.24", "Восточный лес", false));
            locations_info["loc.vl.24"].Description = "Вы в лесу, на севере пролегает дорога, за которой видна ограда кладбища.";
            locations_info["loc.vl.24"].ways.Add("loc.vd.3", "север");
            locations_info["loc.vl.24"].ways.Add("loc.vl.25", "восток");
            locations_info["loc.vl.24"].ways.Add("loc.vl.19", "юг");
            locations_info["loc.vl.24"].ways.Add("loc.vl.23", "запад");
            locations_info.Add("loc.vl.25", new _locationinfo("loc.vl.25", "Восточный лес", false));
            locations_info["loc.vl.25"].Description = "Вы в лесу на северо-востоке от города. На севере видна дорога, на востоке и юге лес сгущается.";
            locations_info["loc.vl.25"].ways.Add("loc.vd.4", "север");
            locations_info["loc.vl.25"].ways.Add("loc.vl.26", "восток");
            locations_info["loc.vl.25"].ways.Add("loc.vl.20", "юг");
            locations_info["loc.vl.25"].ways.Add("loc.vl.24", "запад");
            locations_info.Add("loc.vl.26", new _locationinfo("loc.vl.26", "Восточный лес", false));
            locations_info["loc.vl.26"].Description = "Вы в лесу на северо-востоке от города, к северо-западу виден изгиб реки, а на востоке высятся скалы.";
            locations_info["loc.vl.26"].ways.Add("loc.vl.28", "север");
            locations_info["loc.vl.26"].ways.Add("loc.vl.27", "восток");
            locations_info["loc.vl.26"].ways.Add("loc.vl.21", "юг");
            locations_info["loc.vl.26"].ways.Add("loc.vl.25", "запад");
            locations_info.Add("loc.vl.27", new _locationinfo("loc.vl.27", "Восточный лес", false));
            locations_info["loc.vl.27"].Description = "Лес подступает вплотную к скалам, которые тянутся на юг и север.";
            locations_info["loc.vl.27"].ways.Add("loc.vl.28", "север");
            locations_info["loc.vl.27"].ways.Add("loc.vl.22", "юг");
            locations_info["loc.vl.27"].ways.Add("loc.vl.26", "запад");
            locations_info.Add("loc.vl.28", new _locationinfo("loc.vl.28", "Восточный лес", false));
            locations_info["loc.vl.28"].Description = "Небольшой участок леса, зажатый между дорогой с запада и скалами на востоке.";
            locations_info["loc.vl.28"].ways.Add("loc.vl.29", "север");
            locations_info["loc.vl.28"].ways.Add("loc.vl.26", "юг");
            locations_info["loc.vl.28"].ways.Add("loc.vl.27", "юго-восток");
            locations_info["loc.vl.28"].ways.Add("loc.vd.5", "запад");
            locations_info.Add("loc.vl.29", new _locationinfo("loc.vl.29", "Восточный лес", false));
            locations_info["loc.vl.29"].Description = "Небольшой участок леса, зажатый между дорогой с запада и скалами на востоке. Вдали на севере тоже видны горы.";
            locations_info["loc.vl.29"].ways.Add("loc.vl.30", "север");
            locations_info["loc.vl.29"].ways.Add("loc.vl.28", "юг");
            locations_info["loc.vl.29"].ways.Add("loc.vd.6", "запад");
            locations_info.Add("loc.vl.30", new _locationinfo("loc.vl.30", "Восточный лес", false));
            locations_info["loc.vl.30"].Description = "Вы самом дальнем северо-восточном углу лесу, с востока и севера вплотную пдступают горы, на западе видна дорога, уходящая куда-то под гору.";
            locations_info["loc.vl.30"].ways.Add("loc.vl.29", "юг");
            locations_info["loc.vl.30"].ways.Add("loc.vd.7", "на дорогу");
            locations_info.Add("loc.zl.1", new _locationinfo("loc.zl.1", "Западный лес", false));
            locations_info["loc.zl.1"].Description = "Сразу за дорогой от северных воротам на юго-востоке начинается довольно дремучий лес.";
            locations_info["loc.zl.1"].ways.Add("loc.sd.1", "к северным воротам");
            locations_info["loc.zl.1"].ways.Add("loc.zl.10", "север");
            locations_info["loc.zl.1"].ways.Add("loc.zl.2", "запад");
            locations_info.Add("loc.zl.2", new _locationinfo("loc.zl.2", "Западный лес", false));
            locations_info["loc.zl.2"].Description = "Вас окружает западный лес, на востоке должны находиться северные ворота, а с запада слышен шум воды.";
            locations_info["loc.zl.2"].ways.Add("loc.zl.9", "север");
            locations_info["loc.zl.2"].ways.Add("loc.zl.1", "восток");
            locations_info["loc.zl.2"].ways.Add("loc.zl.3", "запад");
            locations_info.Add("loc.zl.3", new _locationinfo("loc.zl.3", "Западный лес", false));
            locations_info["loc.zl.3"].Description = "Вы на берегу реки, на юге видна небольшая заросшая травой тропинка вдоль городской стены, река течет на запад. С севера почти к самой воде подступает лес.";
            locations_info["loc.zl.3"].ways.Add("loc.zb.1", "на тропу на юге");
            locations_info["loc.zl.3"].ways.Add("loc.zl.4", "вдоль реки на запад");
            locations_info["loc.zl.3"].ways.Add("loc.zl.8", "север");
            locations_info["loc.zl.3"].ways.Add("loc.zl.2", "восток");
            locations_info.Add("loc.zl.4", new _locationinfo("loc.zl.4", "Западный лес", false));
            locations_info["loc.zl.4"].Description = "Вы на берегу реки, которая течет на восток и запад, за спиной с свернйо стороны дремучий лес.";
            locations_info["loc.zl.4"].ways.Add("loc.zl.3", "вдоль реки на восток");
            locations_info["loc.zl.4"].ways.Add("loc.zl.5", "вдоль реки на запад");
            locations_info["loc.zl.4"].ways.Add("loc.zl.7", "север");
            locations_info.Add("loc.zl.5", new _locationinfo("loc.zl.5", "Западный лес", false));
            locations_info["loc.zl.5"].Description = "Вы на берегу реки, которая утекает куда-то вдаль на запад...";
            locations_info["loc.zl.5"].ways.Add("loc.zl.4", "вдоль реки на восток");
            locations_info["loc.zl.5"].ways.Add("loc.zl.6", "на север");
            locations_info.Add("loc.zl.6", new _locationinfo("loc.zl.6", "Западный лес", false));
            locations_info["loc.zl.6"].Description = "Вы в дремучем лесу, с юга слышен шум воды.";
            locations_info["loc.zl.6"].ways.Add("loc.zl.15", "север");
            locations_info["loc.zl.6"].ways.Add("loc.zl.7", "восток");
            locations_info["loc.zl.6"].ways.Add("loc.zl.5", "юг");
            locations_info.Add("loc.zl.7", new _locationinfo("loc.zl.7", "Западный лес", false));
            locations_info["loc.zl.7"].Description = "Вы в дремучем лесу, с юга еле слышен шум воды.";
            locations_info["loc.zl.7"].ways.Add("loc.zl.14", "север");
            locations_info["loc.zl.7"].ways.Add("loc.zl.6", "запад");
            locations_info["loc.zl.7"].ways.Add("loc.zl.4", "юг");
            locations_info["loc.zl.7"].ways.Add("loc.zl.8", "восток");
            locations_info.Add("loc.zl.8", new _locationinfo("loc.zl.8", "Западный лес", false));
            locations_info["loc.zl.8"].Description = "Вы в дремучем лесу.";
            locations_info["loc.zl.8"].ways.Add("loc.zl.13", "север");
            locations_info["loc.zl.8"].ways.Add("loc.zl.9", "восток");
            locations_info["loc.zl.8"].ways.Add("loc.zl.3", "юг");
            locations_info["loc.zl.8"].ways.Add("loc.zl.7", "запад");
            locations_info.Add("loc.zl.9", new _locationinfo("loc.zl.9", "Западный лес", false));
            locations_info["loc.zl.9"].Description = "Вы в дремучем лесу.";
            locations_info["loc.zl.9"].ways.Add("loc.zl.12", "север");
            locations_info["loc.zl.9"].ways.Add("loc.zl.10", "восток");
            locations_info["loc.zl.9"].ways.Add("loc.zl.2", "юг");
            locations_info["loc.zl.9"].ways.Add("loc.zl.8", "запад");
            locations_info.Add("loc.zl.10", new _locationinfo("loc.zl.10", "Западный лес", false));
            locations_info["loc.zl.10"].Description = "Вокруг темный лес, на востоке чуть-чуть просвечивает сквозь листву дорога.";
            locations_info["loc.zl.10"].ways.Add("loc.sd.2", "дорога на востоке");
            locations_info["loc.zl.10"].ways.Add("loc.zl.11", "север");
            locations_info["loc.zl.10"].ways.Add("loc.zl.1", "юг");
            locations_info["loc.zl.10"].ways.Add("loc.zl.9", "запад");
            locations_info.Add("loc.zl.11", new _locationinfo("loc.zl.11", "Западный лес", false));
            locations_info["loc.zl.11"].Description = "Лес тянется вдоль дороги, но сразу видно, что места здесь не хоженные...";
            locations_info["loc.zl.11"].ways.Add("loc.sd.3", "дорога на востоке");
            locations_info["loc.zl.11"].ways.Add("loc.zl.12", "на северо-запад");
            locations_info["loc.zl.11"].ways.Add("loc.zl.10", "вдоль дороги на юг");
            locations_info.Add("loc.zl.12", new _locationinfo("loc.zl.12", "Западный лес", false));
            locations_info["loc.zl.12"].Description = "Северная часть леса, единственный ориентир - дорога на востоке.";
            locations_info["loc.zl.12"].ways.Add("loc.sd.4", "дорога на востоке");
            locations_info["loc.zl.12"].ways.Add("loc.zl.11", "на юго-восток");
            locations_info["loc.zl.12"].ways.Add("loc.zl.9", "юг");
            locations_info["loc.zl.12"].ways.Add("loc.zl.13", "запад");
            locations_info.Add("loc.zl.13", new _locationinfo("loc.zl.13", "Западный лес", false));
            locations_info["loc.zl.13"].Description = "Неожиданно в лесу вы натолкнулись на небольшой деревянный дом, огороженный невысоким забором, за которым пасутся куры и домашний скот.";
            locations_info["loc.zl.13"].ways.Add("loc.krestd", "войти в дом");
            locations_info["loc.zl.13"].ways.Add("loc.zl.12", "восток");
            locations_info["loc.zl.13"].ways.Add("loc.zl.8", "юг");
            locations_info["loc.zl.13"].ways.Add("loc.zl.14", "запад");
            locations_info.Add("loc.zl.14", new _locationinfo("loc.zl.14", "Западный лес", false));
            locations_info["loc.zl.14"].Description = "Вы в глухом лесу.";
            locations_info["loc.zl.14"].ways.Add("loc.zl.13", "восток");
            locations_info["loc.zl.14"].ways.Add("loc.zl.7", "юг");
            locations_info["loc.zl.14"].ways.Add("loc.zl.15", "запад");
            locations_info.Add("loc.zl.15", new _locationinfo("loc.zl.15", "Западный лес", false));
            locations_info["loc.zl.15"].Description = "Прямо в лесу, наполовину ушедшее в землю, стоит каменное строение высотой в полтора роста и единственным входом без двери. Вокруг валяется какой-то мусор и видны следы, правда непонятно, кому принадлежащие.";
            locations_info["loc.zl.15"].ways.Add("loc.zl.14", "восток");
            locations_info["loc.zl.15"].ways.Add("loc.zl.6", "юг");
            locations_info.Add("loc.krestd", new _locationinfo("loc.krestd", "Крестьянский дом", false));
            locations_info["loc.krestd"].ways.Add("loc.zl.13", "выйти на улицу");
            locations_info["loc.krestd"].Description = "Аккуратно прибранная избушка, на столе чистая белая скатерть, а в воздухе пахнет домашним хлебом. Из других предметов домашнего обихода видна кровать у стены и очень старый, весь покрытый пылью, сундук в углу.";
        }

        private void create_locationdatas(bool additems_flag = true, bool addentitys_flag = true)
        {
            locations_data.Add("loc.0", new _locationdata("loc.0"));
            locations_data.Add("loc.lek1", new _locationdata("loc.lek1"));
            locations_data.Add("loc.lek", new _locationdata("loc.lek"));
            locations_data.Add("loc.drag1", new _locationdata("loc.drag1"));
            locations_data.Add("loc.drag", new _locationdata("loc.drag"));
            locations_data.Add("loc.sklad1", new _locationdata("loc.sklad1"));
            locations_data.Add("loc.sklad2", new _locationdata("loc.sklad2"));
            locations_data.Add("loc.sklad", new _locationdata("loc.sklad"));
            locations_data.Add("loc.reg", new _locationdata("loc.reg"));
            locations_data.Add("loc.jd3", new _locationdata("loc.jd3"));
            locations_data.Add("loc.jd4", new _locationdata("loc.jd4"));
            locations_data.Add("loc.jd2", new _locationdata("loc.jd2"));
            locations_data.Add("loc.jd1", new _locationdata("loc.jd1"));
            locations_data.Add("loc.osobn", new _locationdata("loc.osobn"));
            locations_data.Add("loc.tenal", new _locationdata("loc.tenal"));
            locations_data.Add("loc.vv", new _locationdata("loc.vv"));
            locations_data.Add("loc.vpl", new _locationdata("loc.vpl"));
            locations_data.Add("loc.ak1", new _locationdata("loc.ak1"));
            locations_data.Add("loc.bank1", new _locationdata("loc.bank1"));
            locations_data.Add("loc.bank", new _locationdata("loc.bank"));
            locations_data.Add("loc.bank2", new _locationdata("loc.bank2"));
            locations_data.Add("loc.kon1", new _locationdata("loc.kon1"));
            locations_data.Add("loc.kon", new _locationdata("loc.kon"));
            locations_data.Add("loc.centr1", new _locationdata("loc.centr1"));
            locations_data.Add("loc.tav", new _locationdata("loc.tav"));
            locations_data.Add("loc.tav1", new _locationdata("loc.tav1"));
            locations_data.Add("loc.tav2", new _locationdata("loc.tav2"));
            locations_data.Add("loc.tav3", new _locationdata("loc.tav3"));
            locations_data.Add("loc.tav4", new _locationdata("loc.tav4"));
            locations_data.Add("loc.tav5", new _locationdata("loc.tav5"));
            locations_data.Add("loc.br", new _locationdata("loc.br"));
            locations_data.Add("loc.or", new _locationdata("loc.or"));
            locations_data.Add("loc.centr2", new _locationdata("loc.centr2"));
            locations_data.Add("loc.kuzn", new _locationdata("loc.kuzn"));
            locations_data.Add("loc.uv", new _locationdata("loc.uv"));
            locations_data.Add("loc.uz2", new _locationdata("loc.uz2"));
            locations_data.Add("loc.prip", new _locationdata("loc.prip"));
            locations_data.Add("loc.luk", new _locationdata("loc.luk"));
            locations_data.Add("loc.uz1", new _locationdata("loc.uz1"));
            locations_data.Add("loc.jiv", new _locationdata("loc.jiv"));
            locations_data.Add("loc.but", new _locationdata("loc.but"));
            locations_data.Add("loc.kaz1", new _locationdata("loc.kaz1"));
            locations_data.Add("loc.kaz", new _locationdata("loc.kaz"));
            locations_data.Add("loc.dv1", new _locationdata("loc.dv1"));
            locations_data.Add("loc.dv", new _locationdata("loc.dv"));
            locations_data.Add("loc.dv2", new _locationdata("loc.dv2"));
            locations_data.Add("loc.br3", new _locationdata("loc.br3"));
            locations_data.Add("loc.br4", new _locationdata("loc.br4"));
            locations_data.Add("loc.br2", new _locationdata("loc.br2"));
            locations_data.Add("loc.br1", new _locationdata("loc.br1"));
            locations_data.Add("loc.sv", new _locationdata("loc.sv"));
            locations_data.Add("loc.snar", new _locationdata("loc.snar"));
            locations_data.Add("loc.zvv", new _locationdata("loc.zvv"));
            locations_data.Add("loc.zsv", new _locationdata("loc.zsv"));
            locations_data.Add("loc.zb.1", new _locationdata("loc.zb.1"));
            locations_data.Add("loc.zb.2", new _locationdata("loc.zb.2"));
            locations_data.Add("loc.zb.3", new _locationdata("loc.zb.3"));
            locations_data.Add("loc.zb.4", new _locationdata("loc.zb.4"));
            locations_data.Add("loc.zb.5", new _locationdata("loc.zb.5"));
            locations_data.Add("loc.pristan", new _locationdata("loc.pristan"));
            locations_data.Add("loc.port1", new _locationdata("loc.port1"));
            locations_data.Add("loc.port2", new _locationdata("loc.port2"));
            locations_data.Add("loc.ak", new _locationdata("loc.ak"));
            locations_data.Add("loc.ak4", new _locationdata("loc.ak4"));
            locations_data.Add("loc.ak2", new _locationdata("loc.ak2"));
            locations_data.Add("loc.ak5", new _locationdata("loc.ak5"));
            locations_data.Add("loc.ak3", new _locationdata("loc.ak3"));
            locations_data.Add("loc.cpl", new _locationdata("loc.cpl"));
            locations_data.Add("loc.dvr", new _locationdata("loc.dvr"));
            locations_data.Add("loc.dvr2", new _locationdata("loc.dvr2"));
            locations_data.Add("loc.dvr4", new _locationdata("loc.dvr4"));
            locations_data.Add("loc.dvr1", new _locationdata("loc.dvr1"));
            locations_data.Add("loc.dvr5", new _locationdata("loc.dvr5"));
            locations_data.Add("loc.dvr3", new _locationdata("loc.dvr3"));
            locations_data.Add("loc.bl.1", new _locationdata("loc.bl.1"));
            locations_data.Add("loc.bl.2", new _locationdata("loc.bl.2"));
            locations_data.Add("loc.bl.3", new _locationdata("loc.bl.3"));
            locations_data.Add("loc.bl.4", new _locationdata("loc.bl.4"));
            locations_data.Add("loc.bl.5", new _locationdata("loc.bl.5"));
            locations_data.Add("loc.bl.6", new _locationdata("loc.bl.6"));
            locations_data.Add("loc.bl.7", new _locationdata("loc.bl.7"));
            locations_data.Add("loc.bl.8", new _locationdata("loc.bl.8"));
            locations_data.Add("loc.kl.1", new _locationdata("loc.kl.1"));
            locations_data.Add("loc.kl.2", new _locationdata("loc.kl.2"));
            locations_data.Add("loc.kl.3", new _locationdata("loc.kl.3"));
            locations_data.Add("loc.kl.4", new _locationdata("loc.kl.4"));
            locations_data.Add("loc.kl.5", new _locationdata("loc.kl.5"));
            locations_data.Add("loc.kl.6", new _locationdata("loc.kl.6"));
            locations_data.Add("loc.kl.7", new _locationdata("loc.kl.7"));
            locations_data.Add("loc.kl.8", new _locationdata("loc.kl.8"));
            locations_data.Add("loc.kl.9", new _locationdata("loc.kl.9"));
            locations_data.Add("loc.kl.10", new _locationdata("loc.kl.10"));
            locations_data.Add("loc.kl.11", new _locationdata("loc.kl.11"));
            locations_data.Add("loc.kl.12", new _locationdata("loc.kl.12"));
            locations_data.Add("loc.kl.13", new _locationdata("loc.kl.13"));
            locations_data.Add("loc.kl.14", new _locationdata("loc.kl.14"));
            locations_data.Add("loc.kl.15", new _locationdata("loc.kl.15"));
            locations_data.Add("loc.kl.16", new _locationdata("loc.kl.16"));
            locations_data.Add("loc.kl.17", new _locationdata("loc.kl.17"));
            locations_data.Add("loc.kl.18", new _locationdata("loc.kl.18"));
            locations_data.Add("loc.kl.19", new _locationdata("loc.kl.19"));
            locations_data.Add("loc.kl.20", new _locationdata("loc.kl.20"));
            locations_data.Add("loc.kl.21", new _locationdata("loc.kl.21"));
            locations_data.Add("loc.kl.22", new _locationdata("loc.kl.22"));
            locations_data.Add("loc.kl.23", new _locationdata("loc.kl.23"));
            locations_data.Add("loc.kl.24", new _locationdata("loc.kl.24"));
            locations_data.Add("loc.kl.25", new _locationdata("loc.kl.25"));
            locations_data.Add("loc.kl.26", new _locationdata("loc.kl.26"));
            locations_data.Add("loc.kl.27", new _locationdata("loc.kl.27"));
            locations_data.Add("loc.kl.28", new _locationdata("loc.kl.28"));
            locations_data.Add("loc.kl.29", new _locationdata("loc.kl.29"));
            locations_data.Add("loc.kl.30", new _locationdata("loc.kl.30"));
            locations_data.Add("loc.kl.31", new _locationdata("loc.kl.31"));
            locations_data.Add("loc.kl.32", new _locationdata("loc.kl.32"));
            locations_data.Add("loc.kl.33", new _locationdata("loc.kl.33"));
            locations_data.Add("loc.kl.34", new _locationdata("loc.kl.34"));
            locations_data.Add("loc.kl.35", new _locationdata("loc.kl.35"));
            locations_data.Add("loc.kl.36", new _locationdata("loc.kl.36"));
            locations_data.Add("loc.kl.37", new _locationdata("loc.kl.37"));
            locations_data.Add("loc.kl.38", new _locationdata("loc.kl.38"));
            locations_data.Add("loc.kl.39", new _locationdata("loc.kl.39"));
            locations_data.Add("loc.kl.40", new _locationdata("loc.kl.40"));
            locations_data.Add("loc.kl.41", new _locationdata("loc.kl.41"));
            locations_data.Add("loc.kl.42", new _locationdata("loc.kl.42"));
            locations_data.Add("loc.kl.43", new _locationdata("loc.kl.43"));
            locations_data.Add("loc.sd.1", new _locationdata("loc.sd.1"));
            locations_data.Add("loc.sd.2", new _locationdata("loc.sd.2"));
            locations_data.Add("loc.sd.3", new _locationdata("loc.sd.3"));
            locations_data.Add("loc.sd.4", new _locationdata("loc.sd.4"));
            locations_data.Add("loc.kzd", new _locationdata("loc.kzd"));
            locations_data.Add("loc.sl.1", new _locationdata("loc.sl.1"));
            locations_data.Add("loc.sl.2", new _locationdata("loc.sl.2"));
            locations_data.Add("loc.sl.3", new _locationdata("loc.sl.3"));
            locations_data.Add("loc.sl.4", new _locationdata("loc.sl.4"));
            locations_data.Add("loc.sl.5", new _locationdata("loc.sl.5"));
            locations_data.Add("loc.sl.6", new _locationdata("loc.sl.6"));
            locations_data.Add("loc.sl.7", new _locationdata("loc.sl.7"));
            locations_data.Add("loc.sl.8", new _locationdata("loc.sl.8"));
            locations_data.Add("loc.sl.9", new _locationdata("loc.sl.9"));
            locations_data.Add("loc.sl.10", new _locationdata("loc.sl.10"));
            locations_data.Add("loc.sl.11", new _locationdata("loc.sl.11"));
            locations_data.Add("loc.sl.12", new _locationdata("loc.sl.12"));
            //locations.Add("loc.sl.13", new _locationdata("loc.sl.13"));
            locations_data.Add("loc.sl.14", new _locationdata("loc.sl.14"));
            locations_data.Add("loc.sl.15", new _locationdata("loc.sl.15"));
            locations_data.Add("loc.sl.16", new _locationdata("loc.sl.16"));
            locations_data.Add("loc.sl.17", new _locationdata("loc.sl.17"));
            locations_data.Add("loc.vd.1", new _locationdata("loc.vd.1"));
            locations_data.Add("loc.vd.2", new _locationdata("loc.vd.2"));
            locations_data.Add("loc.vd.3", new _locationdata("loc.vd.3"));
            locations_data.Add("loc.vd.4", new _locationdata("loc.vd.4"));
            locations_data.Add("loc.vd.5", new _locationdata("loc.vd.5"));
            locations_data.Add("loc.vd.6", new _locationdata("loc.vd.6"));
            locations_data.Add("loc.vd.7", new _locationdata("loc.vd.7"));
            locations_data.Add("loc.vl.1", new _locationdata("loc.vl.1"));
            locations_data.Add("loc.vl.2", new _locationdata("loc.vl.2"));
            locations_data.Add("loc.vl.3", new _locationdata("loc.vl.3"));
            locations_data.Add("loc.vl.4", new _locationdata("loc.vl.4"));
            locations_data.Add("loc.vl.5", new _locationdata("loc.vl.5"));
            locations_data.Add("loc.vl.6", new _locationdata("loc.vl.6"));
            locations_data.Add("loc.vl.7", new _locationdata("loc.vl.7"));
            locations_data.Add("loc.vl.8", new _locationdata("loc.vl.8"));
            locations_data.Add("loc.vl.9", new _locationdata("loc.vl.9"));
            locations_data.Add("loc.vl.10", new _locationdata("loc.vl.10"));
            locations_data.Add("loc.vl.11", new _locationdata("loc.vl.11"));
            locations_data.Add("loc.vl.12", new _locationdata("loc.vl.12"));
            locations_data.Add("loc.vl.13", new _locationdata("loc.vl.13"));
            locations_data.Add("loc.vl.14", new _locationdata("loc.vl.14"));
            locations_data.Add("loc.vl.15", new _locationdata("loc.vl.15"));
            locations_data.Add("loc.vl.16", new _locationdata("loc.vl.16"));
            locations_data.Add("loc.vl.17", new _locationdata("loc.vl.17"));
            locations_data.Add("loc.vl.18", new _locationdata("loc.vl.18"));
            locations_data.Add("loc.vl.19", new _locationdata("loc.vl.19"));
            locations_data.Add("loc.vl.20", new _locationdata("loc.vl.20"));
            locations_data.Add("loc.vl.21", new _locationdata("loc.vl.21"));
            locations_data.Add("loc.vl.22", new _locationdata("loc.vl.22"));
            locations_data.Add("loc.vl.23", new _locationdata("loc.vl.23"));
            locations_data.Add("loc.vl.24", new _locationdata("loc.vl.24"));
            locations_data.Add("loc.vl.25", new _locationdata("loc.vl.25"));
            locations_data.Add("loc.vl.26", new _locationdata("loc.vl.26"));
            locations_data.Add("loc.vl.27", new _locationdata("loc.vl.27"));
            locations_data.Add("loc.vl.28", new _locationdata("loc.vl.28"));
            locations_data.Add("loc.vl.29", new _locationdata("loc.vl.29"));
            locations_data.Add("loc.vl.30", new _locationdata("loc.vl.30"));
            locations_data.Add("loc.zl.1", new _locationdata("loc.zl.1"));
            locations_data.Add("loc.zl.2", new _locationdata("loc.zl.2"));
            locations_data.Add("loc.zl.3", new _locationdata("loc.zl.3"));
            locations_data.Add("loc.zl.4", new _locationdata("loc.zl.4"));
            locations_data.Add("loc.zl.5", new _locationdata("loc.zl.5"));
            locations_data.Add("loc.zl.6", new _locationdata("loc.zl.6"));
            locations_data.Add("loc.zl.7", new _locationdata("loc.zl.7"));
            locations_data.Add("loc.zl.8", new _locationdata("loc.zl.8"));
            locations_data.Add("loc.zl.9", new _locationdata("loc.zl.9"));
            locations_data.Add("loc.zl.10", new _locationdata("loc.zl.10"));
            locations_data.Add("loc.zl.11", new _locationdata("loc.zl.11"));
            locations_data.Add("loc.zl.12", new _locationdata("loc.zl.12"));
            locations_data.Add("loc.zl.13", new _locationdata("loc.zl.13"));
            locations_data.Add("loc.zl.14", new _locationdata("loc.zl.14"));
            locations_data.Add("loc.zl.15", new _locationdata("loc.zl.15"));
            locations_data.Add("loc.krestd", new _locationdata("loc.krestd"));

            if (additems_flag)
            {
                locations_data["loc.zb.3"].items.Add(new _itemlocdata(1, const_items["item.magic.pearl"], new __respawnitemdata(600, 1200, 0, 2)));
                locations_data["loc.zb.2"].items.Add(new _itemlocdata(1, const_items["item.magic.pearl"], new __respawnitemdata(600, 1200, 0, 2)));
                locations_data["loc.zb.1"].items.Add(new _itemlocdata(1, const_items["item.weapon.ranged.stone"], new __respawnitemdata(600, 1200, 0, 8)));
                locations_data["loc.zl.4"].items.Add(new _itemlocdata(1, const_items["item.crystal.amber"], new __respawnitemdata(600, 1200, 0, 1)));
                locations_data["loc.zl.14"].items.Add(new _itemlocdata(1, const_items["item.food.healherb"], new __respawnitemdata(600, 1200, 0, 2)));
                locations_data["loc.krestd"].items.Add(new _itemlocdata(1, const_items["item.magic.coal"], new __respawnitemdata(600, 1200, 0, 6)));
                locations_data["loc.sl.10"].items.Add(new _itemlocdata(1, const_items["item.magic.wormwood"], new __respawnitemdata(600, 1200, 2, 8)));
                locations_data["loc.sl.6"].items.Add(new _itemlocdata(1, const_items["item.magic.moss"], new __respawnitemdata(600, 1200, 2, 6)));
                locations_data["loc.sl.4"].items.Add(new _itemlocdata(1, const_items["item.weapon.ranged.stone"], new __respawnitemdata(600, 1200, 0, 8)));
                locations_data["loc.vd.7"].items.Add(new _itemlocdata(1, const_items["item.weapon.ranged.stone"], new __respawnitemdata(600, 1200, 0, 8)));
                //locations_data["loc.sl.30"].items.Add(new _itemlocdata(1, const_items["item.magic.sulphur"], new __respawnitemdata(600, 1200, 0, 4)));
                //locations_data["loc.sl.29"].items.Add(new _itemlocdata(1, const_items["item.crystal.adamant"], new __respawnitemdata(600, 1200, 0, 1)));
                locations_data["loc.sl.12"].items.Add(new _itemlocdata(1, const_items["item.magic.sulphur"], new __respawnitemdata(600, 1200, 0, 4)));
                locations_data["loc.sl.11"].items.Add(new _itemlocdata(1, const_items["item.crystal.adamant"], new __respawnitemdata(600, 1200, 0, 1)));
                locations_data["loc.vl.10"].items.Add(new _itemlocdata(1, const_items["item.magic.silk"], new __respawnitemdata(600, 1200, 0, 4)));
                locations_data["loc.vl.16"].items.Add(new _itemlocdata(1, const_items["item.magic.coal"], new __respawnitemdata(600, 1200, 0, 6)));
                locations_data["loc.vl.7"].items.Add(new _itemlocdata(1, const_items["item.magic.moss"], new __respawnitemdata(600, 1200, 0, 2)));
                locations_data["loc.bl.6"].items.Add(new _itemlocdata(1, const_items["item.magic.moss"], new __respawnitemdata(600, 1200, 0, 2)));
                locations_data["loc.bl.8"].items.Add(new _itemlocdata(1, const_items["item.magic.moss"], new __respawnitemdata(600, 1200, 0, 2)));
                locations_data["loc.vl.1"].items.Add(new _itemlocdata(1, const_items["item.crystal.emerald"], new __respawnitemdata(600, 1200, 0, 1)));
                locations_data["loc.br2"].items.Add(new _itemlocdata(1, const_items["item.magic.wormwood"], new __respawnitemdata(600, 1200, 0, 4)));
                locations_data["loc.kl.33"].items.Add(new _itemlocdata(1, const_items["item.magic.sulphur"], new __respawnitemdata(600, 1200, 0, 4)));
                locations_data["loc.kl.17"].items.Add(new _itemlocdata(1, const_items["item.magic.wormwood"], new __respawnitemdata(600, 1200, 0, 4)));
                locations_data["loc.kl.11"].items.Add(new _itemlocdata(1, const_items["item.magic.moss"], new __respawnitemdata(600, 1200, 0, 4)));
                locations_data["loc.kl.43"].items.Add(new _itemlocdata(1, const_items["item.magic.silk"], new __respawnitemdata(600, 1200, 0, 4)));
            }

            if (addentitys_flag)
            {
                locations_data["loc.0"].entitys.Add(new _npc((_npc)const_entitys["npc.beginner"]));
                locations_data["loc.0"].entitys.Last().respawn = new __respawnentitydata("loc.0", 1, 2);
                locations_data["loc.lek"].entitys.Add(new _npc((_npc)const_entitys["npc.healer"]));
                locations_data["loc.lek"].entitys.Last().respawn = new __respawnentitydata("loc.lek", 1, 2);
                locations_data["loc.drag"].entitys.Add(new _npc((_npc)const_entitys["npc.Mahmet"]));
                locations_data["loc.drag"].entitys.Last().respawn = new __respawnentitydata("loc.drag", 1, 2);
                locations_data["loc.drag"].entitys.Last().trader = new __tradingdata(1, 0.5, TimeSpan.FromTicks(2400), "");
                locations_data["loc.drag"].entitys.Last().trader.trader_filter.Add("item.crystal");
                locations_data["loc.drag"].entitys.Last().trader.trader_filter.Add("item.ring");
                locations_data["loc.drag"].entitys.Last().bank.Add(new __itembankdata(90, 0, 1, new _item((_item)const_items["item.ring.gold"])));
                locations_data["loc.drag"].entitys.Last().bank.Add(new __itembankdata(90, 1, 2, new _item((_item)const_items["item.ring.silver"])));
                locations_data["loc.drag"].entitys.Last().bank.Add(new __itembankdata(90, 0, 2, new _item((_item)const_items["item.crystal.adamant"])));
                locations_data["loc.drag"].entitys.Last().bank.Add(new __itembankdata(90, 0, 2, new _item((_item)const_items["item.crystal.emerald"])));
                locations_data["loc.drag"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _item((_item)const_items["item.crystal.ruby"])));
                locations_data["loc.drag"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _item((_item)const_items["item.crystal.amber"])));
                locations_data["loc.sklad2"].entitys.Add(new _npc((_npc)const_entitys["npc.Djon"]));
                locations_data["loc.sklad2"].entitys.Last().respawn = new __respawnentitydata("loc.sklad2", 1, 2);
                locations_data["loc.reg"].entitys.Add(new _npc((_npc)const_entitys["npc.Julien"]));
                locations_data["loc.reg"].entitys.Last().respawn = new __respawnentitydata("loc.reg", 1, 2);
                locations_data["loc.reg"].entitys.Last().trader = new __tradingdata(1, 0.8, TimeSpan.FromTicks(1200), "");
                locations_data["loc.reg"].entitys.Last().trader.trader_filter.Add("item.magic.sulphur");
                locations_data["loc.reg"].entitys.Last().trader.trader_filter.Add("item.magic.coal");
                locations_data["loc.reg"].entitys.Last().trader.trader_filter.Add("item.magic.silk");
                locations_data["loc.reg"].entitys.Last().trader.trader_filter.Add("item.magic.pearl");
                locations_data["loc.reg"].entitys.Last().trader.trader_filter.Add("item.magic.wormwood");
                locations_data["loc.reg"].entitys.Last().trader.trader_filter.Add("item.magic.moss");
                locations_data["loc.reg"].entitys.Last().trader.trader_filter.Add("item.recallrune");
                locations_data["loc.reg"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.recallrune.empty"])));
                locations_data["loc.reg"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.sulphur"])));
                locations_data["loc.reg"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.coal"])));
                locations_data["loc.reg"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.silk"])));
                locations_data["loc.reg"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.pearl"])));
                locations_data["loc.reg"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.wormwood"])));
                locations_data["loc.reg"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.moss"])));
                locations_data["loc.osobn"].entitys.Add(new _npc((_npc)const_entitys["npc.Gregg"]));
                locations_data["loc.osobn"].entitys.Last().respawn = new __respawnentitydata("loc.osobn", 1, 2);
                locations_data["loc.osobn"].entitys.Add(new _npc((_npc)const_entitys["npc.Stoun"]));
                locations_data["loc.osobn"].entitys.Last().respawn = new __respawnentitydata("loc.osobn", 1, 2);
                locations_data["loc.bank"].entitys.Add(new _npc((_npc)const_entitys["npc.bankir"]));
                locations_data["loc.bank"].entitys.Last().respawn = new __respawnentitydata("loc.bank", 1, 2);
                locations_data["loc.tav1"].entitys.Add(new _npc((_npc)const_entitys["npc.Frederik"]));
                locations_data["loc.tav1"].entitys.Last().respawn = new __respawnentitydata("loc.tav1", 1, 2);
                locations_data["loc.tav1"].entitys.Last().trader = new __tradingdata(1, 1, TimeSpan.FromTicks(1200), "");
                locations_data["loc.tav1"].entitys.Last().trader.trader_filter.Add("none");
                locations_data["loc.tav1"].entitys.Last().bank.Add(new __itembankdata(90, 0, 3, new _food((_food)const_items["item.food.meat.fried"])));
                locations_data["loc.tav1"].entitys.Last().bank.Add(new __itembankdata(90, 0, 10, new _food((_food)const_items["item.food.apple"])));
                locations_data["loc.tav1"].entitys.Last().bank.Add(new __itembankdata(90, 0, 12, new _food((_food)const_items["item.food.sandwich"])));
                locations_data["loc.tav1"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _food((_food)const_items["item.food.sausage"])));
                locations_data["loc.tav1"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _food((_food)const_items["item.food.ham"])));
                locations_data["loc.tav1"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _food((_food)const_items["item.food.bread"])));
                locations_data["loc.br"].entitys.Add(new _npc((_npc)const_entitys["npc.Silt"]));
                locations_data["loc.br"].entitys.Last().respawn = new __respawnentitydata("loc.br", 1, 2);
                locations_data["loc.br"].entitys.Last().trader = new __tradingdata(1.2, 0.6, TimeSpan.FromTicks(1200), "");
                locations_data["loc.br"].entitys.Last().trader.trader_filter.Add("item.armor");
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _armor((_armor)const_items["item.armor.body.leather"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _armor((_armor)const_items["item.armor.hand.leather"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _armor((_armor)const_items["item.armor.leg.leather"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _armor((_armor)const_items["item.armor.head.leather"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _armor((_armor)const_items["item.armor.body.bone"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _armor((_armor)const_items["item.armor.hand.bone"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(70, 0, 3, new _armor((_armor)const_items["item.armor.body.mail"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(60, 0, 2, new _armor((_armor)const_items["item.armor.body.full"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(40, 0, 1, new _armor((_armor)const_items["item.armor.body.plate"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(90, 0, 12, new _armor((_armor)const_items["item.armor.shield.wood"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(70, 0, 6, new _armor((_armor)const_items["item.armor.shield.copperwood"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(70, 0, 4, new _armor((_armor)const_items["item.armor.shield.bronze"])));
                locations_data["loc.br"].entitys.Last().bank.Add(new __itembankdata(50, 0, 2, new _armor((_armor)const_items["item.armor.shield.heavy"])));
                locations_data["loc.or"].entitys.Add(new _npc((_npc)const_entitys["npc.Plant"]));
                locations_data["loc.or"].entitys.Last().respawn = new __respawnentitydata("loc.or", 1, 2);
                locations_data["loc.or"].entitys.Last().trader = new __tradingdata(1.2, 0.6, TimeSpan.FromTicks(1200), "");
                locations_data["loc.or"].entitys.Last().trader.trader_filter.Add("item.weapon");
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(90, 0, 18, new _weapon((_weapon)const_items["item.weapon.knife"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(70, 0, 6, new _weapon((_weapon)const_items["item.weapon.knife.hunter"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(40, 0, 2, new _weapon((_weapon)const_items["item.weapon.knife.boot"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(60, 0, 3, new _weapon((_weapon)const_items["item.weapon.knife.butcher"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(70, 0, 4, new _weapon((_weapon)const_items["item.weapon.knife.cutlass"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(90, 0, 8, new _weapon((_weapon)const_items["item.weapon.dagger"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(70, 0, 5, new _weapon((_weapon)const_items["item.weapon.kortik"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(90, 0, 12, new _weapon((_weapon)const_items["item.weapon.shortsword"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(40, 0, 4, new _weapon((_weapon)const_items["item.weapon.broadsword"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(80, 0, 6, new _weapon((_weapon)const_items["item.weapon.halfsword"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(70, 0, 6, new _weapon((_weapon)const_items["item.weapon.longsword"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(60, 0, 3, new _weapon((_weapon)const_items["item.weapon.twohandsword"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(80, 0, 6, new _weapon((_weapon)const_items["item.weapon.sabre"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(70, 0, 6, new _weapon((_weapon)const_items["item.weapon.crookedsword"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(50, 0, 4, new _weapon((_weapon)const_items["item.weapon.yatagan"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(20, 0, 3, new _weapon((_weapon)const_items["item.weapon.samuraysword"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(80, 0, 5, new _weapon((_weapon)const_items["item.weapon.glade"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(30, 0, 3, new _weapon((_weapon)const_items["item.weapon.flamberg"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(70, 0, 5, new _weapon((_weapon)const_items["item.weapon.spear"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(40, 0, 2, new _weapon((_weapon)const_items["item.weapon.halberd"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(80, 0, 4, new _weapon((_weapon)const_items["item.weapon.axe"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(60, 0, 3, new _weapon((_weapon)const_items["item.weapon.poleaxe"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(90, 0, 12, new _weapon((_weapon)const_items["item.weapon.blackjack"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(80, 0, 2, new _weapon((_weapon)const_items["item.weapon.moningstar"])));
                locations_data["loc.or"].entitys.Last().bank.Add(new __itembankdata(20, 0, 2, new _weapon((_weapon)const_items["item.weapon.glefa"])));
                locations_data["loc.kuzn"].entitys.Add(new _npc((_npc)const_entitys["npc.Raks"]));
                locations_data["loc.kuzn"].entitys.Last().respawn = new __respawnentitydata("loc.kuzn", 1, 2);
                locations_data["loc.prip"].entitys.Add(new _npc((_npc)const_entitys["npc.Goston"]));
                locations_data["loc.prip"].entitys.Last().respawn = new __respawnentitydata("loc.prip", 1, 2);
                locations_data["loc.prip"].entitys.Last().trader = new __tradingdata(1, 0.7, TimeSpan.FromTicks(1200), "");
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 1, 8, new _item((_item)const_items["item.recallrune.empty"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.sulphur"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.coal"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.silk"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 1, 2, new _item((_item)const_items["item.magic.pearl"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.wormwood"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.moss"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _weapon((_weapon)const_items["item.weapon.knife"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _weapon((_weapon)const_items["item.weapon.knife.hunter"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 1, new _weapon((_weapon)const_items["item.weapon.knife.boot"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 3, new _weapon((_weapon)const_items["item.weapon.knife.butcher"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _weapon((_weapon)const_items["item.weapon.knife.cutlass"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 8, new _weapon((_weapon)const_items["item.weapon.dagger"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 28, new _item((_item)const_items["item.misc.arrow"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 22, new _item((_item)const_items["item.misc.bolt"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _food((_food)const_items["item.food.meat.fried"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 10, new _food((_food)const_items["item.food.apple"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 12, new _food((_food)const_items["item.food.sandwich"])));
                locations_data["loc.prip"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _food((_food)const_items["item.food.sausage"])));
                locations_data["loc.luk"].entitys.Add(new _npc((_npc)const_entitys["npc.Arant"]));
                locations_data["loc.luk"].entitys.Last().respawn = new __respawnentitydata("loc.luk", 1, 2);
                locations_data["loc.luk"].entitys.Last().trader = new __tradingdata(1.2, 0.6, TimeSpan.FromTicks(1200), "");
                locations_data["loc.luk"].entitys.Last().trader.trader_filter.Add("item.weapon.ranged");
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(90, 0, 32, new _item((_item)const_items["item.misc.arrow"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(90, 0, 32, new _item((_item)const_items["item.misc.bolt"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(90, 0, 32, new _weapon((_weapon)const_items["item.weapon.ranged.stone"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(80, 0, 23, new _weapon((_weapon)const_items["item.weapon.ranged.surricen"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(30, 0, 3, new _weapon((_weapon)const_items["item.weapon.ranged.bumerang"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(40, 0, 6, new _weapon((_weapon)const_items["item.weapon.ranged.tomahawk"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(70, 0, 16, new _weapon((_weapon)const_items["item.weapon.ranged.dropknife"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(40, 0, 12, new _weapon((_weapon)const_items["item.weapon.ranged.dropspear"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(70, 0, 18, new _weapon((_weapon)const_items["item.weapon.ranged.javelin"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _weapon((_weapon)const_items["item.weapon.ranged.sling"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _weapon((_weapon)const_items["item.weapon.ranged.bow"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(90, 0, 8, new _weapon((_weapon)const_items["item.weapon.ranged.shortbow"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(70, 0, 6, new _weapon((_weapon)const_items["item.weapon.ranged.longbow"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(60, 0, 6, new _weapon((_weapon)const_items["item.weapon.ranged.willowbow"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(40, 0, 4, new _weapon((_weapon)const_items["item.weapon.ranged.birchbow"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(30, 0, 2, new _weapon((_weapon)const_items["item.weapon.ranged.hunterbow"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(20, 0, 1, new _weapon((_weapon)const_items["item.weapon.ranged.compoundbow"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(70, 0, 4, new _weapon((_weapon)const_items["item.weapon.ranged.crossbow.light"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(40, 0, 3, new _weapon((_weapon)const_items["item.weapon.ranged.crossbow.middle"])));
                locations_data["loc.luk"].entitys.Last().bank.Add(new __itembankdata(20, 0, 1, new _weapon((_weapon)const_items["item.weapon.ranged.crossbow.hard"])));
                locations_data["loc.jiv"].entitys.Add(new _npc((_npc)const_entitys["npc.Milta"]));
                locations_data["loc.jiv"].entitys.Last().respawn = new __respawnentitydata("loc.jiv", 1, 2);
                locations_data["loc.jiv"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.pig"]));
                locations_data["loc.jiv"].entitys.Last().respawn = new __respawnentitydata("loc.jiv", 600, 1200);
                locations_data["loc.jiv"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.hen"]));
                locations_data["loc.jiv"].entitys.Last().respawn = new __respawnentitydata("loc.jiv", 600, 1200);
                locations_data["loc.but"].entitys.Add(new _npc((_npc)const_entitys["npc.Raksha"]));
                locations_data["loc.but"].entitys.Last().respawn = new __respawnentitydata("loc.but", 1, 2);
                locations_data["loc.but"].entitys.Last().trader = new __tradingdata(1, 0.6, TimeSpan.FromTicks(1200), "");
                locations_data["loc.but"].entitys.Last().trader.trader_filter.Add("item.bottle");
                locations_data["loc.but"].entitys.Last().bank.Add(new __itembankdata(90, 0, 8, new _food((_food)const_items["item.bottle.empty"])));
                locations_data["loc.but"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _food((_food)const_items["item.bottle.life"])));
                locations_data["loc.but"].entitys.Last().bank.Add(new __itembankdata(60, 0, 2, new _food((_food)const_items["item.bottle.life.great"])));
                locations_data["loc.but"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _food((_food)const_items["item.bottle.mana"])));
                locations_data["loc.but"].entitys.Last().bank.Add(new __itembankdata(60, 0, 2, new _food((_food)const_items["item.bottle.mana.great"])));
                locations_data["loc.but"].entitys.Last().bank.Add(new __itembankdata(30, 0, 3, new _food((_food)const_items["item.bottle.health"])));
                locations_data["loc.kaz"].entitys.Add(new _npc((_npc)const_entitys["npc.Markus"]));
                locations_data["loc.kaz"].entitys.Last().respawn = new __respawnentitydata("loc.kaz", 1, 2);
                locations_data["loc.dv"].entitys.Add(new _npc((_npc)const_entitys["npc.Surri"]));
                locations_data["loc.dv"].entitys.Last().respawn = new __respawnentitydata("loc.dv", 1, 2);
                locations_data["loc.dv2"].entitys.Add(new _npc((_npc)const_entitys["npc.Sirs"]));
                locations_data["loc.dv2"].entitys.Last().respawn = new __respawnentitydata("loc.dv2", 1, 2);
                locations_data["loc.snar"].entitys.Add(new _npc((_npc)const_entitys["npc.Sloven"]));
                locations_data["loc.snar"].entitys.Last().respawn = new __respawnentitydata("loc.snar", 1, 2);
                locations_data["loc.snar"].entitys.Last().trader = new __tradingdata(1.2, 0.6, TimeSpan.FromTicks(1200), "");
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 1, 8, new _item((_item)const_items["item.recallrune.empty"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.sulphur"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.coal"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.silk"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 1, 2, new _item((_item)const_items["item.magic.pearl"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.wormwood"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.moss"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _weapon((_weapon)const_items["item.weapon.knife"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(70, 0, 4, new _weapon((_weapon)const_items["item.weapon.knife.hunter"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(40, 0, 1, new _weapon((_weapon)const_items["item.weapon.knife.boot"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(60, 0, 3, new _weapon((_weapon)const_items["item.weapon.knife.butcher"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(70, 0, 4, new _weapon((_weapon)const_items["item.weapon.knife.cutlass"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 0, 8, new _weapon((_weapon)const_items["item.weapon.dagger"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 0, 28, new _item((_item)const_items["item.misc.arrow"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 0, 22, new _item((_item)const_items["item.misc.bolt"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _food((_food)const_items["item.food.meat.fried"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 0, 10, new _food((_food)const_items["item.food.apple"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 0, 12, new _food((_food)const_items["item.food.sandwich"])));
                locations_data["loc.snar"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _food((_food)const_items["item.food.sausage"])));
                locations_data["loc.zsv"].entitys.Add(new _npc((_npc)const_entitys["npc.Yan"]));
                locations_data["loc.zsv"].entitys.Last().respawn = new __respawnentitydata("loc.zsv", 1, 2);
                locations_data["loc.pristan"].entitys.Add(new _npc((_npc)const_entitys["npc.Ded"]));
                locations_data["loc.pristan"].entitys.Last().respawn = new __respawnentitydata("loc.pristan", 1, 2);
                locations_data["loc.pristan"].entitys.Add(new _npc((_npc)const_entitys["npc.Malchugan"]));
                locations_data["loc.pristan"].entitys.Last().respawn = new __respawnentitydata("loc.pristan", 1, 2);
                locations_data["loc.ak"].entitys.Add(new _npc((_npc)const_entitys["npc.Franchesko"]));
                locations_data["loc.ak"].entitys.Last().respawn = new __respawnentitydata("loc.ak", 1, 2);
                locations_data["loc.ak4"].entitys.Add(new _npc((_npc)const_entitys["npc.Djoshua"]));
                locations_data["loc.ak4"].entitys.Last().respawn = new __respawnentitydata("loc.ak4", 1, 2);
                locations_data["loc.ak4"].entitys.Last().trader = new __tradingdata(1.5, 0.5, TimeSpan.FromTicks(1200), "");
                locations_data["loc.ak4"].entitys.Last().trader.trader_filter.Add("item.magic.sulphur");
                locations_data["loc.ak4"].entitys.Last().trader.trader_filter.Add("item.magic.coal");
                locations_data["loc.ak4"].entitys.Last().trader.trader_filter.Add("item.magic.silk");
                locations_data["loc.ak4"].entitys.Last().trader.trader_filter.Add("item.magic.pearl");
                locations_data["loc.ak4"].entitys.Last().trader.trader_filter.Add("item.magic.wormwood");
                locations_data["loc.ak4"].entitys.Last().trader.trader_filter.Add("item.magic.moss");
                locations_data["loc.ak4"].entitys.Last().trader.trader_filter.Add("item.recallrune");
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 1, 8, new _item((_item)const_items["item.recallrune.empty"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 2, 14, new _item((_item)const_items["item.magic.sulphur"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 2, 14, new _item((_item)const_items["item.magic.coal"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 2, 18, new _item((_item)const_items["item.magic.silk"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 1, 12, new _item((_item)const_items["item.magic.pearl"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 3, 10, new _item((_item)const_items["item.magic.wormwood"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 6, 18, new _item((_item)const_items["item.magic.moss"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 0, 12, new _food((_food)const_items["item.bottle.empty"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 0, 8, new _food((_food)const_items["item.bottle.life"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 4, new _food((_food)const_items["item.bottle.life.great"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 0, 8, new _food((_food)const_items["item.bottle.mana"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 4, new _food((_food)const_items["item.bottle.mana.great"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _food((_food)const_items["item.bottle.health"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 12, 24, new _item((_item)const_items["item.scroll.war.arrow"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 8, 16, new _item((_item)const_items["item.scroll.war.firearrow"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 6, 14, new _item((_item)const_items["item.scroll.war.icefirst"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(80, 6, 12, new _item((_item)const_items["item.scroll.war.firebolt"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 4, 8, new _item((_item)const_items["item.scroll.war.iceray"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(60, 4, 8, new _item((_item)const_items["item.scroll.war.firestreem"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(80, 2, 12, new _item((_item)const_items["item.scroll.war.lighting"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(60, 0, 4, new _item((_item)const_items["item.scroll.all.watergross"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(40, 1, 3, new _item((_item)const_items["item.scroll.all.earthquake"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 5, 12, new _item((_item)const_items["item.scroll.createfood"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(80, 2, 8, new _item((_item)const_items["item.scroll.charm"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 8, new _item((_item)const_items["item.scroll.charmenemy"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 8, new _item((_item)const_items["item.scroll.peace"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 6, new _item((_item)const_items["item.scroll.silence"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(50, 0, 4, new _item((_item)const_items["item.scroll.maddnes"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(80, 0, 8, new _item((_item)const_items["item.scroll.summon.wolf"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 6, new _item((_item)const_items["item.scroll.summon.skeleton"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(60, 0, 5, new _item((_item)const_items["item.scroll.summon.golem"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(40, 0, 4, new _item((_item)const_items["item.scroll.summon.demon"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 6, 24, new _item((_item)const_items["item.scroll.heal"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(60, 1, 6, new _item((_item)const_items["item.scroll.heal.great"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(30, 1, 3, new _item((_item)const_items["item.scroll.ressurect"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 4, 12, new _item((_item)const_items["item.scroll.mark"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 6, 18, new _item((_item)const_items["item.scroll.recall"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 1, 6, new _item((_item)const_items["item.rune.war.arrow"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(80, 1, 5, new _item((_item)const_items["item.rune.war.firearrow"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 2, new _item((_item)const_items["item.rune.war.icefirst"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(60, 0, 3, new _item((_item)const_items["item.rune.war.firebolt"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(40, 0, 2, new _item((_item)const_items["item.rune.war.iceray"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(40, 0, 1, new _item((_item)const_items["item.rune.war.firestreem"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(80, 0, 4, new _item((_item)const_items["item.rune.war.lighting"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 1, new _item((_item)const_items["item.rune.all.watergross"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(60, 0, 2, new _item((_item)const_items["item.rune.all.earthquake"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 1, 6, new _item((_item)const_items["item.rune.createfood"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 2, new _item((_item)const_items["item.rune.charm"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(80, 0, 4, new _item((_item)const_items["item.rune.charmenemy"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 3, new _item((_item)const_items["item.rune.peace"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 4, new _item((_item)const_items["item.rune.silence"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(40, 0, 3, new _item((_item)const_items["item.rune.maddnes"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(80, 0, 4, new _item((_item)const_items["item.rune.summon.wolf"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 4, new _item((_item)const_items["item.rune.summon.skeleton"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(60, 0, 3, new _item((_item)const_items["item.rune.summon.golem"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(40, 1, 1, new _item((_item)const_items["item.rune.summon.demon"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _item((_item)const_items["item.rune.heal"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(70, 0, 3, new _item((_item)const_items["item.rune.heal.great"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(20, 0, 2, new _item((_item)const_items["item.rune.ressurect"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.rune.mark"])));
                locations_data["loc.ak4"].entitys.Last().bank.Add(new __itembankdata(90, 2, 4, new _item((_item)const_items["item.rune.recall"])));
                locations_data["loc.ak2"].entitys.Add(new _npc((_npc)const_entitys["npc.Klavdius"]));
                locations_data["loc.ak2"].entitys.Last().respawn = new __respawnentitydata("loc.ak2", 1, 2);
                locations_data["loc.ak5"].entitys.Add(new _npc((_npc)const_entitys["npc.Serpent"]));
                locations_data["loc.ak5"].entitys.Last().respawn = new __respawnentitydata("loc.ak5", 1, 2);
                locations_data["loc.ak3"].entitys.Add(new _npc((_npc)const_entitys["npc.Antonio"]));
                locations_data["loc.ak3"].entitys.Last().respawn = new __respawnentitydata("loc.ak3", 1, 2);
                locations_data["loc.ak3"].entitys.Add(new _npc((_npc)const_entitys["npc.Milton"]));
                locations_data["loc.ak3"].entitys.Last().respawn = new __respawnentitydata("loc.ak3", 1, 2);
                locations_data["loc.dvr"].entitys.Add(new _npc((_npc)const_entitys["npc.Gant"]));
                locations_data["loc.dvr"].entitys.Last().respawn = new __respawnentitydata("loc.dvr", 1, 2);
                locations_data["loc.dvr2"].entitys.Add(new _npc((_npc)const_entitys["npc.Silvestr"]));
                locations_data["loc.dvr2"].entitys.Last().respawn = new __respawnentitydata("loc.dvr2", 1, 2);
                locations_data["loc.dvr2"].entitys.Add(new _npc((_npc)const_entitys["npc.Stouns"]));
                locations_data["loc.dvr2"].entitys.Last().respawn = new __respawnentitydata("loc.dvr2", 1, 2);
                locations_data["loc.dvr2"].entitys.Last().trader = new __tradingdata(1.5, 0.5, TimeSpan.FromTicks(1200), "");
                locations_data["loc.dvr2"].entitys.Last().trader.trader_filter.Add("none");
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 1, 8, new _item((_item)const_items["item.recallrune.empty"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.sulphur"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.coal"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.silk"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.pearl"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.wormwood"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.moss"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 4, 12, new _item((_item)const_items["item.scroll.heal"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(60, 1, 6, new _item((_item)const_items["item.scroll.heal.great"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(30, 1, 3, new _item((_item)const_items["item.scroll.ressurect"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.scroll.mark"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 12, new _item((_item)const_items["item.scroll.recall"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 8, 18, new _item((_item)const_items["item.scroll.war.holyarrow"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(50, 1, 4, new _item((_item)const_items["item.scroll.all.godanger"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 0, 3, new _item((_item)const_items["item.rune.heal"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(70, 0, 2, new _item((_item)const_items["item.rune.heal.great"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(20, 0, 1, new _item((_item)const_items["item.rune.ressurect"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 1, 2, new _item((_item)const_items["item.rune.mark"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 2, new _item((_item)const_items["item.rune.recall"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.rune.war.holyarrow"])));
                locations_data["loc.dvr2"].entitys.Last().bank.Add(new __itembankdata(50, 0, 2, new _item((_item)const_items["item.rune.all.godanger"])));
                locations_data["loc.dvr4"].entitys.Add(new _npc((_npc)const_entitys["npc.LordHagen"]));
                locations_data["loc.dvr4"].entitys.Last().respawn = new __respawnentitydata("loc.dvr4", 1, 2);
                locations_data["loc.dvr4"].entitys.Add(new _npc((_npc)const_entitys["npc.Rene"]));
                locations_data["loc.dvr4"].entitys.Last().respawn = new __respawnentitydata("loc.dvr4", 1, 2);
                locations_data["loc.dvr5"].entitys.Add(new _npc((_npc)const_entitys["npc.Kantares"]));
                locations_data["loc.dvr5"].entitys.Last().respawn = new __respawnentitydata("loc.dvr5", 1, 2);
                locations_data["loc.dvr5"].entitys.Add(new _npc((_npc)const_entitys["npc.KantaresNovobranec"]));
                locations_data["loc.dvr5"].entitys.Last().respawn = new __respawnentitydata("loc.dvr5", 1, 2);
                locations_data["loc.dvr3"].entitys.Add(new _npc((_npc)const_entitys["npc.Hans"]));
                locations_data["loc.dvr3"].entitys.Last().respawn = new __respawnentitydata("loc.dvr3", 1, 2);
                locations_data["loc.vd.2"].entitys.Add(new _npc((_npc)const_entitys["npc.Silvio"]));
                locations_data["loc.vd.2"].entitys.Last().respawn = new __respawnentitydata("loc.vd.2", 1, 2);
                locations_data["loc.vd.2"].entitys.Last().trader = new __tradingdata(1.5, 1, TimeSpan.FromTicks(1200), "");
                locations_data["loc.vd.2"].entitys.Last().trader.trader_filter.Add("item.hunter");
                locations_data["loc.vd.2"].entitys.Last().trader.trader_filter.Add("item.magic.sulphur");
                locations_data["loc.vd.2"].entitys.Last().trader.trader_filter.Add("item.magic.coal");
                locations_data["loc.vd.2"].entitys.Last().trader.trader_filter.Add("item.magic.silk");
                locations_data["loc.vd.2"].entitys.Last().trader.trader_filter.Add("item.magic.pearl");
                locations_data["loc.vd.2"].entitys.Last().trader.trader_filter.Add("item.magic.wormwood");
                locations_data["loc.vd.2"].entitys.Last().trader.trader_filter.Add("item.magic.moss");
                locations_data["loc.vd.2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.sulphur"])));
                locations_data["loc.vd.2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.coal"])));
                locations_data["loc.vd.2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.silk"])));
                locations_data["loc.vd.2"].entitys.Last().bank.Add(new __itembankdata(90, 1, 4, new _item((_item)const_items["item.magic.pearl"])));
                locations_data["loc.vd.2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.wormwood"])));
                locations_data["loc.vd.2"].entitys.Last().bank.Add(new __itembankdata(90, 2, 8, new _item((_item)const_items["item.magic.moss"])));
                locations_data["loc.kzd"].entitys.Add(new _npc((_npc)const_entitys["npc.Leksli"]));
                locations_data["loc.kzd"].entitys.Last().respawn = new __respawnentitydata("loc.kzd", 1, 2);
                locations_data["loc.kzd"].entitys.Last().trader = new __tradingdata(1, 0.8, TimeSpan.FromTicks(1200), "");
                locations_data["loc.kzd"].entitys.Last().trader.trader_filter.Add("item.hunter");
                locations_data["loc.kzd"].entitys.Last().bank.Add(new __itembankdata(90, 0, 4, new _food((_food)const_items["item.food.meat.fried"])));
                locations_data["loc.kzd"].entitys.Last().bank.Add(new __itembankdata(90, 0, 6, new _food((_food)const_items["item.food.sausage"])));
                locations_data["loc.kzd"].entitys.Last().bank.Add(new __itembankdata(90, 0, 2, new _food((_food)const_items["item.food.ham"])));
                locations_data["loc.kon1"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.pig"]));
                locations_data["loc.kon1"].entitys.Last().respawn = new __respawnentitydata("loc.kon1", 600, 1200);
                locations_data["loc.sklad"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.rat"]));
                locations_data["loc.sklad"].entitys.Last().respawn = new __respawnentitydata("loc.sklad", 600, 1200);
                locations_data["loc.sklad"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.rat"]));
                locations_data["loc.sklad"].entitys.Last().respawn = new __respawnentitydata("loc.sklad", 600, 1200);
                locations_data["loc.sklad"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.rat"]));
                locations_data["loc.sklad"].entitys.Last().respawn = new __respawnentitydata("loc.sklad", 600, 1200);
                locations_data["loc.sklad"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.rat"]));
                locations_data["loc.sklad"].entitys.Last().respawn = new __respawnentitydata("loc.sklad", 600, 1200);
                locations_data["loc.br2"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.rat"]));
                locations_data["loc.br2"].entitys.Last().respawn = new __respawnentitydata("loc.br2", 600, 1200);
                locations_data["loc.bank1"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.dog"]));
                locations_data["loc.bank1"].entitys.Last().respawn = new __respawnentitydata("loc.bank1", 600, 1200);
                locations_data["loc.bank1"].entitys.Last().move = new __movedata(10, 20, 180, true);
                locations_data["loc.kl.14"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.zombie"]));
                locations_data["loc.kl.14"].entitys.Last().respawn = new __respawnentitydata("loc.kl.14", 600, 1200);
                locations_data["loc.kl.14"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.kl.3"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.zombie"]));
                locations_data["loc.kl.3"].entitys.Last().respawn = new __respawnentitydata("loc.kl.3", 600, 1200);
                locations_data["loc.kl.3"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.kl.8"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.zombie"]));
                locations_data["loc.kl.8"].entitys.Last().respawn = new __respawnentitydata("loc.kl.8", 600, 1200);
                locations_data["loc.kl.8"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.kl.19"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.zombie"]));
                locations_data["loc.kl.19"].entitys.Last().respawn = new __respawnentitydata("loc.kl.19", 600, 1200);
                locations_data["loc.kl.19"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.kl.38"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.zombie"]));
                locations_data["loc.kl.38"].entitys.Last().respawn = new __respawnentitydata("loc.kl.38", 600, 1200);
                locations_data["loc.kl.38"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.kl.25"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.skeleton"]));
                locations_data["loc.kl.25"].entitys.Last().respawn = new __respawnentitydata("loc.kl.25", 600, 1200);
                locations_data["loc.kl.25"].entitys.Last().move = new __movedata(1, 20, 180, false);
                locations_data["loc.kl.22"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.skeleton"]));
                locations_data["loc.kl.22"].entitys.Last().respawn = new __respawnentitydata("loc.kl.22", 600, 1200);
                locations_data["loc.kl.22"].entitys.Last().move = new __movedata(2, 20, 180, false);
                locations_data["loc.kl.33"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.warriorskeleton"]));
                locations_data["loc.kl.33"].entitys.Last().respawn = new __respawnentitydata("loc.kl.33", 600, 1200);
                locations_data["loc.kl.33"].entitys.Last().move = new __movedata(1, 20, 180, false);
                locations_data["loc.zl.15"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.warriorskeleton"]));
                locations_data["loc.zl.15"].entitys.Last().respawn = new __respawnentitydata("loc.zl.15", 600, 1200);
                locations_data["loc.zl.15"].entitys.Last().move = new __movedata(1, 20, 180, false);
                locations_data["loc.kl.41"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.shadow"]));
                locations_data["loc.kl.41"].entitys.Last().respawn = new __respawnentitydata("loc.kl.41", 600, 1200);
                locations_data["loc.kl.41"].entitys.Last().move = new __movedata(4, 20, 180, false);
                locations_data["loc.kl.43"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.witch"]));
                locations_data["loc.kl.43"].entitys.Last().respawn = new __respawnentitydata("loc.kl.43", 600, 1200);
                locations_data["loc.kl.43"].entitys.Last().move = new __movedata(2, 20, 180, false);
                locations_data["loc.kl.4"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.vampire"]));
                locations_data["loc.kl.4"].entitys.Last().respawn = new __respawnentitydata("loc.kl.4", 600, 1200);
                locations_data["loc.kl.4"].entitys.Last().move = new __movedata(2, 20, 180, false);
                locations_data["loc.vl.26"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.vampire"]));
                locations_data["loc.vl.26"].entitys.Last().respawn = new __respawnentitydata("loc.vl.26", 600, 1200);
                locations_data["loc.vl.26"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.sl.11"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.witch"]));
                locations_data["loc.sl.11"].entitys.Last().respawn = new __respawnentitydata("loc.sl.11", 600, 1200);
                locations_data["loc.sl.11"].entitys.Last().move = new __movedata(2, 20, 180, false);
                locations_data["loc.vl.4"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.snake"]));
                locations_data["loc.vl.4"].entitys.Last().respawn = new __respawnentitydata("loc.vl.4", 600, 1200);
                locations_data["loc.vl.4"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.vl.2"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.orcwarrior"]));
                locations_data["loc.vl.2"].entitys.Last().respawn = new __respawnentitydata("loc.vl.2", 600, 1200);
                locations_data["loc.vl.2"].entitys.Last().move = new __movedata(5, 20, 180, false);
                locations_data["loc.vl.11"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.ogr"]));
                locations_data["loc.vl.11"].entitys.Last().respawn = new __respawnentitydata("loc.vl.11", 600, 1200);
                locations_data["loc.vl.11"].entitys.Last().move = new __movedata(7, 20, 180, false);
                locations_data["loc.zl.6"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.troll"]));
                locations_data["loc.zl.6"].entitys.Last().respawn = new __respawnentitydata("loc.zl.6", 600, 1200);
                locations_data["loc.zl.6"].entitys.Last().move = new __movedata(5, 20, 180, false);
                locations_data["loc.zl.5"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.bear"]));
                locations_data["loc.zl.5"].entitys.Last().respawn = new __respawnentitydata("loc.zl.5", 600, 1200);
                locations_data["loc.zl.5"].entitys.Last().move = new __movedata(2, 20, 180, false);
                locations_data["loc.zl.8"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.fox"]));
                locations_data["loc.zl.8"].entitys.Last().respawn = new __respawnentitydata("loc.zl.8", 600, 1200);
                locations_data["loc.zl.8"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.zl.9"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.wildboar"]));
                locations_data["loc.zl.9"].entitys.Last().respawn = new __respawnentitydata("loc.zl.9", 600, 1200);
                locations_data["loc.zl.9"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.zl.1"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.hare"]));
                locations_data["loc.zl.1"].entitys.Last().respawn = new __respawnentitydata("loc.zl.1", 600, 1200);
                locations_data["loc.zl.1"].entitys.Last().move = new __movedata(4, 10, 60, false);
                locations_data["loc.zl.13"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.cow"]));
                locations_data["loc.zl.13"].entitys.Last().respawn = new __respawnentitydata("loc.zl.13", 600, 1200);
                locations_data["loc.sd.2"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.hen"]));
                locations_data["loc.sd.2"].entitys.Last().respawn = new __respawnentitydata("loc.sd.2", 600, 1200);
                locations_data["loc.sd.2"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.sheep"]));
                locations_data["loc.sd.2"].entitys.Last().respawn = new __respawnentitydata("loc.sd.2", 600, 1200);
                locations_data["loc.sl.5"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.deer"]));
                locations_data["loc.sl.5"].entitys.Last().respawn = new __respawnentitydata("loc.sl.5", 600, 1200);
                locations_data["loc.sl.5"].entitys.Last().move = new __movedata(2, 20, 180, false);
                locations_data["loc.sl.9"].entitys.Add(new _animal((_animal)const_entitys["npc.animal.dove"]));
                locations_data["loc.sl.9"].entitys.Last().respawn = new __respawnentitydata("loc.sl.9", 600, 1200);
                locations_data["loc.sl.9"].entitys.Last().move = new __movedata(10, 20, 180, false);
                locations_data["loc.sl.14"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.wolf"]));
                locations_data["loc.sl.14"].entitys.Last().respawn = new __respawnentitydata("loc.sl.14", 600, 1200);
                locations_data["loc.sl.14"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.vl.20"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.wolf"]));
                locations_data["loc.vl.20"].entitys.Last().respawn = new __respawnentitydata("loc.vl.20", 600, 1200);
                locations_data["loc.vl.20"].entitys.Last().move = new __movedata(3, 20, 180, false);
                locations_data["loc.zl.12"].entitys.Add(new _animal((_animal)const_entitys["npc.crim.wolf"]));
                locations_data["loc.zl.12"].entitys.Last().respawn = new __respawnentitydata("loc.zl.12", 600, 1200);
                locations_data["loc.zl.12"].entitys.Last().move = new __movedata(3, 20, 180, false);
                //locations_data["loc.sl.2"]=>array("item.stand.ressurect"=>"камень воскрешения|Темный обелиск в пол человеческого роста, любой призрак, дотронувшийся до камня, тут же воскресает",
            }
        }

    }

    public class _locationdata
    {
        private string id;
        public List<_itemlocdata> items;
        public List<_entity> entitys;

        public _locationdata()
        {
            this.id = "";
            this.items = new List<_itemlocdata>();
            this.entitys = new List<_entity>();
        }

        public _locationdata(string id)
        {
            this.id = id;
            this.items = new List<_itemlocdata>();
            this.entitys = new List<_entity>();
        }

        public string Id { get { return this.id; } set { this.id = value; } }
    }

    public class _locationinfo
    {
        private string id;
        private string title;
        private string description;
        private bool guard;
        public Dictionary<string, string> ways;

        public _locationinfo()
        {
            this.id = "";
            this.title = "";
            this.description = "";
            this.guard = false;
            this.ways = new Dictionary<string, string>();
        }

        public _locationinfo(string id, string title, bool guard)
        {
            this.id = id;
            this.title = title;
            this.description = "";
            this.guard = guard;
            this.ways = new Dictionary<string, string>();
        }

        public _locationinfo(string id, string title, string description, bool guard)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.guard = guard;
            this.ways = new Dictionary<string, string>();
        }

        public _locationinfo(string rawdata)
        {
            //id|title|guard|to|title|to|title
            string[] data = rawdata.Split('|');
            this.id = data[0];
            this.title = data[1];
            this.description = "";
            this.guard = Convert.ToBoolean(data[2]);
            this.ways = new Dictionary<string, string>();
            for (int i = 3; i < data.Length; i += 2)
            {
                this.ways.Add(data[i + 1], data[i]);
            }
        }

        public string Id { get { return this.id; } set { this.id = value; } }

        public string Title { get { return this.title; } set { this.title = value; } }

        public string Description { get { return this.description; } set { this.description = value; } }

        public bool Guard { get { return this.guard; } set { this.guard = value; } }
    }

    #endregion

    public class _dialoginfo
    {
        private string title;
        public Dictionary<string, string> replies;

        public _dialoginfo()
        {
            this.title = "";
            this.replies = new Dictionary<string, string>();
        }

        public _dialoginfo(string title)
        {
            this.title = title;
            this.replies = new Dictionary<string, string>();
        }

        public string Title { get { return this.title; } set { this.title = value; } }
    }

    #region Игроки и NPC

    public class _entity
    {
        /*protected*/public string id;
        /*protected*/public string title;
        /*protected*/public int life;
        /*protected*/public int life_max;
        /*protected*/public int mana;
        /*protected*/public int mana_max;
        public __wardata war;
        public __skills skills;
        public __equipdata equip;

        public List<string> magic;
        public List<_thing> items;
        public List<__itembankdata> bank;
        public List<_thing> osvej;

        public __movedata move;
        public __tradingdata trader;
        public __respawnentitydata respawn;

        /*protected*/public bool crim;
        /*protected*/public int time_crim;
        /*protected*/public bool bankir;
        /*protected*/public bool healer;
        /*protected*/public bool ghost;
        /*protected*/public bool offline;

        /*protected*/public string attack;
        /*protected*/public string location;
        /*protected*/public string speak;

        /*protected*/public int tame;
        /*protected*/public string follow;
        /*protected*/public string guard;
        /*protected*/public string owner;
        /*protected*/public int time_owner;
        /*protected*/public bool destroyonfree;

        public int Tame { get { return this.tame; } set { this.tame = value; } }
        public bool Bankir { get { return this.bankir; } set { this.bankir = value; } }
        public string Title { get { return this.title; } set { this.title = value; } }

        public _entity()
        {
            this.id = "";
            this.title = "";
            this.life = 0;
            this.life_max = 0;
            this.mana = 0;
            this.mana_max = 0;
            this.war = new __wardata();
            this.skills = new __skills();
            this.equip = new __equipdata();
            this.items = new List<_thing>();
            this.bank = new List<__itembankdata>();
            this.osvej = new List<_thing>();
            this.move = new __movedata();
            this.trader = new __tradingdata();
            this.respawn = new __respawnentitydata();
            this.crim = false;
            this.time_crim = 0;
            this.bankir = false;
            this.healer = false;
            this.offline = false;
            this.attack = "";
            this.location = "";
            this.speak = "";
            this.tame = 0;
            this.follow = "";
            this.guard = "";
            this.owner = "";
            this.time_owner = 0;
            this.destroyonfree = false;
        }

        public _entity(_animal data)
        {
            this.id = data.id;
            this.title = data.title;
            this.life = data.life;
            this.life_max = data.life_max;
            this.mana = data.mana;
            this.mana_max = data.mana_max;
            this.war = new __wardata(data.war);
            this.skills = new __skills(data.skills);
            this.equip = new __equipdata(data.equip);
            this.items = data.items;
            this.bank = data.bank;
            this.osvej = data.osvej;
            this.move = new __movedata(data.move);
            this.trader = new __tradingdata(data.trader);
            this.respawn = new __respawnentitydata(data.respawn);
            this.crim = data.crim;
            this.bankir = data.bankir;
            this.healer = data.healer;
            this.offline = data.offline;
            this.attack = data.attack;
            this.speak = data.speak;
            this.location = data.location;
            this.tame = data.tame;
            this.follow = data.follow;
            this.guard = data.guard;
            this.owner = data.owner;
            this.time_owner = data.time_owner;
            this.destroyonfree = data.destroyonfree;
        }

        public _entity(_player data)
        {
            this.id = data.id;
            this.title = data.title;
            this.life = data.life;
            this.life_max = data.life_max;
            this.mana = data.mana;
            this.mana_max = data.mana_max;
            this.war = new __wardata(data.war);
            this.skills = new __skills(data.skills);
            this.equip = new __equipdata(data.equip);
            this.items = data.items;
            this.bank = data.bank;
            this.osvej = data.osvej;
            this.move = new __movedata(data.move);
            this.trader = new __tradingdata(data.trader);
            this.respawn = new __respawnentitydata(data.respawn);
            this.crim = data.crim;
            this.bankir = data.bankir;
            this.healer = data.healer;
            this.offline = data.offline;
            this.attack = data.attack;
            this.speak = data.speak;
            this.location = data.location;
            this.tame = data.tame;
            this.follow = data.follow;
            this.guard = data.guard;
            this.owner = data.owner;
            this.time_owner = data.time_owner;
            this.destroyonfree = data.destroyonfree;
        }

        public _entity(_npc data)
        {
            this.id = data.id;
            this.title = data.title;
            this.life = data.life;
            this.life_max = data.life_max;
            this.mana = data.mana;
            this.mana_max = data.mana_max;
            this.war = new __wardata(data.war);
            this.skills = new __skills(data.skills);
            this.equip = new __equipdata(data.equip);
            this.items = data.items;
            this.bank = data.bank;
            this.osvej = data.osvej;
            this.move = new __movedata(data.move);
            this.trader = new __tradingdata(data.trader);
            this.respawn = new __respawnentitydata(data.respawn);
            this.crim = data.crim;
            this.bankir = data.bankir;
            this.healer = data.healer;
            this.offline = data.offline;
            this.attack = data.attack;
            this.speak = data.speak;
            this.location = data.location;
            this.tame = data.tame;
            this.follow = data.follow;
            this.guard = data.guard;
            this.owner = data.owner;
            this.time_owner = data.time_owner;
            this.destroyonfree = data.destroyonfree;
        }

        public _entity(_entity data)
        {
            this.id = data.id;
            this.title = data.title;
            this.life = data.life;
            this.life_max = data.life_max;
            this.mana = data.mana;
            this.mana_max = data.mana_max;
            this.war = new __wardata(data.war);
            this.skills = new __skills(data.skills);
            this.equip = new __equipdata(data.equip);
            this.items = data.items;
            this.bank = data.bank;
            this.osvej = data.osvej;
            this.move = new __movedata(data.move);
            this.trader = new __tradingdata(data.trader);
            this.respawn = new __respawnentitydata(data.respawn);
            this.crim = data.crim;
            this.bankir = data.bankir;
            this.healer = data.healer;
            this.offline = data.offline;
            this.attack = data.attack;
            this.speak = data.speak;
            this.location = data.location;
            this.tame = data.tame;
            this.follow = data.follow;
            this.guard = data.guard;
            this.owner = data.owner;
            this.time_owner = data.time_owner;
            this.destroyonfree = data.destroyonfree;
        }

    }

    public class _animal : _entity
    {
        public _animal()
        {
            this.id = "";
            this.title = "";
            this.life = 0;
            this.life_max = 0;
            this.mana = 0;
            this.mana_max = 0;
            this.war = new __wardata();
            this.skills = new __skills();
            this.equip = new __equipdata();
            this.items = new List<_thing>();
            this.bank = new List<__itembankdata>();
            this.osvej = new List<_thing>();
            this.move = new __movedata();
            this.trader = new __tradingdata();
            this.respawn = new __respawnentitydata();
            this.crim = false;
            this.bankir = false;
            this.healer = false;
            this.attack = "";
            this.speak = "";
            this.tame = 0;
            this.follow = "";
            this.guard = "";
            this.owner = "";
            this.time_owner = 0;
            this.destroyonfree = false;
        }

        public _animal(string id, string title, int life, int life_max, __wardata war)
        {
            this.id = id;
            this.title = title;
            this.life = life;
            this.life_max = life_max;
            this.war = new __wardata(war);
        }

        public _animal(_animal data)
        {
            this.id = data.id;
            this.title = data.title;
            this.life = data.life;
            this.life_max = data.life_max;
            this.war = new __wardata(data.war);
        }
    }

    public class _player : _entity
    {
        public _player()
        {
            this.id = "";
            this.title = "";
            this.life = 0;
            this.life_max = 0;
            this.mana = 0;
            this.mana_max = 0;
            this.war = new __wardata();
            this.skills = new __skills();
            this.equip = new __equipdata();
            this.items = new List<_thing>();
            this.bank = new List<__itembankdata>();
            this.osvej = new List<_thing>();
            this.move = new __movedata();
            this.trader = new __tradingdata();
            this.respawn = new __respawnentitydata();
            this.crim = false;
            this.bankir = false;
            this.healer = false;
            this.attack = "";
            this.speak = "";
            this.tame = 0;
            this.follow = "";
            this.guard = "";
            this.owner = "";
            this.time_owner = 0;
            this.destroyonfree = false;
        }

        /// <summary>
        /// Пересчет основных параметров
        /// </summary>
        public void calcparam()
        {
            this.life_max = 10 + this.skills.Str * 10;
            if (this.life < 0) this.life = this.life_max;
            this.mana_max = 10 + this.skills.Inte * 10;
            if (this.mana < 0) this.mana = this.mana_max;
            int uklon = 10 * (this.skills.Dex + this.skills.Uklon - 5);
            int parring = 10 * (this.skills.Dex + this.skills.Parring - 3);
            int magic_uklon = 10 * (this.skills.Inte + this.skills.Magic_uklon - 7);
            int magic_parring = 10 * (this.skills.Inte + this.skills.Magic_resist - 1);
            int magic_shield = 10 * (this.skills.Magic_resist);
            // считаем крутость exp
            // сумма skills, кроме level
            int exp = this.skills.Str + this.skills.Dex + this.skills.Inte + this.skills.Level + this.skills.Points + this.skills.Meditation + this.skills.Steal +
                this.skills.Animaltaming + this.skills.Hand + this.skills.Coldweapon + this.skills.Ranged + this.skills.Parring + this.skills.Uklon +
                this.skills.Magic + this.skills.Magic_resist + this.skills.Magic_uklon + this.skills.Regeneration + this.skills.Hiding + this.skills.Look +
                this.skills.Steallook + this.skills.Animallore + this.skills.Spirit;
            // что одето
            bool b = false;
            int armor = 0, shield = 0;
            if (this.equip == null) this.equip = new __equipdata();
            int str;
            int ranged = 0, damage_min = 0, damage_max = 0, hit = 0, speed = 0;
            string need = "", needtitle = "", weaponby = "";
            bool arm_fl = false, body_fl = false, hand_fl = false, leg_fl = false, head_fl = false, shield_fl = false;
            foreach (_thing item in this.items)
            {
                if (this.equip.Body == ((_armor)item).Id)
                {
                    armor += ((_armor)item).Armor;
                    body_fl = true;
                }
                else if (this.equip.Hand == ((_armor)item).Id)
                {
                    armor += ((_armor)item).Armor;
                    hand_fl = true;
                }
                else if (this.equip.Leg == ((_armor)item).Id)
                {
                    armor += ((_armor)item).Armor;
                    leg_fl = true;
                }
                else if (this.equip.Head == ((_armor)item).Id)
                {
                    armor += ((_armor)item).Armor;
                    head_fl = true;
                }
                else if (this.equip.Shield == ((_armor)item).Id)
                {
                    shield = ((_armor)item).Armor;
                    shield_fl = true;
                }
                else if (this.equip.Arm == ((_weapon)item).Id && ((_weapon)item).Id.Substring(0, 12) == "item.weapon.")
                {
                    //weapon
                    b = true;
                    speed = ((_weapon)item).Speed - Convert.ToInt32(Math.Round((double)(this.skills.Dex / 2)));
                    if (((_weapon)item).Id.Substring(0, 19) == "item.weapon.ranged.") ranged = 1;
                    else ranged = 0;
                    weaponby = ((_weapon)item).Weaponby;
                    str = ((_weapon)item).Str;
                    if (this.skills.Str < str) str = str - this.skills.Str;
                    if (ranged == 1)
                    {
                        // стрельба
                        need = ((_weapon)item).Need_id; // патроны
                        needtitle = ((_weapon)item).Needtitle; // патроны
                        hit = 10 * (this.skills.Dex + this.skills.Ranged - 1);
                    }
                    else
                    {
                        // холодное оружие
                        need = "";
                        needtitle = "";
                        hit = 10 * (this.skills.Dex + this.skills.Coldweapon);
                    }
                    damage_min = ((_weapon)item).Damage_min - str;
                    damage_max = ((_weapon)item).Damage_max - str;
                    // в арбалетах сила не используется
                    if (((_weapon)item).Id.Substring(0, 27) != "item.weapon.ranged.crossbow")
                    {
                        damage_min += this.skills.Str;
                        damage_max += this.skills.Str;
                    }
                    arm_fl = true;
                }
                if (arm_fl && body_fl && hand_fl && leg_fl && head_fl && shield_fl) break;
            }
            if (!b)
            {
                // рукопашная
                ranged = 0;
                need = "";
                needtitle = "";
                damage_min = this.skills.Str + this.skills.Hand - 1;
                damage_max = this.skills.Str + this.skills.Hand + 1;
                hit = 10 * (this.skills.Dex + this.skills.Hand + 2);
                speed = 5 - Convert.ToInt32(Math.Round((double)(this.skills.Dex / 2)));
                weaponby = "";
            }
            // проверка
            if (hit < 0) hit = 0;
            if (uklon < 0) uklon = 0;
            if (parring < 0) parring = 0;
            if (magic_uklon < 0) magic_uklon = 0;
            if (magic_parring < 0) magic_parring = 0;
            if (damage_min < 0) damage_min = 0;
            if (damage_max < 0) damage_max = 0;
            // ок, подводим итог...
            this.war.Hit = hit;
            this.war.Damage_min = damage_min;
            this.war.Damage_max = damage_max;
            this.war.Speed = speed;
            this.war.Ranged = ranged;
            this.war.Armor = armor;
            this.war.Uklon = uklon;
            this.war.Parring = parring;
            this.war.Shield = shield;
            this.war.Magic_uklon = magic_uklon;
            this.war.Magic_parring = magic_parring;
            this.war.Magic_shield = magic_shield;
            this.war.Weaponby = weaponby;
            this.war.Exp = exp;
            this.war.Need = need;
            this.war.Needtitle = needtitle;
        }
    }

    public class _npc : _entity
    {
        public _npc()
        {
            this.id = "";
            this.title = "";
            this.life = 0;
            this.life_max = 0;
            this.mana = 0;
            this.mana_max = 0;
            this.war = new __wardata();
            this.skills = new __skills();
            this.equip = new __equipdata();
            this.items = new List<_thing>();
            this.bank = new List<__itembankdata>();
            this.osvej = new List<_thing>();
            this.move = new __movedata();
            this.trader = new __tradingdata();
            this.respawn = new __respawnentitydata();
            this.crim = false;
            this.bankir = false;
            this.healer = false;
            this.attack = "";
            this.speak = "";
            this.tame = 0;
            this.follow = "";
            this.guard = "";
            this.owner = "";
            this.time_owner = 0;
            this.destroyonfree = false;
        }

        public _npc(string id, string title, int life, int life_max, string speak, __wardata war)
        {
            this.id = id;
            this.title = title;
            this.life = life;
            this.life_max = life_max;
            this.speak = speak;
            this.war = new __wardata(war);
        }

        public _npc(_npc data)
        {
            this.id = data.id;
            this.title = data.title;
            this.life = data.life;
            this.life_max = data.life_max;
            this.speak = data.speak;
            this.war = new __wardata(data.war);
        }
    }

    public class __tradingdata
    {
        private double price_buy;
        private double price_sell;
        private TimeSpan period;
        private string sayno;
        private DateTime trader_time;
        public List<string> trader_filter;

        public __tradingdata()
        {
            this.price_buy = 0;
            this.price_sell = 0;
            this.period = TimeSpan.MinValue;
            this.sayno = "";
            this.trader_filter = new List<string>();
            this.trader_time = DateTime.MinValue;
        }

        public __tradingdata(double price_buy, double price_sell, TimeSpan period, string sayno)
        {
            this.price_buy = price_buy;
            this.price_sell = price_sell;
            this.period = period;
            this.sayno = sayno;
            this.trader_filter = new List<string>();
            this.trader_time = DateTime.MinValue ;
        }

        public __tradingdata(string rawdata)
        {
            //price_buy|price_sell|period|sayno
            string[] data = rawdata.Split('|');
            this.price_buy = Convert.ToDouble(data[0]);
            this.price_sell = Convert.ToDouble(data[1]);
            this.period = TimeSpan.FromTicks(Convert.ToInt32(data[2]));
            this.sayno = data[3];
            this.trader_filter = new List<string>();
            this.trader_time = DateTime.MinValue;
        }

        public __tradingdata(__tradingdata data)
        {
            this.price_buy = data.Price_buy;
            this.price_sell = data.Price_sell;
            this.period = data.Period;
            this.sayno = data.Sayno;
            this.trader_filter = data.trader_filter;
            this.trader_time = data.Trader_time;
        }

        public double Price_buy { get { return this.price_buy; } set { this.price_buy = value; } }

        public double Price_sell { get { return this.price_sell; } set { this.price_sell = value; } }

        public TimeSpan Period { get { return this.period; } set { this.period = value; } }

        public string Sayno { get { return this.sayno; } set { this.sayno = value; } }

        public DateTime Trader_time { get { return this.trader_time; } set { this.trader_time = value; } }

        public string ToString()
        {
            return Convert.ToString(this.price_buy) + "|" + Convert.ToString(this.price_sell) + "|" + Convert.ToString(this.period) + "|" + this.sayno;
        }
    }

    public class __movedata
    {
        //move=num|time_min|time_max|onlyguard,time_nextmove,moved[]: id локаций, которые посетили
        private int num;
        private int time_min;
        private int time_max;
        private bool onlyguard;

        private int time_nextmove;
        public List<string> moved;

        public __movedata()
        {
            this.num = 0;
            this.time_min = 0;
            this.time_max = 0;
            this.onlyguard = false;
            this.time_nextmove = 0;
            this.moved = new List<string>();
        }

        public __movedata(int num, int time_min, int time_max, bool onlyguard)
        {
            this.num = num;
            this.time_min = time_min;
            this.time_max = time_max;
            this.onlyguard = onlyguard;
            this.time_nextmove = 0;
            this.moved = new List<string>();
        }

        public __movedata(string rawdata)
        {
            string[] data = rawdata.Split('|');
            this.num = Convert.ToInt32(data[0]);
            this.time_min = Convert.ToInt32(data[1]);
            this.time_max = Convert.ToInt32(data[2]);
            this.onlyguard = Convert.ToBoolean(data[3]);
            this.time_nextmove = 0;
            this.moved = new List<string>();
        }

        public __movedata(__movedata data)
        {
            this.num = data.num;
            this.time_min = data.time_min;
            this.time_max = data.time_max;
            this.onlyguard = data.onlyguard;
            this.time_nextmove = data.time_nextmove;
            this.moved = data.moved;
        }

        public int Num { get { return this.num; } set { this.num = value; } }

        public int Time_min { get { return this.time_min; } set { this.time_min = value; } }

        public int Time_max { get { return this.time_max; } set { this.time_max = value; } }

        public bool Onlyguard { get { return this.onlyguard; } set { this.onlyguard = value; } }

        public int Time_nextmove { get { return this.time_nextmove; } set { this.time_nextmove = value; } }

        public string ToString()
        {
            return Convert.ToString(this.num) + "|" + Convert.ToString(this.time_min) + "|" + Convert.ToString(this.time_max) + "|" + Convert.ToString(this.onlyguard);
        }
    }

    public class __equipdata
    {
        private string arm;
        private string body;
        private string hand;
        private string leg;
        private string head;
        private string shield;

        public __equipdata()
        {
            this.arm = "";
            this.body = "";
            this.hand = "";
            this.leg = "";
            this.head = "";
            this.shield = "";
        }

        public __equipdata(string arm,string body,string hand,string leg,string head,string shield)
        {
            this.arm = arm;
            this.body = body;
            this.hand = hand;
            this.leg = leg;
            this.head = head;
            this.shield = shield;
        }

        public __equipdata(string rawdata)
        {
            //arm|body|hand|leg|head|shield
            string[] data = rawdata.Split('|');
            this.arm = data[0];
            this.body = data[1];
            this.hand = data[2];
            this.leg = data[3];
            this.head = data[4];
            this.shield = data[5];
        }

        public __equipdata(__equipdata data)
        {
            this.arm = data.Arm;
            this.body = data.Body;
            this.hand = data.Hand;
            this.leg = data.Leg;
            this.head = data.Head;
            this.shield = data.Shield;
        }

        public string Arm { get { return this.arm; } set { this.arm = value; } }

        public string Body { get { return this.body; } set { this.body = value; } }

        public string Hand { get { return this.hand; } set { this.hand = value; } }

        public string Leg { get { return this.leg; } set { this.leg = value; } }

        public string Head { get { return this.head; } set { this.head = value; } }

        public string Shield { get { return this.shield; } set { this.shield = value; } }

        public bool IsEquipped(string id)
        {
            id = id.ToLower();
            if (arm.ToLower() == id || body.ToLower() == id || hand.ToLower() == id || leg.ToLower() == id || head.ToLower() == id || shield.ToLower() == id)
                return true;
            return false;
        }

        public string ToString()
        {
            return this.arm + "|" + this.body + "|" + this.hand + "|" + this.leg + "|" + this.head + "|" + this.shield;
        }
    }

    public class __wardata
    {
        private int hit;
        private int damage_min;
        private int damage_max;
        private int speed;
        private int ranged;
        private int armor;
        private int uklon;
        private int parring;
        private int shield;
        private int magic_uklon;
        private int magic_parring;
        private int magic_shield;
        private string weaponby;
        private int exp;
        private string need;
        private string needtitle;

        public __wardata()
        {
            this.hit = 0;
            this.damage_min = 0;
            this.damage_max = 0;
            this.speed = 0;
            this.ranged = 0;
            this.armor = 0;
            this.uklon = 0;
            this.parring = 0;
            this.shield = 0;
            this.magic_uklon = 0;
            this.magic_parring = 0;
            this.magic_shield = 0;
            this.weaponby = "";
            this.exp = 0;
            this.need = "";
            this.needtitle = "";
        }

        public __wardata(int hit, int damage_min, int damage_max, int speed, int ranged, int armor, int uklon, int parring, int shield, int magic_uklon, int magic_parring, int magic_shield, string weaponby, int exp, string need, string needtitle)
        {
            this.hit = hit;
            this.damage_min = damage_min;
            this.damage_max = damage_max;
            this.speed = speed;
            this.ranged = ranged;
            this.armor = armor;
            this.uklon = uklon;
            this.parring = parring;
            this.shield = shield;
            this.magic_uklon = magic_uklon;
            this.magic_parring = magic_parring;
            this.magic_shield = magic_shield;
            this.weaponby = weaponby;
            this.exp = exp;
            this.need = need;
            this.needtitle = needtitle;
        }

        public __wardata(string rawdata)
        {
            //hit|damage_min|damage_max|speed|ranged|armor|uklon|parring|shield|magic_uklon|magic_parring|magic_shield|weaponby|exp|need|needtitle
            string[] data = rawdata.Split('|');
            this.hit = Convert.ToInt32(data[0]);
            this.damage_min = Convert.ToInt32(data[1]);
            this.damage_max = Convert.ToInt32(data[2]);
            this.speed = Convert.ToInt32(data[3]);
            this.ranged = Convert.ToInt32(data[4]);
            this.armor = Convert.ToInt32(data[5]);
            this.uklon = Convert.ToInt32(data[6]);
            this.parring = Convert.ToInt32(data[7]);
            this.shield = Convert.ToInt32(data[8]);
            this.magic_uklon = Convert.ToInt32(data[9]);
            this.magic_parring = Convert.ToInt32(data[10]);
            this.magic_shield = Convert.ToInt32(data[11]);
            this.weaponby = data[12];
            this.exp = Convert.ToInt32(data[13]);
            this.need = data[14];
            this.needtitle = data[15];
        }

        public __wardata(__wardata data)
        {
            this.hit = data.Hit;
            this.damage_min = data.Damage_min;
            this.damage_max = data.Damage_max;
            this.speed = data.Speed;
            this.ranged = data.Ranged;
            this.armor = data.Armor;
            this.uklon = data.Uklon;
            this.parring = data.Parring;
            this.shield = data.Shield;
            this.magic_uklon = data.Magic_uklon;
            this.magic_parring = data.Magic_parring;
            this.magic_shield = data.Magic_shield;
            this.weaponby = data.Weaponby;
            this.exp = data.Exp;
            this.need = data.Need;
            this.needtitle = data.Needtitle;
        }

        public int Hit { get { return this.hit; } set { this.hit = value; } }

        public int Damage_min { get { return this.damage_min; } set { this.damage_min = value; } }

        public int Damage_max { get { return this.damage_max; } set { this.damage_max = value; } }

        public int Speed { get { return this.speed; } set { this.speed = value; } }

        public int Ranged { get { return this.ranged; } set { this.ranged = value; } }

        public int Armor { get { return this.armor; } set { this.armor = value; } }

        public int Uklon { get { return this.uklon; } set { this.uklon = value; } }

        public int Parring { get { return this.parring; } set { this.parring = value; } }

        public int Shield { get { return this.shield; } set { this.shield = value; } }

        public int Magic_uklon { get { return this.magic_uklon; } set { this.magic_uklon = value; } }

        public int Magic_parring { get { return this.magic_parring; } set { this.magic_parring = value; } }

        public int Magic_shield { get { return this.magic_shield; } set { this.magic_shield = value; } }

        public string Weaponby { get { return this.weaponby; } set { this.weaponby = value; } }

        public int Exp { get { return this.exp; } set { this.exp = value; } }

        public string Need { get { return this.need; } set { this.need = value; } }

        public string Needtitle { get { return this.needtitle; } set { this.needtitle = value; } }

        public string ToString()
        {
            return Convert.ToString(this.hit) + "|" + Convert.ToString(this.damage_min) + "|" + Convert.ToString(this.damage_max) + "|" + Convert.ToString(this.speed)
                + "|" + Convert.ToString(this.ranged) + "|" + Convert.ToString(this.armor) + "|" + Convert.ToString(this.uklon) + "|" + Convert.ToString(this.parring)
                + "|" + Convert.ToString(this.shield) + "|" + Convert.ToString(this.magic_uklon) + "|" + Convert.ToString(this.magic_parring)
                + "|" + Convert.ToString(this.magic_shield) + "|" + this.weaponby + "|" + Convert.ToString(this.exp) + "|" + this.need + "|" + this.needtitle;
        }
    }

    public class __skills
    {
        private int str;
        private int dex;
        private int inte;
        private int level;
        private int points;
        private int meditation;
        private int steal;
        private int animaltaming;
        private int hand;
        private int coldweapon;
        private int ranged;
        private int parring;
        private int uklon;
        private int magic;
        private int magic_resist;
        private int magic_uklon;
        private int regeneration;
        private int hiding;
        private int look;
        private int steallook;
        private int animallore;
        private int spirit;

        public __skills()
        {
            this.str = 0;
            this.dex = 0;
            this.inte = 0;
            this.level = 0;
            this.points = 0;
            this.meditation = 0;
            this.steal = 0;
            this.animaltaming = 0;
            this.hand = 0;
            this.coldweapon = 0;
            this.ranged = 0;
            this.parring = 0;
            this.uklon = 0;
            this.magic = 0;
            this.magic_resist = 0;
            this.magic_uklon = 0;
            this.regeneration = 0;
            this.hiding = 0;
            this.look = 0;
            this.steallook = 0;
            this.animallore = 0;
            this.spirit = 0;
        }

        public __skills(int str, int dex, int inte, int level, int points, int meditation, int steal, int animaltaming, int hand, int coldweapon, int ranged, int parring, int uklon, int magic, int magic_resist, int magic_uklon, int regeneration, int hiding, int look, int steallook, int animallore, int spirit)
        {
            this.str = str;
            this.dex = dex;
            this.inte = inte;
            this.level = level;
            this.points = points;
            this.meditation = meditation;
            this.steal = steal;
            this.animaltaming = animaltaming;
            this.hand = hand;
            this.coldweapon = coldweapon;
            this.ranged = ranged;
            this.parring = parring;
            this.uklon = uklon;
            this.magic = magic;
            this.magic_resist = magic_resist;
            this.magic_uklon = magic_uklon;
            this.regeneration = regeneration;
            this.hiding = hiding;
            this.look = look;
            this.steallook = steallook;
            this.animallore = animallore;
            this.spirit = spirit;
        }

        public __skills(string rawdata)
        {
            //str|dex|int|level|points|meditation|steal|animaltaming|hand|coldweapon|ranged|parring|uklon|magic|magic_resist|magic_uklon|regeneration|hiding|look|steallook|animallore|spirit
            string[] data = rawdata.Split('|');
            this.str = Convert.ToInt32(data[0]);
            this.dex = Convert.ToInt32(data[1]);
            this.inte = Convert.ToInt32(data[2]);
            this.level = Convert.ToInt32(data[3]);
            this.points = Convert.ToInt32(data[4]);
            this.meditation = Convert.ToInt32(data[5]);
            this.steal = Convert.ToInt32(data[6]);
            this.animaltaming = Convert.ToInt32(data[7]);
            this.hand = Convert.ToInt32(data[8]);
            this.coldweapon = Convert.ToInt32(data[9]);
            this.ranged = Convert.ToInt32(data[10]);
            this.parring = Convert.ToInt32(data[11]);
            this.uklon = Convert.ToInt32(data[12]);
            this.magic = Convert.ToInt32(data[13]);
            this.magic_resist = Convert.ToInt32(data[14]);
            this.magic_uklon = Convert.ToInt32(data[15]);
            this.regeneration = Convert.ToInt32(data[16]);
            this.hiding = Convert.ToInt32(data[17]);
            this.look = Convert.ToInt32(data[18]);
            this.steallook = Convert.ToInt32(data[19]);
            this.animallore = Convert.ToInt32(data[20]);
            this.spirit = Convert.ToInt32(data[21]);
        }

        public __skills(__skills data)
        {
            this.str = data.str;
            this.dex = data.dex;
            this.inte = data.inte;
            this.level = data.level;
            this.points = data.points;
            this.meditation = data.meditation;
            this.steal = data.steal;
            this.animaltaming = data.animaltaming;
            this.hand = data.hand;
            this.coldweapon = data.coldweapon;
            this.ranged = data.ranged;
            this.parring = data.parring;
            this.uklon = data.uklon;
            this.magic = data.magic;
            this.magic_resist = data.magic_resist;
            this.magic_uklon = data.magic_uklon;
            this.regeneration = data.regeneration;
            this.hiding = data.hiding;
            this.look = data.look;
            this.steallook = data.steallook;
            this.animallore = data.animallore;
            this.spirit = data.spirit;
        }

        public int Str { get { return this.str; } set { this.str = value; } }

        public int Dex { get { return this.dex; } set { this.dex = value; } }

        public int Inte { get { return this.inte; } set { this.inte = value; } }

        public int Level { get { return this.level; } set { this.level = value; } }

        public int Points { get { return this.points; } set { this.points = value; } }

        public int Meditation { get { return this.meditation; } set { this.meditation = value; } }

        public int Steal { get { return this.steal; } set { this.steal = value; } }

        public int Animaltaming { get { return this.animaltaming; } set { this.animaltaming = value; } }

        public int Hand { get { return this.hand; } set { this.hand = value; } }

        public int Coldweapon { get { return this.coldweapon; } set { this.coldweapon = value; } }

        public int Ranged { get { return this.ranged; } set { this.ranged = value; } }

        public int Parring { get { return this.parring; } set { this.parring = value; } }

        public int Uklon { get { return this.uklon; } set { this.uklon = value; } }

        public int Magic { get { return this.magic; } set { this.magic = value; } }

        public int Magic_resist { get { return this.magic_resist; } set { this.magic_resist = value; } }

        public int Magic_uklon { get { return this.magic_uklon; } set { this.magic_uklon = value; } }

        public int Regeneration { get { return this.regeneration; } set { this.regeneration = value; } }

        public int Hiding { get { return this.hiding; } set { this.hiding = value; } }

        public int Look { get { return this.look; } set { this.look = value; } }

        public int Steallook { get { return this.steallook; } set { this.steallook = value; } }

        public int Animallore { get { return this.animallore; } set { this.animallore = value; } }

        public int Spirit { get { return this.spirit; } set { this.spirit = value; } }

        public int GetSkillByName(string name)
        {
            if (name == "str") return this.str;
            else if (name == "dex") return this.dex;
            else if (name == "int") return this.inte;
            else if (name == "level") return this.level;
            else if (name == "points") return this.points;
            else if (name == "meditation") return this.meditation;
            else if (name == "steal") return this.steal;
            else if (name == "animaltaming") return this.animaltaming;
            else if (name == "hand") return this.hand;
            else if (name == "coldweapon") return this.coldweapon;
            else if (name == "ranged") return this.ranged;
            else if (name == "parring") return this.parring;
            else if (name == "uklon") return this.uklon;
            else if (name == "magic") return this.magic;
            else if (name == "magic_resist") return this.magic_resist;
            else if (name == "magic_uklon") return this.magic_uklon;
            else if (name == "regeneration") return this.regeneration;
            else if (name == "hiding") return this.hiding;
            else if (name == "look") return this.look;
            else if (name == "steallook") return this.steallook;
            else if (name == "animallore") return this.animallore;
            else if (name == "spirit") return this.spirit;
            else return -1;
        }

        public bool SetSkillByName(string name, int value)
        {
            if (name == "str") {this.str = value; return true;}
            else if (name == "dex"){ this.dex = value; return true;}
            else if (name == "int"){  this.inte = value; return true;}
            else if (name == "level"){ this.level = value; return true;}
            else if (name == "points"){ this.points = value; return true;}
            else if (name == "meditation"){ this.meditation = value; return true;}
            else if (name == "steal"){ this.steal = value; return true;}
            else if (name == "animaltaming") {this.animaltaming = value; return true;}
            else if (name == "hand"){ this.hand = value; return true;}
            else if (name == "coldweapon") {this.coldweapon = value; return true;}
            else if (name == "ranged"){ this.ranged = value; return true;}
            else if (name == "parring") {this.parring = value; return true;}
            else if (name == "uklon") {this.uklon = value; return true;}
            else if (name == "magic"){ this.magic = value; return true;}
            else if (name == "magic_resist"){ this.magic_resist = value; return true;}
            else if (name == "magic_uklon"){ this.magic_uklon = value; return true;}
            else if (name == "regeneration"){ this.regeneration = value; return true;}
            else if (name == "hiding"){ this.hiding = value; return true;}
            else if (name == "look"){ this.look = value; return true;}
            else if (name == "steallook") {this.steallook = value; return true;}
            else if (name == "animallore") {this.animallore = value; return true;}
            else if (name == "spirit") { this.spirit = value; return true; }
            else return false;
        }

        public string ToString()
        {
            return
                Convert.ToString(this.str) + "|" + Convert.ToString(this.dex) + "|" + Convert.ToString(this.inte) + "|" + Convert.ToString(this.level) + "|" +
                Convert.ToString(this.points) + "|" + Convert.ToString(this.meditation) + "|" + Convert.ToString(this.steal) + "|" + Convert.ToString(this.animaltaming) + "|" +
                Convert.ToString(this.hand) + "|" + Convert.ToString(this.coldweapon) + "|" + Convert.ToString(this.ranged) + "|" + Convert.ToString(this.parring) + "|" +
                Convert.ToString(this.uklon) + "|" + Convert.ToString(this.magic) + "|" + Convert.ToString(this.magic_resist) + "|" + Convert.ToString(this.magic_uklon) + "|" +
                Convert.ToString(this.regeneration) + "|" + Convert.ToString(this.hiding) + "|" + Convert.ToString(this.look) + "|" + Convert.ToString(this.steallook) + "|" +
                Convert.ToString(this.animallore) + "|" + Convert.ToString(this.spirit);
        }
    }

    public class __respawnentitydata
    {
        private string loc;
        private int time_min;
        private int time_max;

        public __respawnentitydata()
        {
            this.loc = "";
            this.time_min = 0;
            this.time_max = 0;
        }

        public __respawnentitydata(string loc, int time_min, int time_max)
        {
            this.loc = loc;
            this.time_min = time_min;
            this.time_max = time_max;
        }

        public __respawnentitydata(string rawdata)
        {
            //loc|time_min|time_max
            string[] data = rawdata.Split();
            this.loc = data[0];
            this.time_min = Convert.ToInt32(data[1]);
            this.time_max = Convert.ToInt32(data[2]);
        }

        public __respawnentitydata(__respawnentitydata data)
        {
            this.loc = data.Loc;
            this.time_min = data.Time_min;
            this.time_max = data.Time_max;
        }

        public string Loc { get { return this.loc; } set { this.loc = value; } }

        public int Time_min { get { return this.time_min; } set { this.time_min = value; } }

        public int Time_max { get { return this.time_max; } set { this.time_max = value; } }

        public string ToString()
        {
            return this.loc + "|" + Convert.ToString(this.time_min) + "|" + Convert.ToString(this.time_max);
        }
    }

    #endregion

    #region Предметы и магия

    public class _itemlocdata
    {
        private int time;
        public _thing item;
        public __respawnitemdata respawn;

        public _itemlocdata()
        {
            this.time = 0;
            this.item = new _thing();
            this.respawn = new __respawnitemdata();
        }

        public _itemlocdata(int time, _thing item, __respawnitemdata respawn)
        {
            this.time = time;
            if (item is _item) 
            {
                if (item is _food) this.item = new _food((_food)item);
                else if (item is _armor) this.item = new _armor((_armor)item);
                else if (item is _weapon) this.item = new _weapon((_weapon)item);
                else if (item is _note) this.item = new _note((_note)item);
                else this.item = new _item((_item)item);
            }
            else this.item = new _thing();
            this.respawn = new __respawnitemdata(respawn);
        }

        public _itemlocdata(_itemlocdata data)
        {
            this.time = data.time;
            if (item is _item)
            {
                if (item is _food) this.item = new _food((_food)item);
                else if (item is _armor) this.item = new _armor((_armor)item);
                else if (item is _weapon) this.item = new _weapon((_weapon)item);
                else if (item is _note) this.item = new _note((_note)item);
                else this.item = new _item((_item)item);
            }
            else this.item = new _thing();
            this.respawn = new __respawnitemdata(data.respawn);
        }

    }

    public class __itembankdata
    {
        private int ver;
        private int min;
        private int max;
        public _thing item;

        public __itembankdata()
        {
            this.ver = 0;
            this.min = 0;
            this.max = 0;
            this.item = new _thing();
        }

        public __itembankdata(int ver, int min, int max, _thing item)
        {
            this.ver = ver;
            this.min = min;
            this.max = max;
            if (item is _item)
            {
                if (item is _food) this.item = new _food((_food)item);
                else if (item is _armor) this.item = new _armor((_armor)item);
                else if (item is _weapon) this.item = new _weapon((_weapon)item);
                else if (item is _note) this.item = new _note((_note)item);
                else this.item = new _item((_item)item);
            }
            else this.item = new _thing();
        }

        public __itembankdata(string rawdata)
        {
            //ver|min|max
            string[] data = rawdata.Split('|');
            this.ver = Convert.ToInt32(data[0]);
            this.min = Convert.ToInt32(data[1]);
            this.max = Convert.ToInt32(data[2]);
            this.item = new _thing();
        }

        public __itembankdata(__itembankdata data)
        {
            this.ver = data.ver;
            this.min = data.min;
            this.max = data.max;
            if (data.item is _item)
            {
                if (data.item is _food) this.item = new _food((_food)data.item);
                else if (data.item is _armor) this.item = new _armor((_armor)data.item);
                else if (data.item is _weapon) this.item = new _weapon((_weapon)data.item);
                else if (data.item is _note) this.item = new _note((_note)data.item);
                else this.item = new _item((_item)data.item);
            }
            else this.item = new _thing();
        }

        public int Ver { get { return this.ver; } set { this.ver = value; } }

        public int Min { get { return this.min; } set { this.min = value; } }

        public int Max { get { return this.max; } set { this.max = value; } }
    }
    
    public class __respawnitemdata
    {
        private int time_min;
        private int time_max;
        private int count_min;
        private int count_max;

        public __respawnitemdata()
        {
            this.time_min = 0;
            this.time_max = 0;
            this.count_min = 0;
            this.count_max = 0;
        }

        public __respawnitemdata(int time_min, int time_max, int count_min, int count_max)
        {
            this.time_min = time_min;
            this.time_max = time_max;
            this.count_min = count_min;
            this.count_max = count_max;
        }

        public __respawnitemdata(string rawdata)
        {
            //time_min|time_max|count_min|count_max
            string[] data = rawdata.Split('|');
            this.time_min = Convert.ToInt32(data[0]);
            this.time_max = Convert.ToInt32(data[1]);
            this.count_min = Convert.ToInt32(data[2]);
            this.count_max = Convert.ToInt32(data[3]);
        }

        public __respawnitemdata(__respawnitemdata data)
        {
            this.time_min = data.Time_min;
            this.time_max = data.Time_max;
            this.count_min = data.Count_min;
            this.count_max = data.Count_max;
        }

        public int Time_min { get { return this.time_min; } set { this.time_min = value; } }

        public int Time_max { get { return this.time_max; } set { this.time_max = value; } }

        public int Count_min { get { return this.count_min; } set { this.count_min = value; } }

        public int Count_max { get { return this.count_max; } set { this.count_max = value; } }

        public string ToString()
        {
            return Convert.ToString(this.time_min) + "|" + Convert.ToString(this.time_max) + "|" + Convert.ToString(this.count_min) + "|" + Convert.ToString(this.count_max);
        }
    }

    public class _thing
    {
        protected string id;
        protected string title;
        protected int count;
        protected int cost;

        protected int life;
        protected int mana;

        protected int armor;

        protected int damage_min;
        protected int damage_max;
        protected int str;
        protected int speed;
        protected string weaponby;
        protected string need_id;
        protected string needtitle;

        protected string desc;

        public _thing()
        {
            this.id = "";
            this.title = "";
            this.count = 0;
            this.cost = 0;

            this.life = 0;
            this.mana = 0;

            this.armor = 0;

            this.damage_min = 0;
            this.damage_max = 0;
            this.str = 0;
            this.speed = 0;
            this.weaponby = "";
            this.need_id = "";
            this.needtitle = "";

            this.desc = "";
        }

        public _thing(_item data)
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;

            this.life = 0;
            this.mana = 0;

            this.armor = 0;

            this.damage_min = 0;
            this.damage_max = 0;
            this.str = 0;
            this.speed = 0;
            this.weaponby = "";
            this.need_id = "";
            this.needtitle = "";

            this.desc = "";
        }

        public _thing(_food data)
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;

            this.life = data.life;
            this.mana = data.mana;

            this.armor = 0;

            this.damage_min = 0;
            this.damage_max = 0;
            this.str = 0;
            this.speed = 0;
            this.weaponby = "";
            this.need_id = "";
            this.needtitle = "";

            this.desc = "";
        }

        public _thing(_armor data)
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;

            this.life = 0;
            this.mana = 0;

            this.armor = data.armor;

            this.damage_min = 0;
            this.damage_max = 0;
            this.str = 0;
            this.speed = 0;
            this.weaponby = "";
            this.need_id = "";
            this.needtitle = "";

            this.desc = "";
        }

        public _thing(_weapon data)
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;

            this.life = 0;
            this.mana = 0;

            this.armor = 0;

            this.damage_min = data.damage_min;
            this.damage_max = data.damage_max;
            this.str = data.str;
            this.speed = data.speed;
            this.weaponby = data.weaponby;
            this.need_id = data.need_id;
            this.needtitle = data.needtitle;

            this.desc = "";
        }

        public _thing(_note data)
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;

            this.life = 0;
            this.mana = 0;

            this.armor = 0;

            this.damage_min = 0;
            this.damage_max = 0;
            this.str = 0;
            this.speed = 0;
            this.weaponby = "";
            this.need_id = "";
            this.needtitle = "";

            this.desc = data.desc;
        }

        public _thing(_thing data)
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;

            this.life = data.life;
            this.mana = data.mana;

            this.armor = data.armor;

            this.damage_min = data.damage_min;
            this.damage_max = data.damage_max;
            this.str = data.str;
            this.speed = data.speed;
            this.weaponby = data.weaponby;
            this.need_id = data.need_id;
            this.needtitle = data.needtitle;

            this.desc = data.desc;
        }
    }

    public class _item : _thing
    {
        public _item()
            : base()
        {
            
        }

        public _item(string id, string title, int count, int cost)
            : base()
        {
            this.id = id;
            this.title = title;
            this.count = count;
            this.cost = cost;
        }

        public _item(string rawdata)
            : base()
        {
            //id|title|count|cost
            string[] data = rawdata.Split('|');
            this.id = data[0];
            this.title = data[1];
            this.count = Int32.Parse(data[2]);
            this.cost = Int32.Parse(data[3]);
        }

        public _item(_item data)
            : base()
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;
            this.desc = data.desc;
        }

        public string Id { get { return this.id; } set { this.id = value; } }

        public string Title { get { return this.title; } set { this.title = value; } }

        public int Count { get { return this.count; } set { this.count = value; } }

        public int Cost { get { return this.cost; } set { this.cost = value; } }

        public string Description { get { return this.desc; } set { this.desc = value; } }

        public string ToString()
        {
            return this.id + "|" + this.title + "|" + Convert.ToString(this.count) + "|" + Convert.ToString(this.cost);
        }
    }

    public class _food : _item
    {
        public _food()
            : base()
        {
            
        }

        public _food(string id, string title, int count, int cost, int life, int mana)
            : base(id, title, count, cost)
        {
            this.life = life;
            this.mana = mana;
        }

        public _food(string rawdata)
            : base()
        {
            //id|title|count|cost|life|mana
            string[] data = rawdata.Split('|');
            this.id = data[0];
            this.title = data[1];
            this.count = Int32.Parse(data[2]);
            this.cost = Int32.Parse(data[3]);
            this.life = Int32.Parse(data[4]);
            this.mana = Int32.Parse(data[5]);
        }

        public _food(_food data)
            : base()
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;
            this.life = data.life;
            this.mana = data.mana;
            this.desc = data.desc;
        }

        public int Life { get { return this.count; } set { this.count = value; } }

        public int Mana { get { return this.cost; } set { this.cost = value; } }

        public string ToString()
        {
            return this.id + "|" + this.title + "|" + Convert.ToString(this.count) + "|" + Convert.ToString(this.cost) + "|" + Convert.ToString(this.life) + "|" + Convert.ToString(this.mana);
        }
    }

    public class _armor : _item
    {
        public _armor()
            : base()
        {
            
        }

        public _armor(string id, string title, int count, int cost, int armor)
            : base(id, title, count, cost)
        {
            this.armor = armor;
        }

        public _armor(string rawdata)
            : base()
        {
            //id|title|count|cost|armor
            string[] data = rawdata.Split('|');
            this.id = data[0];
            this.title = data[1];
            this.count = Int32.Parse(data[2]);
            this.cost = Int32.Parse(data[3]);
            this.armor = Int32.Parse(data[4]);
        }

        public _armor(_armor data)
            : base()
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;
            this.armor = data.armor;
            this.desc = data.desc;
        }

        public int Armor { get { return this.armor; } set { this.armor = value; } }

        public string ToString()
        {
            return this.id + "|" + this.title + "|" + Convert.ToString(this.count) + "|" + Convert.ToString(this.cost) + "|" + Convert.ToString(this.armor);
        }
    }

    public class _weapon : _item
    {
        public  _weapon()
            : base()
        {
            
        }

        public _weapon(string id, string title, int count, int cost, int damage_min, int damage_max, int str, int speed, string weaponby, string need_id, string needtitle)
            : base(id, title, count, cost)
        {
            this.damage_min = damage_min;
            this.damage_max = damage_max;
            this.str = str;
            this.speed = speed;
            this.weaponby = weaponby;
            this.need_id = need_id;
            this.needtitle = needtitle;
        }

        public _weapon(string rawdata)
            : base()
        {
            //id|title|count|cost|damage_min|damage_max|str|speed|weaponby|need_id|needtitle
            string[] data = rawdata.Split('|');
            this.id = data[0];
            this.title = data[1];
            this.count = Int32.Parse(data[2]);
            this.cost = Int32.Parse(data[3]);
            this.damage_min = Int32.Parse(data[4]);
            this.damage_max = Int32.Parse(data[5]);
            this.str = Int32.Parse(data[6]);
            this.speed = Int32.Parse(data[7]);
            this.weaponby = data[8];
            this.need_id = data[9];
            this.needtitle = data[10];
        }

        public _weapon(_weapon data)
            : base()
        {
            this.id = data.Id;
            this.title = data.Title;
            this.count = data.Count;
            this.cost = data.Cost;
            this.damage_min = data.Damage_min;
            this.damage_max = data.Damage_max;
            this.str = data.Str;
            this.speed = data.Speed;
            this.weaponby = data.Weaponby;
            this.need_id = data.Need_id;
            this.needtitle = data.Needtitle;
        }

        public int Damage_min { get { return this.damage_min; } set { this.damage_min = value; } }

        public int Damage_max { get { return this.damage_max; } set { this.damage_max = value; } }

        public int Str { get { return this.str; } set { this.str = value; } }

        public int Speed { get { return this.speed; } set { this.speed = value; } }

        public string Weaponby { get { return this.weaponby; } set { this.weaponby = value; } }

        public string Need_id { get { return this.need_id; } set { this.need_id = value; } }

        public string Needtitle { get { return this.needtitle; } set { this.needtitle = value; } }

        public string ToString()
        {
            return this.id + "|" + this.title + "|" + Convert.ToString(this.count) + "|" + Convert.ToString(this.cost) + "|" + Convert.ToString(this.damage_min) + "|" + Convert.ToString(this.damage_max) + "|" + Convert.ToString(this.str) + "|" + Convert.ToString(this.speed) + "|" + this.weaponby + "|" + this.need_id + "|" + this.needtitle; ;
        }
    }

    public class _note : _item
    {
        public _note()
            : base()
        {
            
        }

        public _note(string id, string title, int count, int cost, string desc)
            : base(id, title, count, cost)
        {
            this.desc = desc;
        }

        public _note(string rawdata)
            : base()
        {
            //id|title|count|cost|desc
            string[] data = rawdata.Split('|');
            this.id = data[0];
            this.title = data[1];
            this.count = Int32.Parse(data[2]);
            this.cost = Int32.Parse(data[3]);
            this.desc = data[4];
        }

        public _note(_note data)
            : base()
        {
            this.id = data.id;
            this.title = data.title;
            this.count = data.count;
            this.cost = data.cost;
            this.desc = data.desc;
        }

        public string ToString()
        {
            return this.id + "|" + this.title + "|" + Convert.ToString(this.count) + "|" + Convert.ToString(this.cost) + "|" + this.desc;
        }
    }

    public class _magic
    {
        private string id;
        private string title;
        private int mana;
        private int level;
        private string say;
        private int damage_min;
        private int damage_max;
        private bool needtarget;
        private bool onlycrim;
        private int speed;
        public List<__magicneeds> need;

        public _magic()
        {
            this.id = "";
            this.title = "";
            this.mana = 0;
            this.level = 0;
            this.say = "";
            this.damage_min = 0;
            this.damage_min = 0;
            this.needtarget = false;
            this.onlycrim = false;
            this.speed = 0;
            this.need = new List<__magicneeds>();
        }

        public _magic(string id, string title, int mana, int level, string say, int damage_min, int damage_max, bool needtarget, bool onlycrim, int speed)
        {
            this.id = id;
            this.title = title;
            this.mana = mana;
            this.level = level;
            this.say = say;
            this.damage_min = damage_min;
            this.damage_min = damage_max;
            this.needtarget = needtarget;
            this.onlycrim = onlycrim;
            this.speed = speed;
            this.need = new List<__magicneeds>();
        }

        public _magic(string rawdata)
        {
            //id|title|mana|level|say|damage_min|damage_max|needtarget|onlycrim|speed|need_id:count:title|need_id:count:title
            string[] data = rawdata.Split('|');
            this.id = data[0];
            this.title = data[1];
            this.mana = Convert.ToInt32(data[2]);
            this.level = Convert.ToInt32(data[3]);
            this.say = data[4];
            this.damage_min = Convert.ToInt32(data[5]);
            this.damage_min = Convert.ToInt32(data[6]);
            this.needtarget = Convert.ToBoolean(data[7]);
            this.onlycrim = Convert.ToBoolean(data[8]);
            this.speed = Convert.ToInt32(data[9]);
            this.need = new List<__magicneeds>();
            for (int i = 10; i < data.Length; i++)
            {
                this.need.Add(new __magicneeds(data[i]));
            }
        }

        public _magic(_magic data)
        {
            this.id = data.Id;
            this.title = data.Title;
            this.mana = data.Mana;
            this.level = data.Level;
            this.say = data.Say;
            this.damage_min = data.Damage_min;
            this.damage_min = data.Damage_max;
            this.needtarget = data.Needtarget;
            this.onlycrim = data.Onlycrim;
            this.speed = data.Speed;
            this.need = new List<__magicneeds>();
            foreach (__magicneeds item in data.need)
            {
                this.need.Add(new __magicneeds(item));
            }
        }

        public string Id { get { return this.id; } set { this.id = value; } }

        public string Title { get { return this.title; } set { this.title = value; } }

        public int Mana { get { return this.mana; } set { this.mana = value; } }

        public int Level { get { return this.level; } set { this.level = value; } }

        public string Say { get { return this.say; } set { this.say = value; } }

        public int Damage_min { get { return this.damage_min; } set { this.damage_min = value; } }

        public int Damage_max { get { return this.damage_max; } set { this.damage_max = value; } }

        public bool Needtarget { get { return this.needtarget; } set { this.needtarget = value; } }

        public bool Onlycrim { get { return this.onlycrim; } set { this.onlycrim = value; } }

        public int Speed { get { return this.speed; } set { this.speed = value; } }
        
        public string ToString()
        {
            string ret = this.id + "|" + this.title + "|" + Convert.ToString(this.mana) + "|" + Convert.ToString(this.level) + "|" + this.say + "|" +
                Convert.ToString(this.damage_min) + "|" + Convert.ToString(this.damage_max) + "|" + Convert.ToString(this.needtarget) + "|" +
                Convert.ToString(this.onlycrim) + "|" + Convert.ToString(this.speed);
            foreach (__magicneeds item in this.need) ret += "|" + item.ToString();
            return ret;
        }
    }

    public class __magicneeds
    {
        private string need_id;
        private int count;
        private string title;

        public __magicneeds()
        {
            this.need_id = "";
            this.count = 0;
            this.title = "";
        }

        public __magicneeds(string need_id, int count, string title)
        {
            this.need_id = need_id;
            this.count = count;
            this.title = title;
        }

        public __magicneeds(string rawdata)
        {
            //need_id:count:title
            string[] data = rawdata.Split(':');
            this.need_id = data[0];
            this.count = Convert.ToInt32(data[1]);
            this.title = data[2];
        }

        public __magicneeds(__magicneeds data)
        {
            this.need_id = data.Need_id;
            this.count = data.Count;
            this.title = data.Title;
        }

        public string Need_id { get { return this.need_id; } set { this.need_id = value; } }

        public int Count { get { return this.count; } set { this.count = value; } }

        public string Title { get { return this.title; } set { this.title = value; } }

        public string ToString()
        {
            return this.need_id + ":" + Convert.ToString(this.count) + ":" + this.title;
        }
    }

    #endregion

}
