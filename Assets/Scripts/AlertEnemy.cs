using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertEnemy : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            transform.GetComponentInParent<EnemyController>().isChasing = true;
            transform.GetComponentInParent<EnemyController>().prey = collision.gameObject;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            try
            {
                transform.GetComponentInParent<EnemyController>().speed = 1.75f;
            }
            catch
            {
                return;
            }
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            try
            {
                transform.GetComponentInParent<EnemyController>().speed = 1f;
                transform.GetComponentInParent<EnemyController>().isChasing = false;
            }
            catch
            {
                return;
            }
           
        }
        
    }
}
