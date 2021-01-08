using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text digitLabel;
    public Text operatorLabel;
    public Text historyLabel; //todo: make it real

    bool errorDisplayed;    
    bool displayValid;      // is some text already on the screen
    bool specialAction;
    double currentVal;
    double storedVal;
    double result;
    string storedOperator;

    void Start()
    {

        
    }

  
    void Update()
    {
        
    }

    private void ClearCalc()
    {
        digitLabel.text = "0";
        operatorLabel.text = "";
        historyLabel.text = "";
        errorDisplayed = false;
        displayValid = false;
        specialAction = false;
        currentVal = 0;
        storedVal = 0;
        result = 0;
        storedOperator = " ";
    }

    private void UpdateDigitLabel()
    {
        if (!errorDisplayed)
        {
            digitLabel.text = currentVal.ToString();
        }
        displayValid = false;
    }

    private void CalcResult(string operation)
    {
        switch (operation)
        {
            case "=":
                result = currentVal;
                break;
            case "+":
                result = storedVal + currentVal;
                break;
            case "-":
                result = storedVal - currentVal;
                break;
            case "x":
                result = storedVal * currentVal;
                break;
            case "/":
                if (storedVal == 0)
                {
                    errorDisplayed = true;
                    digitLabel.text = "Error cant divide 0";
                }
                else
                {
                    result = storedVal / currentVal;
                }
                break;
            default:
                Debug.Log("Unknow comand!! : " + operation);
                break;
        }
        currentVal = result;
        UpdateDigitLabel();
    }

    private void AddToHistory(string str)
    {
        historyLabel.text += str;
    }

    public void ButtonTapped(string button)
    {
        if (errorDisplayed)
        {
            ClearCalc();
        }

        if((button.ToCharArray()[0] >= '0' && button.ToCharArray()[0] <= '9') || button == ".")
        {
            if(digitLabel.text.Length < 15 || !displayValid)
            {
                if (!displayValid)
                {
                    if (button == '.')
                    {
                        digitLabel.text = "0";
                    }
                    else
                    {
                        digitLabel.text = "";
                    }
                }
                else if(digitLabel.text == "0" && button != '.')
                {
                    digitLabel.text = "";
                }

                digitLabel.text += button;
                displayValid = true;
            }
            else if (button == 'c')
            {
                ClearCalc();
            }
            else if(button == "ce")
        }
        
    }
}
