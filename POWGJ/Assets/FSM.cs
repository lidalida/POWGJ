using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour {

    public delegate IEnumerator Delegate();
    public Delegate actualState;
    public int i = 0;
    public Vector3 dest;
    public Vector3 dir;
    public Vector3 lastPos;
    Transform Player;
    Transform controller;
    public bool isPolygon;

    void Start()
    {
        actualState = Stay;
        dest = new Vector3();
        StartCoroutine(MyCoroutine());
        Player = GameObject.Find("Player").transform;
        controller = GameObject.Find("GameController").transform;
        if (Random.Range(0f, 100f) > 0f)
        {
            isPolygon = true;
            Quaternion rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180f);
            GameObject pol = (GameObject)Instantiate(Resources.Load("Prefabs/Polygon"), transform.position-Vector3.left*(-0.035f)+Vector3.up*(0.017f), rot);
            pol.transform.parent = transform;
        }
        else
            isPolygon = false;
    }
	
    IEnumerator MyCoroutine()
    {
        while(true)
        {
            
            yield return actualState();
        }
        
    }

    IEnumerator DoNotMove()
    {
        yield return new WaitForSeconds(10000f);
    }

    IEnumerator Stay()
    {
        //if(Random.Range(0f,1f)>0.8)
            actualState = Rotate;
        //Debug.Log("I'm still standing, yeah yeah yeah");
        yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
    }

    IEnumerator Rotate()
    {
        dir = new Vector3();
        if (i <= 1)
        {
            dest = transform.position + Vector3.up*Random.Range(-10f,10f) + Vector3.right * Random.Range(-10f, 10f);
            i++;
        }
        dir = (dest - transform.position).normalized;

        if (transform.position.y > -21f && transform.position.y < -18.5f && Random.Range(0f, 1f) > 0.5f)
        {
            if(Random.Range(0f,1f)>0.5f)
                dest = new Vector3(Random.Range(-56f,-70f),transform.position.y,transform.position.z);
            else
                dest = new Vector3(Random.Range(56f, 70f), transform.position.y, transform.position.z);
            dir = (dest - transform.position).normalized;
        }

        if (/*Random.Range(0f,100f)>90 &&*/ Vector3.Distance(transform.position, Player.transform.position) < 10f)
        {
            if (!isPolygon)
                actualState = Follow;
            else
                actualState = Stay;
            yield return new WaitForSeconds(0.001f);
        }

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        actualState = Move;
        //Debug.Log("I'm turning turning turning turning turning around, and all that I can see ...");
        yield return new WaitForSeconds(0.001f);
    }

    IEnumerator Move()
    {
        GetComponent<Rigidbody2D>().velocity = dir;
        GetComponent<Animator>().SetBool("IsMoving",true);
        if(lastPos == transform.position)
            i++;
        if (Vector3.Distance(transform.position, dest) < 0.1f || i>=5)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetBool("IsMoving", false);
            if (!isPolygon)
                actualState = Follow;
            else
                actualState = Stay;
            i = 0;
        }

        lastPos = transform.position;
        //Debug.Log("Keep moving!!!");
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator Follow()
    {
        dest = Player.transform.position;
        dir = (dest - transform.position).normalized;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        GetComponent<Rigidbody2D>().velocity = dir;
        GetComponent<Animator>().SetBool("IsMoving", true);

        if(Vector3.Distance(transform.position, Player.transform.position)<0.8f)
            actualState = Attack;
        //Debug.Log("Running running, -ning");
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator Attack()
    {
        controller.GetComponent<GameController>().lifes--;
        if (controller.GetComponent<GameController>().lifes <= 0)
        {
            Player.GetComponent<PlayerController>().enabled = false;
            Player.GetComponent<Rigidbody2D>().isKinematic = true;
            controller.GetComponent<GameController>().wasted.gameObject.SetActive(true);
        }
        actualState = Stay;
        Debug.Log("Bitch slap!!!");
        yield return new WaitForSeconds(1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        actualState = Stay;
        GetComponent<Animator>().SetBool("IsMoving", false);
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        i = 0;
    }
}
