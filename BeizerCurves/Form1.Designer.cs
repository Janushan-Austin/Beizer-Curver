namespace BeizerCurves
{
    partial class BeizerCurve
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
            this.CameraChangeButton = new System.Windows.Forms.Button();
            this.XCameraTextBox = new System.Windows.Forms.TextBox();
            this.PointSelecter = new System.Windows.Forms.ComboBox();
            this.AddPointButton = new System.Windows.Forms.Button();
            this.RemovePointButton = new System.Windows.Forms.Button();
            this.XPointTextBox = new System.Windows.Forms.TextBox();
            this.UpdatePointButton = new System.Windows.Forms.Button();
            this.ConnectPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.AddHereButton = new System.Windows.Forms.Button();
            this.RemoveHereButton = new System.Windows.Forms.Button();
            this.YPointTextBox = new System.Windows.Forms.TextBox();
            this.ZPointTextBox = new System.Windows.Forms.TextBox();
            this.XPointLabel = new System.Windows.Forms.Label();
            this.YPointLabel = new System.Windows.Forms.Label();
            this.ZPointLabel = new System.Windows.Forms.Label();
            this.YCameraTextBox = new System.Windows.Forms.TextBox();
            this.ZCameraTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LightPositionLabel = new System.Windows.Forms.Label();
            this.ZLightPosTextBox = new System.Windows.Forms.TextBox();
            this.YLightPosTextBox = new System.Windows.Forms.TextBox();
            this.XLightPosTextBox = new System.Windows.Forms.TextBox();
            this.LightPositionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CameraChangeButton
            // 
            this.CameraChangeButton.Location = new System.Drawing.Point(104, 124);
            this.CameraChangeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CameraChangeButton.Name = "CameraChangeButton";
            this.CameraChangeButton.Size = new System.Drawing.Size(73, 35);
            this.CameraChangeButton.TabIndex = 0;
            this.CameraChangeButton.Text = "Move Camera";
            this.CameraChangeButton.UseVisualStyleBackColor = true;
            this.CameraChangeButton.Click += new System.EventHandler(this.CameraChangeButton_Click);
            // 
            // XCameraTextBox
            // 
            this.XCameraTextBox.Location = new System.Drawing.Point(104, 102);
            this.XCameraTextBox.Name = "XCameraTextBox";
            this.XCameraTextBox.Size = new System.Drawing.Size(24, 20);
            this.XCameraTextBox.TabIndex = 1;
            // 
            // PointSelecter
            // 
            this.PointSelecter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PointSelecter.FormattingEnabled = true;
            this.PointSelecter.Items.AddRange(new object[] {
            "point 1",
            "point 2",
            "point 3"});
            this.PointSelecter.Location = new System.Drawing.Point(8, 10);
            this.PointSelecter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PointSelecter.Name = "PointSelecter";
            this.PointSelecter.Size = new System.Drawing.Size(170, 21);
            this.PointSelecter.TabIndex = 2;
            this.PointSelecter.Tag = "";
            this.PointSelecter.SelectedIndexChanged += new System.EventHandler(this.PointSelecter_SelectedIndexChanged);
            // 
            // AddPointButton
            // 
            this.AddPointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPointButton.Location = new System.Drawing.Point(8, 67);
            this.AddPointButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddPointButton.Name = "AddPointButton";
            this.AddPointButton.Size = new System.Drawing.Size(46, 28);
            this.AddPointButton.TabIndex = 3;
            this.AddPointButton.Text = "Add End";
            this.AddPointButton.UseVisualStyleBackColor = true;
            this.AddPointButton.Click += new System.EventHandler(this.AddPointButton_Click);
            // 
            // RemovePointButton
            // 
            this.RemovePointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemovePointButton.Location = new System.Drawing.Point(58, 67);
            this.RemovePointButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RemovePointButton.Name = "RemovePointButton";
            this.RemovePointButton.Size = new System.Drawing.Size(42, 28);
            this.RemovePointButton.TabIndex = 4;
            this.RemovePointButton.Text = "Remove End";
            this.RemovePointButton.UseVisualStyleBackColor = true;
            this.RemovePointButton.Click += new System.EventHandler(this.RemovePointButton_Click);
            // 
            // XPointTextBox
            // 
            this.XPointTextBox.Location = new System.Drawing.Point(104, 46);
            this.XPointTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.XPointTextBox.Name = "XPointTextBox";
            this.XPointTextBox.Size = new System.Drawing.Size(24, 20);
            this.XPointTextBox.TabIndex = 6;
            // 
            // UpdatePointButton
            // 
            this.UpdatePointButton.AutoSize = true;
            this.UpdatePointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePointButton.Location = new System.Drawing.Point(104, 67);
            this.UpdatePointButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UpdatePointButton.Name = "UpdatePointButton";
            this.UpdatePointButton.Size = new System.Drawing.Size(73, 29);
            this.UpdatePointButton.TabIndex = 7;
            this.UpdatePointButton.Text = "Move Point";
            this.UpdatePointButton.UseVisualStyleBackColor = true;
            this.UpdatePointButton.Click += new System.EventHandler(this.UpdatePointButton_Click);
            // 
            // ConnectPointsCheckBox
            // 
            this.ConnectPointsCheckBox.AutoSize = true;
            this.ConnectPointsCheckBox.Location = new System.Drawing.Point(8, 229);
            this.ConnectPointsCheckBox.Name = "ConnectPointsCheckBox";
            this.ConnectPointsCheckBox.Size = new System.Drawing.Size(150, 17);
            this.ConnectPointsCheckBox.TabIndex = 8;
            this.ConnectPointsCheckBox.Text = "Draw lines between points";
            this.ConnectPointsCheckBox.UseVisualStyleBackColor = true;
            this.ConnectPointsCheckBox.CheckedChanged += new System.EventHandler(this.ConnectPointsCheckBox_CheckedChanged);
            // 
            // AddHereButton
            // 
            this.AddHereButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddHereButton.Location = new System.Drawing.Point(8, 37);
            this.AddHereButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddHereButton.Name = "AddHereButton";
            this.AddHereButton.Size = new System.Drawing.Size(46, 28);
            this.AddHereButton.TabIndex = 9;
            this.AddHereButton.Text = "Add Here";
            this.AddHereButton.UseVisualStyleBackColor = true;
            this.AddHereButton.Click += new System.EventHandler(this.AddHereButton_Click);
            // 
            // RemoveHereButton
            // 
            this.RemoveHereButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveHereButton.Location = new System.Drawing.Point(58, 37);
            this.RemoveHereButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RemoveHereButton.Name = "RemoveHereButton";
            this.RemoveHereButton.Size = new System.Drawing.Size(42, 28);
            this.RemoveHereButton.TabIndex = 10;
            this.RemoveHereButton.Text = "Remove Here";
            this.RemoveHereButton.UseVisualStyleBackColor = true;
            this.RemoveHereButton.Click += new System.EventHandler(this.RemoveHereButton_Click);
            // 
            // YPointTextBox
            // 
            this.YPointTextBox.Location = new System.Drawing.Point(128, 46);
            this.YPointTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.YPointTextBox.Name = "YPointTextBox";
            this.YPointTextBox.Size = new System.Drawing.Size(24, 20);
            this.YPointTextBox.TabIndex = 11;
            // 
            // ZPointTextBox
            // 
            this.ZPointTextBox.Location = new System.Drawing.Point(154, 46);
            this.ZPointTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ZPointTextBox.Name = "ZPointTextBox";
            this.ZPointTextBox.Size = new System.Drawing.Size(24, 20);
            this.ZPointTextBox.TabIndex = 12;
            // 
            // XPointLabel
            // 
            this.XPointLabel.AutoSize = true;
            this.XPointLabel.Location = new System.Drawing.Point(110, 31);
            this.XPointLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.XPointLabel.Name = "XPointLabel";
            this.XPointLabel.Size = new System.Drawing.Size(14, 13);
            this.XPointLabel.TabIndex = 13;
            this.XPointLabel.Text = "X";
            // 
            // YPointLabel
            // 
            this.YPointLabel.AutoSize = true;
            this.YPointLabel.Location = new System.Drawing.Point(133, 31);
            this.YPointLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.YPointLabel.Name = "YPointLabel";
            this.YPointLabel.Size = new System.Drawing.Size(14, 13);
            this.YPointLabel.TabIndex = 14;
            this.YPointLabel.Text = "Y";
            // 
            // ZPointLabel
            // 
            this.ZPointLabel.AutoSize = true;
            this.ZPointLabel.Location = new System.Drawing.Point(158, 31);
            this.ZPointLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ZPointLabel.Name = "ZPointLabel";
            this.ZPointLabel.Size = new System.Drawing.Size(14, 13);
            this.ZPointLabel.TabIndex = 15;
            this.ZPointLabel.Text = "Z";
            // 
            // YCameraTextBox
            // 
            this.YCameraTextBox.Location = new System.Drawing.Point(128, 102);
            this.YCameraTextBox.Name = "YCameraTextBox";
            this.YCameraTextBox.Size = new System.Drawing.Size(24, 20);
            this.YCameraTextBox.TabIndex = 16;
            // 
            // ZCameraTextBox
            // 
            this.ZCameraTextBox.Location = new System.Drawing.Point(154, 102);
            this.ZCameraTextBox.Name = "ZCameraTextBox";
            this.ZCameraTextBox.Size = new System.Drawing.Size(24, 20);
            this.ZCameraTextBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Camera position";
            // 
            // LightPositionLabel
            // 
            this.LightPositionLabel.AutoSize = true;
            this.LightPositionLabel.Location = new System.Drawing.Point(5, 169);
            this.LightPositionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LightPositionLabel.Name = "LightPositionLabel";
            this.LightPositionLabel.Size = new System.Drawing.Size(69, 13);
            this.LightPositionLabel.TabIndex = 23;
            this.LightPositionLabel.Text = "Light position";
            // 
            // ZLightPosTextBox
            // 
            this.ZLightPosTextBox.Location = new System.Drawing.Point(154, 167);
            this.ZLightPosTextBox.Name = "ZLightPosTextBox";
            this.ZLightPosTextBox.Size = new System.Drawing.Size(24, 20);
            this.ZLightPosTextBox.TabIndex = 22;
            // 
            // YLightPosTextBox
            // 
            this.YLightPosTextBox.Location = new System.Drawing.Point(128, 167);
            this.YLightPosTextBox.Name = "YLightPosTextBox";
            this.YLightPosTextBox.Size = new System.Drawing.Size(24, 20);
            this.YLightPosTextBox.TabIndex = 21;
            // 
            // XLightPosTextBox
            // 
            this.XLightPosTextBox.Location = new System.Drawing.Point(104, 167);
            this.XLightPosTextBox.Name = "XLightPosTextBox";
            this.XLightPosTextBox.Size = new System.Drawing.Size(24, 20);
            this.XLightPosTextBox.TabIndex = 20;
            // 
            // LightPositionButton
            // 
            this.LightPositionButton.Location = new System.Drawing.Point(104, 189);
            this.LightPositionButton.Margin = new System.Windows.Forms.Padding(2);
            this.LightPositionButton.Name = "LightPositionButton";
            this.LightPositionButton.Size = new System.Drawing.Size(73, 35);
            this.LightPositionButton.TabIndex = 19;
            this.LightPositionButton.Text = "Move Light";
            this.LightPositionButton.UseVisualStyleBackColor = true;
            this.LightPositionButton.Click += new System.EventHandler(this.LightPositionButton_Click);
            // 
            // BeizerCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.LightPositionLabel);
            this.Controls.Add(this.ZLightPosTextBox);
            this.Controls.Add(this.YLightPosTextBox);
            this.Controls.Add(this.XLightPosTextBox);
            this.Controls.Add(this.LightPositionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ZCameraTextBox);
            this.Controls.Add(this.YCameraTextBox);
            this.Controls.Add(this.ZPointLabel);
            this.Controls.Add(this.YPointLabel);
            this.Controls.Add(this.XPointLabel);
            this.Controls.Add(this.ZPointTextBox);
            this.Controls.Add(this.YPointTextBox);
            this.Controls.Add(this.RemoveHereButton);
            this.Controls.Add(this.AddHereButton);
            this.Controls.Add(this.ConnectPointsCheckBox);
            this.Controls.Add(this.UpdatePointButton);
            this.Controls.Add(this.XPointTextBox);
            this.Controls.Add(this.RemovePointButton);
            this.Controls.Add(this.AddPointButton);
            this.Controls.Add(this.PointSelecter);
            this.Controls.Add(this.XCameraTextBox);
            this.Controls.Add(this.CameraChangeButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BeizerCurve";
            this.Text = "Beizure Curve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CameraChangeButton;
        private System.Windows.Forms.TextBox XCameraTextBox;
        private System.Windows.Forms.ComboBox PointSelecter;
        private System.Windows.Forms.Button AddPointButton;
        private System.Windows.Forms.Button RemovePointButton;
        private System.Windows.Forms.TextBox XPointTextBox;
        private System.Windows.Forms.Button UpdatePointButton;
        private System.Windows.Forms.CheckBox ConnectPointsCheckBox;
        private System.Windows.Forms.Button AddHereButton;
        private System.Windows.Forms.Button RemoveHereButton;
        private System.Windows.Forms.TextBox YPointTextBox;
        private System.Windows.Forms.TextBox ZPointTextBox;
        private System.Windows.Forms.Label XPointLabel;
        private System.Windows.Forms.Label YPointLabel;
        private System.Windows.Forms.Label ZPointLabel;
        private System.Windows.Forms.TextBox YCameraTextBox;
        private System.Windows.Forms.TextBox ZCameraTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LightPositionLabel;
        private System.Windows.Forms.TextBox ZLightPosTextBox;
        private System.Windows.Forms.TextBox YLightPosTextBox;
        private System.Windows.Forms.TextBox XLightPosTextBox;
        private System.Windows.Forms.Button LightPositionButton;
    }
}

