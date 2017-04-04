using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float walkLength;
    // Vector2 used as an interval
    public Vector2 waitTime;

    private bool walking;
    private float currentTime;
    private float targetTime;
    private Vector2 target;

    private const float epsilon = .2f;

    void Start()
    {
    }

    void Update()
    {
        if (walking)
        {
            Vector2 diff = target - Util.Convert(transform.position);
            if (diff.sqrMagnitude < epsilon)
            {
                StartWaiting();
                return;
            }
            // TODO change position using vel = (diff).normalized * speed;
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime >= targetTime)
            {
                StartWalking();
            }
        }
    }

    private void StartWalking()
    {
        walking = true;
        target = Util.Convert(transform.position) + Random.insideUnitCircle * walkLength;
    }

    private void StartWaiting()
    {
        // TODO reset vel rb.velocity = new Vector2();
        walking = false;
        currentTime = 0;
        targetTime = Random.Range(waitTime.x, waitTime.y);
    }

    public void ApplyDamage(float f)
    {
        Debug.Log("Damage: " + f);
    }
}