using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallController : MonoBehaviour
{
    Rigidbody2D ballRigidbody;

    public float speed;
    public float randomUp;

    Vector3 startPosition;

    GameControllers cont;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();

        startPosition = transform.position;

        cont = FindObjectOfType<GameControllers>();
    }

    private void OnEnable()
    {
        Invoke("PushBall", 1f);
    }

    void PushBall()
    {
        int dir = Random.Range(0, 2);
        float x;
        if (dir == 0)
            x = speed;
        else
            x = -speed;

        ballRigidbody.AddForce(new Vector2(x, -randomUp));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.y = ballRigidbody.velocity.y;
            //y no change, change x
            vel.x = ballRigidbody.velocity.x / 2 + collision.collider.attachedRigidbody.velocity.x / 2;
            ballRigidbody.velocity = vel;
        }

        if (collision.gameObject.CompareTag("Brick"))
        {
            cont.HitBrick();
            //hitbrick Function
            Destroy(collision.gameObject);
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            cont.LoseLive();
            //Lose Life Function 
            ballRigidbody.velocity = Vector2.zero;
            transform.position = startPosition;
            Invoke("PushBall", 2f);
        }
    }
}
