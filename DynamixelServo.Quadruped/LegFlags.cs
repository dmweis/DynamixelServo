﻿using System;

namespace DynamixelServo.Quadruped
{
    [Flags]
    enum LegFlags
    {
        LeftFront = 1,
        RightFront = 2,
        LeftRear = 4,
        RightRear = 8,
        All = LeftFront | RightFront | LeftRear | RightRear,
        Front = LeftFront | RightFront,
        Rear = LeftRear | RightRear,
        Right = RightFront | RightRear,
        Left = LeftFront | LeftRear
    }
}
