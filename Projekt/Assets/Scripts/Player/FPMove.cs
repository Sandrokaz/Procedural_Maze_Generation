using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMove : MonoBehaviour
{

    [SerializeField] private float playerSpeed;

    public bool isMoving = false;
    
    Rigidbody rb;
    AudioSource stepSound;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stepSound = GetComponent<AudioSource>();
    }



    private void Update()
    {
        if (!isMoving)
        {
            Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, Input.GetAxis("Vertical") * playerSpeed);
            rb.velocity = transform.rotation * new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.y);
            
        }
       

      
    }

}