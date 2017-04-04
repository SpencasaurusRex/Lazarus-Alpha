using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    public float radius;
    public bool clockwise;
    public Vector2 center;
    public float speed;
    private float t;

    void FixedUpdate()
    {
        // Adjust theta
        float dt = Time.fixedDeltaTime * speed / radius;
        // Reverse rotation if clockwise
        if (clockwise) dt = -dt;

        t += dt;

        // Change x,y location
        float x = center.x + Mathf.Cos(t) * radius;
        float y = center.y + Mathf.Sin(t) * radius;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
