using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour {

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
	
	void Update () {
		if (walking)
		{
			
		}
		else
		{
			
		}
	}

	private void StartWalking()
	{
		walking = true;
		target = Random.insideUnitCircle * walkLength;
	}

	private void StartWaiting()
	{
		walking = false;
		currentTime = 0;
		targetTime = Random.Range (waitTime.x, waitTime.y);
	}
}
