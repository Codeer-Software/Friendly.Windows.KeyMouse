namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _button = new Button();
            _textBox = new TextBox();
            SuspendLayout();
            // 
            // _button
            // 
            _button.Location = new Point(68, 89);
            _button.Name = "_button";
            _button.Size = new Size(75, 23);
            _button.TabIndex = 0;
            _button.Text = "button";
            _button.UseVisualStyleBackColor = true;
            _button.Click += _button_Click;
            // 
            // _textBox
            // 
            _textBox.Location = new Point(43, 45);
            _textBox.Name = "_textBox";
            _textBox.Size = new Size(100, 23);
            _textBox.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 166);
            Controls.Add(_textBox);
            Controls.Add(_button);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button _button;
        private TextBox _textBox;
    }
}
