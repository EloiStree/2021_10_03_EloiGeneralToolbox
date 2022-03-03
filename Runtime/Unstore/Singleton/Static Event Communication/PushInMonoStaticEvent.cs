
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public  class PushInMonoStaticEvent : MonoBehaviour
    {
        public  void NotifyEveryWhere(string eventId)
        {
            MonoStaticEvent.NotifyEveryWhere(eventId);
        }
        public  void NotifyEveryWhere(Eloi.StringIdScriptable eventId)
        {
            MonoStaticEvent.NotifyEveryWhere(eventId);
        }

    }
}
