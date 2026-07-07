using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text levelText;

    [Header("Settings")]
    public int pointsToLevelUp = 50;

    private int score = 0;
    private int level = 1;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddPoints(int points)
    {
        score += points;

        Dot[] remainingDots = FindObjectsByType<Dot>(FindObjectsSortMode.None);
        if (remainingDots.Length == 0)
        {
            if (GameAudioManager.Instance != null)
                GameAudioManager.Instance.PlayLevelComplete();

            GameManager.Instance.LoadNextLevel();
        }

        if (score >= level * pointsToLevelUp)
            LevelUp();

        UpdateUI();
    }

    void LevelUp()
    {
        level++;
        EnemyAI enemy = FindFirstObjectByType<EnemyAI>();
        if (enemy != null)
            enemy.moveSpeed += 0.5f;
        UpdateUI();
    }

    public int GetLevel() { return level; }
    public int GetScore() { return score; }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        if (levelText != null)
            levelText.text = "Level: " + level;
    }
}