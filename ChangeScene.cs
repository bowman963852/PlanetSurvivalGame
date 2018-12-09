using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization

	public void changeScene(string scenename){
		SceneManager.LoadScene (scenename);
	}
}