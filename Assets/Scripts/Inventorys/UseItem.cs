using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    PlayerManager playerManager;
    //item atk
    bool useAtk;
    float timerAtk;
    int atkAdd;

    //item Def
    bool useDef;
    float timerDef;
    int defAdd;

    private void Start()
    {
        playerManager = FindAnyObjectByType<PlayerManager>();
    }

    private void Update()
    {
        UseATK();
        UseDEF();
    }
    public void HP(int value)
    {

        var total = value * playerManager.playerMaxHealPoint;
        int healadd = Mathf.FloorToInt(total / 100);

        playerManager.playerCurrentHealPoint = playerManager.playerCurrentHealPoint + healadd > playerManager.playerMaxHealPoint 
            ? playerManager.playerMaxHealPoint : playerManager.playerCurrentHealPoint + healadd;

    }

    public void MP(int value)
    {
        var total = value * playerManager.playerMaxHealPoint;
        int mpadd = Mathf.FloorToInt(total / 100);

        playerManager.playerCurrentManaPoint = playerManager.playerCurrentManaPoint + mpadd > playerManager.playerMaxManaPoint
            ? playerManager.playerMaxManaPoint : playerManager.playerCurrentManaPoint + mpadd;
    }

    public void ATK(int value, float timer)
    {

        var total = value * playerManager.playerAttackPoint;
         atkAdd = Mathf.FloorToInt(total / 100);

        if (!useAtk)
        {
            timerAtk = timer;

            playerManager.playerAttackPoint += atkAdd;
            useAtk = true;
        }

        else if(useAtk)
        {
            timerAtk += timer;
        }
    }

    public void DEF(int value, float timer)
    {
        var total = value * playerManager.playerDefendPoint;
        defAdd = Mathf.FloorToInt(total / 100);

        if (!useDef)
        {
            timerDef = timer;

            playerManager.playerDefendPoint += defAdd;
            useDef = true;
        }

        else if (useDef)
        {
            timerDef += timer;
        }
    }

    public void UseATK()
    {
        if (useAtk)
        {
            timerAtk -= Time.deltaTime;
            if (timerAtk <= 0)
            {
                useAtk = false;
                timerAtk = 0;
                playerManager.playerAttackPoint -= atkAdd;
            }
        }
    }

    public void UseDEF()
    {
        if (useDef)
        {
            timerDef -= Time.deltaTime;
            if (timerDef <= 0)
            {
                useDef = false;
                timerDef = 0;
                playerManager.playerDefendPoint -= defAdd;

            }
        }
    }
}
