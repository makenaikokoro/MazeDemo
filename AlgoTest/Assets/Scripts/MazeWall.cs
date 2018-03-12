using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWall : MonoBehaviour {
    
    private bool _isVisited;
    private Position _coordinate;

    public bool IsVisited { get; set; }    
    public Position Coordinate { get; set; }

    
}
