﻿/**************************************************************************************************
 * 
 *   Copyright (C) 2009 by B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
 ***************************************************************************************************
 *
 *   Project:        NuvoControl
 *   SubProject:     NuvoControl.Test.COMListener
 *   Author:         Ch.Imfeld
 *   Creation Date:  6/12/2009 11:02:29 PM
 * 
 ***************************************************************************************************
 * 
 * Revisions:
 * 1) 6/12/2009 11:02:29 PM, Ch.Imfeld: Initial implementation.
 * 
 **************************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Common.Logging;

namespace NuvoControl.Test.COMListener
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// \class	Program
    ///
    /// \brief	Program. Main program class of COMListener
    ///
    /// \author	Administrator
    /// \date	17.05.2009
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static class Program
    {
        /// <summary>
        /// The main entry point for the application. 
        /// Uses the ILog intercface for common logging.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ILog log = LogManager.GetCurrentClassLogger();
            log.Debug( m=>m("Start of COMListener! (Version={0})", Application.ProductVersion) );
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new COMListener());

            log.Debug(m => m("End of COMListener! (Version={0})", Application.ProductVersion));
        }
    }
}
