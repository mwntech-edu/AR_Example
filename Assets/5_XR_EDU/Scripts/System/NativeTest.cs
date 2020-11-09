using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeTest : MonoBehaviour
{
   public void OnCaptureScreen()
   { 
   Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
   ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

    ss.Apply();

    NativeGallery.SaveImageToGallery(ss, "Screenshots", "MyScreenShot");
}

public void OnSaveScreenshotPress()
   {
      NativeToolkit.SaveScreenshot("MyScreenshot", "MyScreenshotFolder", "jpeg");

      //NativeGallery.SaveImageToGallery("/MyScreenshotFolder/MyScreenshot.jpeg", "", "MyPic", null);

      //NativeGallery.SaveImageToGallery(byte[] mediaBytes, string album, string filename, MediaSaveCallback callback = null)
   }

}
