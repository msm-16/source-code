using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField]
    int money;

    static int worth;

    void Start()
    {
        worth = money;
    }

    public static int GetPrice()
    {
        return worth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.AddPoint(money);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (this.transform.localScale.x > 0.1f)
                this.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            else
                Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
