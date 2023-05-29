using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHotbar : MonoBehaviour
{

    [Header("Defaults Items")]
    public GameObject slotOne;
    public GameObject slotTwo;
    public GameObject slotThree;
    public GameObject slotFour;

    public static GameObject slot1;
    public static GameObject slot2;
    public static GameObject slot3;
    public static GameObject slot4;

    // Start is called before the first frame update
    void Start()
    {
        slot1 = slotOne;
        slot2 = slotTwo;
        slot3 = slotThree;
        slot4 = slotFour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
