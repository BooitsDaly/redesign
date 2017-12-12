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
            this.home_title = new System.Windows.Forms.Label();
            this.home_quote = new System.Windows.Forms.Label();
            this.home_quoteAuthor = new System.Windows.Forms.Label();
            this.home_description = new System.Windows.Forms.Label();
            this.nav.SuspendLayout();
            this.tabHome.SuspendLayout();
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
            this.tabHome.BackColor = System.Drawing.Color.OrangeRed;
            this.tabHome.Controls.Add(this.home_quoteAuthor);
            this.tabHome.Controls.Add(this.home_quote);
            this.tabHome.Controls.Add(this.home_description);
            this.tabHome.Controls.Add(this.home_title);
            this.tabHome.Location = new System.Drawing.Point(4, 54);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(1120, 592);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
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
            // home_title
            // 
            this.home_title.AutoSize = true;
            this.home_title.BackColor = System.Drawing.Color.White;
            this.home_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.home_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_title.ForeColor = System.Drawing.Color.DarkGray;
            this.home_title.Location = new System.Drawing.Point(21, 14);
            this.home_title.Name = "home_title";
            this.home_title.Size = new System.Drawing.Size(217, 78);
            this.home_title.TabIndex = 0;
            this.home_title.Text = "label1";
            this.home_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // home_quote
            // 
            this.home_quote.AutoSize = true;
            this.home_quote.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_quote.Location = new System.Drawing.Point(18, 219);
            this.home_quote.Name = "home_quote";
            this.home_quote.Size = new System.Drawing.Size(126, 46);
            this.home_quote.TabIndex = 2;
            this.home_quote.Text = "label1";
            // 
            // home_quoteAuthor
            // 
            this.home_quoteAuthor.AutoSize = true;
            this.home_quoteAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_quoteAuthor.Location = new System.Drawing.Point(18, 310);
            this.home_quoteAuthor.Name = "home_quoteAuthor";
            this.home_quoteAuthor.Size = new System.Drawing.Size(126, 46);
            this.home_quoteAuthor.TabIndex = 3;
            this.home_quoteAuthor.Text = "label1";
            // 
            // home_description
            // 
            this.home_description.AutoSize = true;
            this.home_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home_description.Location = new System.Drawing.Point(18, 131);
            this.home_description.Name = "home_description";
            this.home_description.Size = new System.Drawing.Size(126, 46);
            this.home_description.TabIndex = 1;
            this.home_description.Text = "label1";
            this.home_description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 662);
            this.Controls.Add(this.nav);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.nav.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl nav;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabDegrees;
        private System.Windows.Forms.Label home_title;
        private System.Windows.Forms.Label home_quote;
        private System.Windows.Forms.Label home_quoteAuthor;
        private System.Windows.Forms.Label home_description;
    }
}

