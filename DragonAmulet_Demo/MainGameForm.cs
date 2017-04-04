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
        string mainplayer;

        private void Form1_Load(object sender, EventArgs e)
        {
            GW = new _gameworld("world.World", "World");

            _player player = new _player();
            player.id = "user.admin";
            player.items.Add(new _food((_food)GW.const_items["item.food.meat"]));
            ((_item)player.items.Last()).Count = 200;
            player.items.Add(new _item((_item)GW.const_items["item.misc.arrow"]));
            ((_item)player.items.Last()).Count = 100;
            player.items.Add(new _item((_item)GW.const_items["item.misc.money"]));
            ((_item)player.items.Last()).Count = 9999999;
            player.items.Add(new _item((_item)GW.const_items["item.hunter.teeths"]));
            player.items.Add(new _item((_item)GW.const_items["item.hunter.skin"]));
            ((_item)player.items.Last()).Count = 0;
            player.items.Add(new _item((_item)GW.const_items["item.magic.moss"]));

            _npc npc = new _npc((_npc)GW.locations_data["loc.snar"].entitys[0]);
            //_entity npc = new _entity(GW.locations_data["loc.snar"].entitys[0]);
            //MessageBox.Show(Convert.ToString(npc.GetType()));

            dialogForm df = new dialogForm(ref player, ref npc, GW.const_dialogs["npc.Sloven"]);
            df.ShowDialog();
        }
    }
}
