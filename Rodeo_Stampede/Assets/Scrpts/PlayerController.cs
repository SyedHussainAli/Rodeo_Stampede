using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int speed = 5;
    private float horizontalInput;
    private Rigidbody playerRb;
    private bool onAnimal=true;
    public bool gameOver = false;
    private GameObject child;
    private int scores = 0;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
        if(Input.GetKeyUp(KeyCode.Space) && onAnimal)
        {
            if (child != null)
            {
                Debug.Log("working");
                /*   child = transform.Find("Animal");
                   child.transform.parent = null;*/

               gameObject.transform.DetachChildren();
            }
            else
                Debug.Log("NoChild");

            playerRb.AddRelativeForce(0, 400, 200);
            onAnimal = false;

            scores += 25;
            Debug.Log("Scores is : " + scores);
        }

    }

    private void PlayerMovement()
    {
        if (!gameOver) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * 0.9f);
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") )
        {
            Debug.Log("gameOver");
            Debug.Log("Your Score is: " + scores);

            gameOver = true;
        }
        if(collision.gameObject.CompareTag("Animal"))
        {
            onAnimal = true;
              collision.gameObject.transform.parent = transform  ;
            child = collision.gameObject;
            transform.position = new Vector3(transform.position.x, 1.54f, transform.position.z);
         //   child.transform.localPosition = Vector3.zero;
            child.transform.position = new Vector3(transform.position.x,transform.position.y-1f , transform.position.z );
           /* scores += 25;
            Debug.Log("Scores is : " + scores);*/

        }
    }
}
