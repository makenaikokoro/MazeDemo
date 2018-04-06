using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
    
    public MazeWall wallPrefab;    
    //public MazeWall[,] walls;
    private  int enterX, enterY; // 入口坐标
    private  int endX, endY; // 出口坐标

    public void Init()
    {
        if (Common.SizeX % 2 == 0 || Common.SizeY % 2 == 0)
        {
            UnityEditor.EditorUtility.DisplayDialog("错误警告", "输入的数值必须为奇数！", "确定");
            return;
        }

        Common.Walls = new MazeWall[Common.SizeX, Common.SizeY];          
        for (int x = 0; x < Common.SizeX; x++)
        {
            for (int y = 0; y < Common.SizeY; y++)
            {
                CreateWall(new Position(x, y));
                if (!IsWall(x, y))
                {
                    CreatePath(Common.Walls[x, y]);
                }

                Common.Walls[x, y].IsVisited = false;
                Common.Walls[x, y].IsRightPath = false;
            }
        }        
        // 设置出入口
        FindEnterEndPoint();

        //Common.Walls = walls;
    }

    public void Create()
    {
        RandomBFS.RandomBFSFunc(Common.Walls[enterX + 1, enterY]);
    }

    private bool IsWall(int x, int y)
    {
        return (x % 2 == 0 || y % 2 == 0) ? true : false;        
    }

    private void CreateWall(Position coordinate)
    {
        MazeWall newWall = Instantiate(wallPrefab) as MazeWall;
        Common.Walls[coordinate.x, coordinate.y] = newWall;
        newWall.Coordinate = coordinate;
        newWall.name = "Maze-" + coordinate.x + "," + coordinate.y;
        newWall.transform.parent = transform;
        newWall.transform.localPosition = new Vector3(coordinate.x, coordinate.y, 0);
    }

    private void CreatePath(MazeWall mWall)
    {
        mWall.IsPath = true;
        mWall.gameObject.SetActive(false);
    }

    private void FindEnterEndPoint()
    {
        enterX = 0;
        enterY = Common.SizeY - 2;
        endX = Common.SizeX - 1;
        endY = 1;
        if(Common.Walls[enterX, enterY].gameObject != null)
        {
            Common.Walls[enterX, enterY].IsPath = true;
            Common.Walls[enterX, enterY].gameObject.SetActive(false);
        }
        if(Common.Walls[endX, endY].gameObject != null)
        {
            Common.Walls[endX, endY].IsPath = true;
            Common.Walls[endX, endY].gameObject.SetActive(false);
        }       
    }        

    public void DrawRedPath()
    {
        if(!FindPath.FindPathFunc(Common.Walls[enterX, enterY]))
        {
            UnityEditor.EditorUtility.DisplayDialog("错误警告", "zbd！", "确定");
            return;
        }
        
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
