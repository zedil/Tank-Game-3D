using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthInfo : MonoBehaviour
{
    public Text healthText;
    private float health=100;
    public Image healthBar;

    public void TakeDamage(int amount)
    {
        if(health < amount) return;

        health -= amount;
        healthText.text = health.ToString();

        // maksimum 100 olduğu için 100e bölündü
        healthBar.fillAmount = health/100f;
        
    }


}
