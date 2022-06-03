using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen1 : MonoBehaviour
{
    public GameObject Panel;
    void Start(){
        Panel.SetActive(false);
    }
    public void OpenPanelOffice(){
        if (Panel != null){
            Panel.SetActive(true);
        }

    }
}
