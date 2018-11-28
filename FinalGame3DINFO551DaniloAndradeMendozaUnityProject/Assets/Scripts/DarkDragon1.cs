using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon1 : Dragon {
    public override void Update () {
            StartCoroutine(WaitAndAttack(this.waitTime));
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("atk01");
        this.boxColliderDragon.size = new Vector3(this.xStartBoxCollider,this.yStartBoxCollider,this.zNewBoxCollider);
    }
    public IEnumerator Wait(float waitTime, Collision collision)
    {
        collision.gameObject.GetComponent<Player>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        collision.gameObject.GetComponent<Player>().enabled = true;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch")|| collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            this.lifePoints--;
            if (this.lifePoints == 0)
            {
                this.animatorMonster.Play("die");
                this.gameObject.SetActive(false);
            }
        }
        else if (collision.gameObject.name == "MAX")
        {
            StartCoroutine(Wait(this.waitTime, collision));
        }
    }
}


