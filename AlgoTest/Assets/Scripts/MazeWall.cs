using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWall : MonoBehaviour {
    
    private bool _isVisited;
    private Position _coordinate;

    public bool IsVisited { get; set; }    
    public Position Coordinate { get; set; }

    public bool IsInArea()
    {
        return (Coordinate.x >= 0 && Coordinate.y >= 0) && (Coordinate.x < Common.SizeX && Coordinate.y < Common.SizeY);
    }
}
