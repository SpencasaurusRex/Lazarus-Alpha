using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // TODO extract these spell variables into spell controller class
    public float castingRate;
    public Homing spell;
    public Transform target;
    private float spellRecharge;

    public float walkingSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        spellRecharge += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && spellRecharge >= castingRate)
        {
            CastSpell();
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector2(x, y) * walkingSpeed * rb.drag);
    }

    private void CastSpell()
    {
        spellRecharge = 0;
        Vector2 towardsTarget = Util.Convert(target.position - transform.position);
        Homing h = (Homing)Instantiate(spell, transform.position, transform.rotation);
        h.target = target;
        Rigidbody2D spellRb = h.GetComponent<Rigidbody2D>();
        spellRb.velocity = towardsTarget.normalized * h.speed;
    }
}
