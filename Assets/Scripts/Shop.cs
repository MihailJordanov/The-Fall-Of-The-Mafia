using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("Text Stats")]
    public TextMeshProUGUI antiJewGunStats;
    public TextMeshProUGUI mp40Stats;
    public TextMeshProUGUI stg44Stats;

    [Header("Text Upgrade Prices")]
    public TextMeshProUGUI antiJewGunUpgradePrice;
    public TextMeshProUGUI mp40UpgradePrice;
    public TextMeshProUGUI stg44UpgradePrice;

    [Header("Text Upgrade Buttons")]
    public TextMeshProUGUI antiJewGunUpgradeButton;
    public TextMeshProUGUI mp40UpgradeButton;
    public TextMeshProUGUI stg44UpgradeButton;

    [Header("Weapons")]
    public Gun antiJewGun;
    public Gun mp40;
    public Gun stg44;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateTexts();
    }

    public void upgradeAntiJewGun()
    {
        if(!antiJewGun.isWeaponMaxed())
        {
            antiJewGun.updateWeapon();
        }
    }

    public void upgradeMP40()
    {
        if (!mp40.isWeaponMaxed())
        {
            mp40.updateWeapon();
        }
    }

    public void upgradeSTG44()
    {
        if (!stg44.isWeaponMaxed())
        {
            stg44.updateWeapon();
        }
    }

    public void updateTextAntiJewGun()
    {
        if (!antiJewGun.isWeaponMaxed())
        {
            antiJewGunUpgradePrice.text = antiJewGun.getCurUpgradePriceWeapon().ToString() + "$";
            if (Stats.Money < antiJewGun.getCurUpgradePriceWeapon())
                antiJewGunUpgradePrice.color = Color.red;
            else
                antiJewGunUpgradePrice.color = Color.white;
        }
        else
        {
            antiJewGunUpgradePrice.text = "";
            antiJewGunUpgradeButton.text = "MAX LEVEL";
        }
        antiJewGunStats.text = "Damage: " + antiJewGun.getDamage() + "\nFire Rate: " + antiJewGun.getFireRate();
    }

    public void updateTextMP40()
    {
        if (!mp40.isWeaponMaxed())
        {
            mp40UpgradePrice.text = mp40.getCurUpgradePriceWeapon().ToString() + "$";
            if (Stats.Money < mp40.getCurUpgradePriceWeapon())
                mp40UpgradePrice.color = Color.red;
            else
                mp40UpgradePrice.color = Color.white;
        }
        else
        {
            mp40UpgradePrice.text = "";
            mp40UpgradeButton.text = "MAX LEVEL";
        }
        mp40Stats.text = "Damage: " + mp40.getDamage() + "\nFire Rate: " + mp40.getFireRate();
    }

    public void updateTextSTG44()
    {
        if (!stg44.isWeaponMaxed())
        {
            stg44UpgradePrice.text = stg44.getCurUpgradePriceWeapon().ToString() + "$";
            if (Stats.Money < stg44.getCurUpgradePriceWeapon())
                stg44UpgradePrice.color = Color.red;
            else
                stg44UpgradePrice.color = Color.white;
        }
        else
        {
            stg44UpgradePrice.text = "";
            stg44UpgradeButton.text = "MAX LEVEL";
        }
        stg44Stats.text = "Damage: " + stg44.getDamage() + "\nFire Rate: " + stg44.getFireRate();
    }

    void updateTexts()
    {
        updateTextAntiJewGun();
        updateTextMP40();
        updateTextSTG44();
    }

}
