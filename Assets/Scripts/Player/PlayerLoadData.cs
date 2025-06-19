using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoadData : MonoBehaviour
{
    public void Awake()
    {
        loadData();
    }

    public void loadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Stats.Money = data.money;
        Stats.JewsKills = data.jewsKills;
        Stats.MaxHealth = data.maxHealth;
        Stats.Exp = data.exp;
        Stats.ExpToNextLevel = data.expToNextLevel;
        Stats.CurLevel = data.curLevel;   
    }

    public void saveDataAndQuit()
    {
        SaveSystem.SavePlayer();
    }

}
