using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkDragon4 : Dragon {
    public Text lifePointsDragonText;
    public override void Update()
    {
        this.coroutine = WaitAndAttack(this.waitTime);
        StartCoroutine(this.coroutine);
        lifePointsDragonText.text = this.lifePoints.ToString();
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("hit");
        this.boxColliderDragon.size = new Vector3(this.xStartBoxCollider, this.yStartBoxCollider, 2.25f);
    }
    public void HitMoreLifePoints()
    {
        PersistentData.singleton.lifePoints--;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch") || collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            this.lifePoints--;
            if (this.lifePoints == 0)
            {
                StartCoroutine(this.DieThenDisappearDarkDragon(this.dieWaitTime));
            }
        }
        else if (collision.gameObject.name == "MAX")
        {
            HitMoreLifePoints();
        }

    }
}
