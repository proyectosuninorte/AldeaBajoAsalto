using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryButton : MonoBehaviour
{
    public enum ItemType { WEAPON,ITEM,ARMOR}; //RING?

    public int itemIndex;

    public ItemType type;

    public void ActivateButton()
    {
        switch(type)
        {
            case ItemType.WEAPON:
                FindObjectOfType<WeaponManager>().
                    ChangeWeapon(itemIndex);
                break;
            case ItemType.ITEM:
                //
                break;
            case ItemType.ARMOR:
                //
                break;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
