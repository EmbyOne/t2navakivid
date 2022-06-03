using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class renderFuck : MonoBehaviour
{
    public GameStateManager manager;
    public Text cashText;
    public Text date;
    public Text revenuu;
    public Text markutsheer;
    public Text currentProduction;


    public Text laborPrice;
    public int laborPriceValue = 100;
    public Button buyLabor;


    // Start is called before the first frame update
    
    void Start(){
        Button buyLaborButton = buyLabor.GetComponent<Button>();
        buyLaborButton.onClick.AddListener(TaskOnClickLabor);
    }
    // Update is called once per frame
    void Update()
    {
        cashText.text = manager.cash.ToString();
        laborPrice.text = laborPriceValue.ToString();
        date.text = manager.day.ToString() + "/" + manager.month.ToString() + "/" + manager.year.ToString();
        revenuu.text = manager.revenue.ToString();
        markutsheer.text = manager.marketShare.ToString();
        currentProduction.text = manager.currentProduction.ToString();
        //Debug.Log(manager.cash);
    }
    void TaskOnClickLabor(){
        if (manager.cash >= laborPriceValue){
            manager.currentProduction *= 1.1f;
            manager.cash -= laborPriceValue;
            laborPriceValue += 100;
        }
    }
}
