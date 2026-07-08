using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    public bool isGameOver = false;

    [Header("UI")]
    public GameObject gameOverPanel;
    public GameObject winPanel;

    void Awake()
    {
        // We removed DontDestroyOnLoad. 
        // This allows the Main Menu and Level 1 to each have their own safe GameManager!
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // ==========================================
    // MAIN MENU
    // ==========================================
    public void StartGame()
    {
        Time.timeScale = 1f; // Ensures the game isn't paused from a previous Game Over

        // IMPORTANT: Change "GameLevel" to the exact name of your teammate's Level 1 scene file!
        SceneManager.LoadScene("MainGame");
    }

    // ==========================================
    // LEVEL LOGIC
    // ==========================================
    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log("Game Over!");
    }

    public void WinGame()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log("You Win!");
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextScene);
        else
            WinGame();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}