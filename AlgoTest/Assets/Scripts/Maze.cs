using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
    
    public MazeWall wallPrefab;    
    public MazeWall[,] walls;
    private  int enterX, enterY; // 入口坐标
    private  int endX, endY; // 出口坐标

    public void Init()
    {
        if (Common.SizeX % 2 == 0 || Common.SizeY % 2 == 0)
        {
            UnityEditor.EditorUtility.DisplayDialog("错误警告", "输入的数值必须为奇数！", "确定");
            return;
        }

        walls = new MazeWall[Common.SizeX, Common.SizeY];          
        for (int x = 0; x < Common.SizeX; x++)
        {
            for (int y = 0; y < Common.SizeY; y++)
            {
                CreateWall(new Position(x, y));
                if (!IsWall(x, y))
                {
                    CreatePath(walls[x, y]);
                }
                walls[x, y].IsVisited = false;
                walls[x, y].IsPath = false;
                walls[x, y].IsRightPath = false;
            }
        }
        Common.Walls = walls;
        // 设置出入口
        FindEnterEndPoint();
    }

    public void Create()
    {
        RandomBFS.RandomBFSFunc(walls[enterX + 1, enterY]);
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

    private void CreatePath(MazeWall mWall)
    {
        mWall.gameObject.SetActive(false);
    }

    private void FindEnterEndPoint()
    {
        enterX = 0;
        enterY = Common.SizeY - 2;
        endX = Common.SizeX - 1;
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

    public void DrawRedPath()
    {
        FindPath.FindPathFunc(Common.Walls[enterX, enterY]);

        for (int i = 0; i < Common.SizeX; i++)
        {
            for(int j = 0; j < Common.SizeY; j++)
            {
                if (Common.Walls[i, j].IsRightPath)
                {
                    Common.Walls[i, j].gameObject.SetActive(true);
                    Common.Walls[i, j].gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
    }
}
