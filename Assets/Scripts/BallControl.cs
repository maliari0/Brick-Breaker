using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upForce = 500;
    public bool inPlay;
    public Transform Paddle;
    public Transform explosion;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            transform.position = Paddle.position;
           
        }
        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * upForce);
        }
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {
            Debug.Log("Ball hit the bottom wall");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);

            
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject,2.5f);

            gm.UpdateScore(other.gameObject.GetComponent<BrickScript>().points);

            Destroy(other.gameObject);
            
        }
    }
    
}
