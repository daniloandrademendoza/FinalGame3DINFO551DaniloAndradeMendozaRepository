using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dragon : MonoBehaviour {
    protected int lifePoints;
    protected Animator animatorMonster;
    protected IEnumerator coroutine;
    protected float waitTime;
    protected BoxCollider boxColliderDragon;
    protected float xStartBoxCollider;
    protected float yStartBoxCollider;
    protected float zStartBoxCollider;
    protected float zNewBoxCollider;
    protected float x2NewBoxCollider;
    protected float y2NewBoxCollier;
    public void Start()
    {
        lifePoints = 10;
        animatorMonster = GetComponent<Animator>();
        waitTime = 15f;
        boxColliderDragon = GetComponent<BoxCollider>();
        xStartBoxCollider = 1f;
        yStartBoxCollider = 1f;
        zStartBoxCollider = 1f;
        zNewBoxCollider = 2.5f;
        x2NewBoxCollider = 5.5f;
        y2NewBoxCollier = 2f;
        
    }
    public abstract void Update();
    public abstract IEnumerator WaitAndAttack(float waitTime);
    public abstract void OnCollisionEnter(Collision collision);
}
