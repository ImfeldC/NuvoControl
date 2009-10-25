﻿/**************************************************************************************************
 * 
 *   Copyright (C) B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
 ***************************************************************************************************
 *
 *   Project:        NuvoControl
 *   SubProject:     NuvoControl.Common.Interfaces
 *   Author:         Bernhard Limacher
 *   Creation Date:  19.05.2009
 *   File Name:      IMonitorControl.cs
 * 
 ***************************************************************************************************
 * 
 * Revisions:
 * 
 **************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using NuvoControl.Common.Configuration;
using NuvoControl.Common;

namespace NuvoControl.Server.FunctionService
{
    public interface IFunctionNotification
    {
        [OperationContract(IsOneWay = true)]
        void OnFunctionStateChanged(Guid functionId);
    }


    /// <summary>
    /// Defines the functions for monitoring and controlling NuvoControl
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IFunctionNotification))]
    public interface IFunction
    {
        [OperationContract]
        void Connect();

        [OperationContract]
        void Disconnect();

        /// <summary>
        /// Enables the service
        /// </summary>
        [OperationContract]
        void Enable(bool enable);


    }
}

/**************************************************************************************************
 * 
 *   Copyright (C) B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
**************************************************************************************************/
