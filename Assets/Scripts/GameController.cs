using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Objects")]
    public GameObject Player;
    public GameObject Spawner;

    [Header("UI")]
    public Text ScoreTxt;

    [Header("End Game UI")]
    
    public GameObject EndPanel;
    public Text NewRecordText;

    public int Score = 0; // ������� ����
    public int ScoreRecord; // ��������� ����

    [Header("Skins")]
    public Sprite Cucumberg;
    public Sprite Banana;

    private SaveController sc;
    private Save save = new Save();
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        sc = gameObject.GetComponent<SaveController>();
        save = sc.GetSave();
        ScoreRecord = save.Record;
        switch (save.ChoosedSkin)
        {
            case 0:
                Player.GetComponent<SpriteRenderer>().sprite = Cucumberg;
                break;
            case 1:
                Player.GetComponent<SpriteRenderer>().sprite= Banana;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Knife")
        {
            Score += 1;
            ScoreTxt.text = $"{Score}";
            Destroy(collision.gameObject);
            if(Score % 10 == 0)
            {
                save.Coin += 1;
                sc.SaveGame(save);

                if (Spawner.GetComponent<SpawnKnifeController>().speedKnife < 6)    // (��������� ��������) // �� �� ������� ����������� - ���-�� ������� �� ���� ��������
                    Spawner.GetComponent<SpawnKnifeController>().speedKnife += 0.35f; //(2.5) //0.5 - 7 �������� | 0.3 - 12 �������� | 0.4 - 9 �������� | 0.35 - 10 �������� 

                if (Spawner.GetComponent<SpawnKnifeController>()._SpawnDely > 1)
                    Spawner.GetComponent<SpawnKnifeController>()._SpawnDely -= 0.2f; //(3) //0.2 - 10 �������� 

                if (Player.GetComponent<PlayerController>().speedRotation < 170)
                    Player.GetComponent<PlayerController>().speedRotation += 6; //(110) // 10 - 6 �������� | 6 - 10 ��������
            }
        }
    }

    public void EndGame() // ����� ��������� ����
    {
        EndPanel.SetActive(true); // �������� ������
        //Time.timeScale = 0; // ������������� ����
        Player.GetComponent<PlayerController>().speedRotation = 0; // ������������� �������� ������
        Spawner.GetComponent<SpawnKnifeController>().speedKnife = 0; // ������������� �������� �����
        Spawner.GetComponent<SpawnKnifeController>()._spawn = false; // ������������� ����� �����

        if(Score > ScoreRecord) // �������� �� ������
            NewRecord();
    }

    void NewRecord()
    {
        NewRecordText.gameObject.SetActive(true);
        ScoreRecord = Score;
        save.Record = ScoreRecord;
        sc.SaveGame(save);
    }
}
