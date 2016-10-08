using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    bool isOpen;

	// Use this for initialization
	void Start () {
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOpen)
                transform.Rotate(Vector3.forward * 90);
            else
                transform.Rotate(Vector3.forward * (-90));
            isOpen = !isOpen;
        }
           

    }
}
