using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidBodyPlayer;
    private float playerSpeed;
    private float playerSpeedRun;
    private Animation animationPlayer;
    private float jumpForce;
    private BoxCollider boxColliderPlayer;
    private float punch;
    private float kick;
    public int lifePoints;
    // Use this for initialization
    void Start()
    {
        rigidBodyPlayer = GetComponent<Rigidbody>();
        playerSpeed = 5f;
        playerSpeedRun = 10f;
        animationPlayer = GetComponent<Animation>();
        jumpForce = 2.5f;
        boxColliderPlayer = GetComponent<BoxCollider>();
        punch = 0f;
        kick = 0f;
        lifePoints = 100;
    }

    // Update is called once per frame
    void Update()
    {
       
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
            if (Input.GetKey(KeyCode.R))
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
            if (Input.GetKey(KeyCode.R))
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
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.R))
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
        else if (Input.GetKey(KeyCode.F))
        {
            animationPlayer.Play("flip");
        }
        else if (Input.GetKey(KeyCode.P))
        {
            animationPlayer.Play("punch");
            boxColliderPlayer.size = new Vector3(0.75f, 1.85f, 1.25f);
            boxColliderPlayer.center = new Vector3(0f, 1f, 0.5f);
           // StartCoroutine(Wait());
           
        }
       
        else if (Input.GetKey(KeyCode.K))
        {
            animationPlayer.Play("kick");
            boxColliderPlayer.size = new Vector3(1.75f, 2f, 1.75f);
            boxColliderPlayer.center = new Vector3(0.5f, 1.5f, 0.5f);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            rigidBodyPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animationPlayer.Play("jump");
        }
        if (this.transform.position.y >= .1)
        {
            rigidBodyPlayer.useGravity = true;
            //this.transform.position= new Vector3(this.transform.position.x,0f,this.transform.position.z);
        }
        else
        {
            rigidBodyPlayer.useGravity = false;
        }
        if (!animationPlayer.IsPlaying("punch")&& !animationPlayer.IsPlaying("kick"))
        {
            boxColliderPlayer.size = new Vector3(.75f, 1.9f, .75f);
            boxColliderPlayer.center = new Vector3(0f, .95f, 0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (Input.GetKey(KeyCode.P))
        {
           
            punch = punch + (1 / 10);
        }
        else if(Input.GetKey(KeyCode.K))
        {
            kick = kick + (1 / 10);
        }
        else if (collision.gameObject.name == "DarkDragon1"|| collision.gameObject.name == "DarkDragon2"|| collision.gameObject.name == "DarkDragon3"|| collision.gameObject.name == "DarkDragon4"|| collision.gameObject.name == "DarkDragon5"|| collision.gameObject.name == "DarkDragon6"|| collision.gameObject.name == "DarkDragon7"|| collision.gameObject.name == "DarkDragon8"|| collision.gameObject.name == "DarkDragon9"|| collision.gameObject.name == "DarkDragon10")
        {
            lifePoints--;
            Debug.Log(lifePoints);
        }
        if(lifePoints==0)
        {
            this.animationPlayer.Play("death");
            this.gameObject.SetActive(false);
        }
        
    }
   // IEnumerator Wait()
   // {
        
       
        //    yield return new WaitForSeconds(60); 
        
    //}
}
