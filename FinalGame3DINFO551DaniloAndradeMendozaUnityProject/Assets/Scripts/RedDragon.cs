using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedDragon : Dragon {
    public Text lifePointsDragonText;
    public override void Update()
    {
        StartCoroutine(WaitAndAttack(this.waitTime));
        lifePointsDragonText.text = this.lifePoints.ToString();
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("Claw Attack");
        this.boxColliderDragon.center = new Vector3(0f, 0f, -0.5f);
    }
   public void TakeOffLifePoints(Collision collision)
    {
        PersistentData.singleton.lifePoints -= 5;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch") || collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            this.lifePoints--;
            if (this.lifePoints == 0)
            {
                this.animatorMonster.Play("Die");
                this.gameObject.SetActive(false);
            }
        }
        else if (collision.gameObject.name == "MAX")
        {
            TakeOffLifePoints(collision);
        }
    }

}
