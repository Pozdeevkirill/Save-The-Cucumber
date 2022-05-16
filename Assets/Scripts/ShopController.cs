using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    
    [Header("Other Setting")]
    public GameObject _cam; // Камера
    public Text PriceText; // текст цены

    [Header("Buttons")]
    public Button BuyBtn; // Кнопка покупки

    public Button CucumbergBtn; // Кнопка огурца
    public Button BananaBtn; // Кнопка банана

    [Header("Prices")]
    public int BananaPrice; 

    private int ChoosedBtn; // Выбранный скин
    private int price; 

    private SaveController sc;
    private Save save = new Save();
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        // Получаем сохранения
        sc = _cam.GetComponent<SaveController>(); 
        save = sc.GetSave();
        //

        // Вешаем на кнопки методы
        CucumbergBtn.onClick.AddListener(CucumbergVoid);
        BananaBtn.onClick.AddListener(BananaVoid);
        //
    }

    void CucumbergVoid()
    {
        BuyBtn.gameObject.SetActive(true);// Включаем кнопку покупки/выбора скина
        ChoosedBtn = 0;// Говорим какой скин сейчас выбран
        if (save.Cucmberg == true) // Проверяем, куплен ли скин
        {
            PriceText.gameObject.SetActive(false); // Выключаем текст цены
            BuyBtn.GetComponentInChildren<Text>().text = "Выбрать";// Меняем текст кнопки
            BuyBtn.interactable = true; //Включаем взаимодействие с кнопкой
            BuyBtn.onClick.AddListener(() => Select(ChoosedBtn)); // Вешаем на кнопку метод
        }
        if(save.ChoosedSkin == 0)// Проверка на выбранный скин
        {
            BuyBtn.interactable = false;//Выключаем взаимодействие с кнопкой
            BuyBtn.GetComponentInChildren<Text>().text = "Выбран";// Меняем текст кнопки
        }
    }
    
    void BananaVoid()
    {
        BuyBtn.gameObject.SetActive(true); // Включаем кнопку покупки/выбора скина
        ChoosedBtn = 1; // Говорим какой скин сейчас выбран
        if(save.Banana == false)// Проверяем, куплен ли скин
        {
            BuyBtn.GetComponentInChildren<Text>().text = "Купить";// Меняем текст кнопки
            price = BananaPrice; // Устанавливаем цены скина
            PriceText.gameObject.SetActive(true); // Включаем текст цены
            PriceText.text = price.ToString(); // Меняем текст цены
            BuyBtn.onClick.AddListener(Buy); // Вешаем на кнопку метод
            if (save.Coin < BananaPrice) // Проверка на кол-во денег
                BuyBtn.interactable = false;//Включаем взаимодействие с кнопкой
            else
                BuyBtn.interactable = true;//Выключаем взаимодействие с кнопкой
        }
        else
        {
            PriceText.gameObject.SetActive(false);// Выключаем текст цены
            BuyBtn.GetComponentInChildren<Text>().text = "Выбрать"; // Меняем текст кнопки
            BuyBtn.onClick.AddListener(() => Select(ChoosedBtn));// Вешаем на кнопку метод
            BuyBtn.interactable = true;//Включаем взаимодействие с кнопкой
            if (save.ChoosedSkin == 1) // Проверка на выбранный скин
            {
                BuyBtn.interactable= false;//Выключаем взаимодействие с кнопкой
                BuyBtn.GetComponentInChildren<Text>().text = "Выбран";// Меняем текст кнопки
            }
        }
    }

    void Buy()
    {
        save.Coin -= price;

        switch (ChoosedBtn)
        {
            case 1:
                save.Banana = true;
                save.ChoosedSkin = 1;
                BananaVoid();
                break;
        }

        PriceText.gameObject.SetActive(false);
        sc.SaveGame(save);
    }

    private void Select(int id)
    {
        BuyBtn.interactable = false;
        BuyBtn.GetComponentInChildren<Text>().text = "Выбран";
        save.ChoosedSkin = id;
        sc.SaveGame(save);
    }
    
}
