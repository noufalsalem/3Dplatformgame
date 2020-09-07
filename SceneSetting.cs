using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class SceneSetting : MonoBehaviour
{
    [SerializeField] GameManager gm;
    [SerializeField] public TMPro.TextMeshProUGUI scoreText;
    public HealthBar healthBar;
    //public Transform playa;
    //public Transform respawnPoint;
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        //playa = transform.Find("Player").GetComponent<Transform>();
        //respawnPoint = transform.Find("RespawnPoint").GetComponent<Transform>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
        if (gm != null)
        {
            gm.MaintainHealthBar(healthBar);
            gm.SetScoreText(scoreText);
            //gm.SetRespawns(respawnPoint, playa);
            //GameManager.GetInstance().SetRespawns(respawnPoint, playa);
        }
    }
}