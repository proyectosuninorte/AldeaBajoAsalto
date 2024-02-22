using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool playerCreated;

    public bool canMove = true;
    public float speed = 5.0f;
    private bool walking = false;
    private bool attacking = false;
    public Vector2 lastMovement = Vector2.zero;

    public float attackTime;
    private float attackTimeCounter;

    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical",
                        WALK = "Walking", LAST_H = "LastH", 
                        LAST_V = "LastV",ATT="Attacking";

    private Animator _animator;
    private Rigidbody2D _rigidBody;

    public string nextUuid;


    // Start is called before the first frame update
    void Start()
    {
        
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
       playerCreated = true;
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;
        if (!canMove)
        {
            _animator.SetBool(ATT, false); //evita q ataque siga
            return;
        }
        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if(attackTimeCounter < 0)
            {
                attacking = false;
                _animator.SetBool(ATT, false);
            }
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            _rigidBody.velocity = Vector2.zero;
            attacking = true;
            attackTimeCounter = attackTime;
            
            _animator.SetBool(ATT,true);
        }

        float horizontalInput = Input.GetAxisRaw(AXIS_H);
        float verticalInput = Input.GetAxisRaw(AXIS_V);

        if (Mathf.Abs(horizontalInput) > 0.2f || Mathf.Abs(verticalInput) > 0.2f)
        {
            walking = true;

            // Normalize the input vector
            Vector2 inputVector = new Vector2(
                horizontalInput, verticalInput).normalized;

            // Set the player's velocity based on the normalized input vector
            _rigidBody.velocity = inputVector * speed;

            lastMovement = inputVector;
        }
    }




    private void LateUpdate()
    {
        if(!walking)
        {
            _rigidBody.velocity = Vector2.zero;
        }

        _animator.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        _animator.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));
        _animator.SetBool(WALK, walking);
        _animator.SetFloat(LAST_H, lastMovement.x);
        _animator.SetFloat(LAST_V, lastMovement.y);
    }
}
