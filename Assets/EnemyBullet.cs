using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //弾速
    public float speed = 10.0f;
    //消滅するまでのタイマー
    public float timer = 2;

    //進行方向
    protected Vector3 forward =
        new Vector3(1, 1, 1);

    //撃ち出す時の角度
    protected Quaternion forwardAxis=
        Quaternion.identity;

    //Rigidbody用変数
    protected Rigidbody rb;

    //Enemy用変数
    protected GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody初期化
        rb=this.GetComponent<Rigidbody>();

        //進行方向設定
        if(enemy!=null)
        {
            forward=enemy.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //移動量を進行方向に加算
        rb.velocity = forwardAxis * forward * speed;
        //空中に浮かないように
        rb.velocity=new Vector3(rb.velocity.x,0,rb.velocity.z);

        //時間制限きたら自然消滅
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //もし当たったオブジェクトのタグがPlayer or PlayerBodyだったら
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBody")
        {
            //自分を消滅させる
            Destroy(this.gameObject);
        }
    }

    //弾を撃ったキャラクターの情報を渡す関数
    public void SetCharacterObject(GameObject character)
    {
        this.enemy = character;
    }

    //撃ち出す角度を設定する関数
    public void SetForwardAxis(Quaternion axis)
    {
        this.forwardAxis = axis;
    }
}
