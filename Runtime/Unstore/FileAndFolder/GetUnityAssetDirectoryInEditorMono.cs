using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eloi
{
    public class GetUnityAssetDirectoryInEditorMono : AbstractMetaAbsolutePathDirectoryMono
    {
        public override void GetPath(out string path)
        {
            path = Directory.GetCurrentDirectory() + "\\Assets";
        }

        public override string GetPath()
        {
            GetPath(out string t);
            return t;
        }

       
    }
}
