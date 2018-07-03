namespace DragonAmulet_Demo
{
    partial class MainGameForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pan_MainMenu = new System.Windows.Forms.Panel();
            this.btn_ForceGame = new System.Windows.Forms.Button();
            this.btn_NewGame = new System.Windows.Forms.Button();
            this.pan_Game = new System.Windows.Forms.Panel();
            this.btn_View = new System.Windows.Forms.Button();
            this.btn_Use = new System.Windows.Forms.Button();
            this.list_LocObjects = new System.Windows.Forms.ListBox();
            this.text_LocDescription = new System.Windows.Forms.TextBox();
            this.debug_location_label = new System.Windows.Forms.Label();
            this.debug_location = new System.Windows.Forms.Label();
            this.debug_selected_label = new System.Windows.Forms.Label();
            this.debug_selected = new System.Windows.Forms.Label();
            this.pan_MainMenu.SuspendLayout();
            this.pan_Game.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_MainMenu
            // 
            this.pan_MainMenu.Controls.Add(this.btn_ForceGame);
            this.pan_MainMenu.Controls.Add(this.btn_NewGame);
            this.pan_MainMenu.Location = new System.Drawing.Point(-999, 12);
            this.pan_MainMenu.Name = "pan_MainMenu";
            this.pan_MainMenu.Size = new System.Drawing.Size(660, 437);
            this.pan_MainMenu.TabIndex = 0;
            // 
            // btn_ForceGame
            // 
            this.btn_ForceGame.Location = new System.Drawing.Point(3, 32);
            this.btn_ForceGame.Name = "btn_ForceGame";
            this.btn_ForceGame.Size = new System.Drawing.Size(75, 23);
            this.btn_ForceGame.TabIndex = 1;
            this.btn_ForceGame.Text = "button2";
            this.btn_ForceGame.UseVisualStyleBackColor = true;
            this.btn_ForceGame.Click += new System.EventHandler(this.btn_ForceGame_Click);
            // 
            // btn_NewGame
            // 
            this.btn_NewGame.Location = new System.Drawing.Point(3, 3);
            this.btn_NewGame.Name = "btn_NewGame";
            this.btn_NewGame.Size = new System.Drawing.Size(75, 23);
            this.btn_NewGame.TabIndex = 0;
            this.btn_NewGame.Text = "button1";
            this.btn_NewGame.UseVisualStyleBackColor = true;
            this.btn_NewGame.Click += new System.EventHandler(this.btn_NewGame_Click);
            // 
            // pan_Game
            // 
            this.pan_Game.Controls.Add(this.btn_View);
            this.pan_Game.Controls.Add(this.btn_Use);
            this.pan_Game.Controls.Add(this.list_LocObjects);
            this.pan_Game.Controls.Add(this.text_LocDescription);
            this.pan_Game.Location = new System.Drawing.Point(12, 12);
            this.pan_Game.Name = "pan_Game";
            this.pan_Game.Size = new System.Drawing.Size(400, 437);
            this.pan_Game.TabIndex = 1;
            this.pan_Game.Visible = false;
            // 
            // btn_View
            // 
            this.btn_View.Location = new System.Drawing.Point(288, 204);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(109, 23);
            this.btn_View.TabIndex = 3;
            this.btn_View.Text = "Осмотреть";
            this.btn_View.UseVisualStyleBackColor = true;
            // 
            // btn_Use
            // 
            this.btn_Use.Location = new System.Drawing.Point(288, 175);
            this.btn_Use.Name = "btn_Use";
            this.btn_Use.Size = new System.Drawing.Size(109, 23);
            this.btn_Use.TabIndex = 2;
            this.btn_Use.Text = "Использовать";
            this.btn_Use.UseVisualStyleBackColor = true;
            // 
            // list_LocObjects
            // 
            this.list_LocObjects.FormattingEnabled = true;
            this.list_LocObjects.Location = new System.Drawing.Point(3, 175);
            this.list_LocObjects.Name = "list_LocObjects";
            this.list_LocObjects.Size = new System.Drawing.Size(279, 160);
            this.list_LocObjects.TabIndex = 1;
            // 
            // text_LocDescription
            // 
            this.text_LocDescription.Location = new System.Drawing.Point(3, 3);
            this.text_LocDescription.Multiline = true;
            this.text_LocDescription.Name = "text_LocDescription";
            this.text_LocDescription.ReadOnly = true;
            this.text_LocDescription.Size = new System.Drawing.Size(394, 166);
            this.text_LocDescription.TabIndex = 0;
            // 
            // debug_location_label
            // 
            this.debug_location_label.AutoSize = true;
            this.debug_location_label.Location = new System.Drawing.Point(418, 12);
            this.debug_location_label.Name = "debug_location_label";
            this.debug_location_label.Size = new System.Drawing.Size(51, 13);
            this.debug_location_label.TabIndex = 4;
            this.debug_location_label.Text = "Location:";
            // 
            // debug_location
            // 
            this.debug_location.AutoSize = true;
            this.debug_location.Location = new System.Drawing.Point(475, 12);
            this.debug_location.Name = "debug_location";
            this.debug_location.Size = new System.Drawing.Size(54, 13);
            this.debug_location.TabIndex = 5;
            this.debug_location.Text = "undefined";
            // 
            // debug_selected_label
            // 
            this.debug_selected_label.AutoSize = true;
            this.debug_selected_label.Location = new System.Drawing.Point(418, 25);
            this.debug_selected_label.Name = "debug_selected_label";
            this.debug_selected_label.Size = new System.Drawing.Size(52, 13);
            this.debug_selected_label.TabIndex = 6;
            this.debug_selected_label.Text = "Selected:";
            // 
            // debug_selected
            // 
            this.debug_selected.AutoSize = true;
            this.debug_selected.Location = new System.Drawing.Point(476, 25);
            this.debug_selected.Name = "debug_selected";
            this.debug_selected.Size = new System.Drawing.Size(54, 13);
            this.debug_selected.TabIndex = 7;
            this.debug_selected.Text = "undefined";
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.debug_selected);
            this.Controls.Add(this.debug_selected_label);
            this.Controls.Add(this.debug_location);
            this.Controls.Add(this.debug_location_label);
            this.Controls.Add(this.pan_Game);
            this.Controls.Add(this.pan_MainMenu);
            this.Name = "MainGameForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pan_MainMenu.ResumeLayout(false);
            this.pan_Game.ResumeLayout(false);
            this.pan_Game.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        //this.ClientSize = new System.Drawing.Size(424, 461);
        //this.ClientSize = new System.Drawing.Size(684, 461);
        #endregion

        private System.Windows.Forms.Panel pan_MainMenu;
        private System.Windows.Forms.Button btn_ForceGame;
        private System.Windows.Forms.Button btn_NewGame;
        private System.Windows.Forms.Panel pan_Game;
        private System.Windows.Forms.TextBox text_LocDescription;
        private System.Windows.Forms.ListBox list_LocObjects;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Button btn_Use;
#if DEBUG
        private System.Windows.Forms.Label debug_location_label;
        private System.Windows.Forms.Label debug_location;
        private System.Windows.Forms.Label debug_selected_label;
        private System.Windows.Forms.Label debug_selected;
#endif
    }
}

