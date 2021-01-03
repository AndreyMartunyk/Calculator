using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalcButton : MonoBehaviour
{
    public Text label;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClick()
    {
        Debug.Log("click: " + label.text);
    }
}
