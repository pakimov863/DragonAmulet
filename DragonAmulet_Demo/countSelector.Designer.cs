namespace DragonAmulet_Demo
{
    partial class countSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_ItemName = new System.Windows.Forms.Label();
            this.lbl_Min = new System.Windows.Forms.Label();
            this.trb_CountBar = new System.Windows.Forms.TrackBar();
            this.tb_ItemName = new System.Windows.Forms.TextBox();
            this.lbl_Selected = new System.Windows.Forms.Label();
            this.tb_Selected = new System.Windows.Forms.TextBox();
            this.lbl_ForCost = new System.Windows.Forms.Label();
            this.tb_ForCost = new System.Windows.Forms.TextBox();
            this.lbl_Max = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trb_CountBar)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Location = new System.Drawing.Point(180, 128);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "ОК";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(261, 128);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // lbl_ItemName
            // 
            this.lbl_ItemName.AutoSize = true;
            this.lbl_ItemName.Location = new System.Drawing.Point(12, 9);
            this.lbl_ItemName.Name = "lbl_ItemName";
            this.lbl_ItemName.Size = new System.Drawing.Size(55, 13);
            this.lbl_ItemName.TabIndex = 2;
            this.lbl_ItemName.Text = "Предмет:";
            // 
            // lbl_Min
            // 
            this.lbl_Min.AutoSize = true;
            this.lbl_Min.Location = new System.Drawing.Point(12, 61);
            this.lbl_Min.Name = "lbl_Min";
            this.lbl_Min.Size = new System.Drawing.Size(13, 13);
            this.lbl_Min.TabIndex = 3;
            this.lbl_Min.Text = "1";
            // 
            // trb_CountBar
            // 
            this.trb_CountBar.Location = new System.Drawing.Point(15, 77);
            this.trb_CountBar.Name = "trb_CountBar";
            this.trb_CountBar.Size = new System.Drawing.Size(321, 45);
            this.trb_CountBar.TabIndex = 5;
            this.trb_CountBar.TickFrequency = 10;
            this.trb_CountBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trb_CountBar.ValueChanged += new System.EventHandler(this.trb_CountBar_ValueChanged);
            // 
            // tb_ItemName
            // 
            this.tb_ItemName.Location = new System.Drawing.Point(73, 6);
            this.tb_ItemName.Name = "tb_ItemName";
            this.tb_ItemName.ReadOnly = true;
            this.tb_ItemName.Size = new System.Drawing.Size(130, 20);
            this.tb_ItemName.TabIndex = 4;
            // 
            // lbl_Selected
            // 
            this.lbl_Selected.AutoSize = true;
            this.lbl_Selected.Location = new System.Drawing.Point(12, 35);
            this.lbl_Selected.Name = "lbl_Selected";
            this.lbl_Selected.Size = new System.Drawing.Size(55, 13);
            this.lbl_Selected.TabIndex = 2;
            this.lbl_Selected.Text = "Выбрано:";
            // 
            // tb_Selected
            // 
            this.tb_Selected.Location = new System.Drawing.Point(73, 32);
            this.tb_Selected.Name = "tb_Selected";
            this.tb_Selected.Size = new System.Drawing.Size(30, 20);
            this.tb_Selected.TabIndex = 4;
            this.tb_Selected.TextChanged += new System.EventHandler(this.tb_Selected_TextChanged);
            // 
            // lbl_ForCost
            // 
            this.lbl_ForCost.AutoSize = true;
            this.lbl_ForCost.Location = new System.Drawing.Point(109, 35);
            this.lbl_ForCost.Name = "lbl_ForCost";
            this.lbl_ForCost.Size = new System.Drawing.Size(19, 13);
            this.lbl_ForCost.TabIndex = 6;
            this.lbl_ForCost.Text = "за";
            // 
            // tb_ForCost
            // 
            this.tb_ForCost.Location = new System.Drawing.Point(134, 32);
            this.tb_ForCost.Name = "tb_ForCost";
            this.tb_ForCost.ReadOnly = true;
            this.tb_ForCost.Size = new System.Drawing.Size(69, 20);
            this.tb_ForCost.TabIndex = 7;
            // 
            // lbl_Max
            // 
            this.lbl_Max.AutoSize = true;
            this.lbl_Max.Location = new System.Drawing.Point(311, 61);
            this.lbl_Max.Name = "lbl_Max";
            this.lbl_Max.Size = new System.Drawing.Size(25, 13);
            this.lbl_Max.TabIndex = 3;
            this.lbl_Max.Text = "100";
            // 
            // countSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 163);
            this.Controls.Add(this.tb_ForCost);
            this.Controls.Add(this.lbl_ForCost);
            this.Controls.Add(this.trb_CountBar);
            this.Controls.Add(this.tb_Selected);
            this.Controls.Add(this.tb_ItemName);
            this.Controls.Add(this.lbl_Selected);
            this.Controls.Add(this.lbl_Max);
            this.Controls.Add(this.lbl_Min);
            this.Controls.Add(this.lbl_ItemName);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "countSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "countSelector";
            ((System.ComponentModel.ISupportInitialize)(this.trb_CountBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_ItemName;
        private System.Windows.Forms.Label lbl_Min;
        private System.Windows.Forms.TrackBar trb_CountBar;
        private System.Windows.Forms.TextBox tb_ItemName;
        private System.Windows.Forms.Label lbl_Selected;
        private System.Windows.Forms.TextBox tb_Selected;
        private System.Windows.Forms.Label lbl_ForCost;
        private System.Windows.Forms.TextBox tb_ForCost;
        private System.Windows.Forms.Label lbl_Max;
    }
}