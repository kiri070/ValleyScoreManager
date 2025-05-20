using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreButtonManager : MonoBehaviour
{
    [Header("�e�`�[���̓_����\������e�L�X�g")]
    public Text score1Text; 
    public Text score2Text;

    [Header("���݂̃Z�b�g����\������e�L�X�g")]
    public Text SetCount;

    [Header("�e�`�[������\������e�L�X�g")]
    public Text Team1; 
    public Text Team2;

    [Header("�e�}�b�`�̃X�R�A��\������e�L�X�g")]
    public Text score1_Save1; 
    public Text score1_Save2;
    public Text score1_Save3;
    public Text score2_Save1;
    public Text score2_Save2;
    public Text score2_Save3;


    public int score1 = 0;
    public int score2 = 0;
    public int SetNum = 1; //�����Z�b�g��
    private int ScoreSaveCount = 1;

    //�F�Ǘ��̂��߂̕ϐ�
    int Score1_1 = 0;
    int Score1_2 = 0;
    int Score1_3 = 0;
    int Score2_1 = 0;
    int Score2_2 = 0;
    int Score2_3 = 0;


    string PointSave; //�e�}�b�`�̓_�����ꎞ�ۑ�
    string Save; //�`�[�����ꎞ�ۑ�
    int SaveScore; //�X�R�A�ꎞ�ۑ�

    bool SetKakunin = false; //�Z�b�g�I���m�F
    bool SetButtonKirikae = true; //�Z�b�g�I���{�^�������邩

    //�e�}�b�`�̃X�R�A�ۑ����X�g
    public List<int> Score1_Save = new List<int>();
    public List<int> Score2_Save = new List<int>();


    public void Start()
    {
        //�������Ƃ��ăZ�b�g����1�ɐݒ�
        SetCount.text = SetNum.ToString();

        //�`�[����
        Team1.text = "�u���[�x���Y";
        Team2.text = "�A�h�o���X";
    }

    public void Update()
    {
        //�F�Ǘ�
        //�X�R�A�̐F
        Text text1 = score1Text.GetComponent<Text>();
        Text text2 = score2Text.GetComponent<Text>();

        //score�̐�Βl���v�Z
        int Gap1 = Mathf.Abs(score1);
        int Gap2 = Mathf.Abs(score2);

        //�Z�b�g�I������
        //score1��21�ȏ�,��Βl��2�ȏ�Ȃ� //score2��21�ȏ�,��Βl��2�ȏ�Ȃ�
        if (score1 >= 21 && Mathf.Abs(score1 - score2) >= 2 || score2 >= 21 && Mathf.Abs(score2 - score1) >= 2)
        {
            //score1�������Ă�����
            if (score1 < score2)
            {
                //�X�R�A�����𔒂ɐݒ�
                text1.color = new Color(1f, 1f, 1f, 1f);

                //��
                text2.color = Color.red;
            }
            //score2�������Ă�����
            else if (score1 > score2)
            {
                //�X�R�A�����𔒂ɐݒ�
                text2.color = new Color(1f, 1f, 1f, 1f);

                //��
                text1.color = Color.red;
            }

            //�Z�b�g�I������
            if (SetKakunin)
            {
                //�Z�b�g����3�Ȃ�3��Ԃ�
                if (SetNum == 3)
                {
                    SetNum = 3;
                }
                //����ȊO�Ȃ�Z�b�g��+1
                else
                {
                    SetNum += 1;
                }

                SetCount.text = SetNum.ToString();



                //�`�[��������ւ�
                Save = Team1.text;
                Team1.text = Team2.text;
                Team2.text = Save;

                //�X�R�A����ւ�
                SaveScore = score1;
                score1 = score2;
                score2 = SaveScore;

                //�X�R�A�����𔒂ɐݒ�
                text1.color = new Color(1f, 1f, 1f, 1f);
                text2.color = new Color(1f, 1f, 1f, 1f);

                //�X�R�A��ۑ�����
                Score1_Save.Add(score1);
                Score2_Save.Add(score2);

                //�Z�b�g���ɂ���ĕۑ�����X�R�A��ς���
                //�P�}�b�`�ڂȂ�
                if (ScoreSaveCount == 1)
                {

                    //�ۑ��X�R�A��\��
                    score1_Save1.text = Score1_Save[0].ToString();
                    score2_Save1.text = Score2_Save[0].ToString();

                    //�ǉ�
                    //�X�R�A���Z�b�g
                    score1 = 0; score2 = 0;
                }
                //2�}�b�`�ڂȂ�
                else if (ScoreSaveCount == 2)
                {
                    //�ۑ��X�R�A�̏�������
                    score1_Save1.text = Score2_Save[0].ToString();
                    score2_Save1.text = Score1_Save[0].ToString();

                    //�ۑ��X�R�A�̏�������
                    score1_Save2.text = Score1_Save[1].ToString();
                    score2_Save2.text = Score2_Save[1].ToString();

                    //�ǉ�
                    //�X�R�A���Z�b�g
                    score1 = 0; score2 = 0;

                }
                //3�}�b�`�ڂȂ�
                else if (ScoreSaveCount == 3)
                {

                    //�ۑ��X�R�A�̏�������
                    score1_Save1.text = Score1_Save[0].ToString();
                    score2_Save1.text = Score2_Save[0].ToString();

                    score1_Save2.text = Score2_Save[1].ToString();
                    score2_Save2.text = Score1_Save[1].ToString();



                    score1_Save3.text = Score1_Save[2].ToString();
                    score2_Save3.text = Score2_Save[2].ToString();

                }

                //����ւ����X�R�A��K�p
                score1Text.text = score1.ToString();
                score2Text.text = score2.ToString();

                //ScoreSaveCount�𑝂₷
                ScoreSaveCount++;

                SetKakunin = false;
                SetButtonKirikae = true;
            }

        }
        //�f���[�X�Ȃ�
        else if (score1 >= 20 && score2 >= 20 && Gap1 == Gap2)
        {
            //�X�R�A������Ԃɐݒ�
            text1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            text2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

            //�������Ȃ�
            return;
        }


        //�e�Z�b�g�̓_���̐F�̊Ǘ�
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

        //�X�R�A2_1���X�R�A1_1���傫���
        if (Score1_1 > Score2_1)
        {
            text1_1.color = Color.red;
            text2_1.color = Color.white;
        }
        //�X�R�A1_1���X�R�A2_1���傫���
        else if (Score2_1 > Score1_1)
        {
            text1_1.color = Color.white;
            text2_1.color = Color.red;
        }

        //�X�R�A2_2���X�R�A1_2���傫���
        if (Score1_2 > Score2_2)
        {
            text1_2.color = Color.red;
            text2_2.color = Color.white;
        }
        //�X�R�A1_2���X�R�A2_2���傫���
        else if (Score2_2 > Score1_2)
        {
            text1_2.color = Color.white;
            text2_2.color = Color.red;
        }

        //�X�R�A2_3���X�R�A1_3���傫���
        if (Score1_3 > Score2_3)
        {
            text1_3.color = Color.red;
            text2_3.color = Color.white;
        }
        //�X�R�A1_3���X�R�A2_3���傫���
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
        score1Text.text = score1.ToString(); //score1�̐�����\�L
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


    //Score1�̃{�^������
    public void Score1PlusButton()
    {
        IncreaseScore_1(1);
    }
    public void Score1MainasuButton()
    {
        DecreaseScore_1(1);
    }

    //Score2�̃{�^������
    public void Score2PlusButton()
    {
        IncreaseScore_2(1);
    }
    public void Score2MainasuButton()
    {
        DecreaseScore_2(1);
    }

    //�Z�b�g�I���m�F�{�^��
    public void SetKakuninButton()
    {
        if (SetButtonKirikae && score1 >= 21 && Mathf.Abs(score1 - score2) >= 2 || SetButtonKirikae && score2 >= 21 && Mathf.Abs(score2 - score1) >= 2)
        {
            SetKakunin = true;
            SetButtonKirikae = false;
        }
    }


    //�R�[�g�`�F���W�{�^��
    public void TeamChangeButton()
    {
        Save = Team1.text;//Team1�̃e�L�X�g��ۑ�
        Team1.text = Team2.text;
        Team2.text = Save;



        SaveScore = score1; //score1�̐��l��ۑ�
        score1 = score2;
        score2 = SaveScore;


        //����ւ����X�R�A��K�p
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();

        //�X�R�A�����ւ���O�ɁA�X�R�A���X�g�����ւ��邽�߂̈ꎞ�ϐ����쐬
        List<int> tempScoreList = new List<int>(Score1_Save);
        Score1_Save = new List<int>(Score2_Save);
        Score2_Save = new List<int>(tempScoreList);

        //�e�}�b�`�̕ۑ��X�R�A�̓���ւ�
        //1�}�b�`�ڂ̓_��
        PointSave = score1_Save1.text;
        score1_Save1.text = score2_Save1.text;
        score2_Save1.text = PointSave;

        //2�}�b�`�ڂ̓_��
        PointSave = score1_Save2.text;
        score1_Save2.text = score2_Save2.text;
        score2_Save2.text = PointSave;

        //3�}�b�`�ڂ̓_��
        PointSave = score1_Save3.text;
        score1_Save3.text = score2_Save3.text;
        score2_Save3.text = PointSave;

    }
}
