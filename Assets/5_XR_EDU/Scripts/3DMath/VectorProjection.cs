using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Project VecU onto VecV 
///  or 
/// Project VecU onto a plane whose normal vector direction is VecV
/// 
/// and save the result on VecP
/// </summary>
public class VectorProjection : MonoBehaviour
{
	public bool m_ProjectionOnPlane = true;
	public bool m_UnityFunctionMode = false;

	public Vector3 m_LocalVecU = Vector3.right; 
	public Vector3 m_VecU;	// World version of m_LocalVecU (Calculated automatically)
	
	/// A target vector when m_ProjectionOnPlane is "False"
	/// A plane normal vector when m_ProjectionOnPlane is "True"
	public Vector3 m_VecV = Vector3.up;	// World Vector

	public Vector3 m_VecP = Vector3.zero;

	
	private Vector3 ProjectVectorOntoVector()
	{
		return (Vector3.Dot(m_VecU, m_VecV) / m_VecV.magnitude) * m_VecV.normalized;
	}

	private Vector3 ProjectVectorOntoPlane()
	{
		
		return m_VecU - ProjectVectorOntoVector();
	}


	private void OnDrawGizmos()
	{
		m_VecU = transform.TransformVector(m_LocalVecU);

		if (m_ProjectionOnPlane)
		{
			if(m_UnityFunctionMode)
				m_VecP = Vector3.ProjectOnPlane(m_VecU, m_VecV);
			else
				m_VecP = ProjectVectorOntoPlane();
		}
		else
		{
			if (m_UnityFunctionMode)
				m_VecP = Vector3.Project(m_VecU, m_VecV);
			else
				m_VecP = ProjectVectorOntoVector();
		}
		
		Vector3 worldPos = transform.position;

		Debug.DrawLine(worldPos, worldPos + m_VecU, Color.red);
		Debug.DrawLine(worldPos, worldPos + m_VecV, Color.green);
		Debug.DrawLine(transform.position, transform.position + m_VecP, Color.magenta);
	}

	void OnGUI()
	{
		Camera cam = Camera.main;

		// Draw labels
		Vector3 zeroScrPos = cam.WorldToScreenPoint(transform.position);

		GUI.Label(new Rect(zeroScrPos.x, Screen.height - zeroScrPos.y + 30, 300, 20), gameObject.name);

	}
}
