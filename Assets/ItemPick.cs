using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemPick : MonoBehaviour
{
    public int itemAmount = 0;
    public Text scoreText;

    public GameObject MenuPause;
    public GameObject MenuScore;
    public GameObject MenuDeath;

    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.name == "item")
        {
            itemAmount++;
            Destroy(collision.gameObject);
            scoreText.text=itemAmount.ToString();
            
        }

        else if(collision.name == "death")
        {
           MenuDeath.SetActive(true);
           Time.timeScale = 0f;
        }
        
    }

}


