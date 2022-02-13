using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playeRigidbody;
    float input;
    //so we can edit in the inspecter
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        playeRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");
        playeRigidbody.AddForce(Vector2.right * input * speed * Time.deltaTime);
        //vector2.right == (1,0)
    }
}
