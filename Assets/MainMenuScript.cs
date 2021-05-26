using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    static public float musicVolume = 1f;
    public Slider mSlider;
    static bool isSliderset = false;
    private void Awake()
    {
        if (isSliderset == false)
        {
            mSlider.value = PlayerPrefs.GetFloat("VolumeSlider");
            isSliderset = true;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
        
    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayLevel2()
    {
        if (PlayerPrefs.GetString("Stage2") == "true")
            SceneManager.LoadScene(2);
        else
        {
            Debug.Log("play audio hereeeeeeeeee (yra resources aplanke)");
        }
            
    }
    public void PlayLevel3()
    {
        if(PlayerPrefs.GetString("Stage3") == "true")
            SceneManager.LoadScene(3);
        else
            Debug.Log("play audio here (yra resources aplanke)");
    }
    public void PlayLevel4()
    {
        if(PlayerPrefs.GetString("Stage4") == "true")
            SceneManager.LoadScene(4);
        else
            Debug.Log("play audio here (yra resources aplanke)");
    }
    public void SetVolume(float vol)
    {
        PlayerPrefs.SetFloat("VolumeSlider", vol);
        //Debug.Log(musicVolume);
    }
}