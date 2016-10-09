using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    GameObject character;
    GameObject spawned, spawned2;
    
	// Use this for initialization
	void Start () {
        //character = GameObject.Find("Character");
        Vector3 pos = new Vector3(-10, -24, 0);
        Vector3 pos2 = new Vector3(-10, -26, 0);

       /* spawned = (GameObject)Instantiate(character, pos, Quaternion.identity);
        spawned.AddComponent<Animator>();
        spawned.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Walking") as RuntimeAnimatorController;
        AnimatorOverrideController overrideController = Resources.Load("Walking_afro_green") as AnimatorOverrideController;
        spawned.GetComponent<Animator>().runtimeAnimatorController = overrideController;*/
        spawned = (GameObject)Instantiate(Resources.Load("Prefabs/Professor"), pos, Quaternion.identity);
        spawned2 = (GameObject)Instantiate(Resources.Load("Prefabs/Professor"), pos2, Quaternion.identity);
        spawned2.GetComponent<Animator>().SetBool("IsMoving", true);


        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
