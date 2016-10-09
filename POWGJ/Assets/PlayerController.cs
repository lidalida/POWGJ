using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int speed = 3;
	// Use this for initialization
	void Start () {
        GetComponent<Animator>().SetBool("IsMoving", false);

        
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Mathf.Sin(Mathf.Deg2Rad * GetComponent<Rigidbody2D>().rotation * (-1)), speed * Mathf.Cos(Mathf.Deg2Rad * GetComponent<Rigidbody2D>().rotation * (-1)));
            GetComponent<Animator>().SetBool("IsMoving", true);
            Debug.Log("true");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Animator>().SetBool("IsMoving", false);
            Debug.Log("false");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * Mathf.Sin(Mathf.Deg2Rad * GetComponent<Rigidbody2D>().rotation * (-1)), -speed * Mathf.Cos(Mathf.Deg2Rad * GetComponent<Rigidbody2D>().rotation * (-1)));
            GetComponent<Animator>().SetBool("IsMoving", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Animator>().SetBool("IsMoving", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
            GetComponent<Rigidbody2D>().rotation -= 5;

        if (Input.GetKey(KeyCode.LeftArrow))
            GetComponent<Rigidbody2D>().rotation += 5;
             


        
    }

    
}
