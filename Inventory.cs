using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    // Use this for initialization
    public GameObject InventoryUI;
    public GameObject ResourceUI;
    public void CallInventory()
    {
        if (InventoryUI.activeSelf)
        {
            InventoryUI.SetActive(false);
            ResourceUI.SetActive(false);
        }
        else
        {
            InventoryUI.SetActive(true);
            ResourceUI.SetActive(true);
        }


    }
}
