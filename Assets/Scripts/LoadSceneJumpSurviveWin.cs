using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneJumpSurviveWin : MonoBehaviour
{
    [Header("Настройки даты и сцены")]
    public int year = 2025;
    public int month = 10;
    public int day = 25;
    public string sceneName;

    private static LoadSceneJumpSurviveWin _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CheckAndTriggerSceneLoadJumpSurviveWin();
    }

    private void CheckAndTriggerSceneLoadJumpSurviveWin()
    {
        DateTime today = DateTime.Now.Date; // Берём только дату, без времени
        DateTime target = new DateTime(year, month, day);

        Debug.Log($"[DateSceneLoader] Сегодня: {today:dd.MM.yyyy}, Цель: {target:dd.MM.yyyy}");

        if (today >= target)
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                Debug.Log($"[DateSceneLoader] Загружается сцена '{sceneName}' по дате {target:dd.MM.yyyy}");
                PlayerPrefs.SetInt($"SceneLoaded_{sceneName}", 1);
                PlayerPrefs.Save();
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogWarning("[DateSceneLoader] Не указано название сцены для загрузки.");
                Screen.orientation = ScreenOrientation.LandscapeLeft;
            }
        }
        else
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}