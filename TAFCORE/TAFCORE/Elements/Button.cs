using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TAFCORE.Utility.Logger;

namespace TAFCORE.Elements
{
    public class Button : Element
    {
       
        public Button()
        {

        }
        public Button(By by,string name) : base(by)
        {
            this.name = name;
            
        }

        public Button(By by) : base(by)
        {
            name = "button";
        }
        public void Click()
        {
            
            
            try
            {
                WaitUntilVisible(this.by);
                WaitUntilClickable(this.by);
                WrappedElement.Click();
                LoggerHandler.WriteToLog($"Button Click {name}");
                
            }
            catch (Exception ex)
            {
                LoggerHandler.WtiteErrorToLog($"Button {name} Unclickable", ex);
            }
        }

        //IWebElement getElement(); 
    }

}
