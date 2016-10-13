namespace ModifyEdmx
{
    partial class Frm_Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOldEdmx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewEdmx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnFromFile = new System.Windows.Forms.Button();
            this.btnFromSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址：";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(59, 18);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(100, 21);
            this.txtServerIP.TabIndex = 1;
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(249, 21);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(100, 21);
            this.txtDataBase.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库：";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(59, 70);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 21);
            this.txtUser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(249, 73);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码：";
            // 
            // txtOldEdmx
            // 
            this.txtOldEdmx.Location = new System.Drawing.Point(59, 115);
            this.txtOldEdmx.Name = "txtOldEdmx";
            this.txtOldEdmx.Size = new System.Drawing.Size(241, 21);
            this.txtOldEdmx.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "原Edmx：";
            // 
            // txtNewEdmx
            // 
            this.txtNewEdmx.Location = new System.Drawing.Point(59, 162);
            this.txtNewEdmx.Name = "txtNewEdmx";
            this.txtNewEdmx.Size = new System.Drawing.Size(241, 21);
            this.txtNewEdmx.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "保存地址：";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(59, 215);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(89, 35);
            this.btnTest.TabIndex = 12;
            this.btnTest.Text = "测试连接";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(204, 215);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 35);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "确定转换";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnFromFile
            // 
            this.btnFromFile.Location = new System.Drawing.Point(315, 115);
            this.btnFromFile.Name = "btnFromFile";
            this.btnFromFile.Size = new System.Drawing.Size(43, 20);
            this.btnFromFile.TabIndex = 14;
            this.btnFromFile.Text = "浏览";
            this.btnFromFile.UseVisualStyleBackColor = true;
            this.btnFromFile.Click += new System.EventHandler(this.btnFromFile_Click);
            // 
            // btnFromSave
            // 
            this.btnFromSave.Location = new System.Drawing.Point(315, 163);
            this.btnFromSave.Name = "btnFromSave";
            this.btnFromSave.Size = new System.Drawing.Size(43, 20);
            this.btnFromSave.TabIndex = 15;
            this.btnFromSave.Text = "浏览";
            this.btnFromSave.UseVisualStyleBackColor = true;
            this.btnFromSave.Click += new System.EventHandler(this.btnFromSave_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 283);
            this.Controls.Add(this.btnFromSave);
            this.Controls.Add(this.btnFromFile);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtNewEdmx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOldEdmx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edmx实体备注批量添加";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOldEdmx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewEdmx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnFromFile;
        private System.Windows.Forms.Button btnFromSave;
    }
}

