using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenDragon : Dragon {
    public Text lifePointsDragonText; 
    public override void Update()
    {
        StartCoroutine(WaitAndAttack(this.waitTime));
        lifePointsDragonText.text = this.lifePoints.ToString();
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("Flame Attack");
        this.boxColliderDragon.center = new Vector3(0f, 0f, -2f);
        this.boxColliderDragon.size = new Vector3(9f, 12f, 12.5f);
    }
   public void Tower(Collision collision)
    {
        collision.transform.position = new Vector3(23.6f, 0f, 135.7f);
        collision.transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch") || collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            this.lifePoints--;
            if (this.lifePoints == 0)
            {
                StartCoroutine(this.DieThenDisappearFourDragons(this.dieWaitTime));
            }
        }
        else if (collision.gameObject.name == "MAX")
        {
            Tower(collision);
        }
    }
}
