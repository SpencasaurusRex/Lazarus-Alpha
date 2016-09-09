using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;

	// TODO extract spell variables into spell controller class
	[SerializeField]
	private float castingRate;

	[SerializeField]
	private Homing spell;

    [SerializeField]
    private float walkingSpeed;

	[SerializeField]
	private Transform target;

	private float spellRecharge;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(x, y) * walkingSpeed;

		spellRecharge += Time.deltaTime;

		if (Input.GetKey (KeyCode.Space) && spellRecharge >= castingRate)
		{
			spellRecharge = 0;
			Homing h = (Homing)Instantiate (spell, transform.position, transform.rotation);
			h.target = target;
		}
	}
}
