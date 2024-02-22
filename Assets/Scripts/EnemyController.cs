using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public bool isChasing=false;
    public bool isMoving;
    public GameObject prey;
    private Rigidbody2D _rigidBody;

    public Vector2 directionToMove;

    public float speed = 1.0f;
    [Tooltip("Tiempo entre Movimientos")]
    public float timeBetweenSteps;
    private float timeBetweenStepsCounter;

    [Tooltip("Tiempo que tarda en moverse")]
    public float timeToMakeStep;
    private float timeToMakeStepCounter;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        timeBetweenStepsCounter = timeBetweenSteps*Random.Range(0.5f,1.5f);
        timeToMakeStepCounter = timeToMakeStep*Random.Range(0.5f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChasing)
        {
            if (isMoving)
            {
                timeToMakeStepCounter -= Time.deltaTime;
                _rigidBody.velocity = directionToMove * speed;
                if (timeToMakeStepCounter < 0)
                { // cuando ya pasó tiempo de moverse
                    isMoving = false;
                    timeBetweenStepsCounter = timeBetweenSteps;
                    _rigidBody.velocity = Vector2.zero;
                }
            }
            else
            {
                timeBetweenStepsCounter -= Time.deltaTime;
                if (timeBetweenStepsCounter < 0)
                {
                    isMoving = true;
                    timeToMakeStepCounter = timeToMakeStep;
                    directionToMove = new Vector2(Random.Range(-1, 2),
                                                Random.Range(-1, 2));

                }

            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, prey.transform.position, speed * Time.deltaTime);
        }
      
    }

    /// <summary>
    /// Añadido por David, detiene al enemigo al chocar al jugador
    /// </summary>
    /// <param name="collision"></param>


    /*
     private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("Brake", 0.2f);
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        prey = collision.gameObject;
        speed = 1.5f;
        isChasing = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isChasing = false;
    }
    private void Brake()
    {
        _rigidBody.velocity = Vector2.zero; 
    }*/


}
