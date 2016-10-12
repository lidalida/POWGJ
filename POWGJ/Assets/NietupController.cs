using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NietupController : MonoBehaviour {

    public Transform controller;
    public Transform Player;
    public Transform Doors1;
    public Transform Doors2;
    public Transform Camera;
    public Transform Text;
    public bool act1, act2, act3, act4;

    public Vector3 dest;
    public Vector3 dir;

    // Use this for initialization
    void Start () {
        Text.GetComponent<Text>().text = "Siemanko " + GameObject.Find("Manager").GetComponent<GUIController>().PlayerName +",\n\nMamy problem, w całej Warszawie internet nie działa, przez strajk szympansów. Jest 5 października dzień spotkania Koła, a kołowicze wciąż nie wiedzą gdzie i o której się dzisiaj spotykamy.Twoim zadaniem jest znaleźć i poinformować jak największą liczbę Polygonków o terminie dzisiejszego spotkania. Poznasz ich bez trudu, dobrze wyróżniają się w tłumie."; 
        controller.GetComponent<GameController>().canvas.gameObject.SetActive(true);
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Player.GetComponent<Animator>().SetBool("IsMoving", false);
        Player.GetComponent<PlayerController>().enabled = false;
        act1 = true;
        act2 = act3 = act4 = false;

    }
	
	// Update is called once per frame
	void Update () {
	    if(act1 && Input.GetKeyDown(KeyCode.E))
        {
            controller.GetComponent<GameController>().canvas.gameObject.SetActive(false);
            Player.GetComponent<PlayerController>().enabled = true;
            Time.timeScale = 1;

            dest = new Vector3(-55.5f, 18f, transform.position.z);
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
        if(act2)
        {
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Player.GetComponent<Animator>().SetBool("IsMoving", false);
            Player.GetComponent<PlayerController>().enabled = false;

            Doors1.rotation = new Quaternion(0, 0, 0, 0);
            Doors2.rotation = new Quaternion(0, 0, 0, 0);

            dest = new Vector3(-53f, -5.5f, transform.position.z);
            dir = (dest - Player.position).normalized;
            float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Player.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            Player.GetComponent<Rigidbody2D>().velocity = dir * 2f;
            Player.GetComponent<Animator>().SetBool("IsMoving", true);

            if (Vector3.Distance(Player.position, dest) < 0.1f)
            {
                Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                Player.GetComponent<Animator>().SetBool("IsMoving", false);
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                act2 = false;
                act3 = true;
            }
        }
        if(act3)
        {
            if(Camera.GetComponent<Camera>().orthographicSize<12)
            {
                Camera.GetComponent<Camera>().orthographicSize = Camera.GetComponent<Camera>().orthographicSize + 0.02f;
            }

            transform.position = new Vector3(-55.5f, 18f, transform.position.z);
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GetComponent<Animator>().SetBool("IsMoving", false);

            dest = new Vector3(-53f, 16f, transform.position.z);
            dir = (dest - Player.position).normalized;
            float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Player.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            Player.GetComponent<Rigidbody2D>().velocity = dir * 3f;
            Player.GetComponent<Animator>().SetBool("IsMoving", true);

            if (Vector3.Distance(Player.position, dest) < 0.1f)
            {
                Player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                Player.GetComponent<Animator>().SetBool("IsMoving", false);
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                act3 = false;
                act4 = true;

                if (controller.GetComponent<GameController>().points > 5000)
                    Text.GetComponent<Text>().text = "GAME OVER\nO Ziomek, nigdy nie widziałem tylu ludzi na spotkaniu Koła, zostajesz Prezesem od zaraz\n\n\nWciśnij SPACE";
                else if (controller.GetComponent<GameController>().points > 2000)
                    Text.GetComponent<Text>().text = "GAME OVER\nWspaniale, udało Ci się powiadomić ziomeczków o spotkaniu. Good Job Mordo\n\n\nWciśnij SPACE";
                else
                    Text.GetComponent<Text>().text = "GAME OVER\nK****, kim Ty się stałeś? Nie dotarłeś nawet do połowy Polygonów...\n\n\nWciśnij SPACE";
                controller.GetComponent<GameController>().canvas.gameObject.SetActive(true);
            }
        }
        if(act4)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Application.LoadLevel("StartScene");
        }
    }
}
