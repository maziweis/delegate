using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托事件
{
    /// <summary>
    /// 自定义 单击 委托类
    /// </summary>
    /// <param name="clickTime"></param>
    public delegate void DGMyClick(DateTime clickTime);

    /// <summary>
    /// 自定义按钮类，继承于 按钮父类
    /// </summary>
    public class MyTripleButton:System.Windows.Forms.Button
    {
        public DGMyClick dgMyClick;

        public MyTripleButton()
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
