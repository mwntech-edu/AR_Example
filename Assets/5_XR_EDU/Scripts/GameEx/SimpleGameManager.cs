using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;

public class SimpleGameManager : MonoBehaviour
{
   public ARSession m_ARSession;

   public ARPlaneManager m_PlaneMgr;
   public PlaceOnPlane m_Place;
   public ARPointCloudManager m_PointCloud;

   public GameObject m_Contents1;

   public void LoadContents1()
   {
      //m_PlaneMgr.subsystem.Stop();
      m_PlaneMgr.enabled      = false;
      m_Place.enabled            = false;
      m_PointCloud.enabled    = false;

      //m_ARSession.Reset();
      m_ARSession.enabled = false;

      m_Contents1.SetActive(true);
   }

   public void LoadContents2()
   {
      m_PlaneMgr.enabled = true;
      //m_PlaneMgr.subsystem.Start();
      m_Place.enabled = true;
      m_PointCloud.enabled = true;

      //m_ARSession.Reset();
      m_ARSession.enabled = true;

      m_Contents1.SetActive(false);
   }
}
