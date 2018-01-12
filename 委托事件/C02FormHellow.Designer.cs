namespace 委托事件
{
    partial class C02FormHellow
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
            this.btnTest = new System.Windows.Forms.Button();
            this.btnPara = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnEach = new System.Windows.Forms.Button();
            this.btnSortInterface = new System.Windows.Forms.Button();
            this.btnSortDelegate = new System.Windows.Forms.Button();
            this.btnFindMax = new System.Windows.Forms.Button();
            this.btnMakeUpStr = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindMaxByDel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(37, 32);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "测试委托";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnPara
            // 
            this.btnPara.Location = new System.Drawing.Point(37, 91);
            this.btnPara.Name = "btnPara";
            this.btnPara.Size = new System.Drawing.Size(75, 23);
            this.btnPara.TabIndex = 1;
            this.btnPara.Text = "委托做参数";
            this.btnPara.UseVisualStyleBackColor = true;
            this.btnPara.Click += new System.EventHandler(this.btnPara_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(37, 199);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(92, 23);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "委托做返回值";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnEach
            // 
            this.btnEach.Location = new System.Drawing.Point(19, 19);
            this.btnEach.Name = "btnEach";
            this.btnEach.Size = new System.Drawing.Size(138, 23);
            this.btnEach.TabIndex = 3;
            this.btnEach.Text = "自定义通用循环方法";
            this.btnEach.UseVisualStyleBackColor = true;
            this.btnEach.Click += new System.EventHandler(this.btnEach_Click);
            // 
            // btnSortInterface
            // 
            this.btnSortInterface.Location = new System.Drawing.Point(175, 19);
            this.btnSortInterface.Name = "btnSortInterface";
            this.btnSortInterface.Size = new System.Drawing.Size(93, 23);
            this.btnSortInterface.TabIndex = 4;
            this.btnSortInterface.Text = "利用接口排序";
            this.btnSortInterface.UseVisualStyleBackColor = true;
            this.btnSortInterface.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnSortDelegate
            // 
            this.btnSortDelegate.Location = new System.Drawing.Point(283, 19);
            this.btnSortDelegate.Name = "btnSortDelegate";
            this.btnSortDelegate.Size = new System.Drawing.Size(93, 23);
            this.btnSortDelegate.TabIndex = 5;
            this.btnSortDelegate.Text = "利用委托排序";
            this.btnSortDelegate.UseVisualStyleBackColor = true;
            this.btnSortDelegate.Click += new System.EventHandler(this.btnSortDelegate_Click);
            // 
            // btnFindMax
            // 
            this.btnFindMax.Location = new System.Drawing.Point(382, 19);
            this.btnFindMax.Name = "btnFindMax";
            this.btnFindMax.Size = new System.Drawing.Size(116, 23);
            this.btnFindMax.TabIndex = 6;
            this.btnFindMax.Text = "泛型方法找最大值";
            this.btnFindMax.UseVisualStyleBackColor = true;
            this.btnFindMax.Click += new System.EventHandler(this.btnFindMax_Click);
            // 
            // btnMakeUpStr
            // 
            this.btnMakeUpStr.Location = new System.Drawing.Point(502, 19);
            this.btnMakeUpStr.Name = "btnMakeUpStr";
            this.btnMakeUpStr.Size = new System.Drawing.Size(93, 23);
            this.btnMakeUpStr.TabIndex = 7;
            this.btnMakeUpStr.Text = "加工字符串";
            this.btnMakeUpStr.UseVisualStyleBackColor = true;
            this.btnMakeUpStr.Click += new System.EventHandler(this.btnMakeUpStr_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindMaxByDel);
            this.groupBox1.Controls.Add(this.btnEach);
            this.groupBox1.Controls.Add(this.btnMakeUpStr);
            this.groupBox1.Controls.Add(this.btnSortInterface);
            this.groupBox1.Controls.Add(this.btnFindMax);
            this.groupBox1.Controls.Add(this.btnSortDelegate);
            this.groupBox1.Location = new System.Drawing.Point(135, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 85);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "委托做参数例子";
            // 
            // btnFindMaxByDel
            // 
            this.btnFindMaxByDel.Location = new System.Drawing.Point(19, 48);
            this.btnFindMaxByDel.Name = "btnFindMaxByDel";
            this.btnFindMaxByDel.Size = new System.Drawing.Size(93, 23);
            this.btnFindMaxByDel.TabIndex = 8;
            this.btnFindMaxByDel.Text = "找最大值";
            this.btnFindMaxByDel.UseVisualStyleBackColor = true;
            this.btnFindMaxByDel.Click += new System.EventHandler(this.btnFindMaxByDel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // C02FormHellow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 328);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnPara);
            this.Controls.Add(this.btnTest);
            this.Name = "C02FormHellow";
            this.Text = "C02FormHellow";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnPara;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnEach;
        private System.Windows.Forms.Button btnSortInterface;
        private System.Windows.Forms.Button btnSortDelegate;
        private System.Windows.Forms.Button btnFindMax;
        private System.Windows.Forms.Button btnMakeUpStr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFindMaxByDel;
        private System.Windows.Forms.Button button1;
    }
}