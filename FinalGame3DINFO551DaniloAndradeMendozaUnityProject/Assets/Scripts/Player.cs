using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rigidBodyPlayer;
    private float playerSpeed;
    public float playerSpeedRun;
    private Animation animationPlayer;
    public float jumpForce;
    private BoxCollider boxColliderPlayer;
    delegate void MyDelegate(string input);
    MyDelegate myDelegate;
    public GameObject[] dragons;
    public int dragonsDead;
    public string gameSceneString;
    private float waitTime;
    void Start()
    {
        rigidBodyPlayer = GetComponent<Rigidbody>();
        playerSpeed = 5f;
        playerSpeedRun = 10f;
        animationPlayer = GetComponent<Animation>();
        jumpForce = 2.5f;
        boxColliderPlayer = GetComponent<BoxCollider>();
        dragonsDead = 0;
        gameSceneString = " ";
        waitTime = 30f;
    }
    
    void Update()
    {
        myDelegate = Controls;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            myDelegate("up");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myDelegate("left");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            myDelegate("down");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myDelegate("right");
        }
        else if (Input.GetKey(KeyCode.F))
        {
            myDelegate("flip");
        }
        else if (Input.GetKey(KeyCode.P))
        {
            myDelegate("punch");
        }
        else if (Input.GetKey(KeyCode.K))
        {
            myDelegate("kick");
        }
        else if (Input.GetKey(KeyCode.J))
        {
            myDelegate("jump");
        }
        if (this.transform.position.y >= .1)
        {
            rigidBodyPlayer.useGravity = true;
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
        dragonsDead = Game2();
        if(dragonsDead==10)
        {
            gameSceneString = "Game2";
            SceneManager.LoadScene("Game2");
           
        }
        if(dragonsDead==4&&gameSceneString=="Game2")
        {
            SceneManager.LoadScene("Won");
        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        for (int k=0; k<dragons.Length; k++)
        {
            if (collision.gameObject == dragons[k])
            {
                PersistentData.singleton.lifePoints--;
            }
        }
        if (PersistentData.singleton.lifePoints == 0)
        {
            StartCoroutine(DieThenDisappear(this.waitTime));
            SceneManager.LoadScene("GameOver");
        }
    }

    void Controls(string input)
    {
        if (input == "up")
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
        else if (input == "left")
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
        else if (input == "down")
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
        else if (input == "right")
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
        else if (input == "flip")
        {
            animationPlayer.Play("flip");
        }
        else if (input == "punch")
        {
            animationPlayer.Play("punch");
            boxColliderPlayer.size = new Vector3(0.75f, 1.85f, 1.25f);
            boxColliderPlayer.center = new Vector3(0f, 1f, 0.5f);
        }
        else if (input == "kick")
        {
            animationPlayer.Play("kick");
            boxColliderPlayer.size = new Vector3(1.75f, 2f, 1.75f);
            boxColliderPlayer.center = new Vector3(0.5f, 1.5f, 0.5f);
        }
        else if(input=="jump")
        {
            animationPlayer.Play("jump");
            rigidBodyPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
        int Game2()
        {
        int j = 0;
        for(int i=0; i<dragons.Length;i++)
        {
            if(dragons[i].activeInHierarchy==false)
            {
                j++;
            }
        }
        return j;
        }
    public IEnumerator DieThenDisappear(float waitTime)
    {
        this.animationPlayer.Play("death");
        yield return new WaitForSeconds(waitTime);
        this.gameObject.SetActive(false);
    }
}
