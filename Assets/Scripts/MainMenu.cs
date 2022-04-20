using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private int _countLevel;
    [SerializeField] private GameObject _settingGameMenu;
    bool _isSetting;
    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _quitButton.onClick.AddListener(()=> { Application.Quit(); });
        _settingsButton.onClick.AddListener(SettingsValue);
        _closeButton.onClick.AddListener(Close);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(_countLevel);
    }

    private void SettingsValue()
    {
        _settingGameMenu.SetActive(true);
        Time.timeScale = 0f;
        _isSetting = true;

    }

    public void Close()
    {
        _settingGameMenu.SetActive(false);// меню паузы не активно 
        Time.timeScale = 1f;// время в нормальном режиме 
        _isSetting = false;
    }

    
}
