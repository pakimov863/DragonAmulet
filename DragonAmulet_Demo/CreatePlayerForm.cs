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
    public partial class CreatePlayerForm : Form
    {
        private static CreatePlayerForm CreatePlayer;
        private static _player returnData;
        public CreatePlayerForm()
        {
            InitializeComponent();
        }

        public static _player ShowForm()
        {
            CreatePlayer = new CreatePlayerForm();
            returnData = new _player();
            CreatePlayer.ShowDialog();
            return returnData;
        }

        // Создать персонажа
        private void button1_Click(object sender, EventArgs e)
        {
            /*returnData = new DragonAmulet_Demo.Utilites._1Player();
            returnData.title = "TestUser";
            returnData.skills = new Dictionary<string, int>();
            returnData.skills["str"] = 1; //0
            returnData.skills["dex"] = 1; //1
            returnData.skills["int"] = 1; //2
            returnData.skills["level"] = 0; //3
            returnData.skills["points"] = 2; //4
            returnData.skills["meditation"] = 0; //5
            returnData.skills["steal"] = 0; //6
            returnData.skills["animaltaming"] = 0; //7
            returnData.skills["hand"] = 0; //8
            returnData.skills["coldweapon"] = 0; //9
            returnData.skills["ranged"] = 0; //10
            returnData.skills["parring"] = 0; //11
            returnData.skills["uklon"] = 0; //12
            returnData.skills["magic"] = 0; //13
            returnData.skills["magic_resist"] =0; //14
            returnData.skills["magic_uklon"] = 0; //15
            returnData.skills["regeneration"] = 0; //16
            returnData.skills["hiding"] = 0; //17
            returnData.skills["look"] = 0; //18
            returnData.skills["steallook"] = 0; //19
            returnData.skills["animallore"] = 0; //20
            returnData.skills["spirit"] = 0; //21
            returnData.location = "loc.0";
            returnData.ghost = false;
            returnData.crim = false;
            returnData.journal = new List<string>();
            returnData.equip = new Dictionary<string, string>();
            returnData.items = new Dictionary<string, string>();
            returnData.items["item.misc.money"] = "монеты|400|1";
            returnData.items["item.note"] = "записка|1|0|Здравствуй, мой юный друг! Зная, что тебе нелегко придется в первое время, я снабдил тебя 400 монетами, потрать их на обучение и, в первую очередь, на поднятие силы и ловкости. Обо всем остальном тебе расскажет привратник Уин. Удачи и береги себя!/nподпись: БОГ";
            returnData.items["item.scroll.createfood"] = "свиток Создать еду|1|20";
            returnData.items["item.scroll.war.arrow"] = "свиток Магическая стрела|3|30";
            returnData.items["item.scroll.summon.wolf"] = "свиток Призвать волка|2|45";
            Utilites.CalcParam(ref returnData);
            CreatePlayer.Dispose();*/
        }

        

        // Отмена создания
        private void button2_Click(object sender, EventArgs e)
        {
            returnData = null;
            CreatePlayer.Dispose();
        }
        
        // Случайные параметры
        private void button3_Click(object sender, EventArgs e)
        {

        }

    }
}
