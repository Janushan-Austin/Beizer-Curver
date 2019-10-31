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
            this.SuspendLayout();
            // 
            // CameraChangeButton
            // 
            this.CameraChangeButton.Location = new System.Drawing.Point(138, 153);
            this.CameraChangeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CameraChangeButton.Name = "CameraChangeButton";
            this.CameraChangeButton.Size = new System.Drawing.Size(97, 43);
            this.CameraChangeButton.TabIndex = 0;
            this.CameraChangeButton.Text = "Update Camera";
            this.CameraChangeButton.UseVisualStyleBackColor = true;
            this.CameraChangeButton.Click += new System.EventHandler(this.CameraChangeButton_Click);
            // 
            // XCameraTextBox
            // 
            this.XCameraTextBox.Location = new System.Drawing.Point(138, 125);
            this.XCameraTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.XCameraTextBox.Name = "XCameraTextBox";
            this.XCameraTextBox.Size = new System.Drawing.Size(30, 22);
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
            this.PointSelecter.Location = new System.Drawing.Point(10, 12);
            this.PointSelecter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointSelecter.Name = "PointSelecter";
            this.PointSelecter.Size = new System.Drawing.Size(225, 24);
            this.PointSelecter.TabIndex = 2;
            this.PointSelecter.Tag = "";
            this.PointSelecter.SelectedIndexChanged += new System.EventHandler(this.PointSelecter_SelectedIndexChanged);
            // 
            // AddPointButton
            // 
            this.AddPointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPointButton.Location = new System.Drawing.Point(10, 83);
            this.AddPointButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddPointButton.Name = "AddPointButton";
            this.AddPointButton.Size = new System.Drawing.Size(61, 34);
            this.AddPointButton.TabIndex = 3;
            this.AddPointButton.Text = "Add End";
            this.AddPointButton.UseVisualStyleBackColor = true;
            this.AddPointButton.Click += new System.EventHandler(this.AddPointButton_Click);
            // 
            // RemovePointButton
            // 
            this.RemovePointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemovePointButton.Location = new System.Drawing.Point(77, 83);
            this.RemovePointButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemovePointButton.Name = "RemovePointButton";
            this.RemovePointButton.Size = new System.Drawing.Size(56, 34);
            this.RemovePointButton.TabIndex = 4;
            this.RemovePointButton.Text = "Remove End";
            this.RemovePointButton.UseVisualStyleBackColor = true;
            this.RemovePointButton.Click += new System.EventHandler(this.RemovePointButton_Click);
            // 
            // XPointTextBox
            // 
            this.XPointTextBox.Location = new System.Drawing.Point(139, 57);
            this.XPointTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XPointTextBox.Name = "XPointTextBox";
            this.XPointTextBox.Size = new System.Drawing.Size(30, 22);
            this.XPointTextBox.TabIndex = 6;
            // 
            // UpdatePointButton
            // 
            this.UpdatePointButton.AutoSize = true;
            this.UpdatePointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePointButton.Location = new System.Drawing.Point(138, 83);
            this.UpdatePointButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdatePointButton.Name = "UpdatePointButton";
            this.UpdatePointButton.Size = new System.Drawing.Size(97, 36);
            this.UpdatePointButton.TabIndex = 7;
            this.UpdatePointButton.Text = "Update Point";
            this.UpdatePointButton.UseVisualStyleBackColor = true;
            this.UpdatePointButton.Click += new System.EventHandler(this.UpdatePointButton_Click);
            // 
            // ConnectPointsCheckBox
            // 
            this.ConnectPointsCheckBox.AutoSize = true;
            this.ConnectPointsCheckBox.Location = new System.Drawing.Point(10, 202);
            this.ConnectPointsCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectPointsCheckBox.Name = "ConnectPointsCheckBox";
            this.ConnectPointsCheckBox.Size = new System.Drawing.Size(194, 21);
            this.ConnectPointsCheckBox.TabIndex = 8;
            this.ConnectPointsCheckBox.Text = "Draw lines between points";
            this.ConnectPointsCheckBox.UseVisualStyleBackColor = true;
            this.ConnectPointsCheckBox.CheckedChanged += new System.EventHandler(this.ConnectPointsCheckBox_CheckedChanged);
            // 
            // AddHereButton
            // 
            this.AddHereButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddHereButton.Location = new System.Drawing.Point(10, 45);
            this.AddHereButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddHereButton.Name = "AddHereButton";
            this.AddHereButton.Size = new System.Drawing.Size(61, 34);
            this.AddHereButton.TabIndex = 9;
            this.AddHereButton.Text = "Add Here";
            this.AddHereButton.UseVisualStyleBackColor = true;
            this.AddHereButton.Click += new System.EventHandler(this.AddHereButton_Click);
            // 
            // RemoveHereButton
            // 
            this.RemoveHereButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveHereButton.Location = new System.Drawing.Point(77, 45);
            this.RemoveHereButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemoveHereButton.Name = "RemoveHereButton";
            this.RemoveHereButton.Size = new System.Drawing.Size(56, 34);
            this.RemoveHereButton.TabIndex = 10;
            this.RemoveHereButton.Text = "Remove Here";
            this.RemoveHereButton.UseVisualStyleBackColor = true;
            this.RemoveHereButton.Click += new System.EventHandler(this.RemoveHereButton_Click);
            // 
            // YPointTextBox
            // 
            this.YPointTextBox.Location = new System.Drawing.Point(171, 57);
            this.YPointTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YPointTextBox.Name = "YPointTextBox";
            this.YPointTextBox.Size = new System.Drawing.Size(30, 22);
            this.YPointTextBox.TabIndex = 11;
            // 
            // ZPointTextBox
            // 
            this.ZPointTextBox.Location = new System.Drawing.Point(205, 57);
            this.ZPointTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZPointTextBox.Name = "ZPointTextBox";
            this.ZPointTextBox.Size = new System.Drawing.Size(30, 22);
            this.ZPointTextBox.TabIndex = 12;
            // 
            // XPointLabel
            // 
            this.XPointLabel.AutoSize = true;
            this.XPointLabel.Location = new System.Drawing.Point(147, 38);
            this.XPointLabel.Name = "XPointLabel";
            this.XPointLabel.Size = new System.Drawing.Size(17, 17);
            this.XPointLabel.TabIndex = 13;
            this.XPointLabel.Text = "X";
            // 
            // YPointLabel
            // 
            this.YPointLabel.AutoSize = true;
            this.YPointLabel.Location = new System.Drawing.Point(177, 38);
            this.YPointLabel.Name = "YPointLabel";
            this.YPointLabel.Size = new System.Drawing.Size(17, 17);
            this.YPointLabel.TabIndex = 14;
            this.YPointLabel.Text = "Y";
            // 
            // ZPointLabel
            // 
            this.ZPointLabel.AutoSize = true;
            this.ZPointLabel.Location = new System.Drawing.Point(211, 38);
            this.ZPointLabel.Name = "ZPointLabel";
            this.ZPointLabel.Size = new System.Drawing.Size(17, 17);
            this.ZPointLabel.TabIndex = 15;
            this.ZPointLabel.Text = "Z";
            // 
            // YCameraTextBox
            // 
            this.YCameraTextBox.Location = new System.Drawing.Point(171, 125);
            this.YCameraTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.YCameraTextBox.Name = "YCameraTextBox";
            this.YCameraTextBox.Size = new System.Drawing.Size(30, 22);
            this.YCameraTextBox.TabIndex = 16;
            // 
            // ZCameraTextBox
            // 
            this.ZCameraTextBox.Location = new System.Drawing.Point(205, 125);
            this.ZCameraTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ZCameraTextBox.Name = "ZCameraTextBox";
            this.ZCameraTextBox.Size = new System.Drawing.Size(30, 22);
            this.ZCameraTextBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Camera position";
            // 
            // BeizerCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 985);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
    }
}

