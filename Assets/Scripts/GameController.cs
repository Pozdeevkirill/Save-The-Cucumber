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

    public int Score = 0; // Текущий счет
    public int ScoreRecord; // Рекордный счет

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

                if (Spawner.GetComponent<SpawnKnifeController>().speedKnife < 6)    // (Начальное значение) // то на сколько увеличиваем - кол-во походов до макс значения
                    Spawner.GetComponent<SpawnKnifeController>().speedKnife += 0.35f; //(2.5) //0.5 - 7 подходов | 0.3 - 12 подходов | 0.4 - 9 подходов | 0.35 - 10 подходов 

                if (Spawner.GetComponent<SpawnKnifeController>()._SpawnDely > 1)
                    Spawner.GetComponent<SpawnKnifeController>()._SpawnDely -= 0.2f; //(3) //0.2 - 10 подходов 

                if (Player.GetComponent<PlayerController>().speedRotation < 170)
                    Player.GetComponent<PlayerController>().speedRotation += 6; //(110) // 10 - 6 подходов | 6 - 10 подходов
            }
        }
    }

    public void EndGame() // Метод остановки игры
    {
        EndPanel.SetActive(true); // Включаем панель
        //Time.timeScale = 0; // Останавливаем игру
        Player.GetComponent<PlayerController>().speedRotation = 0; // Останавливаем вращение игрока
        Spawner.GetComponent<SpawnKnifeController>().speedKnife = 0; // Останавливаем движение ножей
        Spawner.GetComponent<SpawnKnifeController>()._spawn = false; // Останавливаем спавн ножей

        if(Score > ScoreRecord) // Проверка на рекорд
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
