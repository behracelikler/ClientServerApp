namespace ClientApplication
{
    partial class Form_Client
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
            this.button_Send = new System.Windows.Forms.Button();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(501, 46);
            this.button_Send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(124, 42);
            this.button_Send.TabIndex = 0;
            this.button_Send.Tag = "";
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Gonder_Click);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(121, 95);
            this.textBox_Message.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(503, 389);
            this.textBox_Message.TabIndex = 1;
            this.textBox_Message.Tag = "";
            this.textBox_Message.Text = "Please Enter Message";
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(121, 63);
            this.textBox_ServerPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(371, 22);
            this.textBox_ServerPort.TabIndex = 2;
            this.textBox_ServerPort.Tag = "";
            this.textBox_ServerPort.Text = "Server Port";
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(121, 31);
            this.textBox_ServerIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(371, 22);
            this.textBox_ServerIP.TabIndex = 3;
            this.textBox_ServerIP.Tag = "";
            this.textBox_ServerIP.Text = "Server IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server IP :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Port :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 516);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ServerIP);
            this.Controls.Add(this.textBox_ServerPort);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.button_Send);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Message Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

