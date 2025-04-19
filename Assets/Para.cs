using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Para : MonoBehaviour
{
    public static Para Instance;
    public Button bir;
    public Button on;
    public Button elli;
    public Button yüz;
    public Button beþyüz;

    public Button Play;
    public TextMeshProUGUI betText;
    public TextMeshProUGUI bakiyeText;
    public TextMeshProUGUI kazanýlanText;

    public float bakiye;
    public float bahis;

    public GameObject GameUI;
    public GameObject BetUI;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        bahis = 0;
        bakiye = 10000;
        betText.text = 0.ToString();
        bakiyeText.text = "$ " + bakiye.ToString();
    }

    public void Basla()
    {
        if (bahis > 0)
        {
            kazanýlanText.text = "";
            bakiye -= bahis;
            GameManager.Instance.yenioyun();
            GameUI.SetActive(true);
            BetUI.SetActive(false);
            bakiyeText.text = "$ " + bakiye.ToString();
        }
    }
    public void Bir()
    {
        if (bakiye > bahis)
        {
            bahis += 1;
            betText.text = bahis.ToString();
        }
    }
    public void On()
    {
        if (bakiye > bahis)
        {
            bahis += 10;
            betText.text = bahis.ToString();

        }
    }
    public void Elli()
    {
        if (bakiye > bahis)
        {
            bahis += 50;
            betText.text = bahis.ToString();

        }
    }
    public void Yüz()
    {
        if (bakiye > bahis)
        {
            bahis += 100;
            betText.text = bahis.ToString();

        }
    }
    public void Beþyüz()
    {
        if (bakiye > bahis)
        {
            bahis += 500;
            betText.text = bahis.ToString();
        }
    }
    public void oyuncukazandý()
    {
        bakiye += bahis * 2;
        GameUI.SetActive(false);
        BetUI.SetActive(true);
        KartVerici.Instance.sýfýrla();
        bahis = 0;
        betText.text = bahis.ToString();
        bakiyeText.text = "$ " + bakiye.ToString();
        kazanýlanText.text = "";
    }
    public void berabere()
    {
        bakiye += bahis;
        GameUI.SetActive(false);
        BetUI.SetActive(true);
        KartVerici.Instance.sýfýrla();
        bahis = 0;
        betText.text = bahis.ToString();
        bakiyeText.text = "$ " + bakiye.ToString();
        kazanýlanText.text = "";
    }
    public void kurpiyerkazandý()
    {
        GameUI.SetActive(false);
        BetUI.SetActive(true);
        KartVerici.Instance.sýfýrla();
        bahis = 0;
        betText.text = bahis.ToString();
        bakiyeText.text = "$ " + bakiye.ToString();
        kazanýlanText.text = "";
    }
}
