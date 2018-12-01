using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon6 : Dragon {
    public override void Update()
    {
        if (PersistentData.singleton.lifePointsDarkDragon6 == 0)
        {
            StartCoroutine(this.DieThenDisappearDarkDragon(this.dieWaitTime));
        }
        else
        {
            StartCoroutine(WaitAndAttack(this.waitTime));
        }
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("atk02");
        this.boxColliderDragon.size = new Vector3(this.x2NewBoxCollider, this.y2NewBoxCollier, this.zNewBoxCollider);
    }
    public void ThrowFarAway(Collision collision)
    {
        collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x - 5f, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.K)))
        {
            PersistentData.singleton.lifePoints++;
            if (PersistentData.singleton.lifePointsDarkDragon6 > 0)
            {
                PersistentData.singleton.lifePointsDarkDragon6--;
            }

            if (Input.GetKey(KeyCode.P))
            {
                PersistentData.singleton.punch = PersistentData.singleton.punch + 1;
            }
            else if (Input.GetKey(KeyCode.K))
            {
                PersistentData.singleton.kick = PersistentData.singleton.kick + 1;
            }
        }
        else if (collision.gameObject.name == "MAX")
        {
            ThrowFarAway(collision);
        }
    }
}
