using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public int speed = 3;
    public Transform controller;
    List<Vector3> positions;
    // Use this for initialization
    void Start () {
        GetComponent<Animator>().SetBool("IsMoving", false);

        positions = new List<Vector3>();

        for (int i = 0; i < 14; i++)
            for (int j = 0; j < 20; j++)
            {
                positions.Add(new Vector3(-54.51548f - i * 1.01285f, -3.97598f + j * 1.026f, 0));
            }

        for(int i=0; i<positions.Count;i++)
        {
            int k, l;
            k = Random.Range(0, positions.Count);
            l = Random.Range(0, positions.Count);
            Vector3 tmp;
            tmp = positions[k];
            positions[k] = positions[l];
            positions[l] = tmp;
        }
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

        if (transform.position.x > -70f && transform.position.x < -52f && transform.position.y > -5.5f)
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
                    StartCoroutine(Rotate(30, 0.2f));
                    GameObject boom = new GameObject();
                    boom=(GameObject)Instantiate(Resources.Load("Prefabs/boom"), other.gameObject.transform.position, Quaternion.identity);
                    Destroy(other.gameObject);
                    Destroy(boom, 1.0f);
                    controller.GetComponent<GameController>().points += 10;
                }
                else
                {
                    GetComponent<PlayerController>().enabled = false;
                    GetComponent<Rigidbody2D>().isKinematic = true;
                    controller.GetComponent<GameController>().wasted.gameObject.SetActive(true);
                }
                
            }
            else if(other.gameObject.tag=="Weapons")
            {
                /*foreach (Transform child in this.gameObject.transform.)
                {
                    GameObject.Destroy(child.gameObject);
                }*/
                
                other.gameObject.transform.parent = this.gameObject.transform;
                other.gameObject.transform.rotation = this.gameObject.transform.rotation;
                if (other.gameObject.name == "weapon_baseball")
                    other.gameObject.transform.localPosition = new Vector3(0.42f, 0.39f, 0f);
                else if (other.gameObject.name=="weapon_keyboard")
                    other.gameObject.transform.localPosition = new Vector3(0.42f, 0.39f, 0f);
                else if (other.gameObject.name == "weapon_book")
                    other.gameObject.transform.localPosition = new Vector3(0.44f, 0.21f, 0f);
                other.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
                
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag == "People")
            {
                if (other.gameObject.GetComponent<FSM>().isPolygon)
                {
                    controller.GetComponent<GameController>().polygonians.Add(other.gameObject.transform);
                    other.gameObject.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    other.gameObject.transform.GetComponent<Animator>().SetBool("IsMoving", false);
                    other.gameObject.transform.rotation = new Quaternion(0,0,0,0);
                    other.gameObject.transform.GetComponent<FSM>().StopAllCoroutines();
                    GameObject poof = new GameObject();
                    poof = (GameObject)Instantiate(Resources.Load("Prefabs/poof"), other.gameObject.transform.position, Quaternion.identity);
                    Destroy(poof, 1.0f);
                    other.gameObject.transform.position = positions[0];
                    positions.RemoveAt(0);
                   
                    controller.GetComponent<GameController>().points += 100;
                }

            }

        }
    }
    IEnumerator Rotate(float angle, float duration)
    {
        float elapsed = 0f;
        Quaternion from = transform.rotation;
        Quaternion to = from * Quaternion.Euler(Vector3.forward * angle);
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;

        }
        transform.rotation = to;
    }
}
