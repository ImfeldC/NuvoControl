﻿/**************************************************************************************************
 * 
 *   Copyright (C) B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
 ***************************************************************************************************
 *
 *   Project:        NuvoControl
 *   SubProject:     NuvoControl.Server.Service
 *   Author:         Bernhard Limacher
 *   Creation Date:  12.05.2009
 *   File Name:      IConfigureInternal.cs
 * 
 ***************************************************************************************************
 * 
 * Revisions:
 * 1) 12.05.2009, Bernhard Limacher: Definition of the interface.
 * 
 **************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NuvoControl.Common.Configuration;
using NuvoControl.Common.Interfaces;

namespace NuvoControl.Server.Service.Configuration
{
    /// <summary>
    /// An internal interface to access the whole Nuvo Control system configuration.
    /// </summary>
    internal interface IConfigureInternal: IConfigure
    {
        /// <summary>
        /// Returns the Nuvo Control system configuration.
        /// </summary>
        SystemConfiguration SystemConfiguration { get; }

        /// <summary>
        /// Validates the system configuration. See the implementation for details.
        /// </summary>
        /// <returns>True, if system configuration is valid. Otherwise false.</returns>
        bool Validate();
    }
}

/**************************************************************************************************
 * 
 *   Copyright (C) B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
**************************************************************************************************/