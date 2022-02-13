using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllers : MonoBehaviour
{

    public int lives = 3;

    [SerializeField]
    private Text livesText;

    int numOfBricks;
    [SerializeField]
    private Text bricksText;

    
    public GameObject gameOverUI;

    bool gameOver;

    public object scene { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        livesText.text = "Lives: " + lives.ToString();
        numOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        Debug.Log("Number Of Bricks: " + numOfBricks.ToString());
        bricksText.text = "Bricks: " + numOfBricks.ToString();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.anyKeyDown)
        {
            Restart();
        }
    }

    public void LoseLive()
    {
        lives--;
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
            GameOver();
    }

    void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;//pause the game ;1f= normal motion ;<1f slow motion ;>1f faster speed

    }

    public void HitBrick()
    {
        numOfBricks--;
        bricksText.text = "Bricks: " + numOfBricks.ToString();
        if (numOfBricks <= 0)
            Invoke("NextLevel", 2f);

    }
    void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sname = "Level02";
        if (scene.name=="Level02")
            sname = "Level03";
        if (scene.name == "Level03")
            sname = "Level04";
        if (scene.name == "Level04")
            sname = "Level05";

        SceneManager.LoadScene(sname);
    }
    void Restart()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1f;
    }
}
