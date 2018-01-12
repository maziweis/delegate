namespace 委托事件
{
    partial class C03事件
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
            this.btnTrick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTrick
            // 
            this.btnTrick.Location = new System.Drawing.Point(34, 25);
            this.btnTrick.Name = "btnTrick";
            this.btnTrick.Size = new System.Drawing.Size(225, 23);
            this.btnTrick.TabIndex = 0;
            this.btnTrick.Text = "捣乱-把三击按钮对象的委托清空";
            this.btnTrick.UseVisualStyleBackColor = true;
            this.btnTrick.Click += new System.EventHandler(this.btnTrick_Click);
            // 
            // C03事件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 401);
            this.Controls.Add(this.btnTrick);
            this.Name = "C03事件";
            this.Text = "C03事件";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTrick;

    }
}