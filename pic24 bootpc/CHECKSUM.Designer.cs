namespace WindowsFormsApplication1
{
    partial class CHECKSUM
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
            this.radioButton_ADD16 = new System.Windows.Forms.RadioButton();
            this.radioButton_CRC32 = new System.Windows.Forms.RadioButton();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_OUTput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // radioButton_ADD16
            // 
            this.radioButton_ADD16.AutoSize = true;
            this.radioButton_ADD16.Location = new System.Drawing.Point(195, 201);
            this.radioButton_ADD16.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_ADD16.Name = "radioButton_ADD16";
            this.radioButton_ADD16.Size = new System.Drawing.Size(68, 19);
            this.radioButton_ADD16.TabIndex = 0;
            this.radioButton_ADD16.TabStop = true;
            this.radioButton_ADD16.Text = "ADD16";
            this.radioButton_ADD16.UseVisualStyleBackColor = true;
            // 
            // radioButton_CRC32
            // 
            this.radioButton_CRC32.AutoSize = true;
            this.radioButton_CRC32.Location = new System.Drawing.Point(273, 201);
            this.radioButton_CRC32.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton_CRC32.Name = "radioButton_CRC32";
            this.radioButton_CRC32.Size = new System.Drawing.Size(68, 19);
            this.radioButton_CRC32.TabIndex = 0;
            this.radioButton_CRC32.TabStop = true;
            this.radioButton_CRC32.Text = "CRC32";
            this.radioButton_CRC32.UseVisualStyleBackColor = true;
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(37, 44);
            this.textBox_input.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_input.MaxLength = 999999999;
            this.textBox_input.Multiline = true;
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_input.Size = new System.Drawing.Size(812, 149);
            this.textBox_input.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 229);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "计算";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_OUTput
            // 
            this.textBox_OUTput.Location = new System.Drawing.Point(37, 279);
            this.textBox_OUTput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_OUTput.Name = "textBox_OUTput";
            this.textBox_OUTput.Size = new System.Drawing.Size(812, 25);
            this.textBox_OUTput.TabIndex = 1;
            // 
            // CHECKSUM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 368);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_OUTput);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.radioButton_CRC32);
            this.Controls.Add(this.radioButton_ADD16);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "CHECKSUM";
            this.Text = "CHECKSUM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_ADD16;
        private System.Windows.Forms.RadioButton radioButton_CRC32;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_OUTput;
    }
}