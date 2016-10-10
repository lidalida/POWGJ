using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

    GameObject spawned;
    List<GameObject> list;
    string[] prefabs_names = {"Afro_green", "Afro_red", "Boy1_brown", "Boy1_green", "Boy2_blue", "Boy2_green", "Boy2_white", "Girl_blue", "Girl_pink", "Ponytail_blue", "Ponytail_orange", "Professor"};
    public int people_number = 0;
    public int max_people_number=1000;
	// Use this for initialization
	void Start () {
        list = new List<GameObject>();

        for (int i = 0; i < 100; i++)
            SingleSpawn();
        
        InvokeRepeating("SingleSpawn", 0.1f, 3f);
             

        
	
	}
	
	// Update is called once per frame
	void Update () {
     
	
	}

    void SingleSpawn()
    {
        float rnd = Random.value;
        Vector3 pos;
        if (people_number < max_people_number)
        {
            if (rnd < 0.2f)
            {
                //losuj tam gdzie rzadko
                pos = new Vector3(Random.Range(-97, 92), Random.Range(-28, -22), 0);
            }
            else if(rnd>=0.2f && rnd<0.25f)
            {
                pos = new Vector3(Random.Range(90, 92), Random.Range(-9, 14), 0);

            }
            else if (rnd >= 0.25f && rnd < 0.3f)
            {
                pos = new Vector3(Random.Range(-92, -90), Random.Range(-9, 14), 0);

            }
            else if (rnd >= 0.3f && rnd < 0.35f)
            {
                pos = new Vector3(Random.Range(30, 31), Random.Range(-9, 14), 0);

            }
            else if (rnd >= 0.35f && rnd < 0.4f)
            {
                pos = new Vector3(Random.Range(-31, -30), Random.Range(-9, 14), 0);

            }
            else if (rnd >= 0.4f && rnd < 0.45f)
            {
                pos = new Vector3(Random.Range(55, 66), Random.Range(-47, -30), 0);

            }
            else if (rnd >= 0.45f && rnd < 0.5f)
            {
                pos = new Vector3(Random.Range(-66, -55), Random.Range(-47, -30), 0);

            }
            else
            {
                //losuj tam gdzie często
                pos = new Vector3(Random.Range(-92, 92), Random.Range(-21, -11), 0);
            }

            string name = prefabs_names[Random.Range(0, prefabs_names.Length)];
            spawned = (GameObject)Instantiate(Resources.Load("Prefabs/" + name), pos, Quaternion.identity);
            people_number++;
            Debug.Log(people_number);

        }

    }

    
}
