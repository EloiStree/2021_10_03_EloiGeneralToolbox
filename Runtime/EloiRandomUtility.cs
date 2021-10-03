using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Eloi { 

    public class UnityRandomUtility 
    {

        public static void GetRandomEuler(out Vector3 random)
        {
            random = new Vector3();
            GetRandom_n180_180(out random.x);
            GetRandom_n180_180(out random.y);
            GetRandom_n180_180(out random.z);
        }
        public static void GetRandomQuaternion(out Quaternion random)
        {
               GetRandomEuler(out Vector3 euleur);
               random = Quaternion.Euler(euleur);
        }

        

        public static void GetRandomDirectionNormalized(out Vector3 random)
        {
            random = new Vector3();
            GetRandom_n1_1(out random.x);
            GetRandom_n1_1(out random.y);
            GetRandom_n1_1(out random.z);
        }
        public static void GetRandom_0_1(out float random) => GetRandomN2M(0f, 1f, out random);
        public static void GetRandom_0_90(out float random) => GetRandomN2M(0f, 90f, out random);
        public static void GetRandom_0_180(out float random) => GetRandomN2M(0f, 180f, out random);
        public static void GetRandom_0_360(out float random) => GetRandomN2M(0f, 360f, out random);
        public static void GetRandom_n1_1(out float random) => GetRandomN2M(-1f, 1f, out random);
        public static void GetRandom_n90_90(out float random) => GetRandomN2M(-90f, 90f, out random);
        public static void GetRandom_n180_180(out float random) => GetRandomN2M(-180f, 180f, out random);
        public static void GetRandom_n360_360(out float random) => GetRandomN2M(-360f, 360f, out random);

        public static void GetRandomN2M(in float n, in float m, out float random) =>
            random = UnityEngine.Random.Range(n, m); 
        public static void GetRandomN2M(in int n, in int m, out int random) =>
         random = UnityEngine.Random.Range(n, m);


        public static void GetRandomOf<T>(out T result, params T[] list)=>
            result = list[UnityEngine.Random.Range(0, list.Length)];
        
        public static void GetRandomOf<T>(out T result, IEnumerable<T> range) =>
        
           GetRandomOf<T>(out result, range.ToArray());
        

        public static void Next<T>(in FairRandom<T> fairRandom, out T result) =>
            fairRandom.GetNext(out result);
        
        public static void ShuffleParams<T>(out T[] result, params T[] toAffect) =>
        
            ShuffleAsNew(in toAffect, out result);
        
        public static void ShuffleRef<T>(ref T[] toAffect)
        {
            int n = toAffect.Length;
            while (n > 1)
            {
                int k = UnityEngine.Random.Range(0, n--);
                T temp = toAffect[n];
                toAffect[n] = toAffect[k];
                toAffect[k] = temp;
            }
        }

        public static void ShuffleAsNew<T>(in T[] given, out T[] result)
        {
            result = given.ToArray();
            ShuffleRef(ref result);
        }
        public static void GetRandomOf(in string text, out char character)
        {
            character = text[UnityEngine.Random.Range(0, text.Length)];
        }
    }



    

   
}
