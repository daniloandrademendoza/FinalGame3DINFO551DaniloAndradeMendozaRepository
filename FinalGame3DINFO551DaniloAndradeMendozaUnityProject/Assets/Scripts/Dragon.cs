using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dragon : MonoBehaviour {
    protected int lifePoints;
    protected Animator animatorMonster;
    protected IEnumerator coroutine;
    protected float waitTime;
    protected BoxCollider boxColliderDragon;
    protected float zNewBoxCollider;
    protected float zStartBoxCollider;
    public void Start()
    {
        lifePoints = 10;
        animatorMonster = GetComponent<Animator>();
        waitTime = 15f;
        boxColliderDragon = GetComponent<BoxCollider>();
        zNewBoxCollider = 2.5f;
        zStartBoxCollider = 1f;
    }
    public abstract void Update();
    public abstract IEnumerator WaitAndAttack(float waitTime);
    public abstract void OnCollisionEnter(Collision collision);
}
