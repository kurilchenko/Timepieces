using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneSwitcher : MonoBehaviour {

	public List<string> sceneNames = new List<string>();
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {
			OnClickNext();
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Backspace)) {
			OnClickPrev();
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}

	}

	public int currentSceneIndex {
		get {
			var sceneName = Application.loadedLevelName;

			return sceneNames.FindIndex(n => n == sceneName);
		}
	}

	public void OnClickNext() {
		var nextSceneIndex = currentSceneIndex + 1;

		if (currentSceneIndex >= sceneNames.Count - 1) {
			nextSceneIndex = 0;
		}

		Application.LoadLevel(sceneNames[nextSceneIndex]);
	}

	public void OnClickPrev() {
		var nextSceneIndex = currentSceneIndex - 1;
		
		if (currentSceneIndex == 0) {
			nextSceneIndex = sceneNames.Count - 1;
		}
		
		Application.LoadLevel(sceneNames[nextSceneIndex]);
	}

}
