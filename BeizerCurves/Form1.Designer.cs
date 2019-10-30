﻿namespace BeizerCurves
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
            this.DeltaCameraInput = new System.Windows.Forms.TextBox();
            this.PointSelecter = new System.Windows.Forms.ComboBox();
            this.AddPointButton = new System.Windows.Forms.Button();
            this.RemovePointButton = new System.Windows.Forms.Button();
            this.InputPointTextBox = new System.Windows.Forms.TextBox();
            this.UpdatePointButton = new System.Windows.Forms.Button();
            this.ConnectPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.AddHereButton = new System.Windows.Forms.Button();
            this.RemoveHereButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CameraChangeButton
            // 
            this.CameraChangeButton.Location = new System.Drawing.Point(236, 11);
            this.CameraChangeButton.Margin = new System.Windows.Forms.Padding(2);
            this.CameraChangeButton.Name = "CameraChangeButton";
            this.CameraChangeButton.Size = new System.Drawing.Size(92, 19);
            this.CameraChangeButton.TabIndex = 0;
            this.CameraChangeButton.Text = "ChangeCamera";
            this.CameraChangeButton.UseVisualStyleBackColor = true;
            this.CameraChangeButton.Click += new System.EventHandler(this.CameraChangeButton_Click);
            // 
            // DeltaCameraInput
            // 
            this.DeltaCameraInput.Location = new System.Drawing.Point(333, 11);
            this.DeltaCameraInput.Name = "DeltaCameraInput";
            this.DeltaCameraInput.Size = new System.Drawing.Size(100, 20);
            this.DeltaCameraInput.TabIndex = 1;
            // 
            // PointSelecter
            // 
            this.PointSelecter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PointSelecter.FormattingEnabled = true;
            this.PointSelecter.Items.AddRange(new object[] {
            "point 1",
            "point 2"});
            this.PointSelecter.Location = new System.Drawing.Point(9, 11);
            this.PointSelecter.Margin = new System.Windows.Forms.Padding(2);
            this.PointSelecter.Name = "PointSelecter";
            this.PointSelecter.Size = new System.Drawing.Size(92, 21);
            this.PointSelecter.TabIndex = 2;
            this.PointSelecter.Tag = "";
            this.PointSelecter.SelectedIndexChanged += new System.EventHandler(this.PointSelecter_SelectedIndexChanged);
            // 
            // AddPointButton
            // 
            this.AddPointButton.AutoSize = true;
            this.AddPointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPointButton.Location = new System.Drawing.Point(9, 68);
            this.AddPointButton.Margin = new System.Windows.Forms.Padding(2);
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
            this.RemovePointButton.Location = new System.Drawing.Point(59, 68);
            this.RemovePointButton.Margin = new System.Windows.Forms.Padding(2);
            this.RemovePointButton.Name = "RemovePointButton";
            this.RemovePointButton.Size = new System.Drawing.Size(42, 28);
            this.RemovePointButton.TabIndex = 4;
            this.RemovePointButton.Text = "Remove End";
            this.RemovePointButton.UseVisualStyleBackColor = true;
            this.RemovePointButton.Click += new System.EventHandler(this.RemovePointButton_Click);
            // 
            // InputPointTextBox
            // 
            this.InputPointTextBox.Location = new System.Drawing.Point(105, 11);
            this.InputPointTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.InputPointTextBox.Name = "InputPointTextBox";
            this.InputPointTextBox.Size = new System.Drawing.Size(76, 20);
            this.InputPointTextBox.TabIndex = 6;
            // 
            // UpdatePointButton
            // 
            this.UpdatePointButton.AutoSize = true;
            this.UpdatePointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePointButton.Location = new System.Drawing.Point(105, 36);
            this.UpdatePointButton.Margin = new System.Windows.Forms.Padding(2);
            this.UpdatePointButton.Name = "UpdatePointButton";
            this.UpdatePointButton.Size = new System.Drawing.Size(68, 29);
            this.UpdatePointButton.TabIndex = 7;
            this.UpdatePointButton.Text = "Update Point";
            this.UpdatePointButton.UseVisualStyleBackColor = true;
            this.UpdatePointButton.Click += new System.EventHandler(this.UpdatePointButton_Click);
            // 
            // ConnectPointsCheckBox
            // 
            this.ConnectPointsCheckBox.AutoSize = true;
            this.ConnectPointsCheckBox.Location = new System.Drawing.Point(452, 13);
            this.ConnectPointsCheckBox.Name = "ConnectPointsCheckBox";
            this.ConnectPointsCheckBox.Size = new System.Drawing.Size(97, 17);
            this.ConnectPointsCheckBox.TabIndex = 8;
            this.ConnectPointsCheckBox.Text = "Connect points";
            this.ConnectPointsCheckBox.UseVisualStyleBackColor = true;
            this.ConnectPointsCheckBox.CheckedChanged += new System.EventHandler(this.ConnectPointsCheckBox_CheckedChanged);
            // 
            // AddHereButton
            // 
            this.AddHereButton.AutoSize = true;
            this.AddHereButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddHereButton.Location = new System.Drawing.Point(9, 36);
            this.AddHereButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddHereButton.Name = "AddHereButton";
            this.AddHereButton.Size = new System.Drawing.Size(47, 28);
            this.AddHereButton.TabIndex = 9;
            this.AddHereButton.Text = "Add Here";
            this.AddHereButton.UseVisualStyleBackColor = true;
            this.AddHereButton.Click += new System.EventHandler(this.AddHereButton_Click);
            // 
            // RemoveHereButton
            // 
            this.RemoveHereButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveHereButton.Location = new System.Drawing.Point(59, 36);
            this.RemoveHereButton.Margin = new System.Windows.Forms.Padding(2);
            this.RemoveHereButton.Name = "RemoveHereButton";
            this.RemoveHereButton.Size = new System.Drawing.Size(42, 28);
            this.RemoveHereButton.TabIndex = 10;
            this.RemoveHereButton.Text = "Remove Here";
            this.RemoveHereButton.UseVisualStyleBackColor = true;
            this.RemoveHereButton.Click += new System.EventHandler(this.RemoveHereButton_Click);
            // 
            // BeizerCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 874);
            this.Controls.Add(this.RemoveHereButton);
            this.Controls.Add(this.AddHereButton);
            this.Controls.Add(this.ConnectPointsCheckBox);
            this.Controls.Add(this.UpdatePointButton);
            this.Controls.Add(this.InputPointTextBox);
            this.Controls.Add(this.RemovePointButton);
            this.Controls.Add(this.AddPointButton);
            this.Controls.Add(this.PointSelecter);
            this.Controls.Add(this.DeltaCameraInput);
            this.Controls.Add(this.CameraChangeButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BeizerCurve";
            this.Text = "Beizure Curve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CameraChangeButton;
        private System.Windows.Forms.TextBox DeltaCameraInput;
        private System.Windows.Forms.ComboBox PointSelecter;
        private System.Windows.Forms.Button AddPointButton;
        private System.Windows.Forms.Button RemovePointButton;
        private System.Windows.Forms.TextBox InputPointTextBox;
        private System.Windows.Forms.Button UpdatePointButton;
        private System.Windows.Forms.CheckBox ConnectPointsCheckBox;
        private System.Windows.Forms.Button AddHereButton;
        private System.Windows.Forms.Button RemoveHereButton;
    }
}

