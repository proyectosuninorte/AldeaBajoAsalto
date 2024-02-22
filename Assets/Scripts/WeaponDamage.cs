using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;

    private GameObject _hitpoint;
    public GameObject bloodAnim;
    private GameObject currentAnim;
    public GameObject canvasDamage;

    private CharacterStats _stats;
    private void Start()
    {
        _hitpoint = transform.Find("HitPoint").gameObject;
        _stats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float strInc = 1+(_stats.strengthLevels[_stats.level] / 100.0f);
        int totalDamage = (int) (damage * strInc);
        Debug.Log(strInc);
        if (collision.gameObject.tag.Equals("Enemy")){
            if(bloodAnim != null && _hitpoint!= null)
            {
                //Particulas de daño
                currentAnim = Instantiate(bloodAnim, _hitpoint.transform.position, _hitpoint.transform.rotation);
                Destroy(currentAnim, 0.5f);
            }

            var clone = (GameObject)Instantiate(canvasDamage,
                       _hitpoint.transform.position,
                       Quaternion.Euler(Vector3.zero));

            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;

            collision.gameObject.GetComponent<HealthManager>()
                .DamageCharacter(totalDamage);
        }
    }
}
