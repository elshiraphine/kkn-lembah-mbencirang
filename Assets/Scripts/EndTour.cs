using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTour : MonoBehaviour
{
    public void EndT()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
