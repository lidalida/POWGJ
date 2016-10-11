using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int speed = 3;
    public Transform controller;
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
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Animator>().SetBool("IsMoving", false);
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
             
        if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (transform.position.x > -70f && transform.position.x < -52f && transform.position.y > -6f)
            GameObject.Find("Nietup").GetComponent<NietupController>().act2 = true;

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (other.gameObject.tag == "People")
            {
                if(!other.gameObject.GetComponent<FSM>().isPolygon)
                {
                    Destroy(other.gameObject);
                    controller.GetComponent<GameController>().points += 10;
                }
                else
                {
                    GetComponent<PlayerController>().enabled = false;
                    GetComponent<Rigidbody2D>().isKinematic = true;
                    controller.GetComponent<GameController>().wasted.gameObject.SetActive(true);
                }
                
            }
                
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag == "People")
            {
                if (other.gameObject.GetComponent<FSM>().isPolygon)
                {
                    controller.GetComponent<GameController>().polygonians.Add(other.gameObject.transform);
                    other.gameObject.transform.position = new Vector3(-57f,10f,0);
                    controller.GetComponent<GameController>().points += 100;
                }

            }

        }
    }
}
