using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托事件
{
    /// <summary>
    /// 自定义按钮类，继承于 按钮父类
    /// </summary>
    public class MyTripleButtonSelf:System.Windows.Forms.Button
    {
        //1.私有化委托 变量，使得外部无法直接操作修改 此对象
        private DGMyClick dgMyClick;

        //2.提供注册 方法的方式，来为 委托对象 注册
        public void AddClickMethod(DGMyClick dg)
        {
            dgMyClick += dg;
        }
        //3.提供移除 方法的方式.......
        public void RemoveClickMethod(DGMyClick dg)
        {
            dgMyClick -= dg;
        }

        public MyTripleButtonSelf()
        {
            //为父类的 单击事件 注册一个方法（就是 将一个 方法 存入 Click 属性中）
            base.Click += MyTripleButton_Click;
        }

        //
        void MyTripleButton_Click(object sender, EventArgs e)
        {
            //调用 自定义委托类 对象里的方法。
            if (dgMyClick != null)
                dgMyClick(DateTime.Now);
        }

    }
}
