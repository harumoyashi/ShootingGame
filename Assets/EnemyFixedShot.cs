using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のゲームオブジェクトを入れる
    public GameObject bullet;

    //1回で撃つ弾の数を決める
    public int bulletWayNum = 3;

    //撃ち出す弾の間隔を設定
    public float bulletWaySpace = 30;

    //撃ち出す角度を調整
    public int bulletWayAxis = 0;

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
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //タイマーを減らす
        nowTimer -= Time.deltaTime;

        //もしタイマーが0以下になったら弾を生成
        if (nowTimer <= 0.0f)
        {
            //角度調整用変数
            float bulletWaySpaceSplit = 0;

            //1回で発射する弾数分だけループする
            for (int i = 0; i < bulletWayNum; i++)
            {
                //弾を生成
                CreateShotObject(bulletWaySpace - bulletWaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y);

                //角度を調整する
                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }
            //タイマーを初期化
            nowTimer = timer;
        }
    }

    private void CreateShotObject(float axis)
    {
        //弾を生成
        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);

        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        //弾を撃ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacterObject(gameObject);

        //弾を撃ちだす角度を変更する
        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    }
}
