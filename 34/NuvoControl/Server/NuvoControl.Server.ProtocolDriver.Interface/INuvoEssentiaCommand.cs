﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuvoControl.Server.ProtocolDriver.Interface
{
    public interface INuvoEssentiaCommand
    {
        INuvoEssentiaSingleCommand[] commandList { get; }
    }
}