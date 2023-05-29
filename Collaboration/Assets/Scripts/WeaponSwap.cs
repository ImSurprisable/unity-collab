using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{

    public GameObject player;
    public static GameObject equippedItem;
    public Transform hand;
    
    public static GameObject prefabObject;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 handPosition = transform.position;
        Quaternion handRotation = transform.rotation;

        equippedItem = ItemHotbar.slot1;
        prefabObject = Instantiate(equippedItem, handPosition, handRotation, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipItem(ItemHotbar.slot1, hand, prefabObject);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipItem(ItemHotbar.slot2, hand, prefabObject);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipItem(ItemHotbar.slot3, hand, prefabObject);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EquipItem(ItemHotbar.slot4, hand, prefabObject);
        }

    }

    public static void EquipItem(GameObject newEquippedItem, Transform targetTransform, GameObject _prefabObject)
    {
        Destroy(_prefabObject);
        equippedItem = newEquippedItem;
        WeaponSwap.prefabObject = Instantiate(equippedItem, targetTransform.position, targetTransform.rotation, targetTransform);
    }
}


/*

    -Class applied to the player that acts as an inventory of weapons
        -Each weapon assigned to a slot
            -Assignable default weapon variables and public static ones for use in code.
            -Select a slot by pressing the respective number key

    -Use number keys to swap between weapons

*/