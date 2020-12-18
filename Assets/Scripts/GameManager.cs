using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Maze mazePrefab;
    private Maze maze;
    public Text text;
    public Text level;
    public CameraFollow camera;
    public int initialSeconds;
    public int secondsLeft;
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        secondsLeft = initialSeconds;
        level.text = "Level: " + currentLevel;
        StartCoroutine(timer());
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = secondsLeft.ToString();
    }

    private IEnumerator timer()
    {
        while (true)
        {
            secondsLeft -= 1;

            if (secondsLeft <= 0)
            {
                RestartGame();
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void NextLevel()
    {
        EndGame();
        secondsLeft += this.maze.size.x * 2;
        currentLevel += 1;
        level.text = "Level: " + currentLevel;

        IntVector2 nextSize = this.maze.size + new IntVector2(1, 1);
        this.maze = Instantiate(mazePrefab) as Maze;
        maze.game = this;
        maze.camera = camera;
        maze.size = nextSize;
        maze.Generate();
    }

    private void BeginGame()
    {
        this.maze = Instantiate(mazePrefab) as Maze;
        maze.game = this;
        maze.camera = camera;
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
        currentLevel = 1;
        secondsLeft = initialSeconds;
        BeginGame();
    }
}
