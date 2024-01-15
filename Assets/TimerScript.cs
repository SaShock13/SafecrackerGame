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

    [SerializeField]
    AudioSource looseSound;

    bool isWon=false;

    [SerializeField]
    double initialTimerTime = 120; //начальное время таймера

    double timerTime;
    void Start()
    {
        timerTime = initialTimerTime;
        gameCanvas.enabled = true;
        gameOverCanvas.enabled = false;
        timerText.text = timerTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWon)
        {

            if (timerTime > 0)
            {
                timerTime -= Time.deltaTime;
                timerText.text = timerTime.ToString("#.#");
            }
            else 
            {
                
                StopTimer();
                gameOverCanvas.enabled = true;
                gameCanvas.enabled = false;
                looseSound.Play();
            
            }
            

        }

    }
    public void ResetTimer()
    {
        gameOverCanvas.enabled=false;
        timerTime = initialTimerTime;
        timerText.text = timerTime.ToString();
        isWon = false;
    }
    

    public void StopTimer()
    {
        isWon = true;
        timerTime = 0;
    }
}
