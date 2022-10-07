using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_AR : MonoBehaviour
{
    public GameObject CanvasUI;
    private bool isEnable=false;
    private void Start()
    {
        CanvasUI.SetActive(false);
    }
    public void ToggleObject()
    {
        CanvasUI.SetActive(true);

        /*if (!isEnable)
        {
            isEnable = true;
            Debug.Log(isEnable);
        }
        else
        {
            isEnable = false;
            Debug.Log(isEnable);

        }*/
    }
}
