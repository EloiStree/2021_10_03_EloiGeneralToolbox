using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class E_Texture2DColorUtility
    {
        
        public static void TurnAllFullBlackToTransparent(
            ref Color [] colors)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i].r <= 0.01f
                    && colors[i].g <= 0.01f
                       && colors[i].b <= 0.01f)
                    colors[i].a = 0;
            }

        }

        public static bool IsFullBlackOrTransparent(in Color cropColor, in float errorMargin = 0.01f)
        {
            return (cropColor.a <= errorMargin) || (cropColor.r <= errorMargin
                && cropColor.g <= errorMargin
                && cropColor.b <= errorMargin);
        }

        public static void CropBlackAndTransparent(ref Color[] c, in int sourceWidth, in int sourceHeight,
            out Color[] colorCropped, out int cropWidth, out int cropHeight)
        {
            CropColorsTool.Crop(ref c, in sourceWidth, in sourceHeight, out colorCropped, out cropWidth, out cropHeight);
        }
    }
}
