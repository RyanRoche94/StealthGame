using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    Animator animator;
    Vector2 input;


    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
    }
    void FixedUpdate()
    {
        // Detect X Key press 
        if (Input.GetKey(KeyCode.X))
        {
            // Set the Crouch Layer Weight to 0.5, this  
            // activtes the masked couch animation 
            animator.SetLayerWeight(1, 0.5f);

        }
        else
        {
            // Set the Couch Layer Weight back to 0.0 
            // This deactivated the crouch animation 
            animator.SetLayerWeight(1, 0.0f);
        }
    }
}
