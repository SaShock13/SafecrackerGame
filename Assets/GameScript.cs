using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameScript : MonoBehaviour
{
    [SerializeField]
    TMP_Text firstPinNumText;
    [SerializeField]
    TMP_Text secondPinNumText;
    [SerializeField]
    TMP_Text thirdPinNumText;
    [SerializeField]
    Canvas gameCanvas;

    [SerializeField]
    Canvas gameWinCanvas;

    [SerializeField]
    TMP_Text combinationText;
    

    int pin1Num = 0;
    int pin2Num = 7;
    int pin3Num = 8;

    public int hammer1;
    public int hammer2;
    public int hammer3;
    public int SceletonKey1;
    public int SceletonKey2;
    public int SceletonKey3;
    public int drill1;
    public int drill2;
    public int drill3;
    int[] combination;


    // Start is called before the first frame update
    void Start()
    {
       
        
        UpdatePins();
        combination = new int[] { 7, 7, 7 };
        combinationText.text = $"Верная комбинция : {combination[0]} - {combination[1]} - {combination[2]}";
    }





    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseHammer()
    {

        UseTool(hammer1,hammer2,hammer3);
        
    }
    public void UseSceletonKey()
    {

        UseTool(SceletonKey1, SceletonKey2, SceletonKey3);
        
    }
    public void UseDrill()
    {

        UseTool(drill1, drill2, drill3);
        
    }
    /// Общий метод для применения инструментов
    void UseTool(int p1,int p2, int p3) 
    {
        pin1Num = ChangePin(pin1Num,p1);
        pin2Num = ChangePin(pin2Num, p2);
        pin3Num = ChangePin(pin3Num, p3);
        UpdatePins();

        if (pin1Num == combination[0]& pin2Num == combination[1]& pin3Num == combination[2])
        {
            Invoke("WinCanvasShow",0.5f);
            
           
        }

    }

    void WinCanvasShow()
    {
        gameWinCanvas.enabled = true;
        gameCanvas.enabled = false;

    }
    /// Изменяет пины и корректирует при необходимости
    int ChangePin(int pinNum, int pIncrement) 
    {
        if (pinNum + pIncrement < 0)
        {
            return 0;
        }
        else if (pinNum + pIncrement > 9)
        {
            return 9;
        }
        else return pinNum += pIncrement;

    }

    /// обновляет значение пинов на экране
    public void UpdatePins() 
    {
        firstPinNumText.text = pin1Num.ToString();
        secondPinNumText.text = pin2Num.ToString();
        thirdPinNumText.text = pin3Num.ToString();
    }
}
