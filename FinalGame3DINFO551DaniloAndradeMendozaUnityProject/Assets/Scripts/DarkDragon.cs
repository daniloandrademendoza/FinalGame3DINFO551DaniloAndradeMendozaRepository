using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragon : MonoBehaviour {
    private int lifePoints;
    private Animator animatorMonster;
    private IEnumerator coroutine;
    // Use this for initialization
    void Start () {
        lifePoints = 10;
        animatorMonster = GetComponent<Animator>();
       
    }
   
    // Update is called once per frame
    void Update () {
        coroutine = WaitAndPrint(20f, "atk01");
        StartCoroutine(coroutine);
        coroutine = WaitAndPrint(40f, "atk02");
        StartCoroutine(coroutine);
        coroutine = WaitAndPrint(60f, "atk03");
        StartCoroutine(coroutine);
        coroutine = WaitAndPrint(80f, "hit");
        StartCoroutine(coroutine);
        coroutine = WaitAndPrint(100f, "run");
        StartCoroutine(coroutine);
        coroutine = WaitAndPrint(120f, "idle");
        StartCoroutine(coroutine);

    }
    private IEnumerator WaitAndPrint(float waitTime, string attack)
    {
        if (attack == "atk01")
        {
            yield return new WaitForSeconds(waitTime);
            animatorMonster.Play("atk01");
        }
        else if (attack == "atk02")
        {
            yield return new WaitForSeconds(waitTime);
            animatorMonster.Play("atk02");
        }
        else if (attack == "atk03")
        {
            yield return new WaitForSeconds(waitTime);
            animatorMonster.Play("atk03");
        }
        else if (attack == "hit")
        {
            yield return new WaitForSeconds(waitTime);
            animatorMonster.Play("atk03");
        }
        else if (attack == "run")
        {
            yield return new WaitForSeconds(waitTime);
            animatorMonster.Play("atk03");
        }
        else if (attack == "idle")
        {
            yield return new WaitForSeconds(waitTime);
            animatorMonster.Play("atk03");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MAX" && (collision.gameObject.GetComponent<Animation>().IsPlaying("punch")|| collision.gameObject.GetComponent<Animation>().IsPlaying("kick")))
        {
            lifePoints--;
            Debug.Log(lifePoints);
            //StartCoroutine("Wait");
            if (lifePoints == 0)
            {
                animatorMonster.Play("die");
                this.gameObject.SetActive(false);
            }
        }
       
    }
    //IEnumerator Wait()
    //{
    //    for(float i=1f; i>=0; i=i-0.1f)
    //    {
    //        yield return null;
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    StartCoroutine("Wait");
    //}
    
}
