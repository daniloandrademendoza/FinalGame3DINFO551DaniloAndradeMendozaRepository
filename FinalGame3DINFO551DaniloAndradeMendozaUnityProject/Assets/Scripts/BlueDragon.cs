using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueDragon : Dragon {
    public Text lifePointsDragonText;
    public override void Update()
    {
        StartCoroutine(WaitAndAttack(this.waitTime));
        lifePointsDragonText.text = this.lifePoints.ToString();
    }
    public override IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.animatorMonster.Play("Basic Attack");
        this.boxColliderDragon.size = new Vector3(10f,10f,14f);
    }
    public void SendToEntrance(Collision collision)
    {
        collision.transform.position = new Vector3(35.68f, 0f, 65.1f);
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
            SendToEntrance(collision);
        }
    }
}
