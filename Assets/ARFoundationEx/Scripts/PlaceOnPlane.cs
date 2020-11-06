using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
	/// <summary>
	/// Listens for touch events and performs an AR raycast from the screen touch point.
	/// AR raycasts will only hit detected trackables like feature points and planes.
	///
	/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
	/// and moved to the hit position.
	/// </summary>
	[RequireComponent(typeof(ARRaycastManager))]
	public class PlaceOnPlane : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Instantiates this prefab on a plane at the touch location.")]
		GameObject m_PlacedPrefab;

		/// <summary>
		/// The prefab to instantiate on touch.
		/// </summary>
		public GameObject placedPrefab
		{
			get { return m_PlacedPrefab; }
			set { m_PlacedPrefab = value; }
		}

		/// <summary>
		/// The object instantiated as a result of a successful raycast intersection with a plane.
		/// </summary>
		public GameObject spawnedObject { get; private set; }

		static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

		ARRaycastManager m_RaycastManager;


		void Awake()
		{
			m_RaycastManager = GetComponent<ARRaycastManager>();
		}

		bool TryGetTouchPosition(out Vector2 touchPosition)
		{
			if (Input.touchCount > 0)
			{
				touchPosition = Input.GetTouch(0).position;
				return true;
			}

			touchPosition = default;
			return false;
		}


		void RotateTowardCamera()
		{
			if(spawnedObject != null)
			{
				Vector3 vecProj = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up);

				float angle = Vector3.SignedAngle(spawnedObject.transform.right, vecProj, Vector3.up);

				spawnedObject.transform.Rotate(0f, angle, 0f, Space.World);
			}
		}

		
		void Update()
		{
#if UNITY_EDITOR
			if (Input.GetMouseButton(0))
			{
				RaycastHit hit;

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				Physics.Raycast(ray, out hit, 100f);

				if (hit.transform != null)
				{
					Debug.DrawLine(transform.position, hit.point, Color.yellow);
					Debug.Log("Hit!! : " + hit.point.ToString());

					if (spawnedObject == null)
					{
						spawnedObject = Instantiate(m_PlacedPrefab, hit.point, Quaternion.identity);

						RotateTowardCamera();

					}
					else
					{
						Vector3 vecProj = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up);

						spawnedObject.transform.position = hit.point;

						RotateTowardCamera();
					}

					return;
				}
				else
				{
					Debug.Log("No Hit!!");
				}
			}
#endif

			if (!TryGetTouchPosition(out Vector2 touchPosition))
			{
				//if (m_RaycastManager.Raycast(
				//	new Vector2(Screen.width/2, Screen.height/2),
				//	s_Hits, TrackableType.PlaneWithinPolygon))
				//{
				//	// Raycast hits are sorted by distance, so the first one
				//	// will be the closest hit.
				//	var hitPose = s_Hits[0].pose;

				//	PutAxis(s_Hits[0].pose);
					return;
				//}
			}

			if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
			{
				// Raycast hits are sorted by distance, so the first one
				// will be the closest hit.
				var hitPose = s_Hits[0].pose;

				if (spawnedObject == null)
				{
					spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, Quaternion.identity);

					RotateTowardCamera();

				}
				else
				{
					Vector3 vecProj = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up);

					spawnedObject.transform.position = hitPose.position;

					RotateTowardCamera();
				}
			}
		}

		
		public GameObject m_Axis;

		void PutAxis(Pose a_Pose)
		{
			Vector3 vecProj = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up);

			float angle = Vector3.SignedAngle(m_Axis.transform.right, vecProj, Vector3.up);

			m_Axis.transform.position = a_Pose.position;
			m_Axis.transform.Rotate(0f, angle, 0f, Space.World);
		}

	}
}
