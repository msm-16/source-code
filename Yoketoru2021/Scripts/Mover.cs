using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    float speedMin ;
    [SerializeField]
    float speedMax ;
    [SerializeField]
    float speedUp;

    float speed;
    float add = 0;
    int th;
    Rigidbody rb;

    void SpeedUp()
    {
        if(this.gameObject.CompareTag("Enemy"))
        {
            speedMin += add;
            speedMax += add;
            add += speedUp;
        }
    }

    void SetRandomVelocity()
    {
        // 変数thに、0～359の角度を乱数で求める
        th = Random.Range(135, 226);

        // ローカル変数dirに、角度thで長さ1の方向ベクトルを求める
        var dir = new Vector3(Mathf.Cos(th * Mathf.Deg2Rad), Mathf.Sin(th * Mathf.Deg2Rad), 0);

        // 以上で求めた値を使って、速度を設定する
        rb.velocity = dir * speed;
    }

    private void Awake()
    {
        SpeedUp();

        // speedに、speedMin～speedMaxの速度を乱数で求める
        speed = Random.Range(speedMin, speedMax);

        // 変数rbに、Rigidbodyのインスタンスを取得する
        rb = GetComponent<Rigidbody>();

        SetRandomVelocity();
    }

    void FixedUpdate()
    {
        // if (rb.velocity.magnitude == 0f) 浮動小数点ではこれはNG
        if (Mathf.Approximately(rb.velocity.magnitude, 0f))
        {
            SetRandomVelocity();
        }
        rb.velocity = rb.velocity.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        /*//跳ね返りさせたい
        var vec = new Vector3(-Mathf.Sin(th * Mathf.Deg2Rad), Mathf.Cos(th * Mathf.Deg2Rad), 0);
        rb.velocity = vec.normalized * speed;
        */
    }
}