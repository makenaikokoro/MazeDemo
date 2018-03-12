﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Maze mazePrefab;
    private Maze mazeInstance;

    public int sizeX, sizeY; // 迷宫大小

    void Start()
    {
        Common.SizeX = sizeX;
        Common.SizeY = sizeY;
        MazeGenerate();
    }

    void MazeGenerate()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Init();
        mazeInstance.Create();
    }
}
