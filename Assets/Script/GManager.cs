using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    //敵の数数える用変数
    private GameObject[] enemy;

    private GameObject[] player;

    //パネルを登録
    public GameObject clearPanel;
    public GameObject gameoverPanel;

    bool isGameover = false;

    // Start is called before the first frame update
    void Start()
    {
        //パネルを隠す
        clearPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //シーンに存在しているEnemyタグを持っているオブジェクト
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //シーンに1匹もEnemyがいなくなったらパネル表示
        if(enemy.Length == 0&& isGameover == false)
        {
            clearPanel.SetActive(true);
        }

        player = GameObject.FindGameObjectsWithTag("Player");
        if (player.Length == 0)
        {
            isGameover = true;
            for (int i = 0; i < enemy.Length; i++)
            {
                GameObject.Destroy(enemy[i]);
            }
            gameoverPanel.SetActive(true);
        }
    }
}
