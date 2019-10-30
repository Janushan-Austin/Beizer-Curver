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
            this.DeltaCameraInput = new System.Windows.Forms.TextBox();
            this.PointSelecter = new System.Windows.Forms.ComboBox();
            this.AddPointButton = new System.Windows.Forms.Button();
            this.RemovePointButton = new System.Windows.Forms.Button();
            this.InputPointTextBox = new System.Windows.Forms.TextBox();
            this.UpdatePointButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CameraChangeButton
            // 
            this.CameraChangeButton.Location = new System.Drawing.Point(314, 13);
            this.CameraChangeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CameraChangeButton.Name = "CameraChangeButton";
            this.CameraChangeButton.Size = new System.Drawing.Size(123, 23);
            this.CameraChangeButton.TabIndex = 0;
            this.CameraChangeButton.Text = "ChangeCamera";
            this.CameraChangeButton.UseVisualStyleBackColor = true;
            this.CameraChangeButton.Click += new System.EventHandler(this.CameraChangeButton_Click);
            // 
            // DeltaCameraInput
            // 
            this.DeltaCameraInput.Location = new System.Drawing.Point(444, 13);
            this.DeltaCameraInput.Margin = new System.Windows.Forms.Padding(4);
            this.DeltaCameraInput.Name = "DeltaCameraInput";
            this.DeltaCameraInput.Size = new System.Drawing.Size(132, 22);
            this.DeltaCameraInput.TabIndex = 1;
            // 
            // PointSelecter
            // 
            this.PointSelecter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PointSelecter.FormattingEnabled = true;
            this.PointSelecter.Items.AddRange(new object[] {
            "point 1",
            "point 2"});
            this.PointSelecter.Location = new System.Drawing.Point(12, 13);
            this.PointSelecter.Name = "PointSelecter";
            this.PointSelecter.Size = new System.Drawing.Size(121, 24);
            this.PointSelecter.TabIndex = 2;
            this.PointSelecter.Tag = "";
            this.PointSelecter.SelectedIndexChanged += new System.EventHandler(this.PointSelecter_SelectedIndexChanged);
            // 
            // AddPointButton
            // 
            this.AddPointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPointButton.Location = new System.Drawing.Point(12, 43);
            this.AddPointButton.Name = "AddPointButton";
            this.AddPointButton.Size = new System.Drawing.Size(49, 35);
            this.AddPointButton.TabIndex = 3;
            this.AddPointButton.Text = "Add End";
            this.AddPointButton.UseVisualStyleBackColor = true;
            this.AddPointButton.Click += new System.EventHandler(this.AddPointButton_Click);
            // 
            // RemovePointButton
            // 
            this.RemovePointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemovePointButton.Location = new System.Drawing.Point(67, 43);
            this.RemovePointButton.Name = "RemovePointButton";
            this.RemovePointButton.Size = new System.Drawing.Size(66, 35);
            this.RemovePointButton.TabIndex = 4;
            this.RemovePointButton.Text = "Remove End";
            this.RemovePointButton.UseVisualStyleBackColor = true;
            this.RemovePointButton.Click += new System.EventHandler(this.RemovePointButton_Click);
            // 
            // InputPointTextBox
            // 
            this.InputPointTextBox.Location = new System.Drawing.Point(140, 13);
            this.InputPointTextBox.Name = "InputPointTextBox";
            this.InputPointTextBox.Size = new System.Drawing.Size(100, 22);
            this.InputPointTextBox.TabIndex = 6;
            // 
            // UpdatePointButton
            // 
            this.UpdatePointButton.Location = new System.Drawing.Point(165, 41);
            this.UpdatePointButton.Name = "UpdatePointButton";
            this.UpdatePointButton.Size = new System.Drawing.Size(75, 23);
            this.UpdatePointButton.TabIndex = 7;
            this.UpdatePointButton.Text = "Update";
            this.UpdatePointButton.UseVisualStyleBackColor = true;
            this.UpdatePointButton.Click += new System.EventHandler(this.UpdatePointButton_Click);
            // 
            // BeizerCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.UpdatePointButton);
            this.Controls.Add(this.InputPointTextBox);
            this.Controls.Add(this.RemovePointButton);
            this.Controls.Add(this.AddPointButton);
            this.Controls.Add(this.PointSelecter);
            this.Controls.Add(this.DeltaCameraInput);
            this.Controls.Add(this.CameraChangeButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
    }
}

