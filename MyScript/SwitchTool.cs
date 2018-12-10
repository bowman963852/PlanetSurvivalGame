using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTool : MonoBehaviour {

    public GameObject Tools;
    public GameObject usingAxe;
    public GameObject usingPickaxe;
    public GameObject usingHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchToAxe()
    {
        Tools.GetComponent<CommandWalk>().useAxe = true;
        Tools.GetComponent<CommandWalk>().usePickaxe = false;
        Tools.GetComponent<CommandWalk>().useHand = false;
        usingAxe.SetActive(true);
        usingPickaxe.SetActive(false);
        usingHand.SetActive(false);
    }

    public void SwitchToHand()
    {
        Tools.GetComponent<CommandWalk>().useHand = true;
        Tools.GetComponent<CommandWalk>().usePickaxe = false;
        Tools.GetComponent<CommandWalk>().useAxe = false;
        usingHand.SetActive(true);
        usingPickaxe.SetActive(false);
        usingAxe.SetActive(false);
    }
    public void SwitchToPickaxe()
    {
        if (Tools.GetComponent<CommandWalk>().havePickaxe = true)
        {
            Tools.GetComponent<CommandWalk>().usePickaxe = true;
            Tools.GetComponent<CommandWalk>().useAxe = false;
            Tools.GetComponent<CommandWalk>().useHand = false;
            usingPickaxe.SetActive(true);
            usingAxe.SetActive(false);
            usingHand.SetActive(false);
        }
    }
}
