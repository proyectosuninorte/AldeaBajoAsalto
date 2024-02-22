using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class DamageNumber : MonoBehaviour
{

    public float damageSpeed;
    public float damagePoints;

    
    public TMP_Text damageTextPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageTextPro.text = "" + damagePoints;
        this.transform.position = new Vector3(
            this.transform.position.x, 
            this.transform.position.y + damageSpeed * Time.deltaTime,
            this.transform.position.z);
    }
}
