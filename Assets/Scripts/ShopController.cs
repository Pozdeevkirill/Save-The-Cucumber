using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    
    [Header("Other Setting")]
    public GameObject _cam; // ������
    public Text PriceText; // ����� ����

    [Header("Buttons")]
    public Button BuyBtn; // ������ �������

    public Button CucumbergBtn; // ������ ������
    public Button BananaBtn; // ������ ������

    [Header("Prices")]
    public int BananaPrice; 

    private int ChoosedBtn; // ��������� ����
    private int price; 

    private SaveController sc;
    private Save save = new Save();
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        // �������� ����������
        sc = _cam.GetComponent<SaveController>(); 
        save = sc.GetSave();
        //

        // ������ �� ������ ������
        CucumbergBtn.onClick.AddListener(CucumbergVoid);
        BananaBtn.onClick.AddListener(BananaVoid);
        //
    }

    void CucumbergVoid()
    {
        BuyBtn.gameObject.SetActive(true);// �������� ������ �������/������ �����
        ChoosedBtn = 0;// ������� ����� ���� ������ ������
        if (save.Cucmberg == true) // ���������, ������ �� ����
        {
            PriceText.gameObject.SetActive(false); // ��������� ����� ����
            BuyBtn.GetComponentInChildren<Text>().text = "�������";// ������ ����� ������
            BuyBtn.interactable = true; //�������� �������������� � �������
            BuyBtn.onClick.AddListener(() => Select(ChoosedBtn)); // ������ �� ������ �����
        }
        if(save.ChoosedSkin == 0)// �������� �� ��������� ����
        {
            BuyBtn.interactable = false;//��������� �������������� � �������
            BuyBtn.GetComponentInChildren<Text>().text = "������";// ������ ����� ������
        }
    }
    
    void BananaVoid()
    {
        BuyBtn.gameObject.SetActive(true); // �������� ������ �������/������ �����
        ChoosedBtn = 1; // ������� ����� ���� ������ ������
        if(save.Banana == false)// ���������, ������ �� ����
        {
            BuyBtn.GetComponentInChildren<Text>().text = "������";// ������ ����� ������
            price = BananaPrice; // ������������� ���� �����
            PriceText.gameObject.SetActive(true); // �������� ����� ����
            PriceText.text = price.ToString(); // ������ ����� ����
            BuyBtn.onClick.AddListener(Buy); // ������ �� ������ �����
            if (save.Coin < BananaPrice) // �������� �� ���-�� �����
                BuyBtn.interactable = false;//�������� �������������� � �������
            else
                BuyBtn.interactable = true;//��������� �������������� � �������
        }
        else
        {
            PriceText.gameObject.SetActive(false);// ��������� ����� ����
            BuyBtn.GetComponentInChildren<Text>().text = "�������"; // ������ ����� ������
            BuyBtn.onClick.AddListener(() => Select(ChoosedBtn));// ������ �� ������ �����
            BuyBtn.interactable = true;//�������� �������������� � �������
            if (save.ChoosedSkin == 1) // �������� �� ��������� ����
            {
                BuyBtn.interactable= false;//��������� �������������� � �������
                BuyBtn.GetComponentInChildren<Text>().text = "������";// ������ ����� ������
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
        BuyBtn.GetComponentInChildren<Text>().text = "������";
        save.ChoosedSkin = id;
        sc.SaveGame(save);
    }
    
}
