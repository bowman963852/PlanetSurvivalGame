using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour {
    public GameObject EscapeUI;
    public GameObject EndGame;
    public void Yes()
    {
        EndGame.SetActive(true);
        StartCoroutine(Delay());

        SceneManager.LoadScene("CallMenu");

    }
    public void No()
    {
        EscapeUI.SetActive(false);
        Time.timeScale = 1f;
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
    }
}
