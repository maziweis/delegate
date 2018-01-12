using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 委托事件
{
    public partial class C03事件 : Form
    {
        //1.手动 创建 按钮对象
        MyTripleButton btnMyTriple = new MyTripleButton();

        //2.手动 创建 改进型 按钮对象
        MyTripleButtonSelf btnMyTriSelf = new MyTripleButtonSelf();

        //3.手动 创建 事件 按钮对象
        MyTripleButtonSelfEvent btnMyTriSelfEvent = new MyTripleButtonSelfEvent();

        public C03事件()
        {
            InitializeComponent();

            //1.2.设置 按钮的 文本 和位置
            btnMyTriple.Text = "自定义按钮";
            btnMyTriple.Location = new Point(100, 100);
            //1.3.将按钮 显示到 窗体上
            this.Controls.Add(btnMyTriple);
            //1.4.为按钮 的 委托 设置一个 方法（按钮被点击的时候 会被 执行）
            btnMyTriple.dgMyClick = MyTripleClick;


            //2.2.设置 按钮的 文本 和位置
            btnMyTriSelf.Text = "改进型 自定义按钮";
            btnMyTriSelf.Location = new Point(100, 150);
            btnMyTriSelf.Size = new Size(150, 50);
            //2.3.将按钮 显示到 窗体上
            this.Controls.Add(btnMyTriSelf);
            //2.4.为按钮 的 委托 设置一个 方法（按钮被点击的时候 会被 执行）
            btnMyTriSelf.AddClickMethod(MyTripleClick);


            //3.2.设置 按钮的 文本 和位置
            btnMyTriSelfEvent.Text = "事件 自定义按钮";
            btnMyTriSelfEvent.Location = new Point(100, 200);
            btnMyTriSelfEvent.Size = new Size(150, 50);
            //3.3.将按钮 显示到 窗体上
            this.Controls.Add(btnMyTriSelfEvent);
            //3.4.为按钮 的 委托 设置一个 方法（按钮被点击的时候 会被 执行）
            btnMyTriSelfEvent.dgMyClick += MyTripleClick;
            btnMyTriSelfEvent.dgMyClick -= MyTripleClick;
        }

        void MyTripleClick(DateTime clickTime)
        {
            MessageBox.Show("Test" + clickTime);
        }

        private void btnTrick_Click(object sender, EventArgs e)
        {
            //直接 把 按钮对象 里的委托 设置为空，从而 导致委托中原来保存的方法指针都丢失，有可能破坏了 业务的完整性，不安全！！！
            btnMyTriple.dgMyClick = null;
            //新式 按钮，没有把按钮里的 委托对象 暴露给 外部直接操作，所以相对来说 比较安全！！！
            //btnMyTriSelf.RemoveClickMethod(
            //事件 按钮，事件机制 会自动的将 修饰的 委托变量改为私有，并同时提供一个 add 和 remove方法
            //btnMyTriSelfEvent.dgMyClick = null;
        }
    }
}
