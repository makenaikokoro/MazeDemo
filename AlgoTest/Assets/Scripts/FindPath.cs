using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour {

    public static int[,] dir = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // 四个方向

    public static bool FindPathFunc(MazeWall mWall)
    {
        int posX, posY;
        if (!RandomBFS.IsInArea(mWall.Coordinate))
        {
            UnityEditor.EditorUtility.DisplayDialog("错误警告", "数！", "确定");
            return;
        }
        posX = mWall.Coordinate.x;
        posY = mWall.Coordinate.y;

        mWall.IsVisited = true;
        mWall.IsRightPath = true;

        if(x == Common.sizeX - 1 && y == 1)
        {
            return true;
        }

        for(int i = 0; i < 4; i++)
        {
            int newX = posX + dir[i][0];
            int newY = posY + dir[i][1];
            MazeWall newWall = Common.Walls[newX, newY];
            if (RandomBFS.IsInArea(newWall.Coordinate) && newWall.IsPath && !newWall.IsVisited)
            {
                if (FindPathFunc(newWall))
                {
                    return true;
                }
            }
        }
        mWall.IsRightPath = false;

        return false;
    }
}
