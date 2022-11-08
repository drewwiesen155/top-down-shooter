using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    public int weaponDamage = 1;
    public float weaponRateOfFire = .25f;

    public float scoreMultiplier = 1.0f;
    public float movementMultiplier = 1.0f;

    public int scoreCost = 0;
    public float bulletSpeed = 20.0f;


    public bool canPenetrate = false;
    public int numberOfPellets = 1;
    public int PelletSpread = 0;

    private PlayerMovement playerMovement;
    private Shoot shoot;



    //weapon types - shotgun, sniper, assault rifle, revolver, light machine gun
    //shotgun = low damage per pellet, but a lot of pellets
    //sniper = long range, high damage, can penetrate multiple enemies, low rate of fire
    //assault rifle = basic gun, moderate damage, moderate rate of fire
    //revolver = high damage, very low rate of fire, score multiplier for use
    //light machine gun, high damage, high rate of fire, slows movement speed

    //Shoot has
    //public float bulletSpeed = 20f;
    //private float fireRate = .25f;

    //Enemy Line 53 is where I go to add bullet damage
    //Move speed is in move speed

    //gonna focus on fireRate and Damage first

    //I think if bullet holds bulletspeed and weapon damage it'll be easiest
    //Weapon will hold ROF score, move, pen, pellets


    public void UpdateWeapon()
    {
        //here I should be able to change damage/bulletspeed/ROF/score multiplier/movement multiplier
        playerMovement.moveSpeed = 5 * movementMultiplier;
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
