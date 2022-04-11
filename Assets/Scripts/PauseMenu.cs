using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private bool _isPause;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _backButton;

    [SerializeField] private GameObject _pauseGameMenu;


    void Awake()
    {
        _resumeButton.onClick.AddListener(Resume);
        _backButton.onClick.AddListener(LoadMenu);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        _pauseGameMenu.SetActive(false);// ���� ����� �� ������� 
        Time.timeScale = 1f;// ����� � ���������� ������ 
        _isPause = false;
    }

    private void Pause()
    {
       _pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        _isPause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

}
