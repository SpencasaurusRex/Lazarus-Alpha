using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
public class CameraController : MonoBehaviour
{
	private static float TOUCHPAD_DAMPENER = .3f;

	private Camera cam;

	[SerializeField]
	private Transform target;

	[SerializeField]
	private Vector2 zoomRange;

	[SerializeField]
	private float deltaZoom;

	private float zoomVel;
	private float zoomTarget;

	void Start ()
	{
		cam = GetComponent<Camera> ();
		zoomTarget = cam.orthographicSize;
	}

	void Update ()
	{
		// Handle movement
		if (target != null)
		{
			transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
		}

		// Handle smooth zoom
		zoomVel = (zoomTarget - cam.orthographicSize) * deltaZoom;
		cam.orthographicSize += zoomVel * Time.deltaTime;
	}

	void OnGUI ()
	{
		float scrollDelta = 0;

		if (Event.current.type == EventType.ScrollWheel)
		{
			if (Input.mouseScrollDelta.y == 0)
			{
				// Handle touchpad scroll
				scrollDelta = Event.current.delta.y * TOUCHPAD_DAMPENER;
			} else
			{
				// Handle mouse scroll
				scrollDelta = Input.mouseScrollDelta.y;
			}
			zoomTarget -= scrollDelta;
			zoomTarget = Mathf.Clamp (zoomTarget, zoomRange.x, zoomRange.y);
		}
	}
}