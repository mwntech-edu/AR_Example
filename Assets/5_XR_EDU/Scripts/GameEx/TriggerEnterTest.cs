using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerEnterTest : MonoBehaviour
{
   public TextMeshProUGUI m_Text;

	public void OnTriggerEnter(Collider other)
	{
		m_Text.text = other.name;
	}

}
