using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameChanging : MonoBehaviour {

    public Transform manager;
	
	// Update is called once per frame
	void Update()
    {
        manager.GetComponent<GUIController>().PlayerName = GetComponent<InputField>().text;
    }
}
