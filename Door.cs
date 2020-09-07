using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    public AudioSource win;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        win = GameObject.Find("LevelWin").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            win.Play();
            anim.SetBool("canLeave", true);
        }
    }
}
