using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TAFCORE.Utility.Logger;
namespace TAFCORE.Elements
{

    public class Label : Element
    {
        public Label()
        {

        }
        public Label(By by) : base(by)
        {

        }

        public Label(By by,string name) : base(by)
        {
            this.name = name;
        }

        void Click()
        {
            try
            {
                WaitUntilVisible(this.by);
                WaitUntilClickable(this.by);
                WrappedElement.Click();
                LoggerHandler.WriteToLog($"Label {name} Click");

            }
            catch (Exception ex)
            {
                LoggerHandler.WtiteErrorToLog($"Label {name} Unclickable", ex);
            }
        }

    }
}
