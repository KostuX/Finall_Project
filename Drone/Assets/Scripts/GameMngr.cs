using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameMngr : MonoBehaviour
{

   
    public GameObject game_Over;
    public static GameObject playZone;
    public static bool alive;
    public int score, time, health;
    public static int TopScore = 299;
    public bool timeToPlay = false;

    public bool survived = false;

    float current_Time;
    float countDown_Time = 4;
    public TextMeshProUGUI countDown_Text;


    // Start is called before the first frame update
    void Start()
    {
        playZone = GameObject.Find("PlayZone");
                                                     // initial settings
        current_Time = (int)countDown_Time;
        alive = true;
        score = 0;
        time = 0;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive && timeToPlay) { time = (((int)playZone.transform.localScale.x / 10) - 3); } // calculate time to end of zone shrink
        if(survived){ game_Over.gameObject.SetActive(true);}                                   //end of game screen when survived 
       
        isTimeTo_Play();
    }

    public void deduct_Health()                                     // do damage when hitint zone border
    {
        if(!SceneManager.GetActiveScene().name.Equals("FreeRun") ) // no damage in practice mode
        {
            if (health > 5 ) { health -= 5; }
                else
                {
                    health = 0;
                    gameOver();
                    alive = false;
                }
            }
    }

                                                                        // scene manage functions
    public void gameOver() { game_Over.gameObject.SetActive(true); }
    public void MainMenu_Scene() { SceneManager.LoadScene(0); }
    public void cube_Scene() { SceneManager.LoadScene(1); }
    public void freeRun_Scene() { SceneManager.LoadScene(2); }
    public void restart_Game() { Time.timeScale = 1; SceneManager.LoadScene(SceneManager.GetActiveScene().name); }


    public void isTimeTo_Play()
    {                                                                   // time countdown
        if (current_Time < -1) { countDown_Text.text = ""; }          // destry obj instead
        if (current_Time < 1 && current_Time > -3) { countDown_Text.text = "GO!!!"; }
        if (current_Time < 4 && current_Time > 0) { countDown_Text.text = current_Time.ToString("0"); }
        if (current_Time > 3) { countDown_Text.text = "Ready?!"; }

        current_Time -= 1 * Time.deltaTime;
        timeToPlay = current_Time < 0 ? true : false;
                                                                    // TODO poorly written countDown code, must be replaced
    }

}
