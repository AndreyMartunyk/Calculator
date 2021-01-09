using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text digitLabel;
    public Text historyLabel; //todo: make it real

    bool errorDisplayed;    
    bool displayValid;      
    bool specialAction;
    double currentVal;
    double storedVal;
    double result;
    CalcButton storedOperator;

    void Start()
    {
        ClearCalc();
    }

    private void ClearDigitScreen()
    {
        digitLabel.text = "0";
        if (!displayValid)
        {
            ClearCalc();
        }
    }

    private void ClearCalc()
    {
        digitLabel.text = "0";
        historyLabel.text = "";
        errorDisplayed = false;
        displayValid = false;
        specialAction = false;
        currentVal = 0;
        storedVal = 0;
        result = 0;
        storedOperator = CalcButton.none;
    }

    private void UpdateDigitLabel()
    {
        if (!errorDisplayed)
        {
            digitLabel.text = currentVal.ToString();
        }
        displayValid = false;
    }

    private void CalcResult(CalcButton operation)
    {
        switch (operation)
        {
            case CalcButton.equal:
                result = currentVal;
                break;
            case CalcButton.plus:
                result = storedVal + currentVal;
                break;
            case CalcButton.minus:
                result = storedVal - currentVal;
                break;
            case CalcButton.multiply:
                result = storedVal * currentVal;
                break;
            case CalcButton.divide:
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

    public void ButtonTapped(CalcButton button)
    {
        if (errorDisplayed)
        {
            ClearCalc();
        }

        if((button >= CalcButton.zero && button <= CalcButton.nine) || button == CalcButton.dot)
        {
            if(digitLabel.text.Length < 15 || !displayValid)
            {
                if (!displayValid)
                {
                    if (button == CalcButton.dot)
                    {
                        digitLabel.text = "0";
                    }
                    else
                    {
                        digitLabel.text = "";
                    }
                }
                else if (digitLabel.text == "0" && button != CalcButton.dot)
                {
                    digitLabel.text = "";
                }

                if (button != CalcButton.dot || !digitLabel.text.Contains(CalcButton.dot.ToCalcScreenString()))
                {
                    digitLabel.text += button.ToCalcScreenString();
                }
          
                displayValid = true;
            }
           
        }
        else if (button == CalcButton.c)
        {
            ClearCalc();
        }
        else if (button == CalcButton.ce)
        {
            ClearDigitScreen();
        }
        else if (button == CalcButton.del)
        {
            if (digitLabel.text.Length > 0)
            {
                digitLabel.text = digitLabel.text.Remove(digitLabel.text.Length - 1);
            }
        }
        else if (button == CalcButton.reverseSign)
        {
            currentVal = -double.Parse(digitLabel.text);
            UpdateDigitLabel();
            specialAction = true;
        }
        else if (button == CalcButton.persent)
        {
            currentVal = double.Parse(digitLabel.text) / 100.0 * storedVal;
            historyLabel.text += currentVal.ToString();

            UpdateDigitLabel();
            specialAction = true;
        }
        else if (button == CalcButton.power)
        {
            currentVal = Math.Pow(double.Parse(digitLabel.text), 2);
            UpdateDigitLabel();
            specialAction = true;
        }
        else if (button == CalcButton.root)
        {
            currentVal = Math.Sqrt(double.Parse(digitLabel.text));
            UpdateDigitLabel();
            specialAction = true;
        }
        else if (button == CalcButton.dividedByOne)
        {
            currentVal = 1 / double.Parse(digitLabel.text);
            UpdateDigitLabel();
            specialAction = true;
        }
        else if (displayValid || storedOperator == CalcButton.equal || specialAction)
        {
            currentVal = double.Parse(digitLabel.text);
            displayValid = false;
            if (storedOperator != CalcButton.none)
            {
                historyLabel.text += currentVal.ToString();
                CalcResult(storedOperator);
                historyLabel.text += CalcButton.equal.ToCalcScreenString();
                storedOperator = CalcButton.none;
            }
           
            historyLabel.text += currentVal.ToString();
            if (button != CalcButton.equal)
            {
                historyLabel.text += button.ToCalcScreenString();
            }
            //operatorLabel.text = button.ToCalcScreenString();
            storedOperator = button;
            storedVal = currentVal;
            UpdateDigitLabel();
            specialAction = false;
        }

        
        
            
        

    }

   
}
