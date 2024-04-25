﻿using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;


public static class Helpers
{
    public static float Map(float value, float originalMin, float originalMax, float newMin, float newMax, bool clamp)
    {
        // float val = min2 + (max2 - min2) * ((value - min1) / (max1 - min1));
        float newValue = (value - originalMin) / (originalMax - originalMin) * (newMax - newMin) + newMin;
        if (clamp)
        {
            newValue = Mathf.Clamp(newValue, newMin, newMax);
        }

        return newValue;
    }
}