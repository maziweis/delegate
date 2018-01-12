using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C02事件
{
    /// <summary>
    /// 三击按钮类 - 用户点击三次后 执行用户的 方法
    /// </summary>
    public class MyTripleButton:System.Windows.Forms.Button
    {
        Timer time = new Timer();

        public MyTripleButton()
        {
            base.Click += MyTripleButton_Click;
            time.Interval = 1000;
            time.Tick += time_Tick;
        }

        int clickTimes = 0;
        //定义一个 用来保存 用户方法的委托对象
        public event DGMyClick dgMyClick;

        void time_Tick(object sender, EventArgs e)
        {
            clickTimes = 0;
        }

        //每当被点击的时候，此方法会被调用
        void MyTripleButton_Click(object sender, EventArgs e)
        {
            //如果点击次数没达到3次
            if (clickTimes < 2)
            {
                //如果是第一次点击 则启动计时器
                if (clickTimes == 0)
                {
                    time.Start();
                }
                //点击次数++
                clickTimes++;
            }
            else//点击三次后
            {
                //1.执行用户的 方法
                if (dgMyClick != null)
                    dgMyClick(DateTime.Now);
                //2.清空点击次数
                clickTimes = 0;
                //3.重启计时器
                time.Stop();
            }
        }
    }

}
