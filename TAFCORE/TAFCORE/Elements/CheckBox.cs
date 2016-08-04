using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TAFCORE.Utility.WebDriver;
using TAFCORE.Utility.Logger;

namespace TAFCORE.Elements
{
    public class CheckBox : Element
    {
        
        public CheckBox()
        {

        }
        public CheckBox(By by) : base(by)
        {

        }

        public CheckBox(By by,string name) : base(by)
        {
            this.name = name;
        }

        public void Select()
        {
            try
            {


                if (!Selected)
                {
                    WaitUntilVisible(this.by);
                    WaitUntilClickable(this.by);
                    WrappedElement.Click();
                    LoggerHandler.WriteToLog($"CheckBox {name} Selected");
                }
            }
            catch(Exception ex)
            {
                LoggerHandler.WtiteErrorToLog($"CheckBox {name} can't be select", ex);
            }
        }

        public void Deselect()
        {
            if (Selected)
            {
                WaitUntilVisible(this.by);
                WaitUntilClickable(this.by);
                WrappedElement.Click();
            }
        }

        bool isSelect() { return true; }

    }

}
