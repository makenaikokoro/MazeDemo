using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
    
    public MazeWall wallPrefab;
    public MazeWall[,] walls;
    public Position mazeSize;           // 迷宫大小
    private  int enterX, enterY;    // 入口坐标
    private  int endX, endY;              // 出口坐标

    public void Init()
    {
        if (mazeSize.x % 2 == 0 || mazeSize.y % 2 == 0)
        {
            UnityEditor.EditorUtility.DisplayDialog("错误警告", "输入的数值必须为奇数！", "确定");
            return;
        }

        walls = new MazeWall[mazeSize.x, mazeSize.y];          
        for (int x = 0; x < mazeSize.x; x++)
        {
            for (int y = 0; y < mazeSize.y; y++)
            {
                if (IsWall(x, y))
                {
                    CreateWall(new Position(x, y));
                }
                //walls[x, y].IsVisited = false;
            }
        }
        // 设置出入口
        FindEnterEndPoint();
    }

	private bool IsWall(int x, int y)
    {
        return (x % 2 == 0 || y % 2 == 0) ? true : false;        
    }

    private void CreateWall(Position coordinate)
    {
        MazeWall newWall = Instantiate(wallPrefab) as MazeWall;
        walls[coordinate.x, coordinate.y] = newWall;
        newWall.Coordinate = coordinate;
        newWall.name = "Maze-" + coordinate.x + "," + coordinate.y;
        newWall.transform.parent = transform;
        newWall.transform.localPosition = new Vector3(coordinate.x, coordinate.y, 0);
    }

    private void FindEnterEndPoint()
    {
        enterX = 0;
        enterY = mazeSize.y - 2;
        endX = mazeSize.x - 1;
        endY = 1;
        if(walls[enterX, enterY].gameObject != null)
        {
            Destroy(walls[enterX, enterY].gameObject);
        }
        if(walls[endX, endY].gameObject != null)
        {
            Destroy(walls[endX, endY].gameObject);
        }       
    }

    public bool IsInArea(Position coordinate)
    {
        return (coordinate.x >= 0 && coordinate.y >= 0) && (coordinate.x < mazeSize.x && coordinate.y < mazeSize.y);
    }
}
