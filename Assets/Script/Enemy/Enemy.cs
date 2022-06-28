using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemyの体力用変数
    private int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力を指定
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //HP0になったら消滅
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //publicの付け忘れに注意
    public void Damage()
    {
        //Enemyの体力を1減らす
        enemyHp = enemyHp - 1;

        Debug.Log(enemyHp);
    }
}
