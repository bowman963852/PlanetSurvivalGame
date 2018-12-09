using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider loadingSlider;
    public Text loadingText;
    public GameObject option;
    public GameObject Menu;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchranously(sceneIndex));
    }
    IEnumerator LoadAsynchranously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
       loadingScreen.SetActive(true);
        option.SetActive(false);
        Menu.SetActive(false);
        

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;
            loadingText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
