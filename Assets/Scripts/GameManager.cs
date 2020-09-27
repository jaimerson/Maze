using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Maze mazePrefab;
    private Maze maze;
    // Start is called before the first frame update
    void Start()
    {
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        this.maze = Instantiate(mazePrefab) as Maze;
        maze.Generate();
    }

    private void RestartGame()
    {
        Destroy(this.maze.gameObject);
        BeginGame();
    }
}
