using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] disabledUI;

    public void TakeSC()
    {
        foreach (GameObject item in disabledUI)
        {
            item.SetActive(false);
        }
        StartCoroutine(Capture());
    }

    IEnumerator Capture()
    {
        string timestamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "screenshot" + timestamp + ".png";
        string savePath = fileName;
        ScreenCapture.CaptureScreenshot(savePath);
        yield return new WaitForEndOfFrame();
        foreach (GameObject item in disabledUI)
        {
            item.SetActive(true);
        }
    }
}
