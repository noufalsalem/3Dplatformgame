using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Renderer rd;
    [SerializeField] GameManager gm;
    [SerializeField] int damage = 15; //HP decrease value
    [SerializeField] int scoreValue = 5; //score decrease value
    public AudioSource blipSFX;
    


    private void Start()
    {
        rd = GetComponent<Renderer>();
        
        blipSFX = GameObject.Find("EnemyBlip").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if enemy collided with player
        if (other.gameObject.name == "Player")
        {
            //play sound
            blipSFX.Play();
            //remove enemy
            Destroy(this.gameObject);
            //decrease HP
            GameManager.GetInstance().TakeDamage(damage, scoreValue);
            
            
            
        }
        
    }
}
