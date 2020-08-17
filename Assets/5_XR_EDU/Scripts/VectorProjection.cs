using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorProjection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        //OnGUI();
        Debug.DrawRay(transform.position, transform.forward, Color.blue);

         Vector3 x2 = Vector3.Cross(Vector3.up, transform.forward);

      Debug.DrawRay(transform.position, x2, Color.red);

   }

   void OnGUI()
    {
        Camera cam = Camera.main;
        
        // Draw labels
        Vector3 zeroScrPos = cam.WorldToScreenPoint(transform.position);
        
        GUI.Label(new Rect(zeroScrPos.x, Screen.height - zeroScrPos.y, 100, 20), "My Test");
        
    }
}
