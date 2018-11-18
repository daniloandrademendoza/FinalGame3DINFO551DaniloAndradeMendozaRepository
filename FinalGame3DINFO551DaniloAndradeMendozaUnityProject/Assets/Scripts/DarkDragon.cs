using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon : MonoBehaviour {
    private int lifePoints;
    private Animator animatorMonster;
    private IEnumerator coroutine;
    private float waitTime;
    private BoxCollider boxColliderDragon;
    private float zNewBoxCollider;
    private float zStartBoxCollider;
    // Use this for initialization
    void Start () {
        lifePoints = 10;
        animatorMonster = GetComponent<Animator>();
        waitTime = 15f;
        boxColliderDragon = GetComponent<BoxCollider>();
        zNewBoxCollider = 2.5f;
        zStartBoxCollider = 1f;
    }
   
    // Update is called once per frame
    void Update () {
      
        coroutine = WaitAndAttack(waitTime);
        StartCoroutine(coroutine);
        if (!animatorMonster.GetCurrentAnimatorStateInfo(0).IsName("atk01"))
        {
            boxColliderDragon.size = new Vector3(boxColliderDragon.size.x, boxColliderDragon.size.y,zStartBoxCollider);
        }
    }
    private IEnumerator WaitAndAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        animatorMonster.Play("atk01");
        boxColliderDragon.size = new Vector3(boxColliderDragon.size.x,boxColliderDragon.size.y,zNewBoxCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch")|| collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            lifePoints--;
            Debug.Log(lifePoints);
           
            if (lifePoints == 0)
            {
                animatorMonster.Play("die");
                this.gameObject.SetActive(false);
            }
        }
       
    }
  
    
}
