using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CallbackEvent();

public class CallbackEventTest : MonoBehaviour
{
   private CallbackEvent callbackEvent = null;

   void SomeFunc()
	{
      Debug.Log(" Function called ");
	}

    // Start is called before the first frame update
    void Start()
    {
        callbackEvent = SomeFunc;

         callbackEvent();
    }

   
}
