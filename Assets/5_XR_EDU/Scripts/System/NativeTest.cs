using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeTest : MonoBehaviour
{
   public void OnSaveScreenshotPress()
   {
      NativeToolkit.SaveScreenshot("MyScreenshot", "MyScreenshotFolder", "jpeg");
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
