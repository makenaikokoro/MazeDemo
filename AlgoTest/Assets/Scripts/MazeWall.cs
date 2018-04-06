using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWall : MonoBehaviour {
    
    private bool _isVisited;
    private bool _isPath;           //是路径（非墙）
    private Position _coordinate;
    private bool _isRightPath;      //是否为找到的路径
    private bool _isFindPathVisited;

    public bool IsVisited { get; set; }
    public bool IsPath { get; set; }
    public Position Coordinate { get; set; }
    public bool IsRightPath { get; set; }
    public bool IsFindPathVisited { get; set; }
    
}
