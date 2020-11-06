using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeTest : MonoBehaviour
{
   public void OnSaveScreenshotPress()
   {
      NativeToolkit.SaveScreenshot("MyScreenshot", "MyScreenshotFolder", "jpeg");

      //NativeGallery.SaveImageToGallery("/MyScreenshotFolder/MyScreenshot.jpeg", "", "MyPic", null);

      //NativeGallery.SaveImageToGallery(byte[] mediaBytes, string album, string filename, MediaSaveCallback callback = null)
   }

   // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
