using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives = 3;

    [HideInInspector] public int score;
    [HideInInspector] public int highScore;


    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject statsPanel;

    [SerializeField] private TMP_Text livesTxt;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text highScoreTxt;
    [SerializeField] private TMP_Text gameOverScoreTxt;


    

#region SINGLETON
    public static GameManager instance;
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    #endregion


    void Start() 
    {
        gameOverScreen.SetActive(false);
        statsPanel.SetActive(true);

        score = 0;

        if (highScoreTxt != null)
        {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreTxt.text = "Best: " + highScore.ToString();
        }
    }

    void Update()
    {
        if(lives <= 0) {
            GameOver();
        }

        if (livesTxt != null)
        {
            livesTxt.text = lives.ToString();
        }
        if (scoreTxt != null)
        {
            scoreTxt.text = score.ToString();
        }
    }


    public void GameOver()
    {
        // show gameover screen
        gameOverScreen.SetActive(true);
        statsPanel.SetActive(false);

        // set new high score.
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreTxt.text = "Best: " + highScore.ToString();
        }

        gameOverScoreTxt.text = "You scored: " + score.ToString();
    }

    public void RetryLoop() 
    {
        // start this specific loop again
    }

    public void LoadScene(int sceneIndex)
    {
        Time.timeScale = 1.00f;
        // restarts game from the beginning
        SceneManager.LoadScene(sceneIndex);
    }

}
