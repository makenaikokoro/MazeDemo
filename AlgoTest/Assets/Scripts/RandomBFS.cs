using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBFS : MonoBehaviour {

    public static int[,] dir = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // 四个方向
        
    public static RandomQueue<MazeWall> wallList = new RandomQueue<MazeWall>();

    public static void RandomBFSFunc(MazeWall iWall)
    {
        wallList.RandomAdd(iWall);
        iWall.IsVisited = true;

        while (wallList.size() != 0)
        {
            MazeWall curPos = wallList.RandomRemove();           

            for(int i = 0; i < 4; i++)
            {
                Position newPos;
                newPos.x = curPos.Coordinate.x + dir[i, 0] * 2;
                newPos.y = curPos.Coordinate.y + dir[i, 1] * 2;
                
                if (IsInArea(newPos))
                {
                    MazeWall nWall = Common.Walls[newPos.x, newPos.y];
                    if (!nWall.IsVisited)
                    {
                        wallList.RandomAdd(nWall);
                        nWall.IsVisited = true;
                        SetPath(curPos.Coordinate.x + dir[i, 0], curPos.Coordinate.y + dir[i, 1]);
                    }       
                }
            }
        }
    }

    public static bool IsInArea(Position coordinate)
    {
        return (coordinate.x >= 0 && coordinate.y >= 0) && (coordinate.x < Common.SizeX && coordinate.y < Common.SizeY);
    }

    private static void SetPath(int x, int y)
    {
        Position coordinate;
        coordinate.x = x;
        coordinate.y = y;
        if (IsInArea(coordinate))
        {
            Common.Walls[coordinate.x, coordinate.y].IsPath = true;
            Common.Walls[coordinate.x, coordinate.y].gameObject.SetActive(false);
        }
    }
}
