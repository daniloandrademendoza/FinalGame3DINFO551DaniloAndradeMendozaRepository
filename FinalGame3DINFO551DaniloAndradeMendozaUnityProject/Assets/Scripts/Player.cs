using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody rigidBodyPlayer;
    private float playerSpeed;
	// Use this for initialization
	void Start () {
        rigidBodyPlayer = GetComponent<Rigidbody>();
        playerSpeed = 2f;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBodyPlayer.velocity = new Vector3(rigidBodyPlayer.velocity.x,0f,playerSpeed);
            this.transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBodyPlayer.velocity = new Vector3(-playerSpeed,0f,rigidBodyPlayer.velocity.z);
            this.transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBodyPlayer.velocity = new Vector3(rigidBodyPlayer.velocity.x,0f,-playerSpeed);
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rigidBodyPlayer.velocity = new Vector3(playerSpeed,0f,rigidBodyPlayer.velocity.z);
            this.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
	}
}
