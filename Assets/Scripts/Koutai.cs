using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//現在使用していない
public class Koutai : MonoBehaviour
{
    public Text Team1;
    public Text Team2;
    //public GameObject Icon1;
    //public GameObject Icon2;

    string Save; //Teamテキストのセーブ
    int SaveScore;


    private void Start()
    {
        Team1.text = "ブルーベルズ";
        Team2.text = "アドバンス";
    }

    //ラウンド交代処理(まだ使うかわからない)
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

        //セット数(仮)
        //scoreManager.SetNum += 1;
        //scoreManager.SetCount.text = scoreManager.SetNum.ToString();

        //アイコンの移動
        //Vector3 pos1 = Icon1.transform.position;
        //Vector3 pos2 = Icon2.transform.position;
        //pos1.x *= -1;
        //pos2.x *= -1;
        //Icon1.transform.position = pos1;
        //Icon2.transform.position = pos2;
    }
}
