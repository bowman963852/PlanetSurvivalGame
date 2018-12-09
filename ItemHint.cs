using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemHint : MonoBehaviour {

    // Update is called once per frame
    public GameObject itemtip;
    public Text ItemDescript;
	void Update () {
        GameObject hitObject = GvrPointerInputModule.CurrentRaycastResult
            .gameObject;
        if (hitObject.tag.Equals("Items"))
        {
            
            if (hitObject.name.Equals("Forge"))
            {
                ItemDescript.text = "Forge\r\n" +
                                    "costs:\r\n" +
                                    "100 Logs\r\n" +
                                    "90 mines";
            }
            if (hitObject.name.Equals("SpaceShip"))
            {
                ItemDescript.text = "SpaceShip\r\n " +
                                    "costs:\r\n" +
                                    "100 Logs\r\n" +
                                    "60 mines\r\n"+
                                    "30 metals\r\n";
            }
            if (hitObject.name.Equals("Well"))
            {
                ItemDescript.text = "SpaceShip\r\n " +
                                    "costs:\r\n" +
                                    "60 Logs\r\n" +
                                    "50 mines\r\n";

            }
            itemtip.SetActive(true);
        }
        else
            itemtip.SetActive(false);
    }
}
