
namespace Tram_ScheduleGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.haioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.AddTram = new System.Windows.Forms.Button();
            this.AddStop = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.haioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // haioToolStripMenuItem
            // 
            this.haioToolStripMenuItem.Name = "haioToolStripMenuItem";
            this.haioToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.haioToolStripMenuItem.Text = "Haio!";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.AddStop);
            this.splitContainer1.Panel1.Controls.Add(this.AddTram);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox2);
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Size = new System.Drawing.Size(945, 549);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(59, 159);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 57);
            this.button3.TabIndex = 3;
            this.button3.Text = "Show Tramstops";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 69);
            this.button2.TabIndex = 2;
            this.button2.Text = "Display Tram Routes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse Trams";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BrowseTrams_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(256, 17);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(226, 199);
            this.listBox2.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(24, 17);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(226, 199);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.splitContainer1.Panel2.Controls;
            this.bindingSource1.Position = 0;
            // 
            // AddTram
            // 
            this.AddTram.Location = new System.Drawing.Point(59, 278);
            this.AddTram.Name = "AddTram";
            this.AddTram.Size = new System.Drawing.Size(139, 61);
            this.AddTram.TabIndex = 4;
            this.AddTram.Text = "Add Tram";
            this.AddTram.UseVisualStyleBackColor = true;
            this.AddTram.Click += new System.EventHandler(this.AddStop_Click);
            // 
            // AddStop
            // 
            this.AddStop.Location = new System.Drawing.Point(59, 345);
            this.AddStop.Name = "AddStop";
            this.AddStop.Size = new System.Drawing.Size(139, 61);
            this.AddStop.TabIndex = 5;
            this.AddStop.Text = "Add Stop";
            this.AddStop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 573);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem haioToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button AddStop;
        private System.Windows.Forms.Button AddTram;
    }
}

