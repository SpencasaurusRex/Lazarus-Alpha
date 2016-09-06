using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
public class CameraController : MonoBehaviour {

	private Camera cam;

    [SerializeField]
    private Transform target;

	[SerializeField]
	private Vector2 zoomRange;

	[SerializeField]
	private float deltaZoom;

	private float zoomVel;
	private float zoomTarget;

	void Start()
	{
		cam = GetComponent<Camera> ();
		zoomTarget = cam.orthographicSize;
	}

	void Update ()
    {
        if (target != null)
        {
            transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
        }

		zoomTarget -= Input.mouseScrollDelta.y;
		zoomTarget = Mathf.Clamp (zoomTarget, zoomRange.x, zoomRange.y);

		zoomVel = (zoomTarget - cam.orthographicSize) * deltaZoom;

		cam.orthographicSize += zoomVel * Time.deltaTime;
	}
}