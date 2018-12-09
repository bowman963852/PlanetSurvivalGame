using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour {

    public Text TimeText;
    public Text TimeDayText;
    public int TimeHours;
    public float TimeSpeed;
    public int TimeMinutes;
    public string TimeMinutesString;
    public string TimeHoursString;
    public int TimeDays;
    public GameObject tree, tree1, tree2, tree3;
    public GameObject mine, mine1, mine2, mine3;
    public GameObject carrot, carrot1, carrot2, carrot3;
    public GameObject SleepMenuClose;
    public GameObject HealthRecover;
    public GameObject SleepRewater;
    public bool isSleep;
    public GameObject remote;
    public float seasonCount;
    public Text Season;
    public Text speedTest;
    void Start () {
        TimeHours = 7;
        TimeMinutes = 0;
        TimeDays = 1;
        TimeSpeed = 0.2f;
        TimeHoursString = "07";
        TimeMinutesString = "00";
        isSleep = false;
        TimeText.text =TimeHoursString + ":" + TimeMinutesString;
        TimeDayText.text = "Day" + TimeDays;
        StartCoroutine(Timepast());
        seasonCount = 1f;
        Season.text = "春";
        

    }
    IEnumerator Timepast()
    {
        yield return new WaitForSeconds(0.2f);
        TimeMinutes++;
        #region TimeMinutesString
        if (TimeMinutes == 0)
            TimeMinutesString = "00";
        else if (TimeMinutes == 1)
            TimeMinutesString = "01";
        else if (TimeMinutes == 2)
            TimeMinutesString = "02";
        else if (TimeMinutes == 3)
            TimeMinutesString = "03";
        else if (TimeMinutes == 4)
            TimeMinutesString = "04";
        else if (TimeMinutes == 5)
            TimeMinutesString = "05";
        else if (TimeMinutes == 6)
            TimeMinutesString = "06";
        else if (TimeMinutes == 7)
            TimeMinutesString = "07";
        else if (TimeMinutes == 8)
            TimeMinutesString = "08";
        else if (TimeMinutes == 9)
            TimeMinutesString = "09";
        else if (TimeMinutes == 60)
            TimeMinutesString = "00";
        else
            TimeMinutesString = TimeMinutes.ToString();
        #endregion
        if (TimeMinutes == 60)
        {
            TimeHours++;
            TimeMinutes = 0;
        }
        #region TimeHoursString
        if (TimeHours == 0)
                TimeHoursString = "00";
            else if (TimeHours == 1)
                TimeHoursString = "01";
            else if (TimeHours == 2)
                TimeHoursString = "02";
            else if (TimeHours == 3)
                TimeHoursString = "03";
            else if (TimeHours == 4)
                TimeHoursString = "04";
            else if (TimeHours == 5)
                TimeHoursString = "05";
            else if (TimeHours == 6)
                TimeHoursString = "06";
            else if (TimeHours == 7)
                TimeHoursString = "07";
            else if (TimeHours == 8)
                TimeHoursString = "08";
            else if (TimeHours == 9)
                TimeHoursString = "09";
            else if (TimeHours == 24)            
                TimeHoursString = "00";           
            else
                TimeHoursString = TimeHours.ToString();
        #endregion

        if (TimeHours == 24)
        {
            TimeDays++;
            seasonCount += 0.5f;
            if (seasonCount >= 5)
                seasonCount = 1;
            #region seasonCount
            if (seasonCount >= 1 && seasonCount< 2)
            Season.text = "春";
            if (seasonCount >= 2 && seasonCount < 3)
                Season.text = "夏";
            if (seasonCount >= 3 && seasonCount < 4)
                Season.text = "秋";
            if (seasonCount >= 4 && seasonCount < 5)
                Season.text = "冬";
            #endregion
            TimeHours = 0;
#region respawn 
            tree.SetActive(true);
            tree1.SetActive(true);
            tree2.SetActive(true);
            tree3.SetActive(true);
            mine.SetActive(true);
            mine1.SetActive(true);
            mine2.SetActive(true);
            mine3.SetActive(true);
            carrot.SetActive(true);
            carrot1.SetActive(true);
            carrot2.SetActive(true);
            carrot3.SetActive(true);
#endregion
        }
        TimeText.text = TimeHoursString + ":" + TimeMinutesString;
        TimeDayText.text = "Day" + TimeDays;
        StartCoroutine(Timepast());
    }
    public void sleep()
    {
        isSleep = true;

        SleepMenuClose.GetComponent<PauseMenu>().pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SleepMenuClose.GetComponent<PauseMenu>().GameIsPaused = false;
        TimeSpeed = 0.000001f;
        SleepRewater.GetComponent<CommandWalk>().haveWater = true;
        SleepRewater.GetComponent<CommandWalk>().haveWaterIcon.SetActive(true);
#region HealthRecover
        if ((TimeHours>=7&&TimeHours<=24)|| TimeHours==0)
        HealthRecover.GetComponent<Health>().CurrentHealth += 80 ;
        else if(TimeHours == 1)
            HealthRecover.GetComponent<Health>().CurrentHealth += 60;
        else if (TimeHours == 2)
            HealthRecover.GetComponent<Health>().CurrentHealth += 50;
        else if (TimeHours == 3)
            HealthRecover.GetComponent<Health>().CurrentHealth += 40;
        else if (TimeHours == 4)
            HealthRecover.GetComponent<Health>().CurrentHealth += 30;
        else if (TimeHours == 5)
            HealthRecover.GetComponent<Health>().CurrentHealth += 20;
        else if (TimeHours == 6)
            HealthRecover.GetComponent<Health>().CurrentHealth += 10;
#endregion
        remote.GetComponent<CommandWalk>().isWalking = false;
        remote.GetComponent<CommandWalk>().animator.SetBool("IsWalking", false);
    }
    public void EndDay_cheat()
    {
        TimeDays = 14;
        TimeDayText.text = "Day" + TimeDays;
    }
    void Update ()
    {
        if (TimeMinutes == 0 && TimeHours == 7)
        {
            isSleep = false;        //醒來
            TimeSpeed = 1.2f;
        }
        speedTest.text = remote.GetComponent<CommandWalk>().
            Character.GetComponent<Rigidbody>().velocity.magnitude.ToString();
    }
}
