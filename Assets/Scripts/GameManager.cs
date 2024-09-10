
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerScore = 0;
    public int winScore1 = 100;
    public int winScore2 = 300;
    public int winScore3 = 600;
    public int playerDeaths = 0;
    private float elapsedTime = 0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deathsText;
    public TextMeshProUGUI timeText;
    public GameObject uiCanvas;
    public GameObject winScreen;
    public GameObject deathScreen;
    public GameObject endScreen;
    //private bool uiInitialized = false;
    private bool hasWon = false;
    private bool hasWon2 = false;
    private bool hasWon3 = false;
    private bool hasDied = false;

    void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateUIState();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateUIState();
        if (scoreText != null) scoreText.text = "Kills: " + playerScore;
        if (deathsText != null) deathsText.text = "Lives Lost: " + playerDeaths;
        if (timeText != null) timeText.text = "Time: " + Mathf.FloorToInt(elapsedTime);

        if (SceneManager.GetActiveScene().buildIndex == 1 && playerScore >= winScore1 && !hasWon)
        {
            YouWin1();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 && playerScore >= winScore2 && !hasWon2)
        {
            YouWin2();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3 && playerScore >= winScore3 && !hasWon3)
        {
            YouWin3();
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Time.timeScale = 0;
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void AddKill(int kills)
    {
        playerScore += kills;
    }

    public void AddDeath(int deaths)
    {
        playerDeaths += deaths;
        YouLose();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        winScreen.SetActive(false);
        Time.timeScale = 1;
        
    }
    private void YouWin1()
    {
        hasWon = true;
        hasWon2 = false;
        winScreen.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("You Win");
    }

    private void YouWin2()
    {
        
        hasWon2 = true;
        winScreen.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("You Win");
    }

    private void YouWin3()
    {

        hasWon3 = true;
        winScreen.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("You Win");
    }
    private void YouLose()
    {
        hasDied = true;
        deathScreen.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
    void UpdateUIState()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            uiCanvas.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            uiCanvas.SetActive(false);
        }
        else
        {
            uiCanvas.SetActive(true);
        }
    }
    public void GameComplete()
    {
        hasWon = false;
        hasWon2 = false;
        hasWon3 = true;
        endScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}