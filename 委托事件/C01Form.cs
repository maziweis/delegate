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
    //1.声明 委托类（ 必须指定 返回值类型 和 方法参数列表）
    public delegate void DGSayHi(string str);

    public partial class C01Form : Form
    {
        public C01Form()
        {
            InitializeComponent();
            //在窗体构造函数中，为 自定义按钮对象 里的 委托 实例化，并 添加 一个方法
            //                被注册的方法 会被 按钮对象调用，并由按钮对象传入 点击时间 
            //this.myTripleButton1.dgMyClick = new DGMyClick(MyClick);

            //1.手动 创建 按钮对象
            MyTripleButton btnMyTriple = new MyTripleButton();
            //2.设置 按钮的 文本 和位置
            btnMyTriple.Text = "自定义按钮";
            btnMyTriple.Location = new Point(100, 100);
            //3.将按钮 显示到 窗体上
            this.Controls.Add(btnMyTriple);
            //4.为按钮 的 委托 设置一个 方法（按钮被点击的时候 会被 执行）
            btnMyTriple.dgMyClick = MyClick;
            //5.为 委托 追加 方法
            btnMyTriple.dgMyClick += MyClick2;
            //6.为 委托 移除 方法
            btnMyTriple.dgMyClick -= MyClick2;


        }

        void MyClick(DateTime clicktime)
        {
            MessageBox.Show("自定义按钮被点击啦1！！！时间是：" + clicktime.ToString());
        }

        void MyClick2(DateTime clicktime)
        {
            MessageBox.Show("自定义按钮被点击啦2！！！时间是：" + clicktime.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //2.创建委托对象 ， 并 为委托对象 添加一个 方法指针（方法对象地址）
            DGSayHi dgSayHi = new DGSayHi(SayHiInSomeWhere);
            //DGSayHi dgSayHi = new DGSayHi(SayHiInChina); //注意：不能存放 签名 和 委托签名 不一致的方法
            //3.调用委托！（委托对象内部的 方法 就会被调用）
            dgSayHi("哇哈哈哈！");
             //delega = SayHiInChina;
        }

        void SayHiInChina()
        {
            MessageBox.Show("您好~~！：）");
        }

        void SayHiInSomeWhere(string location)
        {
            MessageBox.Show(location + "您好~~！：）");
        }
    }
}
