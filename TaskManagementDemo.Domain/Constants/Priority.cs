﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementDemo.Domain.Constants;

public enum Priority : byte
{
    Low = 0,
    Medium = 1,
    High = 2,
    Blocker = 255
}