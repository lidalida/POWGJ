using UnityEngine;
using System.Collections;

public class CollisionsController : MonoBehaviour {

    private float initialisation_time, lifetime;
    GameObject gameobject;
	// Use this for initialization
	void Start () {

        initialisation_time = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
        lifetime = Time.time - initialisation_time;
	
	}

    void OnCollisionStay2D(Collision2D coll)
    {
        if (lifetime < 0.5)
        {
            Destroy(gameObject);
            GameObject.Find("GameController").GetComponent<Spawn>().people_number--;
            Debug.Log(GameObject.Find("GameController").GetComponent<Spawn>().people_number);

            Debug.Log("destroyed");
            
        }

        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

    }
    void OnCollisionExit2D(Collision2D coll)
    {
    }

    
}
