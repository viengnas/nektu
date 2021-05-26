using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuUiScore;
    private float musicVolume = 1f;
    private AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseMenuUiScore.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseMenuUiScore.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }



}
