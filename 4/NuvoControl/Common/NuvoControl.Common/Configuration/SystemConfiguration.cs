﻿/**************************************************************************************************
 * 
 *   Copyright (C) B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
 ***************************************************************************************************
 *
 *   Project:        NuvoControl
 *   SubProject:     NuvoControl.Common
 *   Author:         Bernhard Limacher
 *   Creation Date:  12.05.2009
 *   File Name:      SystemConfiguration.cs
 * 
 ***************************************************************************************************
 * 
 * Revisions:
 * 1) 12.05.2009, Bernhard Limacher: First implementation.
 * 
 **************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NuvoControl.Common.Configuration
{
    /// <summary>
    /// This is a system configuration class. 
    /// 
    /// It is a data structurer.
    /// It is the root of the whole NuvoControl system configuration.
    /// </summary>
    public class SystemConfiguration
    {
        #region Constants

        /// <summary>
        /// Public constant defining the system configuration version.
        /// </summary>
        public const string VERSION = "1.0";

        /// <summary>
        /// Public constant defining 'ID Undefined'.
        /// </summary>
        public const int ID_UNDEFINED = -1;

        /// <summary>
        /// Public constant defining 'ID Separator'.
        /// </summary>
        public const char ID_SEPARATOR = '.';


        #endregion

        #region Private Members

        /// <summary>
        /// The connected hardware (devices)
        /// </summary>
        private Hardware _hardware = null;

        /// <summary>
        /// Specifies graphical attributes of the system.
        /// </summary>
        private Graphic _graphic = null;

        /// <summary>
        /// Specifies all functions (alarm and sleep) of the system.
        /// </summary>
        private List<Function> _functions = new List<Function>();

        #endregion

        #region SystemConfiguration


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hardware">The connected hardware (devices)</param>
        /// <param name="graphic">Specifies graphical attributes of the system.</param>
        /// <param name="functions">Specifies all functions (alarm and sleep) of the system.</param>
        public SystemConfiguration(Hardware hardware, Graphic graphic, List<Function> functions)
        {
            this._hardware = hardware;
            this._graphic = graphic;
            this._functions = functions;
        }

        #endregion

        #region Public Interface

        /// <summary>
        /// The connected hardware (devices)
        /// </summary>
        public Hardware Hardware
        {
            get { return _hardware; }
        }

        /// <summary>
        /// Specifies graphical attributes of the system.
        /// </summary>
        public Graphic Graphic
        {
            get { return _graphic; }
        }

        /// <summary>
        /// Specifies all functions (alarm and sleep) of the system.
        /// </summary>
        public List<Function> Functions
        {
            get { return _functions; }
        }

        #endregion
    }
}

/**************************************************************************************************
 * 
 *   Copyright (C) B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
**************************************************************************************************/