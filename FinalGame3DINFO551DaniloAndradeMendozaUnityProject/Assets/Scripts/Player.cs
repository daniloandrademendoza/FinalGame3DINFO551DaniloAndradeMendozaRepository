using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody rigidBodyPlayer;
    private float playerSpeed;
    private float playerSpeedRun;
    private Animation animationPlayer;
	// Use this for initialization
	void Start () {
        rigidBodyPlayer = GetComponent<Rigidbody>();
        playerSpeed = 5f;
        playerSpeedRun = 10f;
        animationPlayer = GetComponent<Animation>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.R))
            {
                rigidBodyPlayer.velocity = new Vector3(rigidBodyPlayer.velocity.x, 0f, playerSpeedRun);
                this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                animationPlayer.Play("run");
            }
            else
            {
                rigidBodyPlayer.velocity = new Vector3(rigidBodyPlayer.velocity.x, 0f, playerSpeed);
                this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                animationPlayer.Play("walk");
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(Input.GetKey(KeyCode.R))
            {
                rigidBodyPlayer.velocity = new Vector3(-playerSpeedRun, 0f, rigidBodyPlayer.velocity.z);
                this.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                animationPlayer.Play("run");
            }
            else
            {
                rigidBodyPlayer.velocity = new Vector3(-playerSpeed, 0f, rigidBodyPlayer.velocity.z);
                this.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                animationPlayer.Play("walk");
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if(Input.GetKey(KeyCode.R))
            {
                rigidBodyPlayer.velocity = new Vector3(rigidBodyPlayer.velocity.x, 0f, -playerSpeedRun);
                this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                animationPlayer.Play("run");
            }
            else
            {
                rigidBodyPlayer.velocity = new Vector3(rigidBodyPlayer.velocity.x, 0f, -playerSpeed);
                this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                animationPlayer.Play("walk");
            }
           

        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            if(Input.GetKey(KeyCode.R))
            {
                rigidBodyPlayer.velocity = new Vector3(playerSpeedRun, 0f, rigidBodyPlayer.velocity.z);
                this.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                animationPlayer.Play("run");
            }
            else
            {
                rigidBodyPlayer.velocity = new Vector3(playerSpeed, 0f, rigidBodyPlayer.velocity.z);
                this.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                animationPlayer.Play("walk");
            }
        }
        else if(Input.GetKey(KeyCode.J))
        {
            animationPlayer.Play("jump");
        }
        else if (Input.GetKey(KeyCode.F))
        {
            animationPlayer.Play("flip");
        }
        else if (Input.GetKey(KeyCode.P))
        {
            animationPlayer.Play("punch");
        }
        else if (Input.GetKey(KeyCode.K))
        {
            animationPlayer.Play("kick");
        }
        
    }
}
