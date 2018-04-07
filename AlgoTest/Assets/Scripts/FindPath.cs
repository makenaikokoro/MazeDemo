using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour {

    public static int[,] dir = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // 四个方向

    public static bool FindPathFunc(MazeWall mWall)
    {
        int posX, posY;

        //提取mWall的坐标并在求解迷宫访问过程中标记该坐标
        posX = mWall.Coordinate.x;
        posY = mWall.Coordinate.y;
        mWall.IsFindPathVisited = true;

        //如果该点是合法的，将其标记为正确路径
        if (IsCoordinateInArea(mWall.Coordinate.x, mWall.Coordinate.y))
            mWall.IsRightPath = true;

        //如果该点恰好是终点则返回true
        if(posX == Common.SizeX - 1 && posY == 1)
        {
            return true;
        }
        //循环试探该点周围的四点点
        for(int i = 0; i < 4; i++)
        {
            int newX = posX + dir[i,0];
            int newY = posY + dir[i,1];
            //如果试探的店合法且是一条路径且没有在求解访问中访问过
            if(IsCoordinateInArea(newX, newY))
            {
                MazeWall newWall = Common.Walls[newX, newY];
                if(newWall.IsPath && !newWall.IsFindPathVisited)
                {
                    //在新的点递归调用本函数，如果一直没有返回false，则最终返回true
                    if (FindPathFunc(newWall))
                    {
                        return true;
                    }
                }
            }
        }
        //否则，将该点的“正确路径”的标记取消并返回false
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
