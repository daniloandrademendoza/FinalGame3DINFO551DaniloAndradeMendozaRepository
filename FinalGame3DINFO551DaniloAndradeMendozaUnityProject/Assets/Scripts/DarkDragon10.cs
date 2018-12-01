using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon10 : Dragon {
    public override void Update()
    {
        StartCoroutine(WaitAndAttack(this.waitTime));
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        if (PersistentData.singleton.lifePointsDarkDragon10 == 0)
        {
            StartCoroutine(this.DieThenDisappearDarkDragon(this.dieWaitTime));
        }
        else
        {
            yield return new WaitForSeconds(waitTime);
            this.animatorMonster.Play("idle");
            this.boxColliderDragon.size = new Vector3(this.xStartBoxCollider, this.yStartBoxCollider, 2f);
        }
    }
    public void AffectSkills(Collision collision)
    {
        if (collision.gameObject.GetComponent<Animation>().IsPlaying("punch"))
        {
            PersistentData.singleton.punch--;

        }
        else if (collision.gameObject.GetComponent<Animation>().IsPlaying("kick"))
        {
            PersistentData.singleton.kick--;

        }
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.K)))
        {
            PersistentData.singleton.lifePoints++;
            if (PersistentData.singleton.lifePointsDarkDragon10 > 0)
            {
                PersistentData.singleton.lifePointsDarkDragon10--;
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
            AffectSkills(collision);
        }

    }
}
