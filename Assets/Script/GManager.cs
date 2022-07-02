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
    public GameObject button;

    public int gameScene = 0; //0:play,1:clear,2:gameover

    // Start is called before the first frame update
    void Start()
    {
        //パネルを隠す
        clearPanel.SetActive(false);
        gameoverPanel.SetActive(false);
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //シーンに存在しているEnemyタグを持っているオブジェクト
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //シーンに1匹もEnemyがいなくなったらパネル表示
        if (enemy.Length == 0 && gameScene == 0)
        {
            gameScene = 1;
            clearPanel.SetActive(true);
            button.SetActive(true);
        }

        player = GameObject.FindGameObjectsWithTag("Player");
        if (player.Length == 0 && gameScene != 1)
        {
            gameScene = 2;
            for (int i = 0; i < enemy.Length; i++)
            {
                GameObject.Destroy(enemy[i]);
            }
            gameoverPanel.SetActive(true);
            button.SetActive(true);
        }
    }
}
