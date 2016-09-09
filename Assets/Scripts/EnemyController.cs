using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private float walkLength;

	[SerializeField]
	// Vector2 used as an interval
	private	Vector2 waitTime;

	private bool walking;
	private float currentTime;
	private float targetTime;
	private Vector2 target;
	private Rigidbody2D rb;

	private const float epsilon = .2f;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		if (walking)
		{
			Vector2 diff = target - Util.Convert (transform.position);
			if (diff.sqrMagnitude < epsilon)
			{
				StartWaiting ();
				return;
			}
			rb.velocity = (diff).normalized * speed;
		} else
		{
			currentTime += Time.deltaTime;
			if (currentTime >= targetTime)
			{
				StartWalking ();
			}
		}
	}

	private void StartWalking ()
	{
		walking = true;
		target = Util.Convert(transform.position) + Random.insideUnitCircle * walkLength;
	}

	private void StartWaiting ()
	{
		rb.velocity = new Vector2 ();
		walking = false;
		currentTime = 0;
		targetTime = Random.Range (waitTime.x, waitTime.y);
	}

	public void ApplyDamage(float f)
	{
		Debug.Log("Damage: " + f);
	}
}