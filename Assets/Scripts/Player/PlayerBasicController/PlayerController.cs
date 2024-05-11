using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    CharacterController controller;
    public LayerMask mask;
    public Transform ground;
    private FlashlightController fc;

    [Header("Speed")]
    private float _speed=5;
    public float originalSpeed;
    private float _maxRunSpeed=9f;
    private float _minRunSpeed=2f;


    [Header("Gravity")]
    Vector3 velocity;
    bool isGrounded;
    public float distance = 0.3f;
    public float jumpHeight;
    public float gravity;
    public float originalHeight;
    public float crouchHeight;

    private void Start()
    {
        fc=GameObject.Find("Flashlight").GetComponent<FlashlightController>();
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        fc.Flashlight();
        Movement();
        Crouch();
        Running();
        jump();
    }
    void Movement()
    {
        if(_speed!=0)
        {
            originalSpeed= _speed;
        }
        
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");

        Vector3 move=transform.right*horizontal+transform.forward*vertical;
        controller.Move(move*_speed*Time.deltaTime);   
    }
    void jump()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            velocity.y+=Mathf.Sqrt(jumpHeight*-3.0f*gravity);
        }   
        //ground check
        isGrounded=Physics.CheckSphere(ground.position, distance,mask);

        if (isGrounded&&velocity.y<0)
            velocity.y=0f;

        velocity.y+=gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }

    #region Crouch
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            {
            controller.height=crouchHeight;
            _speed=_minRunSpeed;
            isGrounded=false;
            gravity=-150f;
            }
        if (Input.GetKeyUp(KeyCode.LeftControl))
            {
            controller.height=originalHeight;
            _speed=5f; 
            gravity=-15f;
            }
    }
    #endregion

    #region  Running
    public void Running()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _speed=_maxRunSpeed;
            }
        if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _speed=5f;
            }
    }
    #endregion
}
