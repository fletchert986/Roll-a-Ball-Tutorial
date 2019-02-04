using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text livesText;
    public Text winText;
    //public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int lives;
    //private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        SetCountText();
        SetLivesText();
        //SetScoreText();
        winText.text = "";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        /*if (lives <= 0)
        {
            Die();
        }*/
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            //score++;
            //SetScoreText();
        }
        else if (other.gameObject.CompareTag("Anti-Pickup"))
        {
            other.gameObject.SetActive(false);
            //count--;
            //SetCountText();
            //score--;
            //SetScoreText();
            lives--;
            SetLivesText();
        }
    }

    void Die()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win...I Guess?";
        }
        
    }

    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            winText.text = "You Suck!";
            Die();
        }
    }

    /*void SetScoreText()
    {
        scoreText.text = "Lives: " + lives.ToString();
    }*/
}
