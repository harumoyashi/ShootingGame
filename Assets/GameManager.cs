using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;          //スコア
    public Text textComponent;  //テキスト

    // Start is called before the first frame update
    void Start()
    {
        //スコア初期化
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Rキーでリセット
        if (Input.GetKey(KeyCode.R))
        {
            SceneReset();
        }
    }

    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    public void ScoreCount()
    {
        score += 1000;
        Debug.Log("Score" + score);
        textComponent.text = "Score:" + score;
    }
}
