using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public Transform canvas;
    public Transform Player;
    public Transform wasted;

    public int points;
    public int lifes;
    public List<Transform> polygonians;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                Player.GetComponent<Animator>().SetBool("IsMoving", false);
                Player.GetComponent<PlayerController>().enabled = false;
                Time.timeScale = 0;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Player.GetComponent<PlayerController>().enabled = true;
                Time.timeScale = 1;
            }
        }
	}
}
