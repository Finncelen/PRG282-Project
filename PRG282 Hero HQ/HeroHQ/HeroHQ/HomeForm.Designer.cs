namespace HeroHQ
{
    partial class HomeForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitleBlue = new System.Windows.Forms.Label();
            this.lblTitleRed = new System.Windows.Forms.Label();
            this.lblCream = new System.Windows.Forms.Label();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.btnAddHero = new System.Windows.Forms.Button();
            this.btnManage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGenerateSum = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.txtSummary = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::HeroHQ.Properties.Resources.LOGO_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(14, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitleBlue
            // 
            this.lblTitleBlue.Font = new System.Drawing.Font("Bahnschrift", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(48)))), ((int)(((byte)(73)))));
            this.lblTitleBlue.Location = new System.Drawing.Point(234, 11);
            this.lblTitleBlue.Name = "lblTitleBlue";
            this.lblTitleBlue.Size = new System.Drawing.Size(418, 156);
            this.lblTitleBlue.TabIndex = 1;
            this.lblTitleBlue.Text = "Hero HQ";
            this.lblTitleBlue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleRed
            // 
            this.lblTitleRed.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleRed.Font = new System.Drawing.Font("Bahnschrift SemiBold", 49.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitleRed.Location = new System.Drawing.Point(234, 15);
            this.lblTitleRed.Name = "lblTitleRed";
            this.lblTitleRed.Size = new System.Drawing.Size(418, 156);
            this.lblTitleRed.TabIndex = 2;
            this.lblTitleRed.Text = "Hero HQ";
            this.lblTitleRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCream
            // 
            this.lblCream.BackColor = System.Drawing.Color.Transparent;
            this.lblCream.Font = new System.Drawing.Font("Bahnschrift", 49.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(240)))), ((int)(((byte)(216)))));
            this.lblCream.Location = new System.Drawing.Point(234, 15);
            this.lblCream.Name = "lblCream";
            this.lblCream.Size = new System.Drawing.Size(418, 156);
            this.lblCream.TabIndex = 3;
            this.lblCream.Text = "Hero HQ";
            this.lblCream.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddHero
            // 
            this.btnAddHero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(42)))), ((int)(((byte)(41)))));
            this.btnAddHero.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.btnAddHero.Location = new System.Drawing.Point(47, 39);
            this.btnAddHero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddHero.Name = "btnAddHero";
            this.btnAddHero.Size = new System.Drawing.Size(250, 95);
            this.btnAddHero.TabIndex = 4;
            this.btnAddHero.Text = "Add Hero";
            this.btnAddHero.UseVisualStyleBackColor = false;
            // 
            // btnManage
            // 
            this.btnManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(154)))), ((int)(((byte)(185)))));
            this.btnManage.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.btnManage.Location = new System.Drawing.Point(304, 39);
            this.btnManage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(250, 95);
            this.btnManage.TabIndex = 5;
            this.btnManage.Text = "View/ Manage Heros";
            this.btnManage.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(18)))), ((int)(((byte)(11)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(42)))), ((int)(((byte)(41)))));
            this.btnExit.Location = new System.Drawing.Point(304, 156);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(250, 95);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnGenerateSum
            // 
            this.btnGenerateSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(48)))), ((int)(((byte)(71)))));
            this.btnGenerateSum.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateSum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(154)))), ((int)(((byte)(185)))));
            this.btnGenerateSum.Location = new System.Drawing.Point(47, 156);
            this.btnGenerateSum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerateSum.Name = "btnGenerateSum";
            this.btnGenerateSum.Size = new System.Drawing.Size(250, 95);
            this.btnGenerateSum.TabIndex = 7;
            this.btnGenerateSum.Text = "Generate Summary";
            this.btnGenerateSum.UseVisualStyleBackColor = false;
            this.btnGenerateSum.Click += new System.EventHandler(this.btnGenerateSum_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(48)))), ((int)(((byte)(87)))));
            this.pnlMenu.Controls.Add(this.btnGenerateSum);
            this.pnlMenu.Controls.Add(this.btnExit);
            this.pnlMenu.Controls.Add(this.btnManage);
            this.pnlMenu.Controls.Add(this.btnAddHero);
            this.pnlMenu.Location = new System.Drawing.Point(131, 193);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(601, 289);
            this.pnlMenu.TabIndex = 9;
            // 
            // txtSummary
            // 
            this.txtSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(63)))), ((int)(((byte)(112)))));
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSummary.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.txtSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(240)))), ((int)(((byte)(216)))));
            this.txtSummary.Location = new System.Drawing.Point(131, 489);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(601, 190);
            this.txtSummary.TabIndex = 10;
            this.txtSummary.Visible = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(63)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(880, 691);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblCream);
            this.Controls.Add(this.lblTitleRed);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitleBlue);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HomeForm";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitleBlue;
        private System.Windows.Forms.Label lblTitleRed;
        private System.Windows.Forms.Label lblCream;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button btnAddHero;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGenerateSum;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.TextBox txtSummary;
    }
}

