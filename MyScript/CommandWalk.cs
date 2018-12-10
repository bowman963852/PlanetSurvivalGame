using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandWalk : MonoBehaviour {
    public GameObject Character;
    // Use this for initialization
    public float speed = 0.05f;
    public bool isWalking;
    bool isRotate;
    Vector3 target;
    public Animator animator;
    public GameObject cam;
    Quaternion camRot;
    public Text speedtest;
    public Text distText;

    public Text LogText;
    public Text MineText;
    public Text MetalText;
    public int LogCount = 0;
    public int MineCount = 0;
    public int MetalCount = 0;
    // Use this for initialization
    //public GameObject remote;
    public GameObject WorkShopUI;
    public GameObject ToolMakerUI;
    public GameObject EscapeUI;
    public GameObject energy;
    public GameObject apple, apple1, apple2, apple3;
    public GameObject Well;
    public bool haveWater;
    public GameObject haveWaterIcon;
    public bool havePickaxe;
    public bool usePickaxe;
    public bool useAxe;
    public bool useHand;
    void Start()
    {
        isWalking = false;
        isRotate = false;
        LogText.text = "Log:" + LogCount.ToString();
        MineText.text = "Mine:" + MineCount.ToString();
        MetalText.text = "Metal:" + MetalCount.ToString();
        haveWater = true;
        useHand = true;
        useAxe = false;
        havePickaxe = false;
        usePickaxe = false;

    }

    // Update is called once per frame
    void LookAt(Vector3 target)
    {
        camRot = cam.transform.rotation;

        Vector3 direction = target - Character.transform.position;
        Quaternion rotate = Quaternion.LookRotation(direction);
        Character.transform.rotation = rotate;
    }
    void Move()
    {
        Character.transform.position = Vector3.MoveTowards(Character.transform.position
                                                            , target
                                                            , speed * Time.deltaTime);
        animator.SetBool("IsRunning", true);
        FindObjectOfType<MusicManager>().Play("main");
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
    public void ToolMakerCancle()
    {
        ToolMakerUI.SetActive(false);
        Time.timeScale = 1f;
    }
    IEnumerator rebornWater()
    {
        yield return new WaitForSeconds(432);
        haveWater = true;
        haveWaterIcon.SetActive(true);
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
    public void resume()
    {
        Time.timeScale = 1f;
        WorkShopUI.SetActive(false);
    }
    void Update()
    {
        GameObject tarObj = GvrPointerInputModule.CurrentRaycastResult.gameObject;
        if (tarObj.tag.Equals("Trees")
            || tarObj.tag.Equals("Mines")
            || tarObj.tag.Equals("Food")
            || tarObj.gameObject.tag.Equals("Workshop")
            || tarObj.gameObject.tag.Equals("ToolMaker")
            || tarObj.gameObject.tag.Equals("SpaceShip")
            || tarObj.gameObject.tag.Equals("water"))
        {
            float dist = Vector3.Distance(tarObj.transform.position
                , Character.transform.position);
            distText.text = "Object is:"+tarObj.tag+"\nDistance:" 
                + dist.ToString("0.00") + "\n";

            //col.gameObject.transform.position -= new Vector3(8f,0,0);
            //col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            if (GvrControllerInput.ClickButtonDown )
            {
                if (tarObj.tag.Equals("Trees") && Mathf.Floor(dist) <= 20f && useAxe == true)
                {
                    LogCount += 30;
                    LogText.text = "Log:" + LogCount;
                    GetComponent<CommandWalk>().isWalking = false;
                    GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
                    if (energy.GetComponent<Health>().isThirst == true)
                        energy.GetComponent<Health>().CurrentHealth -= 15;
                    else
                        energy.GetComponent<Health>().CurrentHealth -= 10;
                    energy.GetComponent<Health>().thirstValue += 2;
                    int willThirst = Random.Range(0, 100);
                    if (willThirst <= (energy.GetComponent<Health>().thirstValue + 5))
                        energy.GetComponent<Health>().isThirst = true;


                    float AppleSpawn = Random.Range(0, 1f);
                    if (AppleSpawn >= 0.5f)
                    {
                        switch (tarObj.gameObject.name)
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
                    tarObj.gameObject.SetActive(false);
                }
                if (tarObj.gameObject.tag == "Mines" && Mathf.Floor(dist) <= 20f && usePickaxe == true)
                {                                      
                        tarObj.gameObject.SetActive(false);
                        //Destroy(col.gameObject);
                        MineCount += 30;
                        MineText.text = "Mine:" + MineCount;
                        GetComponent<CommandWalk>().isWalking = false;
                        GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
                        if (energy.GetComponent<Health>().isThirst == true)
                            energy.GetComponent<Health>().CurrentHealth -= 15;
                        else
                            energy.GetComponent<Health>().CurrentHealth -= 10;
                        energy.GetComponent<Health>().thirstValue += 2;
                        int willThirst = Random.Range(0, 100);
                        if (willThirst <= (energy.GetComponent<Health>().thirstValue + 5))
                            energy.GetComponent<Health>().isThirst = true;
                        tarObj.gameObject.SetActive(false);
                    
                }
                if (tarObj.gameObject.tag.Equals("Food") && Mathf.Floor(dist) <= 20f && useHand == true)
                {
                    energy.GetComponent<Health>().CurrentHealth += 5;
                    GetComponent<CommandWalk>().isWalking = false;
                    GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
                    tarObj.gameObject.SetActive(false);
                }
                if (tarObj.gameObject.tag.Equals("Workshop") && Mathf.Floor(dist) <= 20f)
                {
                    GetComponent<CommandWalk>().isWalking = false;
                    GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
                    WorkShopUI.SetActive(true);
                    Time.timeScale = 0f;
                }
                if (tarObj.gameObject.tag.Equals("ToolMaker") && Mathf.Floor(dist) <= 20f)
                {
                    GetComponent<CommandWalk>().isWalking = false;
                    GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
                    ToolMakerUI.SetActive(true);
                    Time.timeScale = 0f;

                }
                if (tarObj.gameObject.tag.Equals("SpaceShip") && Mathf.Floor(dist) <= 50f)
                {
                    GetComponent<CommandWalk>().isWalking = false;
                    GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
                    EscapeUI.SetActive(true);
                    Time.timeScale = 0f;
                }
                if (tarObj.gameObject.tag.Equals("water") && Mathf.Floor(dist) <= 20f && useHand == true)
                {

                    if (haveWater == true)
                    {
                        GetComponent<CommandWalk>().isWalking = false;
                        GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
                        energy.GetComponent<Health>().isThirst = false;
                        haveWater = false;
                        haveWaterIcon.SetActive(false);
                        StartCoroutine(rebornWater());
                    }
                }

            }
                
            //Destroy(col.gameObject);
            
        }
        if (GvrControllerInput.ClickButtonDown && 
            GvrPointerInputModule.CurrentRaycastResult.gameObject.name.Equals("Map")
            )
        {
            target = GvrPointerInputModule.CurrentRaycastResult.worldPosition;
            Debug.Log(target);
            
            LookAt(target);
            cam.transform.rotation = camRot;
            isWalking = true;
        }
        if(isWalking)
            Move();

        

        if (Character.transform.position == target ||
            Character.GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            animator.SetBool("IsRunning", false);
            isWalking = false;
        }
        //Rotate();
	}
    void LateUpdate()
    {
        //fix cam rotation while character is moving
        //cam.transform.rotation = camRot;
    }
}
