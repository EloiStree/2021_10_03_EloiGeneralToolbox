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

        public static void DrawLine(ref Color[] color, 
            int x1, int y1,
            int x2, int y2, in Color drawColor, 
            in int textureWidth)
        {
            float xPix = x1;
            float yPix = y1;

            float width = x2 - x1;
            float height = y2 - y1;
            float length = Mathf.Abs(width);
            if (Mathf.Abs(height) > length)
                length = Mathf.Abs(height);
            int intLength = (int)length;
            float dx = width / (float)length;
            float dy = height / (float)length;
            for (int i = 0; i <= intLength; i++)
            {
                int index = ((int)yPix) * (textureWidth) + (int)xPix;
                if (index >= 0 && index < color.Length) { 
                    color[index] = drawColor;
                }

                xPix += dx;
                yPix += dy;
            }
        }


        public static int Get1DIndex(in int x, in int y, in int width)
        {
            return y * width + x;
        }
    }
}
