using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            GetComponent<Rigidbody2D>().velocity = Vector2.up*5;
        else if(Input.GetKeyUp(KeyCode.UpArrow))
            GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
    }
}
