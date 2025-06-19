using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float fireRateTimer = 0;
    private bool isSniper = false;
    private bool isWeaponMaxLevel = false;
    private float curUpgradePriceWeapon = 0;

    [Header("Sound Effect")]
    public AudioSource src;
    public AudioClip soundEffect;

    [Header("Weapon")]
    public bool isAutomatic = false;
    public float damage = 10f;
    public float range = 100f;
    [Range(0.1f, 10)]
    public float fireRate;

    public Camera fpsCam;
    public PlayerLook plLook;
    public ParticleSystem muzzleFlash;
    public GameObject hurtEnemytEffect;
    public GameObject cartridgeInTheWallEffect;
    public GameObject sniperScaleZoomUI;

    [HideInInspector]
    public int curLevel = 0;

    [Header("Damage on Levels")]
    public float dmgLvlOne = 0;
    public float dmgLvlTwo = 0;
    public float dmgLvlThree = 0;

    [Header("Upgrades prices")]
    public float priceLvlOne = 0;
    public float priceLvlTwo = 0;
    public float priceLvlThree = 0;




    // Update is called once per frame
    void Update()
    {
        mouseClickingShootAndSniper(); 
        fireRateTimer += Time.deltaTime;
    }

    public void Shoot()
    {
        if (fireRateTimer > fireRate)
        {
            src.clip = soundEffect;
            src.Play();
            muzzleFlash.Play();

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.takeDamage(getDamage());
                    GameObject hurtImpactGo = Instantiate(hurtEnemytEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(hurtImpactGo, 1f);
                }
                else
                {
                        GameObject hurtWallEffect = Instantiate(cartridgeInTheWallEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        hurtWallEffect.transform.position += hurtWallEffect.transform.forward / 1000;
                }
            }
            fireRateTimer = 0;
        }
    }

    public void Sniper()
    {
        isSniper = !isSniper;

        if (isSniper)
        {
            plLook.xSensitivity = 5f;
            plLook.ySensitivity = 5f;
            fpsCam.fieldOfView = 10;
            sniperScaleZoomUI.SetActive(true);
        }
        else
        {
            plLook.xSensitivity = 30f;
            plLook.ySensitivity = 30f;
            fpsCam.fieldOfView = 60;
            sniperScaleZoomUI.SetActive(false);
        }
    }

    public void mouseClickingShootAndSniper()
    {
        if (isAutomatic)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Sniper();
        }
    }

    public void updateWeapon()
    {
        if (curLevel == 0)
        {
            if (Stats.Money >= priceLvlOne)
            {
                curLevel++;
                curUpgradePriceWeapon = priceLvlTwo;
                Stats.Money -= priceLvlOne;
            }
        }
        else if (curLevel == 1)
        {
            if (Stats.Money >= priceLvlTwo)
            {
                curLevel++;
                curUpgradePriceWeapon = priceLvlThree;
                Stats.Money -= priceLvlTwo;
            }
        }
        else if(curLevel == 2)
        {
            if (Stats.Money >= priceLvlThree)
            {
                curLevel++;
                Stats.Money -= priceLvlThree;
                isWeaponMaxLevel = true;
            }
        }
    }

    public bool isWeaponMaxed()
    {
        return isWeaponMaxLevel;
    }

    public float getDamage()
    {
        if(curLevel == 1)
        {
            return dmgLvlOne;
        }
        if(curLevel == 2)
        {
            return dmgLvlTwo;
        }
        if (curLevel == 3)
        {
            return dmgLvlThree;
        }
        return damage;
    }

    public float getCurUpgradePriceWeapon()
    {
        if (curLevel == 0)
            return priceLvlOne;
        return curUpgradePriceWeapon;
    }

    public float getFireRate()
    {
        return fireRate;
    }
}
