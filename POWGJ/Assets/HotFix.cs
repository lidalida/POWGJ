using UnityEngine;
using System.Collections;

public class HotFix : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<PlayerController>().enabled)
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.LoadLevel("StartScene");
	}
}
