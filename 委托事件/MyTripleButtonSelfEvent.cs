using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托事件
{
    /// <summary>
    /// 自定义按钮类，继承于 按钮父类
    /// </summary>
    public class MyTripleButtonSelfEvent:System.Windows.Forms.Button
    {
        /*使用 事件event封装 委托变量，编译后：
         * 1.会把被修饰的委托变量私有化(private)
         * 2.会生成一个 与 委托变量 同名的 事件语法，内部包含 add 和 remove方法
         *                                        add 和 remove方法内部都是操作 私有的委托变量
         * 3.当外部访问 委托变量时，实际上访问的是 同名的事件语法，并使用 += 和 -= 为封装的 私有委托变量 增删方法
         */
        public event DGMyClick dgMyClick;

        public MyTripleButtonSelfEvent()
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
