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
    public Button �ekButton;
    public Button pasButton;

    public int kurpiyerPuan = 0;
    public int oyuncuPuan = 0;

    public TextMeshProUGUI oyuncuText;
    public TextMeshProUGUI kurpiyerText;
    public TextMeshProUGUI kazananText;

    public int oyuncuAsSay�s�;
    public int ka�kezaspuaneksildi;

    public int kurpiyerAsSay�s�;
    public int ka�kezkurpiyerpuaneksildi;

    public static GameManager Instance;
    #endregion
    private void Awake()
    {
        Instance = this;
    }

    public void yenioyun()
    {
        kurpiyerAsSay�s� = 0;
        ka�kezkurpiyerpuaneksildi = 0;
        oyuncuAsSay�s� = 0;
        ka�kezaspuaneksildi = 0;
        oyuncuPuan = 0;
        kurpiyerPuan = 0;
        kazananText.text = "";
        KartVerici.Instance.s�f�rla();
        �ek();
        KurpiyerKart�ek();
        kurpiyeryazd�r�c�();
        KurpiyerKart�ek();
        �ek();
    }
    public void �ek()
    {
        int rastgeleSay� = UnityEngine.Random.Range(0, 52);
        if (rastgeleSay� % 13 < 10)
        {
            oyuncuPuan += (rastgeleSay� % 13) + 1;
            oyuncuyazd�r�c�();
        }
        if (rastgeleSay� % 13 >= 10)
        {
            oyuncuPuan += 10;
            oyuncuyazd�r�c�();
        }
        if (rastgeleSay� % 13 == 0)
        {
            oyuncuAsSay�s�++;
            oyuncuPuan += 10;
            oyuncuyazd�r�c�();
        }
        if (oyuncuPuan > 21 && oyuncuAsSay�s� > 0 && ka�kezaspuaneksildi < oyuncuAsSay�s�)
        {
            for (int i = 0; i < oyuncuAsSay�s� - ka�kezaspuaneksildi; i++)
            {
                oyuncuPuan -= 10;
                ka�kezaspuaneksildi++;
            }
            oyuncuyazd�r�c�();
        }
        KartVerici.Instance.oyuncucardvisual(rastgeleSay�);
        if (oyuncuPuan >= 21)
            Pas();
    }

    public void Pas()
    {
        kurpiyeryazd�r�c�();
        KartVerici.Instance.kapal�kart.transform.rotation = Quaternion.identity;

        if (kurpiyerPuan < 17)
        {
            KurpiyerKart�ek();
            kontrol();
        }
        else
            kontrol();
    }
    public void KurpiyerKart�ek()
    {
        int rastgeleSay� = UnityEngine.Random.Range(0, 52);
        if (rastgeleSay� % 13 < 10)
        {
            kurpiyerPuan += (rastgeleSay� % 13) + 1;
        }
        if (rastgeleSay� % 13 == 0)
        {
            kurpiyerPuan += 10;
            kurpiyerAsSay�s�++;
        }
        if (rastgeleSay� % 13 >= 10)
        {
            kurpiyerPuan += 10;
        }
        if (kurpiyerPuan > 21 && kurpiyerAsSay�s� > 0 && ka�kezkurpiyerpuaneksildi < kurpiyerAsSay�s�)
        {
            for (int i = 0; i < kurpiyerAsSay�s� - ka�kezkurpiyerpuaneksildi; i++)
            {
                kurpiyerPuan -= 10;
                ka�kezkurpiyerpuaneksildi++;
            }
        }
        KartVerici.Instance.kurpiyercardvisual(rastgeleSay�);
    }
    public void kontrol()
    {
        kurpiyeryazd�r�c�();
        if (kurpiyerPuan < 17)
            Pas();
        if (kurpiyerPuan > 21 && oyuncuPuan > 21 || kurpiyerPuan == oyuncuPuan)
        {
            kazananText.text = "berabere";
            Para.Instance.kazan�lanText.text = "+$ " + Para.Instance.bahis.ToString();
            StartCoroutine(beraberesonu�());
        }
        else if ((kurpiyerPuan <= 21 && oyuncuPuan > 21) || (kurpiyerPuan <= 21 && kurpiyerPuan > oyuncuPuan))
        {
            kazananText.text = "kurpiyer kazand�";
            Para.Instance.kazan�lanText.text = "-$ " + Para.Instance.bahis.ToString();
            StartCoroutine(kurpiyersonu�());

        }
        else
        {
            kazananText.text = "oyuncu kazand�";
            Para.Instance.kazan�lanText.text = "+$ " + (Para.Instance.bahis * 2).ToString();
            StartCoroutine(oyuncusonu�());

        }
    }
    private void oyuncuyazd�r�c�()
    {
        oyuncuText.text = oyuncuPuan.ToString();
    }
    private void kurpiyeryazd�r�c�()
    {
        kurpiyerText.text = kurpiyerPuan.ToString();
    }

    IEnumerator beraberesonu�()
    {
        yield return new WaitForSeconds(2f);
        Para.Instance.berabere();
    }
    IEnumerator oyuncusonu�()
    {
        yield return new WaitForSeconds(2f);
        Para.Instance.oyuncukazand�();
    }
    IEnumerator kurpiyersonu�()
    {
        yield return new WaitForSeconds(2f);
        Para.Instance.kurpiyerkazand�();
    }
}
