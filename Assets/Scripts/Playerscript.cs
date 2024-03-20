using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class Playerscript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D myBody;
    public float moveSpeed = 2f;
    private int score;
    public TMP_Text scoreText, recordText;
    private BoxCollider2D box;


    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        box =  GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        score = 0;
        recordText.text = PlayerPrefs.GetInt("record", 0).ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if(Input.GetAxisRaw("Horizontal")>0f)
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
    }
    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.CompareTag("plataforma"))
        {

            score++;
            PlayerPrefs.SetInt("record", 0);
            scoreText.text = score.ToString();
        }
        if (other.collider.CompareTag("plataforma1"))
        {

            score = score + 4; ;
        }
        if (other.collider.CompareTag("plataforma2"))
        {

            score = score + 2; ;
        }
    }


    public void Update()
    {
        scoreText.text = score.ToString();
        if(score > PlayerPrefs.GetInt("record", 0))
        {
            PlayerPrefs.SetInt("record", score);
            //recordText.text = PlayerPrefs.GetInt("record", 0).ToString();
        }
    }

}
