using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class E_ReflectionCS : MonoBehaviour
{



    public static IEnumerable<Type> GetEnumerableOfTypeThroughAssemblies<T>() where T : class
    {
        return GetEnumerableOfTypeInAssemblies<T>(AppDomain.CurrentDomain.GetAssemblies());
    }
    public static IEnumerable<Type> GetEnumerableOfTypeInAssemblies<T>(params Assembly [] assemblies) where T : class
    {
        return assemblies
                       .SelectMany(assembly => assembly.GetTypes())
                       .Where(type => type.IsSubclassOf(typeof(T)));
    }
   

}
