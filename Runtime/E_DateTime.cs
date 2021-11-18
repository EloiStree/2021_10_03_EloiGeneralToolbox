using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi { 
public class E_DateTime 
{
    public static void GetTimeOfDayAsDateTime(out DateTime date, in int hours = 0, in int minutes = 0, in int seconds = 0, in int milliseconds = 0)
    {
        DateTime now = DateTime.Now;
        date = new DateTime(now.Year, now.Month, now.Day, hours, minutes, seconds, milliseconds);

    }

    public static void IsBetween(in DateTime time, in DateTime start, in DateTime end, out bool isBetween) => isBetween = (time >= start && time <= end);
    
}

}