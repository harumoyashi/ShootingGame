using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //子オブジェクトのサイズを入れるための変数
    private float Left, Right, Top, Bottom;

    //カメラから見た画面左下の座標を入れる変数
    Vector3 LeftBottom;
    //カメラから見た画面右下の座標を入れる変数
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトの数だけループ処理を行う
        foreach (Transform child in gameObject.transform)
        {
            //子オブジェクトの中で一番右にいたら
            if (child.localPosition.x >= Right)
            {
                //子オブジェクトのローカルX座標を右端用の変数に代入する
                Right = child.transform.localPosition.x;
            }
            if (child.localPosition.x <= Left)
            {
                Left = child.transform.localPosition.x;
            }
            if (child.localPosition.z >= Top)
            {
                Top = child.transform.localPosition.z;
            }
            if (child.localPosition.z <= Bottom)
            {
                Bottom = child.transform.localPosition.z;
            }
        }

        //カメラとプレイヤーの距離を測る(表示画面の四隅を設定するために必要)
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        //スクリーン画面左下の位置を設定する
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        //スクリーン右上の位置を設定する
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
    }

    // Update is called once per frame
    void Update()
    {
        //ワールド座標取得
        Vector3 pos = transform.position;
        //移動速度
        float speed = 0.02f;

        //SHIFT押してる間低速移動
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.01f;
        }

        //移動処理
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            pos.x += speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            pos.x -= speed;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            pos.z += speed;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            pos.z -= speed;
        }

        //プレイヤーのワールド座標に代入
        transform.position = new Vector3(
            Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top)
            );
    }
}
