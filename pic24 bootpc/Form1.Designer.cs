namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_openserial = new System.Windows.Forms.Button();
            this.comboBox_serial = new System.Windows.Forms.ComboBox();
            this.openFileDialog_HEXFILE = new System.Windows.Forms.OpenFileDialog();
            this.button_enterboot = new System.Windows.Forms.Button();
            this.button_startdownload = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.烧录文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算校验和ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_totalsize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_totalframe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_curframe = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_serialstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_loadstep = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.跳转到APP = new System.Windows.Forms.Button();
            this.读取当前固件信息 = new System.Windows.Forms.Button();
            this.文件CRC32 = new System.Windows.Forms.TextBox();
            this.接受CRC32 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_openserial
            // 
            this.button_openserial.Location = new System.Drawing.Point(31, 90);
            this.button_openserial.Margin = new System.Windows.Forms.Padding(4);
            this.button_openserial.Name = "button_openserial";
            this.button_openserial.Size = new System.Drawing.Size(100, 29);
            this.button_openserial.TabIndex = 0;
            this.button_openserial.Text = "打开串口";
            this.button_openserial.UseVisualStyleBackColor = true;
            this.button_openserial.Click += new System.EventHandler(this.button_openserial_Click);
            // 
            // comboBox_serial
            // 
            this.comboBox_serial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_serial.FormattingEnabled = true;
            this.comboBox_serial.Location = new System.Drawing.Point(31, 46);
            this.comboBox_serial.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_serial.Name = "comboBox_serial";
            this.comboBox_serial.Size = new System.Drawing.Size(160, 23);
            this.comboBox_serial.TabIndex = 1;
            // 
            // openFileDialog_HEXFILE
            // 
            this.openFileDialog_HEXFILE.Filter = "hex文件|*.hex|bin文件|*.bin";
            // 
            // button_enterboot
            // 
            this.button_enterboot.Location = new System.Drawing.Point(31, 174);
            this.button_enterboot.Margin = new System.Windows.Forms.Padding(4);
            this.button_enterboot.Name = "button_enterboot";
            this.button_enterboot.Size = new System.Drawing.Size(100, 29);
            this.button_enterboot.TabIndex = 2;
            this.button_enterboot.Text = "进入BOOT";
            this.button_enterboot.UseVisualStyleBackColor = true;
            this.button_enterboot.Click += new System.EventHandler(this.button_enterboot_Click);
            // 
            // button_startdownload
            // 
            this.button_startdownload.Location = new System.Drawing.Point(31, 210);
            this.button_startdownload.Margin = new System.Windows.Forms.Padding(4);
            this.button_startdownload.Name = "button_startdownload";
            this.button_startdownload.Size = new System.Drawing.Size(100, 29);
            this.button_startdownload.TabIndex = 3;
            this.button_startdownload.Text = "开始烧录";
            this.button_startdownload.UseVisualStyleBackColor = true;
            this.button_startdownload.Click += new System.EventHandler(this.button_startdownload_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.烧录文件ToolStripMenuItem,
            this.计算校验和ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(487, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 烧录文件ToolStripMenuItem
            // 
            this.烧录文件ToolStripMenuItem.Name = "烧录文件ToolStripMenuItem";
            this.烧录文件ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.烧录文件ToolStripMenuItem.Text = "烧录文件";
            this.烧录文件ToolStripMenuItem.Click += new System.EventHandler(this.烧录文件ToolStripMenuItem_Click);
            // 
            // 计算校验和ToolStripMenuItem
            // 
            this.计算校验和ToolStripMenuItem.Name = "计算校验和ToolStripMenuItem";
            this.计算校验和ToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.计算校验和ToolStripMenuItem.Text = "计算校验和";
            this.计算校验和ToolStripMenuItem.Click += new System.EventHandler(this.计算校验和ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "总字节数";
            // 
            // textBox_totalsize
            // 
            this.textBox_totalsize.Location = new System.Drawing.Point(328, 44);
            this.textBox_totalsize.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_totalsize.Name = "textBox_totalsize";
            this.textBox_totalsize.Size = new System.Drawing.Size(132, 25);
            this.textBox_totalsize.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "总帧数";
            // 
            // textBox_totalframe
            // 
            this.textBox_totalframe.Location = new System.Drawing.Point(328, 78);
            this.textBox_totalframe.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_totalframe.Name = "textBox_totalframe";
            this.textBox_totalframe.Size = new System.Drawing.Size(132, 25);
            this.textBox_totalframe.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "当前帧";
            // 
            // textBox_curframe
            // 
            this.textBox_curframe.Location = new System.Drawing.Point(328, 111);
            this.textBox_curframe.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_curframe.Name = "textBox_curframe";
            this.textBox_curframe.Size = new System.Drawing.Size(132, 25);
            this.textBox_curframe.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_serialstatus,
            this.toolStripProgressBar_loadstep,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 350);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(487, 26);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_serialstatus
            // 
            this.toolStripStatusLabel_serialstatus.Name = "toolStripStatusLabel_serialstatus";
            this.toolStripStatusLabel_serialstatus.Size = new System.Drawing.Size(114, 21);
            this.toolStripStatusLabel_serialstatus.Text = "串口状态：关闭";
            // 
            // toolStripProgressBar_loadstep
            // 
            this.toolStripProgressBar_loadstep.Name = "toolStripProgressBar_loadstep";
            this.toolStripProgressBar_loadstep.Size = new System.Drawing.Size(133, 20);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 21);
            // 
            // 跳转到APP
            // 
            this.跳转到APP.Location = new System.Drawing.Point(31, 276);
            this.跳转到APP.Margin = new System.Windows.Forms.Padding(4);
            this.跳转到APP.Name = "跳转到APP";
            this.跳转到APP.Size = new System.Drawing.Size(100, 29);
            this.跳转到APP.TabIndex = 8;
            this.跳转到APP.Text = "跳转到APP";
            this.跳转到APP.UseVisualStyleBackColor = true;
            this.跳转到APP.Click += new System.EventHandler(this.跳转到APP_Click);
            // 
            // 读取当前固件信息
            // 
            this.读取当前固件信息.Location = new System.Drawing.Point(31, 246);
            this.读取当前固件信息.Name = "读取当前固件信息";
            this.读取当前固件信息.Size = new System.Drawing.Size(100, 29);
            this.读取当前固件信息.TabIndex = 9;
            this.读取当前固件信息.Text = "获取硬件信息";
            this.读取当前固件信息.UseVisualStyleBackColor = true;
            this.读取当前固件信息.Click += new System.EventHandler(this.读取当前固件信息_Click);
            // 
            // 文件CRC32
            // 
            this.文件CRC32.Location = new System.Drawing.Point(326, 155);
            this.文件CRC32.Name = "文件CRC32";
            this.文件CRC32.Size = new System.Drawing.Size(129, 25);
            this.文件CRC32.TabIndex = 10;
            // 
            // 接受CRC32
            // 
            this.接受CRC32.Location = new System.Drawing.Point(336, 296);
            this.接受CRC32.Name = "接受CRC32";
            this.接受CRC32.Size = new System.Drawing.Size(129, 25);
            this.接受CRC32.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "文件CRC32";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 306);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "接受CRC32";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "复位";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 376);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.接受CRC32);
            this.Controls.Add(this.文件CRC32);
            this.Controls.Add(this.读取当前固件信息);
            this.Controls.Add(this.跳转到APP);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox_curframe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_totalframe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_totalsize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_startdownload);
            this.Controls.Add(this.button_enterboot);
            this.Controls.Add(this.comboBox_serial);
            this.Controls.Add(this.button_openserial);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_openserial;
        private System.Windows.Forms.ComboBox comboBox_serial;
        private System.Windows.Forms.OpenFileDialog openFileDialog_HEXFILE;
        private System.Windows.Forms.Button button_enterboot;
        private System.Windows.Forms.Button button_startdownload;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 烧录文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算校验和ToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_totalsize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_totalframe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_curframe;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_serialstatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_loadstep;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button 跳转到APP;
        private System.Windows.Forms.Button 读取当前固件信息;
        private System.Windows.Forms.TextBox 文件CRC32;
        private System.Windows.Forms.TextBox 接受CRC32;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}

