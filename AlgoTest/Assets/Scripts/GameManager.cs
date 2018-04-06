using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Maze mazePrefab;
    private Maze mazeInstance;

    public int sizeX, sizeY; // 迷宫大小

    void Start()
    {
        MazeGenerate();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
    }

    void MazeGenerate()
    {
        Common.SizeX = sizeX;
        Common.SizeY = sizeY;
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Init();
        mazeInstance.Create();
    }

    void Restart()
    {
        Destroy(mazeInstance.gameObject);
        MazeGenerate();
    }

    void OnFindPathButtonClick()
    {
        mazeInstance.DrawRedPath();
    }
}
