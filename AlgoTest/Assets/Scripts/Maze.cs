using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {
    
    public MazeWall wallPrefab;
    public MazeWall[,] walls;
    public Position mazeSize; // size of maze

    public void Init()
    {
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

    public bool IsInArea(Position coordinate)
    {
        return (coordinate.x >= 0 && coordinate.y >= 0) && (coordinate.x < mazeSize.x && coordinate.y < mazeSize.y);
    }
}
