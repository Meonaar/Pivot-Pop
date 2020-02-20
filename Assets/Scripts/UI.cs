using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public PlayerMovement pm;
    public GameObject gameOverMenu;
    public GameObject scoreMenu;

    public Text scoreText;
    public Text scoreTextGameOver;
    // Start is called before the first frame update

    void Start()
    {
        scoreText.text = "0";
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = pm.score.ToString("0");
        scoreTextGameOver.text = scoreText.text;

        if (pm == null)
        {
            gameOverMenu.SetActive(true);
            scoreMenu.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
