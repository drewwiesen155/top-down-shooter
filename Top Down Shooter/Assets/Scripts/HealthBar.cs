using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Slider hpBar;
    public Gradient grad; //Wont work for some reason

   public void setHealth(int health)
    {
        hpBar.value = health;
    }

    public void setMaxHealth(int maxHp)
    {
        hpBar.maxValue = maxHp;
        hpBar.value = maxHp;
    }
}
