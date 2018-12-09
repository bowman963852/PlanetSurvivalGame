using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public Slider HealthSlider;
    public Text HealthText;
    [Range(0, 100)]
    public int CurrentHealth;
    public float HealthLosing;
    public GameObject Sleeping;
    public int thirstValue;
    public bool isThirst;
    public GameObject isThirstIcon;

    void Start()
    {   
        CurrentHealth = 100;
        HealthLosing = 5f;
        StartCoroutine(lostHealth());
        isThirst = false;
        


    }
    IEnumerator lostHealth()
    {
        yield return new WaitForSeconds(HealthLosing);
        CurrentHealth--;
        HealthText.text = CurrentHealth.ToString() + "%";
        HealthSlider.value = ((float)CurrentHealth / 100f);
        if (CurrentHealth == 0)
        {
            HealthText.text = "Wasted！";
        }
        else
        {
            StartCoroutine(lostHealth());
        }
            
    }
    void Update()
    {
        if(Sleeping.GetComponent<TimeCount>().isSleep=true) StopCoroutine(lostHealth());
            else
                StartCoroutine(lostHealth());

        if (isThirst == true)
        {
            HealthLosing = 2.5f;
            isThirstIcon.SetActive(true);
        }
        else
        {
            HealthLosing = 5f;
            isThirstIcon.SetActive(false);

        }

        if (CurrentHealth >= 100)
            CurrentHealth = 100;
        if (CurrentHealth <= 0)
            CurrentHealth = 0;
    }

}
