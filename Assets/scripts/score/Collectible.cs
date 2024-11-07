using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameController gameController;
    private AudioSource  audioSource;
    void Start()
    {   
        audioSource = GameObject.Find("Sonido moneda").GetComponent<AudioSource>();
        gameController = FindObjectOfType<GameController>();
    }
     
    void Collect()      
    {    
        audioSource.Play(); 
        gameController.AddScore(50);
        
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
       Collect();  
      }  
    } 
}
