using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



	
public class callMenu : MonoBehaviour
{
    public GameObject Option;
    

    public void CallOption()
    {
        FindObjectOfType<MusicManager>().Play("click");

        Option.SetActive(true);
	

	}
    public void PlayGame()
    {
        FindObjectOfType<MusicManager>().Play("click");

        SceneManager.LoadScene("GamePlay");
    }
    public void CloseMenu()
    {
        FindObjectOfType<MusicManager>().Play("click");
        Option.SetActive(false);


    }
    public void doquit()
    {
        FindObjectOfType<MusicManager>().Play("click");
        Debug.Log("quit this game");
        Application.Quit();
    }
}
