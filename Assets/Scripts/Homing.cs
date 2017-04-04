using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Homing : MonoBehaviour
{
	[SerializeField]
	private float speed;

	private Transform target;
	private Rigidbody2D rb;

	void Update ()
	{
		if (target == null)
		{
			return;
		}

		Vector2 pos = Util.Convert (transform.position);
		Vector2 targetPos = Util.Convert (target.position);
		Vector2 desiredVelocity = (targetPos - pos).normalized * speed;
		Vector2 force = (desiredVelocity - rb.velocity).normalized * speed;
        
		rb.AddForce (force);

		Vector3 rotation = transform.eulerAngles;
		rotation.z = Mathf.Rad2Deg * Mathf.Atan2 (rb.velocity.y, rb.velocity.x);
		transform.eulerAngles = rotation;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy")
		{
			coll.gameObject.SendMessage ("ApplyDamage", 1);
			Destroy (this.gameObject);
			Destroy (this);
		}
	}

	public void Fire(Vector2 towards, Transform target)
	{
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (towards * speed);
		this.target = target;
	}
}