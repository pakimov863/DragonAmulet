namespace DragonAmulet_Demo
{
    partial class speakForm
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
            this.pan_NpcDialog = new System.Windows.Forms.Panel();
            this.tb_History = new System.Windows.Forms.TextBox();
            this.clist_DialogVariants = new System.Windows.Forms.CheckedListBox();
            this.btn_End = new System.Windows.Forms.Button();
            this.btn_Say = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_DialogWith = new System.Windows.Forms.Label();
            this.pan_NpcDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_NpcDialog
            // 
            this.pan_NpcDialog.Controls.Add(this.tb_History);
            this.pan_NpcDialog.Controls.Add(this.clist_DialogVariants);
            this.pan_NpcDialog.Controls.Add(this.btn_End);
            this.pan_NpcDialog.Controls.Add(this.btn_Say);
            this.pan_NpcDialog.Controls.Add(this.label2);
            this.pan_NpcDialog.Controls.Add(this.lbl_DialogWith);
            this.pan_NpcDialog.Location = new System.Drawing.Point(12, 12);
            this.pan_NpcDialog.Name = "pan_NpcDialog";
            this.pan_NpcDialog.Size = new System.Drawing.Size(444, 287);
            this.pan_NpcDialog.TabIndex = 2;
            // 
            // tb_History
            // 
            this.tb_History.Location = new System.Drawing.Point(3, 32);
            this.tb_History.Multiline = true;
            this.tb_History.Name = "tb_History";
            this.tb_History.ReadOnly = true;
            this.tb_History.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_History.Size = new System.Drawing.Size(438, 152);
            this.tb_History.TabIndex = 4;
            // 
            // clist_DialogVariants
            // 
            this.clist_DialogVariants.CheckOnClick = true;
            this.clist_DialogVariants.FormattingEnabled = true;
            this.clist_DialogVariants.Location = new System.Drawing.Point(3, 190);
            this.clist_DialogVariants.Name = "clist_DialogVariants";
            this.clist_DialogVariants.Size = new System.Drawing.Size(352, 94);
            this.clist_DialogVariants.TabIndex = 3;
            this.clist_DialogVariants.SelectedIndexChanged += new System.EventHandler(this.clist_DialogVariants_SelectedIndexChanged);
            // 
            // btn_End
            // 
            this.btn_End.Location = new System.Drawing.Point(361, 261);
            this.btn_End.Name = "btn_End";
            this.btn_End.Size = new System.Drawing.Size(80, 23);
            this.btn_End.TabIndex = 2;
            this.btn_End.Text = "Закончить";
            this.btn_End.UseVisualStyleBackColor = true;
            this.btn_End.Click += new System.EventHandler(this.btn_End_Click);
            // 
            // btn_Say
            // 
            this.btn_Say.Location = new System.Drawing.Point(361, 190);
            this.btn_Say.Name = "btn_Say";
            this.btn_Say.Size = new System.Drawing.Size(80, 23);
            this.btn_Say.TabIndex = 1;
            this.btn_Say.Text = "Сказать";
            this.btn_Say.UseVisualStyleBackColor = true;
            this.btn_Say.Click += new System.EventHandler(this.btn_Say_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-116, -134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Диалог с:";
            // 
            // lbl_DialogWith
            // 
            this.lbl_DialogWith.AutoSize = true;
            this.lbl_DialogWith.Location = new System.Drawing.Point(3, 8);
            this.lbl_DialogWith.Name = "lbl_DialogWith";
            this.lbl_DialogWith.Size = new System.Drawing.Size(57, 13);
            this.lbl_DialogWith.TabIndex = 0;
            this.lbl_DialogWith.Text = "Диалог с:";
            // 
            // speakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 311);
            this.Controls.Add(this.pan_NpcDialog);
            this.Name = "speakForm";
            this.Text = "speakForm";
            this.pan_NpcDialog.ResumeLayout(false);
            this.pan_NpcDialog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_NpcDialog;
        private System.Windows.Forms.TextBox tb_History;
        private System.Windows.Forms.CheckedListBox clist_DialogVariants;
        private System.Windows.Forms.Button btn_End;
        private System.Windows.Forms.Button btn_Say;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_DialogWith;
    }
}