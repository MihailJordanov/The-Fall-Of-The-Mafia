using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerItems : MonoBehaviour
{
    [HideInInspector]
    public int silverKeysCount = 2;
    [HideInInspector]
    public int goldenKeysCount = 0;
    [HideInInspector]
    public int blueKeysCount = 0;

    [Header("Grenades")]
    public int grenadeCount = 10;

    [SerializeField]
    [Header("UI")]
    private GameObject silverKeysUI;



    [Header("Text")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI silverKeysText;
    public TextMeshProUGUI grenageText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        visibleKeys();
        updateTexts();
    }

    public void getMoney(float money)
    {
        Stats.Money += money;
    }

    public void getSilverKey()
    {
        silverKeysCount++;
    }

    public void visibleKeys()
    {
        if (silverKeysCount > 0)
        {
            silverKeysUI.SetActive(true);
        }
        else
        {
            silverKeysUI.SetActive(false);
        }
    }

    public void updateTexts()
    {
        moneyText.text = Stats.Money.ToString() + "$";
        silverKeysText.text = "x " + silverKeysCount.ToString();

        if (grenadeCount <= 0)
            grenageText.color = Color.red;
        else
            grenageText.color = Color.white;
        grenageText.text = grenadeCount.ToString();
    }

    public void CollectGrenade(int amount)
    {
        if (amount < 0)
            amount = 0;
        grenadeCount += amount;
    }

    
}
