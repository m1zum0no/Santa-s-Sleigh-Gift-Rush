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

    // ���������� ��� ���������� UI
    public GameObject continueButton;
    // ... ������ UI ��������

    // ���������� ��� ���������� ���������
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
        // �������������� �������� ��� ����� ����, ��������, ������� UI, ��������� ������ � �.�.
    }

    private void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        // �������������� �������� ��� ������������� ����
    }

    private void ShowAd()
    {
        OnAdClosed();
        // ����� ��� ��� ������ �������
        // ��������, ����� ������ ������ ������� �� ������ ���������� SDK

        // ����� ������ �������, ��������, ��� ����� ����� ����������� ����
        // ��� ����� ������� � �������, ������� ���������� ����� ���������� ������ �������
        // ��������:
        // AdManager.ShowInterstitialAd(OnAdClosed);
    }

    // ���� ����� ����� ������� ����� �������� �������
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
        // ����� ��� ��� ������������� ����, ��������, �������� ����������� ������
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
        // ���������� ��������� ������
        currentLevel = level;
        score = newScore;
        // ���������� ������ � ���������� ������
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetInt("Score", score);
    }

    public void LoadProgress()
    {
        // �������� ���������
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        score = PlayerPrefs.GetInt("Score", 0);

        // ���������� ��������� ������ "����������"
        continueButton.SetActive(currentLevel > 0);
    }

    public void UpdateUI()
    {
        // ���������� UI � ����������� �� ��������� ����
    }

    // ������ �������, ��������, ��� ���������� ������
}