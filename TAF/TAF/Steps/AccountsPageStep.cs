﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF.Page;

namespace TAF.Steps
{
   public class AccountsPageStep : Step
    {

        public static void AddAccount()
        {
            AccountsPage ap = new AccountsPage();
            ap.ClickOnHref();
        }

    }
}
