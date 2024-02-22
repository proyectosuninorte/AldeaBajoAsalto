using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;
using Unity.VisualScripting;
public class UIManager : MonoBehaviour
{

    public Slider playerHealthBar;
    public TMP_Text playerHealthText;
    
    public TMP_Text playerLevelText;
    public Slider playerExpBar;
    public Image PlayerAvatar;

    public HealthManager playerHealthManager;
    public CharacterStats playerStats;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        /*
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.Health;

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append("HP: ").
            Append(playerHealthManager.Health).Append("/")
            .Append(playerHealthManager.maxHealth);
        playerHealthText.text = stringBuilder.ToString();

        playerLevelText.text = "Nivel: "+playerStats.level;

        if(playerStats.level >= playerStats.expToLevelUp.Length)
        {
            playerExpBar.enabled = false;
            return;
        }
        playerExpBar.maxValue = playerStats.expToLevelUp[playerStats.level];
        playerExpBar.minValue = playerStats.expToLevelUp[playerStats.level-1];
        playerExpBar.value = playerStats.exp;
        */
    }

    public GameObject inventoryPanel;
    public Button inventoryButton;

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
        if(inventoryPanel.activeInHierarchy )
        {
            // vaciar antes
            foreach(Transform t in inventoryPanel.transform)
            {
                Destroy(t.gameObject);
            }
            FillInventory();
        }
    }

    public void FillInventory()
    {
        WeaponManager manager = FindObjectOfType<WeaponManager>();
        List<GameObject> weapons =  manager
                            .GetAllWeapons();
        int i = 0;
        foreach (GameObject w in weapons)
        {
            Button tempB = Instantiate(inventoryButton,
                                      inventoryPanel.transform);
            tempB.GetComponent<InventoryButton>().type =
                InventoryButton.ItemType.WEAPON;
            tempB.GetComponent<InventoryButton>().itemIndex = i;

            tempB.onClick.AddListener(() => tempB.GetComponent<InventoryButton>
                                        ().ActivateButton());
            tempB.image.sprite = w.GetComponent<SpriteRenderer>().sprite;
            i++;
        }
    }

    public void ChangeHP()
    {
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.Health;
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append("HP: ").
            Append(playerHealthManager.Health).Append("/")
            .Append(playerHealthManager.maxHealth);
        playerHealthText.text = stringBuilder.ToString();
    }

    public void ChangeEXP()
    {
        playerExpBar.maxValue = playerStats.expToLevelUp[playerStats.level];
        playerExpBar.minValue = playerStats.expToLevelUp[playerStats.level - 1];
        playerExpBar.value = playerStats.exp;
    }

    public void ChangeLVL()
    {
        playerLevelText.text = "Nivel: " + playerStats.level;

        if (playerStats.level >= playerStats.expToLevelUp.Length)
        {
            playerExpBar.enabled = false;
            return;
        }
    }
}
