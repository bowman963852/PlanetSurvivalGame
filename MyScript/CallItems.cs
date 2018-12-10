using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CallItems : MonoBehaviour {

    //public GameObject itemType;
    //public GameObject Forge, SpaceShip;
    public Text LogText, MineText, MetalText;
    public GameObject charObject;
    public GameObject PickAxeIcon;
    public void CallToScene(GameObject item) {
        #region testing
        /*if (itemStr.Equals("cube"))
        {
            GameObject item = GameObject.CreatePrimitive(PrimitiveType.Cube);
            item.transform.position = new Vector3(93f, 1.15f, 43.41f);
        }*/
        /*if (itemStr.Equals("Forge"))
        {
            
            //Instantiate(Forge);

        }*/
        #endregion
        //Instantiate(item);
        if (item.name.Equals("Forge"))
        {
            if (charObject.GetComponent<CommandWalk>().LogCount >= 100
                && charObject.GetComponent<CommandWalk>().MineCount >= 90)
            {
                item.SetActive(true);
                charObject.GetComponent<CommandWalk>().LogCount -= 100;
                charObject.GetComponent<CommandWalk>().MineCount -= 90;

                charObject.GetComponent<CommandWalk>().LogText.text
                    = "Log:" + charObject.GetComponent<CommandWalk>().LogCount;

                charObject.GetComponent<CommandWalk>().MineText.text
                    = "Mine:" + charObject.GetComponent<CommandWalk>().MineCount;
            }
        }
        if (item.name.Equals("SpaceShip"))
        {
            if (charObject.GetComponent<CommandWalk>().LogCount >= 100
                && charObject.GetComponent<CommandWalk>().MineCount >= 60
                && charObject.GetComponent<CommandWalk>().MetalCount >= 30)
            {
                item.SetActive(true);
                charObject.GetComponent<CommandWalk>().LogCount -= 100;
                charObject.GetComponent<CommandWalk>().MineCount -= 60;
                charObject.GetComponent<CommandWalk>().MetalCount -= 30;

                charObject.GetComponent<CommandWalk>().LogText.text
                    = "Log:" + charObject.GetComponent<CommandWalk>().LogCount;

                charObject.GetComponent<CommandWalk>().MineText.text
                    = "Mine:" + charObject.GetComponent<CommandWalk>().MineCount;

                charObject.GetComponent<CommandWalk>().MetalText.text
                    = "Metal:" + charObject.GetComponent<CommandWalk>().MetalCount;
            }
        }
        if (item.name.Equals("water well"))
        {
            if (charObject.GetComponent<CommandWalk>().LogCount >= 60
                && charObject.GetComponent<CommandWalk>().MineCount >= 50)
            {
                item.SetActive(true);
                charObject.GetComponent<CommandWalk>().LogCount -= 60;
                charObject.GetComponent<CommandWalk>().MineCount -= 50;

                charObject.GetComponent<CommandWalk>().LogText.text
                    = "Log:" + charObject.GetComponent<CommandWalk>().LogCount;

                charObject.GetComponent<CommandWalk>().MineText.text
                    = "Mine:" + charObject.GetComponent<CommandWalk>().MineCount;
            }
        }
        

    }
    public void StateChangePickaxe()
    {
        if(charObject.GetComponent<CommandWalk>().havePickaxe == false)
        if (charObject.GetComponent<CommandWalk>().LogCount >= 50)
        {
            charObject.GetComponent<CommandWalk>().LogCount -= 50;
                PickAxeIcon.SetActive(true);
            charObject.GetComponent<CommandWalk>().havePickaxe = true;
            
            charObject.GetComponent<CommandWalk>().LogText.text
                = "Log:" + charObject.GetComponent<CommandWalk>().LogCount;
        }
    }

}