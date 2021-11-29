using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody drone_RB;
    private GameMngr gameMngr_Script;

    public Rigidbody Drone;

    public GameObject playZone;
    public GameObject drone_OBJ;

    public float speed = 500f;
    public float turnSpeed = 100;
    public static bool isPaused;
    public GameObject inGameMenu;
    public GameObject in_Game_Menu_Button;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        gameMngr_Script = GameObject.Find("GameMngr").GetComponent<GameMngr>();
       drone_RB = GetComponent<Rigidbody>();
        drone_OBJ = GameObject.Find("Drone_OBJ"); 
    }

    // Update is called once per frame
    void Update()
    {

        if (GameMngr.alive)                                                     // run only if "alive"
        {
            checkedInput();
            know_Your_Limits();   
        }

    }



    public void checkedInput()                                                  // user controls
    {
        if (gameMngr_Script.timeToPlay && !gameMngr_Script.survived)
        {     
            
                                                                              // if alive || not paused



/*

            // forward / backward
            if (Input.GetKey(KeyCode.W))
           { transform.Translate(Vector3.forward * Time.deltaTime * speed); }
           //   {drone_RB.AddRelativeForce(0,0,50);drone_RB.AddRelativeTorque (10, 0, 0);}


            if (Input.GetKey(KeyCode.S))
            { transform.Translate(Vector3.forward * Time.deltaTime * (-speed)); }

            //left / right
            if (Input.GetKey(KeyCode.D))
            { transform.Translate(Vector3.right * Time.deltaTime * turnSpeed); }
            if (Input.GetKey(KeyCode.A))
            { transform.Translate(Vector3.right * Time.deltaTime * (-turnSpeed)); }

            // up / down
            if (Input.GetKey(KeyCode.UpArrow))
            { transform.Translate(Vector3.up * Time.deltaTime * turnSpeed); }
            if (Input.GetKey(KeyCode.DownArrow))
            { transform.Translate(Vector3.up * Time.deltaTime * (-turnSpeed)); }

            //left / right
            if (Input.GetKey(KeyCode.RightArrow))
            { transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed / 2); }
            if (Input.GetKey(KeyCode.LeftArrow))
            { transform.Rotate(Vector3.up * Time.deltaTime * (-turnSpeed / 2)); }
              */
        }
      
                                                    // TODO make movement more realistic by adding forces
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) { resume();}
             else { pause(); }
        }

    }

    void know_Your_Limits()                                             // keep player in zone
    {
        float half_Of_playZone = playZone.transform.localScale.x / 2;
        if (drone_OBJ.CompareTag("Drone_OBJ"))
        {
            if (gameObject.transform.position.x > half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
                gameMngr_Script.deduct_Health();
            }
            if (gameObject.transform.position.x < -half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
                gameMngr_Script.deduct_Health();
            }

            if (gameObject.transform.position.y > half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
                gameMngr_Script.deduct_Health();
            }
            if (gameObject.transform.position.y < -half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
                gameMngr_Script.deduct_Health();
            }

            if (gameObject.transform.position.z > half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
                gameMngr_Script.deduct_Health();
            }
            if (gameObject.transform.position.z < -half_Of_playZone)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
                gameMngr_Script.deduct_Health();
            }

        }

    }
                            // Pause/Resume
    public void resume()
    {
        inGameMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void pause()
    {
        inGameMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(in_Game_Menu_Button);
        Time.timeScale = 0;
        isPaused = true;
    }

                                           /// quit game


}
