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
    public Button y�z;
    public Button be�y�z;

    public Button Play;
    public TextMeshProUGUI betText;
    public TextMeshProUGUI bakiyeText;
    public TextMeshProUGUI kazan�lanText;

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
            kazan�lanText.text = "";
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
    public void Y�z()
    {
        if (bakiye > bahis)
        {
            bahis += 100;
            betText.text = bahis.ToString();

        }
    }
    public void Be�y�z()
    {
        if (bakiye > bahis)
        {
            bahis += 500;
            betText.text = bahis.ToString();
        }
    }
    public void oyuncukazand�()
    {
        bakiye += bahis * 2;
        GameUI.SetActive(false);
        BetUI.SetActive(true);
        KartVerici.Instance.s�f�rla();
        bahis = 0;
        betText.text = bahis.ToString();
        bakiyeText.text = "$ " + bakiye.ToString();
        kazan�lanText.text = "";
    }
    public void berabere()
    {
        bakiye += bahis;
        GameUI.SetActive(false);
        BetUI.SetActive(true);
        KartVerici.Instance.s�f�rla();
        bahis = 0;
        betText.text = bahis.ToString();
        bakiyeText.text = "$ " + bakiye.ToString();
        kazan�lanText.text = "";
    }
    public void kurpiyerkazand�()
    {
        GameUI.SetActive(false);
        BetUI.SetActive(true);
        KartVerici.Instance.s�f�rla();
        bahis = 0;
        betText.text = bahis.ToString();
        bakiyeText.text = "$ " + bakiye.ToString();
        kazan�lanText.text = "";
    }
}
