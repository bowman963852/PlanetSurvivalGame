using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchResource : MonoBehaviour {
    public Text LogText;
    public Text MineText;
    public Text MetalText;
    public int LogCount = 0;
    public int MineCount = 0;
    public int MetalCount = 0;
    // Use this for initialization
    public GameObject remote;
    public GameObject WorkShopUI;
    public GameObject ToolMakerUI;
    public GameObject EscapeUI;
    public GameObject energy;
    public GameObject apple, apple1, apple2, apple3;
    public GameObject Well;
    public bool haveWater;
    public GameObject haveWaterIcon;
    public bool havePickaxe;
    
    
    
    void Start()
    {
        LogText.text = "Log:"+LogCount.ToString();
        MineText.text = "Mine:"+MineCount.ToString();
        MetalText.text = "Metal:"+MetalCount.ToString();
        haveWater = true;
        havePickaxe = false;
        
    }
    /*void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "Trees")
        {
            //col.gameObject.transform.position -= new Vector3(8f,0,0);
            //col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            col.gameObject.SetActive(false);
            //Destroy(col.gameObject);
            LogCount += 30;
            LogText.text = "Log:" + LogCount;
            remote.GetComponent<CommandWalk>().isWalking = false;
            remote.GetComponent<CommandWalk>().animator.SetBool("IsWalking",false);
            if(energy.GetComponent<Health>().isThirst == true)
                energy.GetComponent<Health>().CurrentHealth -= 15;
            else
                energy.GetComponent<Health>().CurrentHealth -= 10;
            energy.GetComponent<Health>().thirstValue+=2;
            int willThirst = Random.Range(0, 100);
            if (willThirst <= (energy.GetComponent<Health>().thirstValue + 5))
                energy.GetComponent<Health>().isThirst = true;


            float AppleSpawn = Random.Range(0,1f);
            if (AppleSpawn >= 0.5f)
            {
                switch (col.gameObject.name)
                {
                    case "Oak_Tree":
                        apple.SetActive(true);
                        break;
                    case "Oak_Tree (1)":
                        apple1.SetActive(true);
                        break;
                    case "Oak_Tree (2)":
                        apple2.SetActive(true);
                        break;
                    case "Oak_Tree (3)":
                        apple3.SetActive(true);
                        break;
                }
                
            }
            
        }
        if (col.gameObject.tag == "Mines")
        {
            if (havePickaxe == true)
            {
                col.gameObject.SetActive(false);
                //Destroy(col.gameObject);
                MineCount += 30;
                MineText.text = "Mine:" + MineCount;
                remote.GetComponent<CommandWalk>().isWalking = false;
                remote.GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
                if (energy.GetComponent<Health>().isThirst == true)
                    energy.GetComponent<Health>().CurrentHealth -= 15;
                else
                    energy.GetComponent<Health>().CurrentHealth -= 10;
                energy.GetComponent<Health>().thirstValue += 2;
                int willThirst = Random.Range(0, 100);
                if (willThirst <= (energy.GetComponent<Health>().thirstValue + 5))
                    energy.GetComponent<Health>().isThirst = true;

            }
        }
        if (col.gameObject.tag.Equals("Food"))
        {
            col.gameObject.SetActive(false);
            energy.GetComponent<Health>().CurrentHealth += 5;
            remote.GetComponent<CommandWalk>().isWalking = false;
            remote.GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
        }

        if (col.gameObject.tag.Equals("Workshop"))
        {
            remote.GetComponent<CommandWalk>().isWalking = false;
            remote.GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
            WorkShopUI.SetActive(true);
            Time.timeScale = 0f;
        }
        if (col.gameObject.tag.Equals("ToolMaker"))
        {
            remote.GetComponent<CommandWalk>().isWalking = false;
            remote.GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
            ToolMakerUI.SetActive(true);
            
        }
        if (col.gameObject.tag.Equals("SpaceShip"))
        {
            remote.GetComponent<CommandWalk>().isWalking = false;
            remote.GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
            EscapeUI.SetActive(true);
            Time.timeScale = 0f;
        }
        if (col.gameObject.tag.Equals("water")) { 
        
            if (haveWater == true) { 
                remote.GetComponent<CommandWalk>().isWalking = false;
                remote.GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
                energy.GetComponent<Health>().isThirst = false;
                haveWater = false;
                haveWaterIcon.SetActive(false);
                StartCoroutine(rebornWater());
            }
        }
    }*/
    public void resume()
    {
        Time.timeScale = 1f;
        WorkShopUI.SetActive(false);
    }
    public void ToolMakerCancle()
    {
        ToolMakerUI.SetActive(false);
    }
    public void Resource_Cheat()
    {
        MineCount = 999;
        MetalCount = 999;
        LogCount = 999;

        LogText.text = "Log:" + LogCount;
        MetalText.text = "Metal:" + MetalCount;
        MineText.text = "Mine:" + MineCount;

    }
    public void Metal_Add()
    {
        MineCount -= 30;
        MetalCount += 10;

        MetalText.text = "Metal:" + MetalCount;
        MineText.text = "Mine:" + MineCount;
    }
    public void Metal_Decrease()
    {
        MetalCount -= 10;
        MineCount += 30;

        MetalText.text = "Metal:" + MetalCount;
        MineText.text = "Mine:" + MineCount;
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag.Equals("Workshop"))
        {
            WorkShopUI.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
    IEnumerator rebornWater()
    {
        yield return new WaitForSeconds(432);
        haveWater = true;
        haveWaterIcon.SetActive(true);
    }

}
