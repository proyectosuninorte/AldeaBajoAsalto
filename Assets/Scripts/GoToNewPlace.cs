using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New scene name here";
    public bool needsClick = false;

    public string uuid;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Teleport(collision.gameObject.name);
             
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

       Teleport(collision.gameObject.name);

    }
    private void Teleport(string objName)
    {
        if (objName == "Player")
        {
            if (!needsClick || (needsClick && Input.GetMouseButtonDown(0)))
            {
                FindObjectOfType<PlayerController>().nextUuid = uuid;
                SceneManager.LoadScene(newPlaceName);
            }
        }
        
        
    }
}
