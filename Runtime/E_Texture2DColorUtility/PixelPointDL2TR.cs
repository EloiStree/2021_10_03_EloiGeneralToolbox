using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PixelPointDL2TR
{
    public int m_x;
    public int m_y;



    public PixelPointDL2TR(int x, int y)
    {
        m_x = x;
        m_y = y;
    }
    public PixelPointDL2TR(PixelPointDL2TR source)
    {
        m_x = source.m_x;
        m_y = source.m_y;
    }



    public int Get1D(in int arrayWidth)
    {
        return arrayWidth * m_y + m_x;
    }
    public void Set1D(in int index, in int width)
    {
        m_x = index % width;
        m_y = (int)(index / (float)width);
    }
    public void Set(int x, int y)
    {
        m_x = x;
        m_y = y;
    }

    public void Set(in PixelPointDL2TR point)
    {
        m_x = point.m_x;
        m_y = point.m_y;
    }
}
public class PixelPointUtility
{
    public static void GetRightOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_x += 1;
    }
    public static void GetLeftOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_x -= 1;
    }
    public static void GetDownOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_y -= 1;
    }
    public static void GetUpOf(in PixelPointDL2TR cursor, ref PixelPointDL2TR nextPoint)
    {
        nextPoint.Set(in cursor);
        nextPoint.m_y += 1;
    }
}