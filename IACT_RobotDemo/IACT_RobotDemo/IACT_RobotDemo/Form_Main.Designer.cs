namespace IACT_RobotDemo
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.AngleText = new System.Windows.Forms.TextBox();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.cameraInfoText = new System.Windows.Forms.TextBox();
            this.OffsetX = new System.Windows.Forms.TextBox();
            this.OffsetY = new System.Windows.Forms.TextBox();
            this.antennaLength = new System.Windows.Forms.TextBox();
            this.antennaHeight = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(91, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 79);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Connect);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(441, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 75);
            this.button2.TabIndex = 1;
            this.button2.Text = "Emergency Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_EmergencyStop);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(276, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 79);
            this.button3.TabIndex = 2;
            this.button3.Text = "Login";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Login);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(603, 310);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 75);
            this.button4.TabIndex = 3;
            this.button4.Text = "Logout";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Logout);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button5.Location = new System.Drawing.Point(91, 310);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(167, 75);
            this.button5.TabIndex = 4;
            this.button5.Text = "Execute Robot#1";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_ExecuteRobot1);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button6.Location = new System.Drawing.Point(441, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(148, 79);
            this.button6.TabIndex = 5;
            this.button6.Text = "ServerOn";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_ServerOn);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button7.Location = new System.Drawing.Point(276, 310);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(146, 75);
            this.button7.TabIndex = 6;
            this.button7.Text = "Execute Robot#2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_ExecuteRobot2);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button8.Location = new System.Drawing.Point(441, 116);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(147, 75);
            this.button8.TabIndex = 7;
            this.button8.Text = "Reset";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button_Reset);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button11.Location = new System.Drawing.Point(603, 19);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(150, 79);
            this.button11.TabIndex = 10;
            this.button11.Text = "ServerOff";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button_ServerOff);
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button14.Location = new System.Drawing.Point(91, 211);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(167, 75);
            this.button14.TabIndex = 11;
            this.button14.Text = "OpenControllerPort";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button_OpenControllerPort);
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button15.Location = new System.Drawing.Point(276, 211);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(149, 75);
            this.button15.TabIndex = 12;
            this.button15.Text = "SendString";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button_SendString);
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button16.Location = new System.Drawing.Point(441, 211);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(148, 75);
            this.button16.TabIndex = 13;
            this.button16.Text = "SendAngle";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button_SendAngle);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button17.Location = new System.Drawing.Point(601, 211);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(146, 75);
            this.button17.TabIndex = 14;
            this.button17.Text = "SendPosition";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button_SendPosition);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button10.Location = new System.Drawing.Point(91, 114);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(167, 77);
            this.button10.TabIndex = 18;
            this.button10.Text = "canTakePic";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button_canTakePic);
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button20.Location = new System.Drawing.Point(770, 101);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(129, 47);
            this.button20.TabIndex = 19;
            this.button20.Text = "getAngle";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button_getAngle);
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button21.Location = new System.Drawing.Point(770, 172);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(129, 49);
            this.button21.TabIndex = 20;
            this.button21.Text = "getOffset";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button_getOffset);
            // 
            // AngleText
            // 
            this.AngleText.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AngleText.Location = new System.Drawing.Point(925, 108);
            this.AngleText.Name = "AngleText";
            this.AngleText.Size = new System.Drawing.Size(249, 36);
            this.AngleText.TabIndex = 21;
            this.AngleText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AngleText.TextChanged += new System.EventHandler(this.AngleText_TextChanged);
            // 
            // button22
            // 
            this.button22.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button22.Location = new System.Drawing.Point(770, 23);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(169, 56);
            this.button22.TabIndex = 22;
            this.button22.Text = "OpenCamera#1";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button_OpenCamera1);
            // 
            // button23
            // 
            this.button23.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button23.Location = new System.Drawing.Point(770, 294);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(129, 51);
            this.button23.TabIndex = 23;
            this.button23.Text = "CameraInfo";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button_CameraInfo);
            // 
            // cameraInfoText
            // 
            this.cameraInfoText.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cameraInfoText.Location = new System.Drawing.Point(925, 304);
            this.cameraInfoText.Name = "cameraInfoText";
            this.cameraInfoText.Size = new System.Drawing.Size(249, 36);
            this.cameraInfoText.TabIndex = 24;
            this.cameraInfoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cameraInfoText.TextChanged += new System.EventHandler(this.check_left_x_TextChanged);
            // 
            // OffsetX
            // 
            this.OffsetX.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OffsetX.Location = new System.Drawing.Point(925, 172);
            this.OffsetX.Name = "OffsetX";
            this.OffsetX.Size = new System.Drawing.Size(104, 36);
            this.OffsetX.TabIndex = 25;
            this.OffsetX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OffsetY
            // 
            this.OffsetY.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OffsetY.Location = new System.Drawing.Point(926, 232);
            this.OffsetY.Name = "OffsetY";
            this.OffsetY.Size = new System.Drawing.Size(104, 36);
            this.OffsetY.TabIndex = 26;
            this.OffsetY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OffsetY.TextChanged += new System.EventHandler(this.OffsetY_TextChanged);
            // 
            // antennaLength
            // 
            this.antennaLength.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.antennaLength.Location = new System.Drawing.Point(1055, 172);
            this.antennaLength.Name = "antennaLength";
            this.antennaLength.Size = new System.Drawing.Size(100, 36);
            this.antennaLength.TabIndex = 27;
            // 
            // antennaHeight
            // 
            this.antennaHeight.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.antennaHeight.Location = new System.Drawing.Point(1055, 232);
            this.antennaHeight.Name = "antennaHeight";
            this.antennaHeight.Size = new System.Drawing.Size(100, 36);
            this.antennaHeight.TabIndex = 28;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button9.Location = new System.Drawing.Point(269, 114);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(160, 77);
            this.button9.TabIndex = 29;
            this.button9.Text = "canTakeSecPic";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button_canTakeSecPic);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 402);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.antennaHeight);
            this.Controls.Add(this.antennaLength);
            this.Controls.Add(this.OffsetY);
            this.Controls.Add(this.OffsetX);
            this.Controls.Add(this.cameraInfoText);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.AngleText);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form_Main";
            this.Text = "IACT Robot Test";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.TextBox AngleText;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.TextBox cameraInfoText;
        private System.Windows.Forms.TextBox OffsetX;
        private System.Windows.Forms.TextBox OffsetY;
        private System.Windows.Forms.TextBox antennaLength;
        private System.Windows.Forms.TextBox antennaHeight;
        private System.Windows.Forms.Button button9;

    }
}

