using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_EndTour : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    public void ToggleObject()
    {
       
        GameObject EndingObject = GameObject.FindGameObjectWithTag("Finish");

        Debug.Log("Hello there");
        EndingObject.SetActive(true);
    }
}
