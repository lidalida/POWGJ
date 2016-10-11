using UnityEngine;
using System.Collections;

public class PolygonRotating : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.up*3);
	}
}
