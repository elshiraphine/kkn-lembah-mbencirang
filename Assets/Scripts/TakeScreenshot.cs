using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
public class TakeScreenshot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] disabledUI;
    protected const string MEDIA_STORE_IMAGE_MEDIA = "android.provider.MediaStore$Images$Media";
    protected static AndroidJavaObject m_Activity;
    public void TakeSC()
    {
        foreach (GameObject item in disabledUI)
        {
            item.SetActive(false);
        }
        //StartCoroutine(Capture());
        StartCoroutine(CaptureScreenshotCoroutine(Screen.width, Screen.height));

    }

    IEnumerator Capture()
    {
        string timestamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "ARSC_screenshot" + timestamp + ".png";
        string savePath = GetAndroidExternalStoragePath()+"/"+fileName;
        

        Console.Instance.Log(savePath, "blue");
        Console.Instance.Log(fileName, "blue");

        Debug.Log(savePath);
        ScreenCapture.CaptureScreenshot(fileName);
        

        yield return new WaitForEndOfFrame();
        foreach (GameObject item in disabledUI)
        {
            item.SetActive(true);
        }
    }

    private IEnumerator CaptureScreenshotCoroutine(int width, int height)
    {
        yield return new WaitForEndOfFrame();
        Texture2D tex = new Texture2D(width, height);
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        string timestamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "ARSC_screenshot" + timestamp;
        yield return tex;
        string path = SaveImageToGallery(tex, fileName, "ARVM AR Screenshot");
        Console.Instance.Log("Picture has been saved at:" + path, "blue");
        foreach (GameObject item in disabledUI)
        {
            item.SetActive(true);
        }
    }


    private string GetAndroidExternalStoragePath()
    {
        if (Application.platform != RuntimePlatform.Android)
            return Application.persistentDataPath;

        var jc = new AndroidJavaClass("android.os.Environment");
        var path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory",
            jc.GetStatic<string>("DIRECTORY_DCIM"))
            .Call<string>("getAbsolutePath");
        return path;
    }

    

    protected static string SaveImageToGallery(Texture2D a_Texture, string a_Title, string a_Description)
    {
        using (AndroidJavaClass mediaClass = new AndroidJavaClass(MEDIA_STORE_IMAGE_MEDIA))
        {
            using (AndroidJavaObject contentResolver = Activity.Call<AndroidJavaObject>("getContentResolver"))
            {
                AndroidJavaObject image = Texture2DToAndroidBitmap(a_Texture);
                return mediaClass.CallStatic<string>("insertImage", contentResolver, image, a_Title, a_Description);
            }
        }
    }

    protected static AndroidJavaObject Texture2DToAndroidBitmap(Texture2D a_Texture)
    {
        byte[] encodedTexture = a_Texture.EncodeToPNG();
        using (AndroidJavaClass bitmapFactory = new AndroidJavaClass("android.graphics.BitmapFactory"))
        {
            return bitmapFactory.CallStatic<AndroidJavaObject>("decodeByteArray", encodedTexture, 0, encodedTexture.Length);
        }
    }

    protected static AndroidJavaObject Activity
    {
        get
        {
            if (m_Activity == null)
            {
                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                m_Activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
            return m_Activity;
        }
    }



}
