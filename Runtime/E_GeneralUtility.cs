using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;

namespace Eloi
{
    public class E_GeneralUtility
    {


        public static void GetTimeULongId(in DateTime time, out ulong id)
        {
            string createdDate = time.ToString("yyyy MM dd HH mm ss ffff");
            id = ulong.Parse(createdDate.Replace(" ", ""));
        }

        public static void SetApplicationAsCultureInvariant()
        {
           
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
                CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
            
        }

        public static void GetTimeLongId(out ulong id)
        {
            DateTime n = DateTime.Now;
            GetTimeULongId(in n, out id);
        }

        public static void ListAsQueueInsert<T>(in T value, in int maxCount, ref List<T> list)
        {
            if (list == null)
                return;
            list.Insert(0, value);
            for (int i = 0; i < list.Count-maxCount; i++)
            {
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}