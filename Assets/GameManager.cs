using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region atamalar
    public Button çekButton;
    public Button pasButton;

    public int kurpiyerPuan = 0;
    public int oyuncuPuan = 0;

    public TextMeshProUGUI oyuncuText;
    public TextMeshProUGUI kurpiyerText;
    public TextMeshProUGUI kazananText;

    public int oyuncuAsSayýsý;
    public int kaçkezaspuaneksildi;

    public int kurpiyerAsSayýsý;
    public int kaçkezkurpiyerpuaneksildi;

    public static GameManager Instance;
    #endregion
    private void Awake()
    {
        Instance = this;
    }

    public void yenioyun()
    {
        kurpiyerAsSayýsý = 0;
        kaçkezkurpiyerpuaneksildi = 0;
        oyuncuAsSayýsý = 0;
        kaçkezaspuaneksildi = 0;
        oyuncuPuan = 0;
        kurpiyerPuan = 0;
        kazananText.text = "";
        KartVerici.Instance.sýfýrla();
        Çek();
        KurpiyerKartÇek();
        kurpiyeryazdýrýcý();
        KurpiyerKartÇek();
        Çek();
    }
    public void Çek()
    {
        int rastgeleSayý = UnityEngine.Random.Range(0, 52);
        if (rastgeleSayý % 13 < 10)
        {
            oyuncuPuan += (rastgeleSayý % 13) + 1;
            oyuncuyazdýrýcý();
        }
        if (rastgeleSayý % 13 >= 10)
        {
            oyuncuPuan += 10;
            oyuncuyazdýrýcý();
        }
        if (rastgeleSayý % 13 == 0)
        {
            oyuncuAsSayýsý++;
            oyuncuPuan += 10;
            oyuncuyazdýrýcý();
        }
        if (oyuncuPuan > 21 && oyuncuAsSayýsý > 0 && kaçkezaspuaneksildi < oyuncuAsSayýsý)
        {
            for (int i = 0; i < oyuncuAsSayýsý - kaçkezaspuaneksildi; i++)
            {
                oyuncuPuan -= 10;
                kaçkezaspuaneksildi++;
            }
            oyuncuyazdýrýcý();
        }
        KartVerici.Instance.oyuncucardvisual(rastgeleSayý);
        if (oyuncuPuan >= 21)
            Pas();
    }

    public void Pas()
    {
        kurpiyeryazdýrýcý();
        KartVerici.Instance.kapalýkart.transform.rotation = Quaternion.identity;

        if (kurpiyerPuan < 17)
        {
            KurpiyerKartÇek();
            kontrol();
        }
        else
            kontrol();
    }
    public void KurpiyerKartÇek()
    {
        int rastgeleSayý = UnityEngine.Random.Range(0, 52);
        if (rastgeleSayý % 13 < 10)
        {
            kurpiyerPuan += (rastgeleSayý % 13) + 1;
        }
        if (rastgeleSayý % 13 == 0)
        {
            kurpiyerPuan += 10;
            kurpiyerAsSayýsý++;
        }
        if (rastgeleSayý % 13 >= 10)
        {
            kurpiyerPuan += 10;
        }
        if (kurpiyerPuan > 21 && kurpiyerAsSayýsý > 0 && kaçkezkurpiyerpuaneksildi < kurpiyerAsSayýsý)
        {
            for (int i = 0; i < kurpiyerAsSayýsý - kaçkezkurpiyerpuaneksildi; i++)
            {
                kurpiyerPuan -= 10;
                kaçkezkurpiyerpuaneksildi++;
            }
        }
        KartVerici.Instance.kurpiyercardvisual(rastgeleSayý);
    }
    public void kontrol()
    {
        kurpiyeryazdýrýcý();
        if (kurpiyerPuan < 17)
            Pas();
        if (kurpiyerPuan > 21 && oyuncuPuan > 21 || kurpiyerPuan == oyuncuPuan)
        {
            kazananText.text = "berabere";
            Para.Instance.kazanýlanText.text = "+$ " + Para.Instance.bahis.ToString();
            StartCoroutine(beraberesonuç());
        }
        else if ((kurpiyerPuan <= 21 && oyuncuPuan > 21) || (kurpiyerPuan <= 21 && kurpiyerPuan > oyuncuPuan))
        {
            kazananText.text = "kurpiyer kazandý";
            Para.Instance.kazanýlanText.text = "-$ " + Para.Instance.bahis.ToString();
            StartCoroutine(kurpiyersonuç());

        }
        else
        {
            kazananText.text = "oyuncu kazandý";
            Para.Instance.kazanýlanText.text = "+$ " + (Para.Instance.bahis * 2).ToString();
            StartCoroutine(oyuncusonuç());

        }
    }
    private void oyuncuyazdýrýcý()
    {
        oyuncuText.text = oyuncuPuan.ToString();
    }
    private void kurpiyeryazdýrýcý()
    {
        kurpiyerText.text = kurpiyerPuan.ToString();
    }

    IEnumerator beraberesonuç()
    {
        yield return new WaitForSeconds(2f);
        Para.Instance.berabere();
    }
    IEnumerator oyuncusonuç()
    {
        yield return new WaitForSeconds(2f);
        Para.Instance.oyuncukazandý();
    }
    IEnumerator kurpiyersonuç()
    {
        yield return new WaitForSeconds(2f);
        Para.Instance.kurpiyerkazandý();
    }
}
