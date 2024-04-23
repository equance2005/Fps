using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController characterController;
    public float walkspeed = 10f;//�����ٶ�
    public float runspeed = 15f;//�����ٶ�
    public float speed;
    public Vector3 moveDirection;//�����ƶ�����

    public Transform groundCheck;
    public float groundDistance = 0.41f;
    public LayerMask groundMash;

    public float jumpForce = 3f;
    public Vector3 velocity;
    public float gravity = -75f;//����


    public bool isRun;
    private bool isJump;
    private bool isGround;


    public float slopeForce = 6.0f;
    public float slopeForceRayLength = 2.0f;


    [Header("��������")]
    public AudioSource audioSource;
    public AudioClip walkingSound;
    public AudioClip runingSound;

    [Header("��λ����")]
   [Tooltip("���ܰ���")] public KeyCode runInputName;//���ܼ�λ
   [Tooltip("��Ծ����")] public string jumpInputName = "Jump";



    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();  
        runInputName = KeyCode.LeftShift;
  
    }

    private void Update()
    {
        CheckGround();
        Move();
    } 


    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        isRun  = Input.GetKey(runInputName);
        if(isRun)
        {
            speed = runspeed;

        }
        else
        {
            speed = walkspeed;
        }
         

        moveDirection = (transform.right * h + transform.forward * v).normalized; //���÷���
        characterController.Move(moveDirection*speed*Time.deltaTime);
        if(isGround== false)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        characterController.Move(velocity*Time.deltaTime);
        Jump();
        if(OnSlpe())
        {
            characterController.Move(Vector3.down * characterController.height / 2 * slopeForce*Time.deltaTime);
        }
        PlayFootStepSound();
    }


    public void PlayFootStepSound()
    {
        if (isGround && moveDirection.sqrMagnitude > 0.9f)
        {
            audioSource.clip = isRun ? runingSound : walkingSound;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();

            }
        }
        else
       {
        if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }

       }


    }


    


    public void Jump()
    {
        
      isJump =  Input.GetButtonDown(jumpInputName);
        if(isJump && isGround)
        {
            velocity.y = Mathf.Sqrt( jumpForce * -2f * gravity);
        }
    }


    public void CheckGround()
    {

       isGround = Physics.CheckSphere(groundCheck.position,groundDistance, groundMash);
        if(isGround && velocity.y<=0)
        {

            velocity.y = -2f; 

        }




    }

    public bool OnSlpe()
    {
        if (isJump)
            return false;

        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit,characterController.height/2 * slopeForceRayLength))
        {
           
            if (hit.normal != Vector3.up)
            {
                return true;
            }


        }
        return false;

    }



}
