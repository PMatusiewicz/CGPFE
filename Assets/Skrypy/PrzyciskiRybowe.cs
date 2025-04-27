using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class PrzyciskiRybowe : MonoBehaviour
{
    public PunktPrzerabianiaRyb punkt;
    public ZachowanieBaita bait;
    [SerializeField]
    private TMP_Text kasaTekst;
    int kasa = 100000;
    int cenaZylki = 200;
    int cenaSzybkosci = 200;
    public static bool hakKupiony = false;
    GameObject[] upgradeGranice;
    [SerializeField]
    private Volume volume;
    [SerializeField]
    private GameObject duzy_hak;

    void Start()
    {
        // Time.timeScale = 5f;
        Application.targetFrameRate = 10;
        punkt = GameObject.Find("PunktPrzerabianiaRyb").GetComponent<PunktPrzerabianiaRyb>();
        bait = GameObject.Find("bait").GetComponent<ZachowanieBaita>();
        upgradeGranice = GameObject.FindGameObjectsWithTag("upgradegranice");
        Array.Sort(upgradeGranice, (a,b) => a.name.CompareTo(b.name));
        AktualizacjaTekstu();
    }
    void BaitIndexCheck()
    {
        if (bait.indexBaita > 3)
        {
            bait.indexBaita = 3;
        }
        bait.srBaita.sprite = bait.sprites[bait.indexBaita];
        volume.profile.TryGet(out Bloom bloom);
        switch(bait.indexBaita)
        {
            case 0:
                bloom.tint.value = new Color(1, 0, 0);
                break;
            case 1:
                bloom.tint.value = new Color(1, 1, 0);
                break;
            case 2:
                bloom.tint.value = new Color(0, 1, 0);
                break;
            case 3:
                bloom.tint.value = new Color(1, 0, 1);
                break;
            default:
                bloom.tint.value = new Color(1, 0, 0);
                break;
        }
    }
    public void Przyneta()
    {
        punkt.zlapanaRyba.transform.position = new Vector2(-16f, 7f);
        punkt.zlapanaRyba.transform.parent = null;
        bait.rybaZlowiona = false;
        bait.indexBaita = punkt.zlapanaRyba.GetComponent<RybaBehaviour>().baitLevel + 1;
        BaitIndexCheck();
        StartCoroutine("OdliczanieZrespieniaRyby");
    }
    public void Sprzedaz()
    {
        punkt.zlapanaRyba.transform.position = new Vector2(-16f, 7f);
        punkt.zlapanaRyba.transform.parent = null;
        bait.rybaZlowiona = false;
        bait.indexBaita = 0;
        kasa += punkt.zlapanaRyba.GetComponent<RybaBehaviour>().kasaRyba;
        AktualizacjaTekstu();
        BaitIndexCheck();
        StartCoroutine("OdliczanieZrespieniaRyby");
    }

    public void Zylka()
    {
        if (kasa >= cenaZylki)
        {
            kasa -= cenaZylki;
            switch (cenaZylki)
            {
                default:
                    GameObject.Find("zylka").SetActive(false);
                    upgradeGranice[4].SetActive(false);
                    break;
                case 200:
                    cenaZylki = 300;
                    upgradeGranice[0].SetActive(false);
                    break;
                case 300:
                    cenaZylki = 600;
                    upgradeGranice[1].SetActive(false);
                    break;
                case 600:
                    cenaZylki = 1400;
                    upgradeGranice[2].SetActive(false);
                    break;
                case 1400:
                    cenaZylki = 3000;
                    upgradeGranice[3].SetActive(false);
                    break;
            }
            AktualizacjaTekstu();
            GameObject.Find("zylka").transform.GetChild(0).GetComponent<TMP_Text>().text = "Długość żyłki\n" + cenaZylki + "zł";
        }
    }
    public void Szybkosc()
    {
        if (kasa >= cenaSzybkosci)
        {
            GameObject.Find("bait").GetComponent<ZachowanieBaita>().speed += 0.75f;
            kasa -= cenaSzybkosci;
            switch (cenaSzybkosci)
            {
                default:
                    GameObject.Find("szybkosc").SetActive(false);
                    break;
                case 200:
                    cenaSzybkosci = 300;
                    break;
                case 300:
                    cenaSzybkosci = 600;
                    break;
                case 600:
                    cenaSzybkosci = 1400;
                    break;
                case 1400:
                    cenaSzybkosci = 1900;
                    break;
                case 1900:
                    cenaSzybkosci = 3000;
                    break;
            }
            AktualizacjaTekstu();
            GameObject.Find("szybkosc").transform.GetChild(0).GetComponent<TMP_Text>().text = "Szybkość\n" + cenaSzybkosci + "zł";
        }
    }
    public void Hak()
    {
        if (kasa >= 2500)
        {
            hakKupiony = true;
            kasa -= 2500;
            GameObject.Find("hak").SetActive(false);
            AktualizacjaTekstu();
            duzy_hak.SetActive(true);
        }
    }

    IEnumerator OdliczanieZrespieniaRyby()
    {
        GameObject obecnaRyba = punkt.zlapanaRyba;
        RybaBehaviour.ZasiegiSpawnu zasiegiSpawnu = obecnaRyba.GetComponent<RybaBehaviour>().zasiegiSpawnu;
        yield return new WaitForSeconds(1f);
        obecnaRyba.transform.position = new Vector2(Random.Range(zasiegiSpawnu.pozycja1.x, zasiegiSpawnu.pozycja2.x), Random.Range(zasiegiSpawnu.pozycja1.y, zasiegiSpawnu.pozycja2.y));
        obecnaRyba.GetComponent<RybaBehaviour>().enabled = true;
        obecnaRyba.GetComponent<RybaBehaviour>().isEnabled = true;
        obecnaRyba.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    void AktualizacjaTekstu()
    {
        kasaTekst.text = kasa + "zł";
    }
}
