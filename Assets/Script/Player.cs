using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int playerHp;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //HP0になったら消滅
        if (playerHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage()
    {
        //Playerの体力を1減らす
        playerHp--;

        Debug.Log(playerHp);
    }
}
