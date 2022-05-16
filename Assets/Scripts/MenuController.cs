using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text RecordTxt;
    public Text CoinText;

    private SaveController sc;
    private Save save = new Save();
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        sc = GetComponent<SaveController>();
        save = sc.GetSave();

        RecordTxt.text = $"Best: {save.Record}";
        CoinText.text = save.Coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
