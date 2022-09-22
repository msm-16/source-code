using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float time;
    float sTime;

    [SerializeField]
    Image timerUI;

    static int point;
    static float timer;

    public Camera camera_object;
    private RaycastHit hit;
    Vector3 mousePosition;

    static int count;

    bool end;
    bool move;

    static new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Time.timeScale = 1;
        sTime = Time.time;
        move = false;
        count = 0;
        point = 0;
    }

    void Update()
    {
        timerUI.fillAmount = 1-timer;

        if (!end)
        {
            Timer();
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    var objTag = hit.collider.tag;

                    if (objTag.Equals("Money"))
                    {
                        move = true;
                    }
                }
            }
            if (Input.GetMouseButton(0))
            {
                if (move)
                {
                    if (hit.collider != null)
                    {
                        mousePosition = Input.mousePosition;
                        mousePosition.z = 10;
                        hit.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                move = false;
            }
        }
        else
        {
            if (!Over.GetPlaySE())
                if (Input.GetMouseButtonDown(0))
                    SceneManager.LoadScene("Title");
        }

        if (count == MoneyManager.GetSpawnCount())
        {
            count = 0;
            MoneyManager.SetSpawn();
        }
    }

    void Timer()
    {
        var t = Time.time - sTime;
        if (time < t)
        {
            ToOver();
        }
        timer = t / time;
    }

    public static void AddPoint(int money)
    {
        point += money;
        count++;
        audio.PlayOneShot(audio.clip);
    }

    public static int GetPoint()
    {
        return point;
    }

    void ToOver()
    {
        end = true;
        Time.timeScale = 0;
        SceneManager.LoadScene("Over", LoadSceneMode.Additive);
    }
}
