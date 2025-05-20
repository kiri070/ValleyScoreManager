using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Koutai : MonoBehaviour
{
    public Text Team1;
    public Text Team2;

    string Save; //Teamテキストのセーブ
    int SaveScore;


    private void Start()
    {
        Team1.text = "ブルーベルズ";
        Team2.text = "アドバンス";
    }

    //ラウンド交代処理
    public void CoatChangeButton()
    {
        Save = Team1.text;//Team1のテキストを保存
        Team1.text = Team2.text;
        Team2.text = Save;

        //ScoreButtonManagerクラスのインスタンスを取得してからアクセスする
        ScoreButtonManager scoreManager = FindObjectOfType<ScoreButtonManager>();

        SaveScore = scoreManager.score1; //score1の数値を保存
        scoreManager.score1 = scoreManager.score2;
        scoreManager.score2 = SaveScore;

        //入れ替えたスコアを適用
        scoreManager.score1Text.text = scoreManager.score1.ToString();
        scoreManager.score2Text.text = scoreManager.score2.ToString();
    }
}
