//#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using NCMB;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static bool CanChangeToTitle { get; private set; }

    [SerializeField]
    GameObject[] prefab = new GameObject[3];
    [SerializeField]
    int[] spawnCount = new int[3];

    [SerializeField]
    TextMeshProUGUI scoreText = default;
    [SerializeField]
    TextMeshProUGUI timeText = default;

    static bool clear;
    static bool gameover;

    static int score;
    static float time;

    static int check = 60;
    static int reduce = 5 ;

    const float StartTime = 60f;
    const float RankingShowWait = 1f;


    static IEnumerator RankingProc()
    {
        CanChangeToTitle = false;
        yield return new WaitForSeconds(RankingShowWait);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);

        CanChangeToTitle = true;
    }

    public static float GetTime
    {
        get
        {
            return Mathf.Round(time * 10f) / 10f;
        }
    }

    public static void AddPoint(int point)
    {
        score += point;

        HigtScore.CheckHighScore(score);

        Instance.UpdateScoreText();
    }

    private void Awake()
    {
        Instance = this;

        score = 0;
        time = StartTime;

        clear = false;
        gameover = false;
    }

    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;

        if (Mathf.Approximately(GetTime, check))
        {
            if (check >= reduce)
            {
                if(check % 10 == 0)
                {
                    spawnCount[0]++;
                    Spawner.Spawne(spawnCount[0], prefab[0]);
                }
                else
                {
                    spawnCount[1]++;
                    Spawner.Spawne(spawnCount[1], prefab[1]);
                }
                check -= reduce;
                spawnCount[2]++;
                Spawner.Spawne(spawnCount[2], prefab[2]);
            }
        }

        if (time <= 0)
        {
            time = 0;
            ToClear();
        }
        if (clear || gameover) return;
        UpdateTimeText();
    }

    void UpdateTimeText()
    {
        timeText.text = $"{time:0.0}";
    }

    void Start()
    {
        TinyAudio.PlaySE(TinyAudio.SE.Start);
    }

    public static void ToClear()
    {
        if (clear || gameover) return;

        clear = true;

        AddPoint(1000);

        ToEnd();

        SceneManager.LoadScene("Clear", LoadSceneMode.Additive);

        Instance.StartCoroutine(RankingProc());
    }

    public static void ToGameover()
    {
        if (clear || gameover) return;

        gameover = true;

        ToEnd();

        SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);

        Instance.StartCoroutine(RankingProc());
    }

    public static void ToEnd()
    {
        check = 60;

        GameObject[] a = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in a)
        {
            Destroy(enemy);
        }
        GameObject[] b = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in b)
        {
            Destroy(item);
        }
        GameObject[] c = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in c)
        {
            Destroy(player);
        }

        CylinderManager.E();
    }

    void UpdateScoreText()
    {
        scoreText.text = $"{score:00000}";
    }

    void Update()
    {
#if DEBUG_KEY
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        }
#endif
    }
}
