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
        if(Vector3.Distance(GameObject.Find("Player").transform.position,transform.position+Vector3.left)<1.2f)
            if(Time.timeScale!=0)
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isOpen)
                        transform.Rotate(Vector3.forward * 90);
                    else
                        transform.Rotate(Vector3.forward * (-90));
                    isOpen = !isOpen;
                }
           

    }
}
