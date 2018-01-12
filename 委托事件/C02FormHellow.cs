using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 委托事件
{
    /* 1.声明委托的本质：
     *  1.1委托编译后 生成一个 同名类(DGTest) 
     *  1.2继承关系： DGTest -> MulticastDelegate -> Delegate
     */
    public delegate void DGTest();

    public delegate string DGTest2(string strName);

    public partial class C02FormHellow : Form
    {
        public C02FormHellow()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //语法糖：在C#中有很多 简洁语法，实质是由编译器 在编译时 转成 完整语法，那么这种 简洁语法叫做语法糖
            //2.创建委托对象
            DGTest dg = Test;//new DGTest(this.Test);
            /*3.为委托追加方法的本质：
             *    是为 被追加的方法创建一个新的委托对象，并将 方法 指针存入对象的 父类的父类(Delegate)的 IntPtr 变量中
             *    然后再将 新创建的委托 添加到 当前委托对象(dg)的 数组中
             */
            dg += Test2;//编译后：(DGTest) Delegate.Combine(dg, new DGTest(this.Test2));
            dg += Test3;//编译后：(DGTest) Delegate.Combine(dg, new DGTest(this.Test3));
            dg -= Test3;//编译后：(DGTest) Delegate.Remove(dg, new DGTest(this.Test3));
            /*4.调用委托，其实就是通过调用委托对象里的Invoke方法 遍历 委托内部的数组，然后依次调用 数组中的 方法
             */
            dg();//编译后：dg.Invoke();
            
            /* 委托的作用：
             *   1.将方法做为参数
             *   2.将方法作为返回值
             */
        }

        void Test()
        {
            MessageBox.Show("Test");
        }

        void Test2()
        {
            MessageBox.Show("Test2");
        }

        void Test3()
        {
            MessageBox.Show("Test3");
        }

        #region 1.0 委托当参数
        private void btnPara_Click(object sender, EventArgs e)
        {
            InvokeTest(Test);
            InvokeTest(Test2);
            InvokeTest(Test3);
        }

        /// <summary>
        /// 委托当参数使用： 调用 3个 Test 方法 中的某一个
        /// </summary>
        /// <param name="strType"></param>
        public void InvokeTest(DGTest dgTest)
        {
            dgTest();
        } 
        #endregion

        #region 2.0 委托当返回值
        private void btnReturn_Click(object sender, EventArgs e)
        {
            DGTest dg = InvokeTest("1");
            dg();
        }

        /// <summary>
        /// 委托当返回值
        /// </summary>
        /// <param name="strType"></param>
        /// <returns></returns>
        public DGTest InvokeTest(string strType)
        {
            switch (strType)
            {
                case "1":
                    return Test;
                case "2":
                    return Test2;
                default:
                    return Test3;
            }
        } 
        #endregion

        #region 3.0 完成 Each方法

        private void btnEach_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            list.Add("刘德华");
            list.Add("张学友");
            list.Add("郭富城");
            list.Add("黎明");

            Each(list, ShowName);
        }

        void ShowName(int index, object item)
        {
            MessageBox.Show(index + ",item=" + item);
        }

        public delegate void DGEachFunc(int index, object item);

        /// <summary>
        /// 遍历 集合 ，并 一次 调用 传入的回调方法
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="func">回调方法委托</param>
        public void Each(ArrayList list, DGEachFunc func)
        {
            for (int i = 0; i < list.Count; i++)
            {
                //调用传入的方法（其实是传入的委托对象 调用 委托对象里的方法）
                func(i, list[i]);
            }
        } 
        #endregion

        #region 4.0 使用接口排序
        /// <summary>
        /// 使用接口排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSort_Click(object sender, EventArgs e)
        {
            List<Dog> list = new List<Dog>();
            list.Add(new Dog() { name = "小白", age = 12 });
            list.Add(new Dog() { name = "小黑", age = 1 });
            list.Add(new Dog() { name = "小黄", age = 2 });

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(i + "：" + list[i].name + ",age=" + list[i].age);
            }

            //此处 传递一个 IComparer接口的实现类 对象进去 ，目的 是 为 Sort 排序方法里的 比较过程 提供一个 比大小的方法。
            list.Sort(new CompareDog());

            Console.WriteLine("排序后：");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(i + "：" + list[i].name + ",age=" + list[i].age);
            }
        } 
        #endregion

        #region 5.0 使用委托排序
        /// <summary>
        /// 使用委托排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortDelegate_Click(object sender, EventArgs e)
        {
            List<Dog> list = new List<Dog>();
            list.Add(new Dog() { name = "小白", age = 12 });
            list.Add(new Dog() { name = "小黑", age = 1 });
            list.Add(new Dog() { name = "小黄", age = 2 });

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(i + "：" + list[i].name + ",age=" + list[i].age);
            }

            //传入 的参数 为 一个 符合 Comparison 委托签名的方法
            list.Sort(ComparisonDog);

            //list.Sort((x, y) => x.age - y.age);
            //int d = list.Max(x => x.age);

            Console.WriteLine("排序后：");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(i + "：" + list[i].name + ",age=" + list[i].age);
            }
        }

        int ComparisonDog(Dog x, Dog y)
        {
            return x.age - y.age;
        } 
        #endregion

        #region 6.0 使用泛型方法 加 泛型委托 完成 通用版的 Max方法
        /// <summary>
        /// 使用泛型方法 加 泛型委托 完成 通用版的 Max方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindMax_Click(object sender, EventArgs e)
        {
            int[] arrInt = new int[5] { 1, 2, 5, 6, 3 };
            //int Max = MaxInt(arrInt);
            int max = MaxValue<int>(arrInt, (x, y) => x - y);


            string[] arrStr = new string[] { "a", "c", "b" };
            string maxLengthStr = MaxValue<string>(arrStr, (x, y) => x.Length - y.Length);

            Dog[] dogs = new Dog[] { new Dog() { age = 1, name = "小白" }, new Dog() { age = 0, name = "小白2" }, new Dog() { age = 5, name = "小白3" } };
            Dog maxAgeDog = MaxValue<Dog>(dogs, (x, y) => x.age - y.age);

        }

        int MaxInt(int[] arr)
        {
            int maxInt = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (maxInt < arr[i])
                {
                    maxInt = arr[i];
                }
            }
            return maxInt;
        }


        T MaxValue<T>(T[] arr, Comparison<T> func)
        {
            T maxInt = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                //使用委托来 完成元素 大小的比较过程！
                if (func(maxInt, arr[i]) < 0)
                {
                    maxInt = arr[i];
                }
            }
            return maxInt;
        } 
        #endregion

        #region 9.0 调用 委托 加工 数组里的 每个字符串
        /// <summary>
        /// 调用 委托 加工 数组里的 每个字符串
        /// </summary>
        private void btnMakeUpStr_Click(object sender, EventArgs e)
        {
            //创建数组
            string[] strArr = new string[] { "bb", "小李", "飞到" };
            //加工后产生新的数组，并将 方法 作为 第二个参数 传入
            string[] strArrNew = MakeUpStrArr(strArr, x=>x+"i");
            //遍历新数组 检查结果
            for (int i = 0; i < strArrNew.Length; i++)
            {
                Console.WriteLine(strArrNew[i]);
            }
        }

        //为传入字符串加一个 新的字符串
        string MakeUpStr(string str)
        {
            return str += "- : )";
        }

        //为传入的字符串数组 里的每个字符串 追加一个 新的字符串，并作为新字符串数组返回
        string[] MakeUpStrArr(string[] arrStr, DGMakeUpStr dgMakeUpStr)
        {
            //创建新数组
            string[] arrstrNew = new string[arrStr.Length];
            //遍历字符串数组
            for (int i = 0; i < arrStr.Length; i++)
            {
                arrstrNew[i] = dgMakeUpStr(arrStr[i]);//此处调用 传入的委托对象里的方法 为 字符串加工
            }
            //返回新数组
            return arrstrNew;
        } 
        #endregion


        private void btnFindMaxByDel_Click(object sender, EventArgs e)
        {
            DGCompare dg = new DGCompare(IntCompare);

            //找最大数值
            object[] arrInt = {5, 4, 1, 9, 8};
            int maxInt = Convert.ToInt32(GetMax(arrInt, new DGCompare(IntCompare)));

            //找最长字符串
            object[] arrStr = { "ui", "xiaomi", "lei", "h" };
            string maxLenStr = GetMax(arrStr, StringCompare).ToString();

            //找年龄最大的狗
            object[] arrDog = { new Dog { name = "小白", age = 21 }, new Dog { name = "小黑", age = 11 }, new Dog { name = "小花", age = 5 } };
            Dog oldestDog = GetMax(arrDog, DogCompare) as Dog;
        }

        /// <summary>
        /// 根据 比较方法找最大值
        /// </summary>
        /// <returns></returns>
        object GetMax(object[] values, DGCompare comparor)
        {
            object max = values[0];
            foreach (object obj in values)
            {
                if (comparor.Invoke(obj, max) > 0)
                {
                    max = obj;
                }
            }
            return max;
        }

        //--------------------------------- 三个不同的比较方法 ----------------------------
        public int IntCompare(object value1, object value2)
        {
            int i1 = (int)value1;
            int i2 = (int)value2;
            return i1 - i2;
        }

        public int StringCompare(object value1, object value2)
        {
            string i1 = (string)value1;
            string i2 = (string)value2;
            return i1.Length - i2.Length;
        }

        public int DogCompare(object value1, object value2)
        {
            Dog i1 = (Dog)value1;
            Dog i2 = (Dog)value2;
            return i1.age - i2.age;
        }

        #region 利用委托排序2
        private void button1_Click(object sender, EventArgs e)
        {
            int[] intAttr = new int[] {234,567,234,123,675,55 };
            int i = this.getMaxValue(intAttr,(x,y)=>x-y);
            Console.WriteLine(i);

            string[] strAttr = new string[] { "ser3w4r","fdt","e","we4efrge5dsfg","asdfasdgter"};
            string str = this.getMaxValue(strAttr,(x,y)=>x.Length-y.Length);
            Console.WriteLine(str);
        }

        public  T getMaxValue<T>(T[] t,Comparison<T> func) 
        {
            T maxT = t[0];
            for (int i = 0; i < t.Length; i++)
            {
                if (func(t[i],maxT)> 0)
                { 
                    maxT=t[i];
                }
            }
            return maxT;
        }

        #endregion
    }

    public delegate string DGMakeUpStr(string str);
    delegate int DGCompare(object v1, object v2);
}
