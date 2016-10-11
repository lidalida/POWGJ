using UnityEngine;
using System.Collections;

public class NietupController : MonoBehaviour {

    public Transform controller;
    public bool act1, act2;

    public Vector3 dest;
    public Vector3 dir;

    // Use this for initialization
    void Start () {
        controller.GetComponent<GameController>().canvas.gameObject.SetActive(true);
        controller.GetComponent<GameController>().Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        controller.GetComponent<GameController>().Player.GetComponent<Animator>().SetBool("IsMoving", false);
        controller.GetComponent<GameController>().Player.GetComponent<PlayerController>().enabled = false;
        act1 = true;
        act2 = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(act1 && Input.GetKeyDown(KeyCode.E))
        {
            controller.GetComponent<GameController>().canvas.gameObject.SetActive(false);
            controller.GetComponent<GameController>().Player.GetComponent<PlayerController>().enabled = true;
            Time.timeScale = 1;

            dest = new Vector3(-55.5f, 17f, transform.position.z);
            dir = (dest - transform.position).normalized;
            float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            GetComponent<Rigidbody2D>().velocity = dir*6f;
            GetComponent<Animator>().SetBool("IsMoving", true);
           
            act1 = false;
        }
        if (Vector3.Distance(transform.position, dest) < 0.1f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetBool("IsMoving", false);
            transform.rotation = Quaternion.Euler(0f,0f,180f);
        }
        /*if(act2)
        {
            controller.GetComponent<GameController>().Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            controller.GetComponent<GameController>().Player.GetComponent<Animator>().SetBool("IsMoving", false);
            controller.GetComponent<GameController>().Player.GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0;
        }*/
    }
}
