using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]

public class PlayerController : MonoBehaviour
{
    public KeyCode m_Up = KeyCode.W;
    public KeyCode m_Down = KeyCode.S;
    public KeyCode m_Left = KeyCode.A;
    public KeyCode m_Right = KeyCode.D;
    public KeyCode m_Modifier = KeyCode.LeftShift;
	public float m_Speed = 1;
    public float m_SprintMultiplier = 1.75f;

    void Update()
    {
		Vector2 direction = new Vector2();

		//Get the direction based on the keys the user pressed
		if (Input.GetKey(m_Up))
		{
			direction += Vector2.up;
		}
		if (Input.GetKey(m_Down))
		{
			direction += Vector2.down;
		}
		if (Input.GetKey(m_Left))
		{
			direction += Vector2.left;
		}
		if (Input.GetKey(m_Right))
		{
			direction += Vector2.right;
		}

		// If the user told the player to change direction: change it, otherwise keep still 
		if (!(direction.x == 0 && direction.y == 0)) {
			direction.Normalize ();
			float z = Mathf.Atan2 (direction.y, direction.x);
			z *= Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3 (0.0f, 0.0f, z);
		}

		// Apply speed and time to the direction vector
		direction *= Time.deltaTime * m_Speed;

        if (Input.GetKey(m_Modifier))
        {
            //If sprinting
            direction *= m_SprintMultiplier;
        }

		// Move the direction
		transform.position += new Vector3(direction.x, direction.y, 0.0f);
	}
}
