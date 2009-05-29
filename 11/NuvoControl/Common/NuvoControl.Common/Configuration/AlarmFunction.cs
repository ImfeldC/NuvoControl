﻿/**************************************************************************************************
 * 
 *   Copyright (C) B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
 ***************************************************************************************************
 *
 *   Project:        NuvoControl
 *   SubProject:     NuvoControl.Common
 *   Author:         Bernhard Limacher
 *   Creation Date:  14.05.2009
 *   File Name:      AlarmFunction.cs
 * 
 ***************************************************************************************************
 * 
 * Revisions:
 * 1) 14.05.2009, Bernhard Limacher: First implementation.
 * 
 **************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuvoControl.Common.Configuration
{
    [Serializable]
    public class AlarmFunction: Function
    {
        #region Private Members

        private TimeSpan _alarmTime = new TimeSpan(7, 0, 0);
        private TimeSpan _alarmDuration = new TimeSpan(0, 10, 0);
        private Address _sourceId = new Address(SystemConfiguration.ID_UNDEFINED, SystemConfiguration.ID_UNDEFINED);
        private List<DayOfWeek> _validOnDays = new List<DayOfWeek>();

        #endregion

        #region Constructors

        public AlarmFunction(Guid id, Address zoneId, Address sourceId, TimeSpan alarmTime, TimeSpan alarmDuration, List<DayOfWeek> validOnDays)
            : base(id, zoneId)
        {
            this._alarmTime = alarmTime;
            this._alarmDuration = alarmDuration;
            this._sourceId = sourceId;
            this._validOnDays = validOnDays;
        }

        #endregion

        #region Public Interface

        public TimeSpan AlarmTime
        {
            get { return _alarmTime; }
        }

        public TimeSpan AlarmDuration
        {
            get { return _alarmDuration; }
        }

        public Address SourceId
        {
            get { return _sourceId; }
        }

        public List<DayOfWeek> ValidOnDays
        {
            get { return _validOnDays; }
        }

        #endregion
    }
}

/**************************************************************************************************
 * 
 *   Copyright (C) B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
**************************************************************************************************/
