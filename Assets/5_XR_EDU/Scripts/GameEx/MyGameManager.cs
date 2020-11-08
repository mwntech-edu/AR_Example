using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += SearchContentGO;
   }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void OnStartButtonClick()
   {
      SceneManager.LoadScene( 1, LoadSceneMode.Single); 
   }

   public void LoadEmptyScene()
   {
      SceneManager.LoadScene("_Empty_", LoadSceneMode.Single);
   }

   public void LoadScene(int a_SceneNumber)
   {      
      SceneManager.LoadScene(a_SceneNumber, LoadSceneMode.Single);
   }

   public GameObject m_Content1;

   public void SearchContentGO(Scene scene, LoadSceneMode mode)
	{
      m_Content1 = null;
      m_Content1 = GameObject.Find("Contents");
	}

}
