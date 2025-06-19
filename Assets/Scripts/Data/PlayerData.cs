using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float money;
    public float jewsKills;
    public float maxHealth;
    public float exp;
    public float expToNextLevel;
    public int curLevel;

    public PlayerData()
    {
        money = Stats.Money;
        jewsKills = Stats.JewsKills;
        maxHealth = Stats.MaxHealth;
        exp = Stats.Exp;    
        expToNextLevel = Stats.ExpToNextLevel;
        curLevel = Stats.CurLevel;
    }

}
