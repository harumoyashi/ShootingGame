using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //弾を生成する
            Instantiate(Bullet,transform.position,Quaternion.identity);
        }
    }

    //ゲームオブジェクトをインスペクターから参照するための変数
    public GameObject Bullet;
}
