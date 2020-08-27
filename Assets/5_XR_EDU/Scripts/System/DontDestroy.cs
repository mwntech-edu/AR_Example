using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	// Use this for initialization
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}