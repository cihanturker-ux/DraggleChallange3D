using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField] private GameObject swipeToPlay;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private Slider feverBar;

    private bool isLerping = false;
    private float lerpDuration = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (GameManager.hasGameStarted)
        {
            GameStarted();
        }
    }

    public void GameStarted()
    {
        swipeToPlay.SetActive(false);
    }

    public void SettingsButtonClicked()
    {
        settingsButton.SetActive(false);
        settingsPanel.SetActive(true);

        Time.timeScale = 0;
    }

    public void SettingsPanelCloseButtonClicked()
    {
        settingsPanel.SetActive(false);
        settingsButton.SetActive(true);
        
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        restartButton.SetActive(true);
    }

    public void LevelCompleted()
    {
        nextLevelPanel.SetActive(true);
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void UpdateFeverBar(int value, int requiredValue)
    {
        StartCoroutine(UpdateFeverValueSmoothly(value, requiredValue));
    }

    public void ResetFeverBar()
    {
        feverBar.value = 0f;
    }

    IEnumerator UpdateFeverValueSmoothly(int value, int requiredValue)
    {
        /*float targetValue = (float) value / requiredValue;
        float duration = 1f;
        float time = duration;
        while (time >= 0f)
        {
            time -= Time.deltaTime;
            feverBar.value = Mathf.Lerp(feverBar.value, targetValue, time / duration);
            yield return null;
        }*/
        
        /*float targetValue = (float) value / requiredValue;
        
        while (feverBar.value < targetValue)
        {
            feverBar.value = Mathf.Lerp(feverBar.value, targetValue, Time.deltaTime);
            yield return null;
        }*/
        Debug.Log("update");
        isLerping = true;
        float timeStartedLerping = Time.time;
        float startingValue = (float) (value - 1) / requiredValue;
        float targetValue = value / requiredValue;
        
        while (isLerping)
        {
            float timeSinceStarted = Time.time - timeStartedLerping;
            float percentageComplete = timeSinceStarted / lerpDuration; 
            Debug.Log("aaa", gameObject);
            feverBar.value = Mathf.Lerp(startingValue, targetValue, percentageComplete);
            yield return null;
            
            if (percentageComplete >= 1.0f)
            {
                isLerping = false;
            }
        }
    }
}
