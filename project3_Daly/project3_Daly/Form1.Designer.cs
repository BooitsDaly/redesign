namespace project3_Daly
{
    partial class Form1
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
            this.nav = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.tabDegrees = new System.Windows.Forms.TabPage();
            this.nav.SuspendLayout();
            this.SuspendLayout();
            // 
            // nav
            // 
            this.nav.Controls.Add(this.tabHome);
            this.nav.Controls.Add(this.tabDegrees);
            this.nav.ItemSize = new System.Drawing.Size(100, 50);
            this.nav.Location = new System.Drawing.Point(-4, 0);
            this.nav.Name = "nav";
            this.nav.SelectedIndex = 0;
            this.nav.Size = new System.Drawing.Size(1128, 650);
            this.nav.TabIndex = 0;
            // 
            // tabHome
            // 
            this.tabHome.Location = new System.Drawing.Point(4, 54);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(1120, 592);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // tabDegrees
            // 
            this.tabDegrees.Location = new System.Drawing.Point(4, 54);
            this.tabDegrees.Name = "tabDegrees";
            this.tabDegrees.Padding = new System.Windows.Forms.Padding(3);
            this.tabDegrees.Size = new System.Drawing.Size(1120, 592);
            this.tabDegrees.TabIndex = 1;
            this.tabDegrees.Text = "Degrees";
            this.tabDegrees.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 662);
            this.Controls.Add(this.nav);
            this.Name = "Form1";
            this.Text = "Form1";
            this.nav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl nav;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabDegrees;
    }
}

