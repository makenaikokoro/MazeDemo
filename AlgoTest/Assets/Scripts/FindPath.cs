using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour {

    public static int[,] dir = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // 四个方向

    public static bool FindPathFunc(MazeWall mWall)
    {
        int posX, posY;
        //if (!RandomBFS.IsInArea(mWall.Coordinate))
        //{
        //    UnityEditor.EditorUtility.DisplayDialog("错误警告", "数！", "确定");
        //    return false;
        //}
        posX = mWall.Coordinate.x;
        posY = mWall.Coordinate.y;

        mWall.IsFindPathVisited = true;
        if (IsCoordinateInArea(mWall.Coordinate.x, mWall.Coordinate.y))
            mWall.IsRightPath = true;

        if(posX == Common.SizeX - 1 && posY == 1)
        {
            return true;
        }

        for(int i = 0; i < 4; i++)
        {
            int newX = posX + dir[i,0];
            int newY = posY + dir[i,1];
            if(IsCoordinateInArea(newX, newY))
            {
                MazeWall newWall = Common.Walls[newX, newY];
                if(newWall.IsPath && !newWall.IsFindPathVisited)
                {
                    if (FindPathFunc(newWall))
                    {
                        return true;
                    }
                }
            }
        }
        if (IsCoordinateInArea(mWall.Coordinate.x, mWall.Coordinate.y))
        {
            mWall.IsRightPath = false;
        }        

        return false;
    }

    static bool IsCoordinateInArea(int x,int y)
    {
        return (x >= 0 && y >= 0 && x < Common.SizeX && y < Common.SizeY);
    }
}
