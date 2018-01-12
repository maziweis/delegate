using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C02事件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //1.创建三击按钮对象
            MyTripleButton myBtn = new MyTripleButton();
            //2.利用一个事件机制 为 按钮里的委托对象 注册一个 方法（或 移除一个方法）
            myBtn.dgMyClick += ClickSelf;
            //3.注意：因为使用了事件机制 封装了 按钮里的委托对象，所以不能 直接 赋值 和 调用委托了
            //myBtn.dgMyClick = null;
            //myBtn.dgMyClick();
            this.Controls.Add(myBtn);
        }

        void ClickSelf(DateTime time)
        {
            MessageBox.Show("三击了~~~~~~~~~~~~~！加分！");
        }
    }
}
