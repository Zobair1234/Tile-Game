using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject song;
    public GameObject gameOver;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameOver.SetActive(true);
            GameManager.Instance.PauseGame();
            GameManager.Instance.gameover=true;
            song.GetComponent<AudioSource>().Stop();
            


        }    
    }
}
