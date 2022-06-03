using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
    public int year = 2022, month = 1, day = 1;
    public float cash = 100;
    public float marketShare = 0.1f;
    public float currentProduction = 1.0f;
    public float salePrice = 1.0f;
    public float avgPrice = 1.0f;
    public List<float> mktShareModifyers; 
    public float inputPrice;
    public float currentTotalExpenseses;
    public float economy = 1.0f;
    public float revenue;

    public float timeDelay = 1.0f;

    protected float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeDelay) {
            timer = 0f;
            day++;
            if (day > 30) {
                month++;
                day = 1;
            }
            if (month > 12) {
                year++;
                month = 1;
            }
            passDay();
        }
    }

    public void passDay() {
        System.Random rnd = new System.Random();

        this.revenue = (this.salePrice - this.inputPrice) * this.currentProduction;
        this.cash += currentProduction * (this.salePrice - this.inputPrice) - this.currentTotalExpenseses;
        this.marketShare = ((revenue) / (this.economy * 69420)) * 100;

    

        if (rnd.Next(1, 50) == 1) {
            this.economy -= 0.3f;
        }
        this.economy += (float)rnd.NextDouble() * 0.199f + 0.02f;
        this.salePrice = economy; //???????
        
    }
}
