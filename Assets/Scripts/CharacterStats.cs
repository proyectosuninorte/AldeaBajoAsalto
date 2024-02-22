using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int level;
    public int exp;

    [Tooltip("exp requerida para subir de nivel")]
    public int[] expToLevelUp;
    public int[] hpLevels;
    public int[] strengthLevels;
    public int[] speedLevels;
    public int[] defenseLevels;
    public int[] luckLevels;


    private HealthManager healthManager;
    private PlayerController playerController;
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        healthManager = GetComponent<HealthManager>();
        playerController = GetComponent<PlayerController>();
        uiManager = FindObjectOfType<UIManager>();
        AddExperience(0);

    }


    public void AddExperience(int exp)
    {
       
        this.exp += exp;
        if (level >= expToLevelUp.Length)
        { //cuando ya está en nivel maximo
            return;
        }
        // - expToLevelUp[level-1]
        if (this.exp  >= expToLevelUp[level])
        {
            level++;
            healthManager.UpdateMaxHealth(hpLevels[level]);
            playerController.attackTime -= speedLevels[level] / 100;
        }
        uiManager.ChangeHP();
        uiManager.ChangeEXP();
        uiManager.ChangeLVL();
    }
}
