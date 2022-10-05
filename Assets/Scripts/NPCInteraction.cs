using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCInteraction : Collidable
{
    public int damagePoint = 1;
    public float pushForce = 0f;

    private Animator anim;
    private float cooldown = 0.5f;
    private float lastTalk;

    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time - lastTalk > cooldown)
            {
                lastTalk = Time.time;
                Talk();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

            // Create new damage object, then we'll send it to the fighter we've hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            Talk();

        }
    }
    private void Talk()
    {
        anim.SetTrigger("Talk");
    }

}
