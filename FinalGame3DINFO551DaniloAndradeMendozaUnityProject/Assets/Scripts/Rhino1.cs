using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino1 : Rhino{
    public override void Update()
    {
        StartCoroutine(WaitAndAttack(this.waitTime));
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorRhino.Play("attack");
       // this.boxColliderRhino.size = new Vector3(this.xStartBoxCollider, this.yStartBoxCollider, this.zNewBoxCollider);
    }
   // public IEnumerator Wait(float waitTime, Collision collision)
   // {
        
   // }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch") || collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            this.lifePoints--;
          //  StartCoroutine(Wait(this.waitTime, collision));
            if (this.lifePoints == 0)
            {
                this.animatorRhino.Play("dead");
                this.gameObject.SetActive(false);
            }
        }
    }

}
