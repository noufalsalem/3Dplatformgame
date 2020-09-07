using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] Renderer rd;
    [SerializeField] GameManager gm;
    [SerializeField] int potionHP = 15;
    public AudioSource potionSound;

    private void Start()
    {
        rd = GetComponent<Renderer>();
        potionSound = GameObject.Find("PotionSound").GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            
            //remove potion
            Destroy(this.gameObject);
            //add to health
            GameManager.GetInstance().PotionHPUpdate(potionHP);

            if (GameManager.GetInstance().currentHealth < 85)
            {
                //play sound
                potionSound.Play();
            }
        }
    }
}
