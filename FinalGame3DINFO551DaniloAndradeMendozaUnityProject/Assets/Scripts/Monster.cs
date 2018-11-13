using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    private int lifePoints;
	// Use this for initialization
	void Start () {
        lifePoints = 13;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        lifePoints--;
        Debug.Log(lifePoints);
        StartCoroutine("Wait");
        if(lifePoints == 0)
        {
            this.gameObject.SetActive(false);
        }
       
    }
    IEnumerator Wait()
    {
        for(float i=1f; i>=0; i=i-0.1f)
        {
            yield return null;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        StartCoroutine("Wait");
    }
    
}
