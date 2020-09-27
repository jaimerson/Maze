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
    public int initialSeconds;
    private int secondsLeft;
    private int currentLevel;
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

        if (secondsLeft <= 0)
        {
            RestartGame();
        }
    }

    private IEnumerator timer()
    {
        while (true)
        {
            secondsLeft -= 1;
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
