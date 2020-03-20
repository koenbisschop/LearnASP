﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ledenbeheer
{
    public partial class DefaultError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            if (exc != null)
                lblErrorMessage.Text = exc.Message;
        }

      
    }
}