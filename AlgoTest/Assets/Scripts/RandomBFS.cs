using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBFS : MonoBehaviour {

    public static int[,] dir = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // 四个方向
        
    public static List<MazeWall> wallList = new List<MazeWall>();

    public static void RandomBFSFunc(MazeWall iWall)
    {
        wallList.Add(iWall);
        iWall.IsVisited = true;

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
                
                if (IsInArea(newPos))
                {
                    MazeWall nWall = Common.Walls[newPos.x, newPos.y];
                    if (!nWall.IsVisited)
                    {
                        wallList.Add(nWall);
                        nWall.IsVisited = true;
                        SetPath(curWall.Coordinate.x + dir[i, 0], curWall.Coordinate.y + dir[i, 1]);
                    }       
                }
            }
        }
    }

    private static bool IsInArea(Position coordinate)
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
            Common.Walls[coordinate.x, coordinate.y].gameObject.SetActive(false);
        }
    }
}
