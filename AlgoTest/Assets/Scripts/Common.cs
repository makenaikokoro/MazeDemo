using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 管理全局变量
public class Common {

    private int _sizeX, _sizeY;
    private MazeWall[,] _walls;

    public static int SizeX { get; set; }
    public static int SizeY { get; set; }
    public static MazeWall[,] Walls { get; set; }
}
