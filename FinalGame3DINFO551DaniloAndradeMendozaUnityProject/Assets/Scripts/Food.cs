using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : MonoBehaviour {
    protected int lifePointsFood;
    protected int lifePointsNeeded;
    public abstract void Start();
    public abstract void OnCollisionEnter(Collision collision);
}
