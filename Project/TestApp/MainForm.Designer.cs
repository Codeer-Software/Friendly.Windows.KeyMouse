namespace TestApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this._list = new System.Windows.Forms.ListBox();
            this._textBox = new System.Windows.Forms.TextBox();
            this._clickCheck = new System.Windows.Forms.Label();
            this._moveCheck = new System.Windows.Forms.Label();
            this._keyTest = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _list
            // 
            this._list.FormattingEnabled = true;
            this._list.ItemHeight = 12;
            this._list.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this._list.Location = new System.Drawing.Point(152, 12);
            this._list.Name = "_list";
            this._list.Size = new System.Drawing.Size(120, 100);
            this._list.TabIndex = 0;
            // 
            // _textBox
            // 
            this._textBox.Location = new System.Drawing.Point(13, 24);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(100, 19);
            this._textBox.TabIndex = 1;
            // 
            // _clickCheck
            // 
            this._clickCheck.AutoSize = true;
            this._clickCheck.Location = new System.Drawing.Point(205, 240);
            this._clickCheck.Name = "_clickCheck";
            this._clickCheck.Size = new System.Drawing.Size(67, 12);
            this._clickCheck.TabIndex = 2;
            this._clickCheck.Text = "Click Check";
            // 
            // _moveCheck
            // 
            this._moveCheck.AutoSize = true;
            this._moveCheck.Location = new System.Drawing.Point(205, 214);
            this._moveCheck.Name = "_moveCheck";
            this._moveCheck.Size = new System.Drawing.Size(68, 12);
            this._moveCheck.TabIndex = 3;
            this._moveCheck.Text = "Move Check";
            // 
            // _keyTest
            // 
            this._keyTest.Location = new System.Drawing.Point(207, 179);
            this._keyTest.Name = "_keyTest";
            this._keyTest.Size = new System.Drawing.Size(53, 19);
            this._keyTest.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._keyTest);
            this.Controls.Add(this._moveCheck);
            this.Controls.Add(this._clickCheck);
            this.Controls.Add(this._textBox);
            this.Controls.Add(this._list);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _list;
        private System.Windows.Forms.TextBox _textBox;
        private System.Windows.Forms.Label _clickCheck;
        private System.Windows.Forms.Label _moveCheck;
        private System.Windows.Forms.TextBox _keyTest;
    }
}

