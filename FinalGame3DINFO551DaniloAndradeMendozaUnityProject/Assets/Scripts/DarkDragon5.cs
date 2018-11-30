using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkDragon5 : Dragon {
    public Text lifePointsDragonText;
    public override void Update()
    {
        lifePointsDragonText.text = this.lifePoints.ToString();
        if (this.lifePoints == 0)
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
        this.animatorMonster.Play("idle");
      this.boxColliderDragon.size = new Vector3(this.xStartBoxCollider, this.yStartBoxCollider, 2f);
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
            if (this.lifePoints > 0)
            {
                this.lifePoints--;
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
