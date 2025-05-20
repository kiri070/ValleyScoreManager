using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Koutai : MonoBehaviour
{
    public Text Team1;
    public Text Team2;

    string Save; //Team�e�L�X�g�̃Z�[�u
    int SaveScore;


    private void Start()
    {
        Team1.text = "�u���[�x���Y";
        Team2.text = "�A�h�o���X";
    }

    //���E���h��㏈��
    public void CoatChangeButton()
    {
        Save = Team1.text;//Team1�̃e�L�X�g��ۑ�
        Team1.text = Team2.text;
        Team2.text = Save;

        //ScoreButtonManager�N���X�̃C���X�^���X���擾���Ă���A�N�Z�X����
        ScoreButtonManager scoreManager = FindObjectOfType<ScoreButtonManager>();

        SaveScore = scoreManager.score1; //score1�̐��l��ۑ�
        scoreManager.score1 = scoreManager.score2;
        scoreManager.score2 = SaveScore;

        //����ւ����X�R�A��K�p
        scoreManager.score1Text.text = scoreManager.score1.ToString();
        scoreManager.score2Text.text = scoreManager.score2.ToString();
    }
}
