using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KartVerici : MonoBehaviour
{
    public static KartVerici Instance;
    private void Awake()
    {
        Instance = this;
    }
    public Transform oyuncuspawnPoint;
    public Transform kurpiyerspawnPoint;
    float x = 0;
    float y = 0;
    float z = 0;

    float k = 0;
    float l = 0;
    float m = 0;
    public GameObject[] kart;

    public int kurpiyerkaçýncýkart = 0;

    public GameObject kapalýkart;


    public void oyuncucardvisual(int b)
    {
        GameObject card = Instantiate(kart[b], new Vector3(oyuncuspawnPoint.transform.position.x + x, oyuncuspawnPoint.transform.position.y + y, oyuncuspawnPoint.transform.position.z + z), Quaternion.identity);
        card.transform.localScale = new Vector3(0.035f, 0.035f, 0.035f);
        x += 0.12f;
        y += 0.001f;
        z += 0.1f;
        card.transform.parent = oyuncuspawnPoint;
    }
    public void kurpiyercardvisual(int b)
    {
        kurpiyerkaçýncýkart++;
        if (kurpiyerkaçýncýkart == 2)
        {
            kapalýkart = Instantiate(kart[b], new Vector3(kurpiyerspawnPoint.transform.position.x + k, kurpiyerspawnPoint.transform.position.y + l, kurpiyerspawnPoint.transform.position.z + m), Quaternion.identity);
            kapalýkart.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            kapalýkart.transform.localScale = new Vector3(0.035f, 0.035f, 0.035f);
            k += 0.12f;
            l += 0.001f;
            m += 0f;
            kapalýkart.transform.parent = kurpiyerspawnPoint;
        }
        else
        {
            GameObject card = Instantiate(kart[b], new Vector3(kurpiyerspawnPoint.transform.position.x + k, kurpiyerspawnPoint.transform.position.y + l, kurpiyerspawnPoint.transform.position.z + m), Quaternion.identity);
            card.transform.localScale = new Vector3(0.035f, 0.035f, 0.035f);
            k += 0.12f;
            l += 0.001f;
            m += 0f;
            card.transform.parent = kurpiyerspawnPoint;
        }

    }
    public void sýfýrla()
    {
        kurpiyerkaçýncýkart = 0;
        foreach (Transform child in oyuncuspawnPoint)
        {
            Destroy(child.gameObject);
        }
        x = 0; y = 0; z = 0;

        foreach (Transform child in kurpiyerspawnPoint)
        {
            Destroy(child.gameObject);
        }
        k = 0; l = 0; m = 0;
    }
}
