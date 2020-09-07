using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField] GameManager gm;
    

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
        //lose life if health reaches 0
        if (slider.normalizedValue <= 0)
        {
            GameManager.GetInstance().UpdateLives();
            GameManager.GetInstance().currentHealth = GameManager.GetInstance().maxHealth;
            SetMaxHealth(GameManager.GetInstance().maxHealth);
        }
    }
}
