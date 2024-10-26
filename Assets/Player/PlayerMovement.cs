using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    //Variables - Adjust value in script
    [HideInInspector]
    public float posX;
    [HideInInspector]
    public bool moveX;

    [HideInInspector]
    public float posY;
    [HideInInspector]
    public bool moveY;

    [HideInInspector]
    public float posZ;
    [HideInInspector]
    public bool moveZ;


    [HideInInspector]
    public CharacterController controller;

    [HideInInspector]
    public PlayerStuffDJ blockAccessParameters;

    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public Vector3 velocity;
    public bool isGrounded;

    
    public List<KeyCode> keyUp = new List<KeyCode> { KeyCode.W, KeyCode.UpArrow };
    public List<KeyCode> keyLeft = new List<KeyCode> { KeyCode.A, KeyCode.LeftArrow };
    public List<KeyCode> keyDown = new List<KeyCode> { KeyCode.S, KeyCode.DownArrow };
    public List<KeyCode> keyRight = new List<KeyCode> { KeyCode.D, KeyCode.RightArrow };

    public bool isPlayerOne;
    int playerIndex;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();



        //Allow players to move and grab their positions
        moveX = true;
        moveY = true;
        moveZ = true;

  
       
        
        //Sets the key index dependent on if player is player 1
        if (isPlayerOne == true)
        {
            playerIndex = 0;
        }
        else
        {
            playerIndex = 1;
        }

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;

        Vector3 moveDirection = Vector3.zero;



        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        // Movement listeners
        if (moveX)
        {
            if (Input.GetKey(keyLeft[playerIndex]))
            {
                
                moveDirection += Vector3.left; // Move left


               
            }
            if (Input.GetKey(keyRight[playerIndex]))
            {
               
                moveDirection += Vector3.right; // Move right
            }

           
        }

        if (moveZ)
        {
            if (Input.GetKey(keyUp[playerIndex]))
            {
                
                moveDirection += Vector3.forward; // Move forward
            }
            if (Input.GetKey(keyDown[playerIndex]))
            {
                
                moveDirection += Vector3.back; // Move backward
            }
        }
        controller.Move(moveSpeed * Time.deltaTime * moveDirection);


        // Update position
        Vector3 transformVec = new Vector3(posX, posY, posZ);

        if (transformVec - transform.position != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }


        transform.position = transformVec;


        // Rotate to face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }



}
