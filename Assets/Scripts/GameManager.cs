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

    public void NextLevel()
    {
        EndGame();

        IntVector2 nextSize = this.maze.size + new IntVector2(1, 1);
        this.maze = Instantiate(mazePrefab) as Maze;
        maze.game = this;
        maze.size = nextSize;
        maze.Generate();
    }

    private void BeginGame()
    {
        this.maze = Instantiate(mazePrefab) as Maze;
        maze.game = this;
        maze.Generate();
    }

    private void EndGame()
    {
        this.maze.Reset();
        Destroy(this.maze.gameObject);
    }

    private void RestartGame()
    {
        EndGame();
        BeginGame();
    }
}
