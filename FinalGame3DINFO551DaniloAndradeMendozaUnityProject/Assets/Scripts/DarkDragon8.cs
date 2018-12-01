using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon8 : Dragon {
    public override void Update()
    {
        if (PersistentData.singleton.lifePointsDarkDragon8 == 0)
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
        this.animatorMonster.Play("atk03");
        this.boxColliderDragon.center = new Vector3(0f, 2f, 0f);
        this.boxColliderDragon.size = new Vector3(6f, 3f, this.zStartBoxCollider);
    }
    public void ThrowDown(Collision collision)
    {
        collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y - 5f, collision.gameObject.transform.position.z);
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.K)))
        {
            PersistentData.singleton.lifePoints++;
            if (PersistentData.singleton.lifePointsDarkDragon8 > 0)
            {
                PersistentData.singleton.lifePointsDarkDragon8--;
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
            ThrowDown(collision);
        }

    }
}
