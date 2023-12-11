using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private bool isGamePaused = false;
    public bool isPlayerWon = false;
    [SerializeField] string[] levels;
    [SerializeField] int levelsArraySize;

    // Переменные для управления UI
    public GameObject continueButton;
    // ... другие UI элементы

    // Переменные для сохранения прогресса
    private int currentLevel = 0;
    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLevelStatus(bool status)
    {
        isPlayerWon = status;
    }
    public void ShowAdAndPauseGame()
    {
        PauseGame();
        ShowAd();
    }
    private void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        // Дополнительные действия для паузы игры, например, скрытие UI, остановка звуков и т.д.
    }

    private void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        // Дополнительные действия для возобновления игры
    }

    private void ShowAd()
    {
        OnAdClosed();
        // Здесь код для показа рекламы
        // Например, вызов метода показа рекламы из вашего рекламного SDK

        // После показа рекламы, возможно, вам нужно будет возобновить игру
        // Это можно сделать в колбэке, который вызывается после завершения показа рекламы
        // Например:
        // AdManager.ShowInterstitialAd(OnAdClosed);
    }

    // Этот метод можно вызвать после закрытия рекламы
    private void OnAdClosed()
    {
        ResumeGame();
        if (isPlayerWon)
        {
            ChangeScene("WinScene");
            AudioManagerScript.Instance.PlaySFX(1);
            if (currentLevel < levelsArraySize - 1)
            {
                currentLevel++;
            }
        }
        else
        {
            ChangeScene("FailureScene");
            AudioManagerScript.Instance.PlaySFX(0);
        }
    }
    private void InitializeGame()
    {
        // Здесь код для инициализации игры, например, загрузка сохраненных данных
        LoadProgress();
        UpdateUI();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SwitchToAvaibleLvl()
    { 
        SceneManager.LoadScene(levels[currentLevel]);
    }

    public void ShowUIElement(GameObject uiElement)
    {
        uiElement.SetActive(true);
    }

    public void HideUIElement(GameObject uiElement)
    {
        uiElement.SetActive(false);
    }

    public void SaveProgress(int level, int newScore)
    {
        // Сохранение прогресса игрока
        currentLevel = level;
        score = newScore;
        // Сохранение данных в постоянную память
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetInt("Score", score);
    }

    public void LoadProgress()
    {
        // Загрузка прогресса
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        score = PlayerPrefs.GetInt("Score", 0);

        // Обновление состояния кнопки "Продолжить"
        continueButton.SetActive(currentLevel > 0);
    }

    public void UpdateUI()
    {
        // Обновление UI в зависимости от состояния игры
    }

    // Другие функции, например, для управления счетом
}