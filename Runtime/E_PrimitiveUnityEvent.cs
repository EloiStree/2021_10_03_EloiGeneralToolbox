using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    [System.Serializable]
    public class PrimitiveUnityEvent_Short : UnityEvent<short> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_Byte : UnityEvent<byte> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_Int : UnityEvent<int> { }

    [System.Serializable]
    public class PrimitiveUnityEvent_Float : UnityEvent<float> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_Long : UnityEvent<long> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_Doube : UnityEvent<double> { }

    [System.Serializable]
    public class PrimitiveUnityEvent_Bool : UnityEvent<bool> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_String : UnityEvent<string> { }

    [System.Serializable]
    public class PrimitiveUnityEvent_DoubleString : UnityEvent<string, string> { }

    [System.Serializable]
    public class PrimitiveUnityEvent_UShort : UnityEvent<ushort> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_UInt : UnityEvent<uint> { }
    [System.Serializable]
    public class PrimitiveUnityEvent_ULong : UnityEvent<ulong> { }



}