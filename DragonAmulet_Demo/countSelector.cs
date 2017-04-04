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
    public partial class countSelector : Form
    {
        public int selectedCount = 1;
        private double coef;
        private int cost;
        private int count;
        public countSelector()
        {
            InitializeComponent();
        }

        public countSelector(_item item, double coefficient)
        {
            InitializeComponent();
            this.Text = String.Format("Выбор количества для: {0}", item.Title);
            coef = coefficient;
            cost = item.Cost;
            if (item.Count < 100) { trb_CountBar.TickFrequency = 1; trb_CountBar.SmallChange = 1; }
            else if (item.Count < 1000) { trb_CountBar.TickFrequency = 10; trb_CountBar.SmallChange = 10; }
            else if (item.Count < 10000) { trb_CountBar.TickFrequency = 100; trb_CountBar.SmallChange = 100; }
            else if (item.Count < 1000000) { trb_CountBar.TickFrequency = 10000; trb_CountBar.SmallChange = 10000; }
            else { trb_CountBar.TickFrequency = 1000000; trb_CountBar.SmallChange = 1000000; }
            tb_ForCost.Text = Convert.ToString(selectedCount * item.Cost * coefficient);
            count = item.Count;
            trb_CountBar.Maximum = item.Count;
            lbl_Max.Text = Convert.ToString(item.Count);
            tb_ItemName.Text = item.Title;
            tb_Selected.Text = Convert.ToString(selectedCount);
        }

        public countSelector(_item item)
        {
            InitializeComponent();
            this.Text = String.Format("Выбор количества для: {0}", item.Title);
            coef = 0;
            cost = 0;
            if (item.Count < 100) { trb_CountBar.TickFrequency = 1; trb_CountBar.SmallChange = 1; }
            else if (item.Count < 1000) { trb_CountBar.TickFrequency = 10; trb_CountBar.SmallChange = 10; }
            else if (item.Count < 10000) { trb_CountBar.TickFrequency = 100; trb_CountBar.SmallChange = 100; }
            else if (item.Count < 1000000) { trb_CountBar.TickFrequency = 10000; trb_CountBar.SmallChange = 10000; }
            else { trb_CountBar.TickFrequency = 1000000; trb_CountBar.SmallChange = 1000000; }
            tb_ForCost.Visible = false;
            lbl_ForCost.Visible = false;
            count = item.Count;
            trb_CountBar.Maximum = item.Count;
            lbl_Max.Text = Convert.ToString(item.Count);
            tb_ItemName.Text = item.Title;
            tb_Selected.Text = Convert.ToString(selectedCount);
        }

        private void trb_CountBar_ValueChanged(object sender, EventArgs e)
        {
            selectedCount = trb_CountBar.Value;
            tb_Selected.Text = Convert.ToString(selectedCount);
            tb_ForCost.Text = Convert.ToString(selectedCount * cost * coef);
        }

        private void tb_Selected_TextChanged(object sender, EventArgs e)
        {
            int newCount;
            if (Int32.TryParse(tb_Selected.Text, out newCount))
            {
                if (newCount < 0 || newCount > count) tb_Selected.BackColor = Color.LightCoral;
                else
                {
                    tb_Selected.BackColor = SystemColors.Window;
                    selectedCount = newCount;
                    trb_CountBar.Value = selectedCount;
                    tb_ForCost.Text = Convert.ToString(selectedCount * cost * coef);
                }
            }
            else tb_Selected.BackColor = Color.LightCoral;
        }
    }
}
