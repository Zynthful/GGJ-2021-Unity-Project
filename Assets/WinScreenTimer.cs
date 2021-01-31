using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class WinScreenTimer : MonoBehaviour
{
    void Start()
    {
        string seconds = (Mathf.CeilToInt(GameManager.instance.endTime) % 60).ToString();
        if(seconds == "0"){seconds = "00";}
        GetComponent<TextMeshProUGUI>().text = String.Format("{0}:{1}", new object[2]{Mathf.FloorToInt(Mathf.CeilToInt(GameManager.instance.endTime)/60), seconds});
    }
}
