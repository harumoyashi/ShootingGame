using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //敵の数数える用変数
    private GameObject[] enemy;

    //パネルを登録
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        //パネルを隠す
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //シーンに存在しているEnemyタグを持っているオブジェクト
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //シーンに1匹もEnemyがいなくなったらパネル表示
        if(enemy.Length == 0)
        {
            panel.SetActive(true);
        }
    }
}
