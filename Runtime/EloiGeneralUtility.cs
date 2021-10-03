using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class EloiGeneralUtility
    {


        public static void GetTimeULongId(in DateTime time, out ulong id)
        {
            string createdDate = time.ToString("yyyy MM dd HH mm ss ffff");
            id = ulong.Parse(createdDate.Replace(" ", ""));
        }
        public static void GetTimeLongId(out ulong id)
        {
            DateTime n = DateTime.Now;
            GetTimeULongId(in n, out id);
        }


    }
}