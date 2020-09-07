using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    [SerializeField] Renderer rd;
    [SerializeField] GameManager gm;
    [SerializeField] int value = 10;
    public AudioSource successAlert;

    private void Start()
    {
        rd = GetComponent<Renderer>();
        
        successAlert = GameObject.Find("Success").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if collided with player
        if (other.gameObject.name == "Player")
        {
            //play sound
            successAlert.Play();
            //remove diamond
            Destroy(this.gameObject);
            //add to score
            GameManager.GetInstance().UpdateScore(value);
        }
        
    }
}
