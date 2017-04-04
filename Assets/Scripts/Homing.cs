using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Homing : MonoBehaviour
{
    public float speed;
    public Transform target;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector2 pos = Util.Convert(transform.position);
        // TODO: Instead of homing towards the center of an object, home towards the center of it's collision?
        Vector2 targetPos = Util.Convert(target.position);
        Vector2 desiredVelocity = (targetPos - pos).normalized * speed;
        Vector2 force = (desiredVelocity - rb.velocity).normalized * speed;

        rb.AddForce(force);

        Vector3 rotation = transform.eulerAngles;
        rotation.z = Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.y, rb.velocity.x);
        transform.eulerAngles = rotation;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("ApplyDamage", 10);
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}