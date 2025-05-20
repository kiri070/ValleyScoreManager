using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreButtonManager : MonoBehaviour
{
    [Header("各チームの点数を表示するテキスト")]
    public Text score1Text; 
    public Text score2Text;

    [Header("現在のセット数を表示するテキスト")]
    public Text SetCount;

    [Header("各チーム名を表示するテキスト")]
    public Text Team1; 
    public Text Team2;

    [Header("各マッチのスコアを表示するテキスト")]
    public Text score1_Save1; 
    public Text score1_Save2;
    public Text score1_Save3;
    public Text score2_Save1;
    public Text score2_Save2;
    public Text score2_Save3;


    public int score1 = 0;
    public int score2 = 0;
    public int SetNum = 1; //初期セット数
    private int ScoreSaveCount = 1;

    //色管理のための変数
    int Score1_1 = 0;
    int Score1_2 = 0;
    int Score1_3 = 0;
    int Score2_1 = 0;
    int Score2_2 = 0;
    int Score2_3 = 0;


    string PointSave; //各マッチの点数を一時保存
    string Save; //チーム名一時保存
    int SaveScore; //スコア一時保存

    bool SetKakunin = false; //セット終了確認
    bool SetButtonKirikae = true; //セット終了ボタン押せるか

    //各マッチのスコア保存リスト
    public List<int> Score1_Save = new List<int>();
    public List<int> Score2_Save = new List<int>();


    public void Start()
    {
        //初期化としてセット数を1に設定
        SetCount.text = SetNum.ToString();

        //チーム名
        Team1.text = "ブルーベルズ";
        Team2.text = "アドバンス";
    }

    public void Update()
    {
        //色管理
        //スコアの色
        Text text1 = score1Text.GetComponent<Text>();
        Text text2 = score2Text.GetComponent<Text>();

        //scoreの絶対値を計算
        int Gap1 = Mathf.Abs(score1);
        int Gap2 = Mathf.Abs(score2);

        //セット終了処理
        //score1が21以上,絶対値が2以上なら //score2が21以上,絶対値が2以上なら
        if (score1 >= 21 && Mathf.Abs(score1 - score2) >= 2 || score2 >= 21 && Mathf.Abs(score2 - score1) >= 2)
        {
            //score1が負けていたら
            if (score1 < score2)
            {
                //スコア文字を白に設定
                text1.color = new Color(1f, 1f, 1f, 1f);

                //赤
                text2.color = Color.red;
            }
            //score2が負けていたら
            else if (score1 > score2)
            {
                //スコア文字を白に設定
                text2.color = new Color(1f, 1f, 1f, 1f);

                //赤
                text1.color = Color.red;
            }

            //セット終了処理
            if (SetKakunin)
            {
                //セット数が3なら3を返す
                if (SetNum == 3)
                {
                    SetNum = 3;
                }
                //それ以外ならセット数+1
                else
                {
                    SetNum += 1;
                }

                SetCount.text = SetNum.ToString();



                //チーム名入れ替え
                Save = Team1.text;
                Team1.text = Team2.text;
                Team2.text = Save;

                //スコア入れ替え
                SaveScore = score1;
                score1 = score2;
                score2 = SaveScore;

                //スコア文字を白に設定
                text1.color = new Color(1f, 1f, 1f, 1f);
                text2.color = new Color(1f, 1f, 1f, 1f);

                //スコアを保存する
                Score1_Save.Add(score1);
                Score2_Save.Add(score2);

                //セット数によって保存するスコアを変える
                //１マッチ目なら
                if (ScoreSaveCount == 1)
                {

                    //保存スコアを表示
                    score1_Save1.text = Score1_Save[0].ToString();
                    score2_Save1.text = Score2_Save[0].ToString();

                    //追加
                    //スコアリセット
                    score1 = 0; score2 = 0;
                }
                //2マッチ目なら
                else if (ScoreSaveCount == 2)
                {
                    //保存スコアの書き換え
                    score1_Save1.text = Score2_Save[0].ToString();
                    score2_Save1.text = Score1_Save[0].ToString();

                    //保存スコアの書き換え
                    score1_Save2.text = Score1_Save[1].ToString();
                    score2_Save2.text = Score2_Save[1].ToString();

                    //追加
                    //スコアリセット
                    score1 = 0; score2 = 0;

                }
                //3マッチ目なら
                else if (ScoreSaveCount == 3)
                {

                    //保存スコアの書き換え
                    score1_Save1.text = Score1_Save[0].ToString();
                    score2_Save1.text = Score2_Save[0].ToString();

                    score1_Save2.text = Score2_Save[1].ToString();
                    score2_Save2.text = Score1_Save[1].ToString();



                    score1_Save3.text = Score1_Save[2].ToString();
                    score2_Save3.text = Score2_Save[2].ToString();

                }

                //入れ替えたスコアを適用
                score1Text.text = score1.ToString();
                score2Text.text = score2.ToString();

                //ScoreSaveCountを増やす
                ScoreSaveCount++;

                SetKakunin = false;
                SetButtonKirikae = true;
            }

        }
        //デュースなら
        else if (score1 >= 20 && score2 >= 20 && Gap1 == Gap2)
        {
            //スコア文字を赤に設定
            text1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            text2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

            //何もしない
            return;
        }


        //各セットの点数の色の管理
        Score1_1 = int.Parse(score1_Save1.text);
        Score1_2 = int.Parse(score1_Save2.text);
        Score1_3 = int.Parse(score1_Save3.text);

        Score2_1 = int.Parse(score2_Save1.text);
        Score2_2 = int.Parse(score2_Save2.text);
        Score2_3 = int.Parse(score2_Save3.text);

        Text text1_1 = score1_Save1.GetComponent<Text>();
        Text text1_2 = score1_Save2.GetComponent<Text>();
        Text text1_3 = score1_Save3.GetComponent<Text>();
        Text text2_1 = score2_Save1.GetComponent<Text>();
        Text text2_2 = score2_Save2.GetComponent<Text>();
        Text text2_3 = score2_Save3.GetComponent<Text>();

        //スコア2_1よりスコア1_1が大きれば
        if (Score1_1 > Score2_1)
        {
            text1_1.color = Color.red;
            text2_1.color = Color.white;
        }
        //スコア1_1よりスコア2_1が大きれば
        else if (Score2_1 > Score1_1)
        {
            text1_1.color = Color.white;
            text2_1.color = Color.red;
        }

        //スコア2_2よりスコア1_2が大きれば
        if (Score1_2 > Score2_2)
        {
            text1_2.color = Color.red;
            text2_2.color = Color.white;
        }
        //スコア1_2よりスコア2_2が大きれば
        else if (Score2_2 > Score1_2)
        {
            text1_2.color = Color.white;
            text2_2.color = Color.red;
        }

        //スコア2_3よりスコア1_3が大きれば
        if (Score1_3 > Score2_3)
        {
            text1_3.color = Color.red;
            text2_3.color = Color.white;
        }
        //スコア1_3よりスコア2_3が大きれば
        else if (Score2_3 > Score1_3)
        {
            text1_3.color = Color.white;
            text2_3.color = Color.red;
        }
    }

    //Score1
    public void IncreaseScore_1(int num)
    {
        score1 += num;
        score1Text.text = score1.ToString(); //score1の数字を表記
    }

    public void DecreaseScore_1(int num)
    {
        score1 -= num;
        score1Text.text = score1.ToString();
    }

    //Score2
    public void IncreaseScore_2(int num)
    {
        score2 += num;
        score2Text.text = score2.ToString();
    }

    public void DecreaseScore_2(int num)
    {
        score2 -= num;
        score2Text.text = score2.ToString();
    }


    //Score1のボタン処理
    public void Score1PlusButton()
    {
        IncreaseScore_1(1);
    }
    public void Score1MainasuButton()
    {
        DecreaseScore_1(1);
    }

    //Score2のボタン処理
    public void Score2PlusButton()
    {
        IncreaseScore_2(1);
    }
    public void Score2MainasuButton()
    {
        DecreaseScore_2(1);
    }

    //セット終了確認ボタン
    public void SetKakuninButton()
    {
        if (SetButtonKirikae && score1 >= 21 && Mathf.Abs(score1 - score2) >= 2 || SetButtonKirikae && score2 >= 21 && Mathf.Abs(score2 - score1) >= 2)
        {
            SetKakunin = true;
            SetButtonKirikae = false;
        }
    }


    //コートチェンジボタン
    public void TeamChangeButton()
    {
        Save = Team1.text;//Team1のテキストを保存
        Team1.text = Team2.text;
        Team2.text = Save;



        SaveScore = score1; //score1の数値を保存
        score1 = score2;
        score2 = SaveScore;


        //入れ替えたスコアを適用
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();

        //スコアを入れ替える前に、スコアリストを入れ替えるための一時変数を作成
        List<int> tempScoreList = new List<int>(Score1_Save);
        Score1_Save = new List<int>(Score2_Save);
        Score2_Save = new List<int>(tempScoreList);

        //各マッチの保存スコアの入れ替え
        //1マッチ目の点数
        PointSave = score1_Save1.text;
        score1_Save1.text = score2_Save1.text;
        score2_Save1.text = PointSave;

        //2マッチ目の点数
        PointSave = score1_Save2.text;
        score1_Save2.text = score2_Save2.text;
        score2_Save2.text = PointSave;

        //3マッチ目の点数
        PointSave = score1_Save3.text;
        score1_Save3.text = score2_Save3.text;
        score2_Save3.text = PointSave;

    }
}
