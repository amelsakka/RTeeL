namespace RTeeL
{
    partial class Form_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.button_fixText = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_fixed = new System.Windows.Forms.TextBox();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.button_fixFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_fixText
            // 
            this.button_fixText.Font = new System.Drawing.Font("Calibri", 12F);
            this.button_fixText.Location = new System.Drawing.Point(211, 199);
            this.button_fixText.Name = "button_fixText";
            this.button_fixText.Size = new System.Drawing.Size(167, 30);
            this.button_fixText.TabIndex = 2;
            this.button_fixText.Text = "↓  Fix Text   ↓";
            this.tt.SetToolTip(this.button_fixText, "ALT + ENTER");
            this.button_fixText.UseVisualStyleBackColor = true;
            this.button_fixText.Click += new System.EventHandler(this.button_fixText_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fixed text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input text";
            // 
            // textBox_fixed
            // 
            this.textBox_fixed.AcceptsReturn = true;
            this.textBox_fixed.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox_fixed.Location = new System.Drawing.Point(33, 230);
            this.textBox_fixed.Multiline = true;
            this.textBox_fixed.Name = "textBox_fixed";
            this.textBox_fixed.ReadOnly = true;
            this.textBox_fixed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_fixed.Size = new System.Drawing.Size(530, 171);
            this.textBox_fixed.TabIndex = 0;
            this.textBox_fixed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_fixed_KeyDown);
            // 
            // textBox_input
            // 
            this.textBox_input.AcceptsReturn = true;
            this.textBox_input.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox_input.Location = new System.Drawing.Point(33, 38);
            this.textBox_input.Multiline = true;
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_input.Size = new System.Drawing.Size(530, 160);
            this.textBox_input.TabIndex = 0;
            this.textBox_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_input_KeyDown);
            // 
            // button_fixFile
            // 
            this.button_fixFile.Font = new System.Drawing.Font("Calibri", 12F);
            this.button_fixFile.Location = new System.Drawing.Point(68, 12);
            this.button_fixFile.Name = "button_fixFile";
            this.button_fixFile.Size = new System.Drawing.Size(291, 42);
            this.button_fixFile.TabIndex = 2;
            this.button_fixFile.Text = "Fix Text from File";
            this.tt.SetToolTip(this.button_fixFile, "CTRL + O");
            this.button_fixFile.UseVisualStyleBackColor = true;
            this.button_fixFile.Click += new System.EventHandler(this.button_fixFile_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(542, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 47);
            this.button1.TabIndex = 3;
            this.tt.SetToolTip(this.button1, "About");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text File|*.txt|XML file|*.xml|All Files|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Open RTL Original File";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Text File|*.txt|XML file|*.xml|All Files|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Save RTL Fixed File";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_input);
            this.groupBox1.Controls.Add(this.textBox_fixed);
            this.groupBox1.Controls.Add(this.button_fixText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 410);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fix Text";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(210)))));
            this.groupBox2.Controls.Add(this.button_fixFile);
            this.groupBox2.Location = new System.Drawing.Point(12, 428);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 60);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fix File";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 498);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RTeeL - RTL Fix";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_fixText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_fixed;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_fixFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

