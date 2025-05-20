using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//���ݎg�p���Ă��Ȃ�
public class TeamChange : MonoBehaviour
{
    public Text Team1;
    public Text Team2;
    //public GameObject Icon1;
    //public GameObject Icon2;

    string Save; //Team�e�L�X�g�̃Z�[�u
    int SaveScore;

    ScoreButtonManager scoreManager;

    private void Start()
    {
        Team1.text = "�u���[�x���Y";
        Team2.text = "�A�h�o���X";

        //ScoreButtonManager�N���X�̃C���X�^���X���擾���Ă���A�N�Z�X����
        scoreManager = FindObjectOfType<ScoreButtonManager>();
    }

    //���E���h��㏈��
    public void TeamChangeButton()
    {
        

        Save = Team1.text;//Team1�̃e�L�X�g��ۑ�
        Team1.text = Team2.text;
        Team2.text = Save;

        

        SaveScore = scoreManager.score1; //score1�̐��l��ۑ�
        scoreManager.score1 = scoreManager.score2;
        scoreManager.score2 = SaveScore;


        //����ւ����X�R�A��K�p
        scoreManager.score1Text.text = scoreManager.score1.ToString();
        scoreManager.score2Text.text = scoreManager.score2.ToString();

        //�e�}�b�`�̕ۑ��X�R�A�̓���ւ�
        ////1�}�b�`��
        //scoreManager.score1_Save1.text = scoreManager.Score2_Save[0].ToString();
        //scoreManager.score2_Save1.text = scoreManager.Score1_Save[0].ToString();

        ////2�}�b�`��
        //scoreManager.score1_Save2.text = scoreManager.Score2_Save[1].ToString();
        //scoreManager.score2_Save2.text = scoreManager.Score1_Save[1].ToString();

        ////3�}�b�`��
        //scoreManager.score1_Save3.text = scoreManager.Score2_Save[2].ToString();
        //scoreManager.score2_Save3.text = scoreManager.Score1_Save[2].ToString();

        //�A�C�R���̈ړ�
        //Vector3 pos1 = Icon1.transform.position;
        //Vector3 pos2 = Icon2.transform.position;
        //pos1.x *= -1;
        //pos2.x *= -1;
        //Icon1.transform.position = pos1;
        //Icon2.transform.position = pos2;
    }
}
