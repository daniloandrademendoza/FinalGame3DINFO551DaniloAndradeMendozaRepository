using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon3 : Dragon {
    public override void Update()
    {
        this.coroutine = WaitAndAttack(this.waitTime);
        StartCoroutine(this.coroutine);
        if (!this.animatorMonster.GetCurrentAnimatorStateInfo(0).IsName("atk03"))
        {
            this.boxColliderDragon.center = new Vector3(0f,0.5f,0f);
            this.boxColliderDragon.size = new Vector3(this.xStartBoxCollider, this.yStartBoxCollider, this.zStartBoxCollider);
        }
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("atk03");
        this.boxColliderDragon.center = new Vector3(0f,2f,0f);
        this.boxColliderDragon.size = new Vector3(6f,3f,this.zStartBoxCollider);
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
