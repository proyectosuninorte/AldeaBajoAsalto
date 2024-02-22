using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update

    /*[Tooltip("Tiempo que tarda el jugador en revivir")]
    public float timeToRevivePlayer;
    private float timeRevivalCounter;
    private bool playerReviving;*/

    public int damage;
    public GameObject canvasDamage;
    private UIManager manager;

    private CharacterStats _stats;
    private void Start()
    {
        _stats = GameObject.Find("Player").GetComponent<CharacterStats>();
        manager = FindObjectOfType<UIManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float defInc = (1 - _stats.defenseLevels[_stats.level] / 100.0f);
        int totalDamage = (int) (damage*defInc) ;

        totalDamage = Mathf.Clamp(totalDamage, 1, 999);


        float missProb = _stats.luckLevels[_stats.level];
        if(Random.Range(0,100)<missProb)
        {
            totalDamage = 0;
        }

        if (totalDamage < 0 )
        {
            totalDamage = 0;
        }
        
        if (collision.gameObject.name.Equals("Player"))
        {
            var clone = (GameObject)Instantiate(canvasDamage,
                collision.gameObject.transform.position,
                Quaternion.Euler(Vector3.zero));

            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;

            collision.gameObject.GetComponent<HealthManager>().
                DamageCharacter(totalDamage);
            
            manager.ChangeHP();
        }

        
    }
    // Update is called once per frame
    /*void Update()
    {
        if(playerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;
            if(timeRevivalCounter < 0)
            {
                playerReviving=false;
                thePlayer.SetActive(true);
            }
        }
    }*/
}
