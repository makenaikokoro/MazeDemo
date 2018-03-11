using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBFS : MonoBehaviour {

	enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

    public List<MazeWall> wallList = new List<MazeWall>();

    public void RandomBFSFun(MazeWall mWall)
    {
        MazeWall first = mWall;
        wallList.Add(first);
        first.IsVisited = true;
    }
}
