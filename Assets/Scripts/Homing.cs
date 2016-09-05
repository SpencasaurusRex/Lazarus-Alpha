using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Homing : MonoBehaviour
{
	public Transform target;
	private Rigidbody2D rb;

	[SerializeField]
	private float speed;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		if (target == null)
		{
			return;
		}

		Vector2 pos = Util.convert (transform.position);
		Vector2 targetPos = Util.convert (target.position);
        Vector2 desiredVelocity = (targetPos - pos).normalized * speed;
        Vector2 force = (desiredVelocity - rb.velocity).normalized * speed;
        
		rb.AddForce (force);
	}
}