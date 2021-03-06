﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    // TODO extract these spell variables into spell controller class
    public float castingRate;
    private float spellRecharge;
    public Homing spell;
    public Transform target;

    public float walkingSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(x, y) * walkingSpeed;

        spellRecharge += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && spellRecharge >= castingRate)
        {
            FireSpell();
        }
    }

    void FireSpell()
    {
        spellRecharge = 0;
        Vector2 towards = Util.Convert(target.position) - Util.Convert(transform.position);
        Homing h = (Homing)Instantiate(spell, transform.position, transform.rotation);
        h.Fire(towards, target);
    }
}
