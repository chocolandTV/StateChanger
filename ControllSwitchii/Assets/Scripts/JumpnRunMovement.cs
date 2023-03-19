using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpnRunMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float JumpPower = 0.0f;
    private bool _isJumping= false;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerController.Instance.isJumping && !_isJumping)
        {
            // Jump();
            JumpPower = 5.0f;
        }
        if(PlayerController.Instance.isGrounded)
        {
            _isJumping =false;
        }
        Vector3 input = new Vector3 (PlayerController.Instance.nextDirection.x,(JumpPower -0.89f),0);
        rb.MovePosition(transform.position + input *PlayerController.Instance.movementSpeed * Time.deltaTime);
        // IF GROUNDED OR JUMP COUNT ++ RESET ISJUMPING
        JumpPower=0.0f;
    }
    private void Jump()
    {
    //    rb.AddForce(transform.up * JumpPower);
       _isJumping = true;
       Debug.Log("Jumping");
    }
    
}
