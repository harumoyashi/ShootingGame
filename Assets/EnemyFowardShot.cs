using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFowardShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のゲームオブジェクトを入れる
    public GameObject bullet;

    //撃ち出す間隔を決める
    public float timer = 1.0f;

    //最初に撃ち出すまでの時間を決める
    public float delayTimer = 1.0f;

    //現在のタイマー
    float nowTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //タイマー初期化
        nowTimer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー情報が入ってなかったら取得
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //タイマーを減らす
        nowTimer -= Time.deltaTime;

        //もしタイマーが0以下になったら弾を生成
        if(nowTimer <= 0.0f)
        {
            CreateShotObject(-transform.localEulerAngles.y);

            //タイマーリセット
            nowTimer = timer;
        }
    }

    private void CreateShotObject(float axis)
    {
        //ベクトルを取得
        var direction = player.transform.position - transform.position;

        //ベクトルのYを初期化
        direction.y = 0;

        //向きを取得
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        //弾を生成
        GameObject bulletClone=
            Instantiate(bullet,transform.position,Quaternion.identity);

        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //弾を撃ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を撃ちだす角度を変更する
        bulletObject.SetForwardAxis(lookRotation*Quaternion.AngleAxis(axis,Vector3.up));
    }
}
