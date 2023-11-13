using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;
    bool wDown;
    bool jDown;
    bool isJump;

    Vector3 moveVec;
    Rigidbody rigid;
    Animator anim;

    public PlayerInput playerInput;
    public Vector2 movementInput;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        playerInput = CharacterSelected.instance.playerInput;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Character_Selector" || WelcomeText.displayingText)
            return;

        GetInput();
        Move();
        Turn();
        Jump();

    }

    void GetInput()
    {
        movementInput = playerInput.actions["Move"].ReadValue<Vector2>();

        //hAxis = Input.GetAxis("Horizontal");
        //vAxis = Input.GetAxis("Vertical");
        //wDown = Input.GetButton("Walk");
        wDown = playerInput.actions["Walk"].IsPressed();
        jDown = playerInput.actions["Jump"].WasPressedThisFrame();
        //jDown = Input.GetButtonDown("Jump");
    }


    void Move()
    {
        moveVec = new Vector3(movementInput.x, 0, movementInput.y)/*new Vector3(hAxis, 0, vAxis)*/.normalized;

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;
        //rigid.velocity = moveVec * speed * (wDown ? 0.3f : 1f);
        //rigid.velocity = new Vector3(rigid.velocity.x, -9.81f, rigid.velocity.z);

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 50, ForceMode.Impulse);
            //rigid.velocity = new Vector3(rigid.velocity.x, 550, rigid.velocity.z);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }



}
