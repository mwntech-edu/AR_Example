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


    }

    void OnGUI()
    {
     
        Camera cam = Camera.main;
        
        // Draw labels
        Vector3 zeroScrPos = cam.WorldToScreenPoint(transform.position);
        
        GUI.Label(new Rect(zeroScrPos.x, Screen.height - zeroScrPos.y, 100, 20), "My Test");
        
    }
}
