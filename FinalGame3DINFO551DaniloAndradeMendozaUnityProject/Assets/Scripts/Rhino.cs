using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rhino : MonoBehaviour {
    protected int lifePoints;
    protected Animator animatorRhino;
    protected IEnumerator coroutine;
    protected float waitTime;
    protected BoxCollider boxColliderRhino;
    protected float xStartBoxCollider;
    protected float yStartBoxCollider;
    protected float zStartBoxCollider;
    protected float xCenterStartBoxCollider;
    protected float yCenterStartBoxCollider;
    protected float zCenterStartBoxCollider;
    public void Start()
    {
        lifePoints = 10;
        animatorRhino = GetComponent<Animator>();
        waitTime = 15f;
        boxColliderRhino = GetComponent<BoxCollider>();
        xStartBoxCollider = 1f;
        yStartBoxCollider = 2.25f;
        zStartBoxCollider = 2.5f;
        xCenterStartBoxCollider = 0f;
        yCenterStartBoxCollider = .5f;
        zCenterStartBoxCollider = .25f;
}
    public abstract void Update();
    public abstract IEnumerator WaitAndAttack(float waitTime);
    public abstract void OnCollisionEnter(Collision collision);
}
