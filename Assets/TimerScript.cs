using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text timerText;
    [SerializeField]
    Canvas gameCanvas;
    
    [SerializeField]
    Canvas gameOverCanvas;
    


    double timerTime =30;
    void Start()
    {
       
        gameCanvas.enabled = true;
        gameOverCanvas.enabled = false;
        timerText.text = timerTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerTime > 0)
        {
            timerTime -= Time.deltaTime;
            //timerText.text = System.Math.Round(timerTime, 3).ToString();
            timerText.text = timerTime.ToString("#.#");
        }
        else 
        {
            gameOverCanvas.enabled = true;
            gameCanvas.enabled = false;
            
        }
    }
    
}
