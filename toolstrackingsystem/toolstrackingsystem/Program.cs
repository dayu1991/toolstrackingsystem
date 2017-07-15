﻿using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toolstrackingsystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //独立的log4net.config
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            //DialogResult就是用来判断是否返回父窗体的
            if (formLogin.DialogResult == DialogResult.OK)
            {
                //在线程中打开主窗体
                FormMain formtest = new FormMain();
                formtest.Tag = formLogin.Tag;
                Application.Run(formtest);
            }
        }
    }
}
