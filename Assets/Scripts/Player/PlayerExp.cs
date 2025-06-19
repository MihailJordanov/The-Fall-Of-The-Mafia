using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExp : MonoBehaviour
{
    //private float exp;
    private float lerpTimer;

    [Header("Player Health")]
    public PlayerHealth playerHealth;

    [Header("Exp Text")]
    public TextMeshProUGUI curLevelText;

    [Header("Exp Bar")]
    public float chipSpeed = 2f;
    public Image frontExpBar;
    public Image backExpBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelUp();
        Stats.Exp = Mathf.Clamp(Stats.Exp, 0, Stats.ExpToNextLevel);
        updateExpUI();
        updateHealthText();
    }

    public void updateExpUI()
    {
        float fillF = frontExpBar.fillAmount;
        float fillB = backExpBar.fillAmount;
        float hFraction = Stats.Exp / Stats.ExpToNextLevel;
        if (fillB > hFraction)
        {
            frontExpBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backExpBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backExpBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontExpBar.fillAmount = Mathf.Lerp(fillF, backExpBar.fillAmount, percentComplete);
        }
    }

    public void getExp(float expAmount)
    {
        Stats.Exp += expAmount;
        lerpTimer = 0f;
    }

    public void updateHealthText()
    {
        curLevelText.text = "Lv. " + Stats.CurLevel;
    }

    public void levelUp()
    {
        if (Stats.Exp >= Stats.ExpToNextLevel)
        {
            Stats.Exp -= Stats.ExpToNextLevel;
            Stats.ExpToNextLevel += (Stats.ExpToNextLevel / 5);
            Stats.CurLevel++;
            Stats.MaxHealth += (int)(Stats.MaxHealth / 10);
            playerHealth.RestoreHealth(Stats.MaxHealth);
        }
    }
}
