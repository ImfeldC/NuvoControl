﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NuvoControl.Server.WebServer
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lableHostNum.Text = Global.NumOfDiscoveredConfigurationHosts.ToString();
            labelHostAdress.Text = Global.ConfigurationHostAdress;
            linkHostAdress.Text = Global.ConfigurationHostAdress;
        }
    }
}
