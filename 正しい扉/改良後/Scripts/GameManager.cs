using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Transform player;
    public Transform goal;
    public Transform[] miss = new Transform[4];
    
    public GameObject[] pos = new GameObject[6];
    
    public TextMeshProUGUI sec;
    
    public float starttime;
    public float timer;

    public bool start;
    
    Vector3 startPos;
    Vector3 goalPos;
    Vector3 missPos;
    Vector3 angle;
    /*
    public static bool clear;
    public static bool gameover;
    */
    public bool clear;
    public bool gameover;

    int startRand;
    int goalRand;
    int missRand;

    private void Awake()
    {
        Instance = this;
        clear = false;
        gameover = false;
        start = false;
        
    }

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        StartPos();
        GoalPos();
        MissPos();
        sec.text = $"{30:00.00}秒";
        timer = 1;
        SceneManager.SetActiveScene(gameObject.scene);
    }

    void Update()
    {
        /*if(start)
        {
            sec.text = $"{20 - (Time.time - starttime):00.00}秒";
            if (Time.time - starttime >= 20)
            {
                sec.text = $"00.00秒";
                ToGameover();
            }
        }*/
    }

    void StartPos()
    {
        startRand = Random.Range(0, 6);
        startPos = pos[startRand].transform.position;
        startPos.y = 1;
        player.position = startPos;
        angle = player.eulerAngles;
        angle.y= pos[startRand].transform.eulerAngles.y;
        player.eulerAngles = angle;
    }
    void GoalPos()
    {
        do{
            goalRand= Random.Range(0, 6);
        }while (startRand == goalRand);
        
        goalPos= pos[goalRand].transform.position;
        goalPos.y = 1;
        goal.position = goalPos;
        angle = goal.eulerAngles;
        angle.y = pos[goalRand].transform.eulerAngles.y;
        goal.eulerAngles = angle;
    }
    void MissPos()
    {
        int i=0;
        for(missRand = 0; missRand < 6; missRand++)
        {
            if (i < 5)
            {
                if (missRand != startRand && missRand != goalRand)
                {
                    missPos = pos[missRand].transform.position;
                    missPos.y = 1;
                    miss[i].position = missPos;
                    angle = miss[i].eulerAngles;
                    angle.y = pos[missRand].transform.eulerAngles.y;
                    miss[i].eulerAngles = angle;
                    i++;
                }
            }
        }
    }

    public void ToClear()
    {
        if (clear || gameover) return;

        clear = true;

        Time.timeScale = 0;

        Timer.Instance.anim.SetBool("ColorChange", false);

        SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
    }
    public void ToGameover()
    {
        if (clear || gameover) return;

        gameover = true;

        Time.timeScale = 0;

        Timer.Instance.anim.SetBool("ColorChange", false);

        SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
    }
}
