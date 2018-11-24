using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon2 : Dragon {
    public override void Update()
    {
        this.coroutine = WaitAndAttack(this.waitTime);
        StartCoroutine(this.coroutine);
        if (!this.animatorMonster.GetCurrentAnimatorStateInfo(0).IsName("atk02"))
        {
            this.boxColliderDragon.size = new Vector3(this.xStartBoxCollider, this.yStartBoxCollider, this.zStartBoxCollider);
        }
       
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("atk02");
        this.boxColliderDragon.size = new Vector3(this.x2NewBoxCollider, this.y2NewBoxCollier, this.zNewBoxCollider);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch") || collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            this.lifePoints--;
            if (this.lifePoints == 0)
            {
                this.animatorMonster.Play("die");
                this.gameObject.SetActive(false);
                
            }
        }

    }
}
