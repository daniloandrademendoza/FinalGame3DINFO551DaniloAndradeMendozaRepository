using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDragon : Dragon {
    public override void Update()
    {
        StartCoroutine(WaitAndAttack(this.waitTime));
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
            Debug.Log(this.lifePoints);
            SendToEntrance(collision);
            if (this.lifePoints == 0)
            {
                this.animatorMonster.Play("Die");
                this.gameObject.SetActive(false);
            }
        }
        else if (collision.gameObject.name == "MAX")
        {
            Debug.Log("collision");
            SendToEntrance(collision);
        }
    }
}
