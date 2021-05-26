using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemPick : MonoBehaviour
{
    public int itemAmount = 0;
    public int nextStage = 0;
    public Text scoreText;

    public GameObject MenuDeath;
    int priesBattleKnyguskaicius = 0;
    bool knygoscalculated = false;
    bool bossstatus = false;
    public Animator animator;
    public AudioSource audioSrc;
    int counter = 0;

    private void Awake()
    {
        audioSrc.GetComponent<AudioSource>();
        audioSrc.volume = PlayerPrefs.GetFloat("VolumeSlider");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.name.Contains("item"))
        {
            itemAmount++;
            scoreText.text = itemAmount.ToString();
            Destroy(collision.gameObject);
        }

        else if(collision.name.Contains("death"))
        {
           MenuDeath.SetActive(true);
           Time.timeScale = 0f;
        }

        else if (collision.name == "nextlevel")
        {
            nextStage = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetString("Stage" + nextStage, "true");
            PlayerPrefs.Save();
            Debug.Log("saved Stage" + nextStage);
            PlayerPrefs.SetInt("currentScene", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(12);
        }
        else if (collision.name == "nextlevelback")
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentScene") + 1);
        }
    }




    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.E) && bossstatus == false)
        {
            counter++;
            animator.SetTrigger("shot");


            if (counter == 5 && bossstatus == false)
            {
                GameObject boss = GameObject.Find("boss");
                GameObject bossfence = GameObject.Find("bossfence");
                bossstatus = true;
                animator.SetTrigger("dead");
                StartCoroutine(waiter(1, animator));
                Destroy(bossfence);
            }
        }
    }

    IEnumerator waiter(int time, Animator animator)
    {
        yield return new WaitForSeconds(time);
        animator.speed = 0;
    }
}