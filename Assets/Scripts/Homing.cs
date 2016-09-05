using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Homing : MonoBehaviour
{
	public Transform target;

	[SerializeField]
	private float speed;

	private Rigidbody2D rb;

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
		Vector2 neededForce = targetPos - pos - rb.velocity;

		Debug.Log (neededForce * speed);

		if (Util.isZero (neededForce))
		{
			Debug.Log ("Exiting");
			return;
		}

		rb.AddForce (neededForce * speed);
	}
}
