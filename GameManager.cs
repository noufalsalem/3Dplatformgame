using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Score variables
    [SerializeField] public int score = 0;
    [SerializeField] public TMPro.TextMeshProUGUI scoreText;
    //Health Variables
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentHealth;
    public HealthBar healthBar;
    //Lives variables
    [SerializeField] public Image[] hearts; //hearts as lives
    [SerializeField] public Sprite fullHeart;
    [SerializeField] public Sprite emptyHeart;
    [SerializeField] public int lives = 5;
    [SerializeField] public int numOfLives = 5;

    //[SerializeField] GameObject Player;

    // respawn variables
    [SerializeField] Transform player;
    [SerializeField] Transform respawnPt;

    static GameManager instance; //The OG 

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        
    }

    public void Start()
    {
        if (healthBar == null)
        {
            healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        }
        
        //Player = GameObject.Find("Player").GetComponent<GameObject>();
        if (scoreText == null)
        {
            scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        }

        //healthbar start value
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        respawnPt = GameObject.FindWithTag("RespawnPt").GetComponent<Transform>();
        
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();



    }

    void OnDestroy()
    {
        Debug.Log("GameManager has been destroyed.");
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfLives)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }

        //Find new respawn point After load scene
        if (respawnPt == null)
        {
            respawnPt = GameObject.FindWithTag("RespawnPt").GetComponent<Transform>();
        }
    }

    public void TakeDamage(int damage, int scoreValue)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        //decrease score
        if (score >= scoreValue)
        {
            score -= scoreValue;
            scoreText.text = score.ToString();
        } 
        
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        
    }

    public void UpdateLives()
    {
        if (lives <= numOfLives && lives > 1)
        { 
            lives--;
            // -- respawn --
            player.transform.position = respawnPt.transform.position;
            Physics.SyncTransforms();
            

        } else if (lives == 1)
        {
            SceneManager.LoadScene("Game_Over");
        }
        
    }

    public void PotionHPUpdate(int potionHP)
    {
        if (currentHealth < 85 && currentHealth > 0)
        {
            currentHealth += potionHP;
            healthBar.SetHealth(currentHealth);
        }
        
    }

    
    public void SetScoreText(TextMeshProUGUI aScoreText)
    {
        scoreText = aScoreText;
        scoreText.text = score.ToString();
        Debug.Log("Score not found");
    }

    public void MaintainHealthBar(HealthBar hb)
    {
        healthBar = hb;
    }

    public void SetRespawns(Transform respawn, Transform chr)
    {
        //respawnPt.transform.position = respawn.transform.position;
        respawnPt = respawn;
        player = chr;
        
    }

    
}
