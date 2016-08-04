using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAFCORE.Utility.WebDriver;
using TAFCORE.Utility.Logger;
using OpenQA.Selenium;
namespace TAFCORE.Elements
{
    public class RadioButton : Element
    {
        public RadioButton() { }

        public RadioButton(By by) : base(by) { }
        public RadioButton(By by,string name) : base(by)
        {
            this.name = name;
        }
        public void Click()
        {
            try
            {
                WaitUntilVisible(this.by);
                WaitUntilClickable(this.by);
                WrappedElement.Click();
                LoggerHandler.WriteToLog($"RadioButton was {name} clicked");
            }
            catch (Exception ex)
            {
                LoggerHandler.WtiteErrorToLog($"RadioButton wasn't {name} clicked", ex);
            }
        }

        bool isSelect() { return true; }
    }
}
