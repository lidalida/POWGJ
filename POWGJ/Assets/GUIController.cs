using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

    public string PlayerName;

	public void ChangeScene(string sceneName)
    {
        DontDestroyOnLoad(transform.gameObject);
        Application.LoadLevel(sceneName);
    }

    public void TheEnd()
    {
        Application.Quit();
    }
}