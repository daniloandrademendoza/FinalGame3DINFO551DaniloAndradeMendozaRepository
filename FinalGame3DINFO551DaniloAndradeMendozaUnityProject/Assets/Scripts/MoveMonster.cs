using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveMonster : MonoBehaviour {
    public float timeMove;
    public LayerMask collisionLayer;
    private BoxCollider boxColliderMonster;
    private Rigidbody rigidBodyMonster;
    private float inverseTimeMove;
	// Use this for initialization
	protected virtual void Start () {
        timeMove = .1f;
        boxColliderMonster = GetComponent<BoxCollider>();
        rigidBodyMonster = GetComponent<Rigidbody>();
        inverseTimeMove = 1f / timeMove;
	}
    protected bool MoveEnemy(int x, int y, int z, out RaycastHit rayCastHit)
    {
        Vector3 begin = transform.position;
        Vector3 finish = begin + new Vector3(x, y, z);
        boxColliderMonster.enabled = false;
        rayCastHit = Physics.Linecast(begin, finish, collisionLayer);
        boxColliderMonster.enabled = true;
        if(rayCastHit.transform == null)
        {
            StartCoroutine(moveSteady(finish));
            return true;
        }
    }
    protected IEnumerator moveSteady(Vector3 finish)
    {
        float distanceLeft = (transform.position - finish).sqrMagnitude;
        while(distanceLeft> float.Epsilon)
        {
            Vector3 newLocation = Vector3.MoveTowards(rigidBodyMonster.position, finish, inverseTimeMove * Time.deltaTime);
            rigidBodyMonster.MovePosition(newLocation);
            distanceLeft = (transform.position - finish).sqrMagnitude;
            yield return null;
        }
    }
    protected abstract void onCantMove<T>(T component)
        where T : Component;


	
}
