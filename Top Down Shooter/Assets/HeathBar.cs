using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider hpBar;

   public void SetHealth(int health)
    {
        hpBar.value = health;
    }

    public void SetMaxHealth(int maxHp)
    {
        hpBar.maxValue = maxHp;
        hpBar.value = maxHp;
    }
}
