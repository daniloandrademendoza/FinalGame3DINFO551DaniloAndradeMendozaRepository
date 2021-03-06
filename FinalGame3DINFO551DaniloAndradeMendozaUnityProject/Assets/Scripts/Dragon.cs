﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dragon : MonoBehaviour {
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
    protected float dieWaitTime;
    public void Start()
    {
        animatorMonster = GetComponent<Animator>();
        waitTime = 15f;
        boxColliderDragon = GetComponent<BoxCollider>();
        xStartBoxCollider = 1f;
        yStartBoxCollider = 1f;
        zStartBoxCollider = 1f;
        zNewBoxCollider = 2.5f;
        x2NewBoxCollider = 5.5f;
        y2NewBoxCollier = 2f;
        dieWaitTime = 10f;
    }
    public abstract void Update();
    public abstract IEnumerator WaitAndAttack(float waitTime);
    public abstract void OnCollisionEnter(Collision collision);
    public IEnumerator DieThenDisappearDarkDragon(float waitTime)
    {
        this.animatorMonster.Play("die");
        this.gameObject.SetActive(false);    
        yield return new WaitForSeconds(waitTime);
    }
    public IEnumerator DieThenDisappearFourDragons(float waitTime)
    {
         this.animatorMonster.Play("Die");
        this.gameObject.SetActive(false);
         yield return new WaitForSeconds(waitTime);

    }
}

