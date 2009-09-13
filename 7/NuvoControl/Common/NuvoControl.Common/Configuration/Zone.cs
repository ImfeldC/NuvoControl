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
 *   File Name:      Zone.cs
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
using System.Windows;
using System.Runtime.Serialization;

namespace NuvoControl.Common.Configuration
{
    /// <summary>
    /// Zone Configuration class.
    /// </summary>
    [DataContract]
    public class Zone
    {
        #region Private Members

        /// <summary>
        /// The address of the zone.
        /// </summary>
        [DataMember]
        private Address _id = new Address(SystemConfiguration.ID_UNDEFINED, SystemConfiguration.ID_UNDEFINED);
        
        /// <summary>
        /// The name of the zone.
        /// </summary>
        [DataMember]
        private string _name = String.Empty;

        /// <summary>
        /// The file name of the zone picture.
        /// </summary>
        [DataMember]
        private string _picturePath = String.Empty;

        /// <summary>
        /// The file type of the zone picture.
        /// </summary>
        [DataMember]
        private string _pictureType = String.Empty;

        /// <summary>
        /// The coordinates of the zone within the floor plan.
        /// </summary>
        [DataMember]
        private List<Point> _floorPlanCoordinates = new List<Point>();

        /// <summary>
        /// The coordinate of the zone control within the zone.
        /// </summary>
        [DataMember]
        private Point _zoneControlCoordinate = new Point(0, 0);

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Zone()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The address of the zone.</param>
        /// <param name="name">The name of the zone.</param>
        /// <param name="picturePath">The file name of the zone picture.</param>
        /// <param name="pictureType">The file type of the zone picture.</param>
        /// <param name="floorPlanCoordinates">The coordinates of the zone within the floor plan.</param>
        /// <param name="zoneControlCoordinate">The coordinatee of the zone control within the zone.</param>
        public Zone(Address id, string name, string picturePath, string pictureType, List<Point> floorPlanCoordinates, Point zoneControlCoordinate)
        {
            this._id = id;
            this._name = name;
            this._picturePath = picturePath;
            this._pictureType = pictureType;
            this._floorPlanCoordinates = floorPlanCoordinates;
            this._zoneControlCoordinate = zoneControlCoordinate;
        }

        #endregion

        #region Public Interface Members

        /// <summary>
        /// The address of the zone.
        /// </summary>
        public Address Id
        {
            get { return _id; }
        }

        /// <summary>
        /// The name of the zone.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// The file name of the zone picture.
        /// </summary>
        public string PicturePath
        {
            get { return _picturePath; }
        }

        /// <summary>
        /// The file type of the zone picture.
        /// </summary>
        public string PictureType
        {
            get { return _pictureType; }
        }

        /// <summary>
        /// The coordinates of the zone within the floor plan.
        /// </summary>
        public List<Point> FloorPlanCoordinates
        {
            get { return _floorPlanCoordinates; }
        }


        /// <summary>
        /// The coordinate of the zone within the zone.
        /// </summary>
        public Point ZoneControlCoordinate
        {
            get { return _zoneControlCoordinate; }
        }

        #endregion
    }
}

/**************************************************************************************************
 * 
 *   Copyright (C) B. Limacher, C. Imfeld. All Rights Reserved. Confidential
 * 
**************************************************************************************************/