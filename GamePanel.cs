using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private Text level;
    [SerializeField] private Text time;
    [SerializeField] private GameObject winPanel;
    private DataTimeLevel data = new DataTimeLevel();

    private void Start()
    {
        data = JsonUtility.FromJson<DataTimeLevel>(PlayerPrefs.GetString("TimeLevel"));
        Time.timeScale = 1;
        Player.win.AddListener(OpenWinPanel);
    }

    private void OpenWinPanel()
    {
        winPanel.SetActive(true);
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("OpenLevels")) PlayerPrefs.SetInt("OpenLevels", SceneManager.GetActiveScene().buildIndex);
        if (data.timeLevel[SceneManager.GetActiveScene().buildIndex - 2] > (int)Time.timeSinceLevelLoad) data.timeLevel[SceneManager.GetActiveScene().buildIndex - 2] = (int)Time.timeSinceLevelLoad;
        Time.timeScale = 0;
    }

    void Update()
    {
        level.text = "Level " + (SceneManager.GetActiveScene().buildIndex - 1);
        time.text = "Time: " + Time.timeSinceLevelLoad.ToString("000");
    }

    public void RestartLevel()
    {
        Ads.ShowAds();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        Ads.ShowAds();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnDestroy()
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("TimeLevel", json);
    }
}