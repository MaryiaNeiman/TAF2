﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using System.Threading;

namespace TAFCORE.Utility.Attachment
{
    public class Attachment
    {

        public static void AttachFile(string path)
        {
            //IAutoItX3 autoIT = new AutoItX3();
            //autoIT.WinActivate("File Upload");
            //autoIT.Send(path);
            //Thread.Sleep(3000);
            //autoIT.Send("{ENTER}");
            System.Windows.Forms.SendKeys.SendWait(path);
            Thread.Sleep(1000);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            Thread.Sleep(5000);
        }
    }
}
