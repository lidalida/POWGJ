using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void TheEnd()
    {
        Application.Quit();
    }
}
