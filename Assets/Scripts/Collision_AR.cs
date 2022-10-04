using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_AR : MonoBehaviour
{
    public GameObject secondBody;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hello");
    }
    public void EnableSecond()
    {
        Debug.Log("Hello");

        secondBody.SetActive(false);
    }
}
