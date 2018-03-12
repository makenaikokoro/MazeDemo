using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBFS : MonoBehaviour {

    public static int[,] dir = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // 四个方向
        
    public static List<MazeWall> wallList = new List<MazeWall>();

    public static void RandomBFSFunc(MazeWall mWall)
    {
        wallList.Add(mWall);
        mWall.IsVisited = true;

        while (wallList.Count != 0)
        {
            int curIndex = Random.Range(0, wallList.Count - 1);
            MazeWall curWall = wallList[curIndex];
            wallList.RemoveAt(curIndex);

            for(int i = 0; i < 4; i++)
            {
                Position newPos;
                newPos.x = curWall.Coordinate.x + dir[i, 0] * 2;
                newPos.y = curWall.Coordinate.y + dir[i, 1] * 2;

                if (mWall.IsInArea() && !mWall.IsVisited)
                {
                    wallList.Add(mWall);
                    mWall.IsVisited = true;

                }
            }
        }
    }
}
