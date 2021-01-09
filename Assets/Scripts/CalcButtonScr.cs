using Assets.Scripts;
using UnityEngine;


public class CalcButtonScr : MonoBehaviour
{
    public CalcButton button;
    private Manager _manager;

    private void Start()
    {
        _manager = GetComponentInParent<Manager>();
    }

    public void onClick()
    {
        _manager.ButtonTapped(button);
    }


}
