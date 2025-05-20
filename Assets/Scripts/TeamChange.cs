using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//現在使用していない
public class TeamChange : MonoBehaviour
{
    public Text Team1;
    public Text Team2;
    //public GameObject Icon1;
    //public GameObject Icon2;

    string Save; //Teamテキストのセーブ
    int SaveScore;

    ScoreButtonManager scoreManager;

    private void Start()
    {
        Team1.text = "ブルーベルズ";
        Team2.text = "アドバンス";

        //ScoreButtonManagerクラスのインスタンスを取得してからアクセスする
        scoreManager = FindObjectOfType<ScoreButtonManager>();
    }

    //ラウンド交代処理
    public void TeamChangeButton()
    {
        

        Save = Team1.text;//Team1のテキストを保存
        Team1.text = Team2.text;
        Team2.text = Save;

        

        SaveScore = scoreManager.score1; //score1の数値を保存
        scoreManager.score1 = scoreManager.score2;
        scoreManager.score2 = SaveScore;


        //入れ替えたスコアを適用
        scoreManager.score1Text.text = scoreManager.score1.ToString();
        scoreManager.score2Text.text = scoreManager.score2.ToString();

        //各マッチの保存スコアの入れ替え
        ////1マッチ目
        //scoreManager.score1_Save1.text = scoreManager.Score2_Save[0].ToString();
        //scoreManager.score2_Save1.text = scoreManager.Score1_Save[0].ToString();

        ////2マッチ目
        //scoreManager.score1_Save2.text = scoreManager.Score2_Save[1].ToString();
        //scoreManager.score2_Save2.text = scoreManager.Score1_Save[1].ToString();

        ////3マッチ目
        //scoreManager.score1_Save3.text = scoreManager.Score2_Save[2].ToString();
        //scoreManager.score2_Save3.text = scoreManager.Score1_Save[2].ToString();

        //アイコンの移動
        //Vector3 pos1 = Icon1.transform.position;
        //Vector3 pos2 = Icon2.transform.position;
        //pos1.x *= -1;
        //pos2.x *= -1;
        //Icon1.transform.position = pos1;
        //Icon2.transform.position = pos2;
    }
}
