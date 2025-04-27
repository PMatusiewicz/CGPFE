using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PunktPrzerabianiaRyb : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zlapanaRyba;
    private GameObject[] przyciski;
    private GameObject tekstRyba;
    private bool koniecGry = false;
    void Start()
    {
        przyciski = GameObject.FindGameObjectsWithTag("przyciskryba");
        tekstRyba = GameObject.Find("NazwaRyba");
        tekstRyba.SetActive(false);
        foreach (GameObject przycisk in przyciski)
        {
            przycisk.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "ryba")
        {
            zlapanaRyba = col.gameObject;
            tekstRyba.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Złapana Ryba: \n" + zlapanaRyba.GetComponent<RybaBehaviour>().tekstRyba;
            tekstRyba.SetActive(true);
            foreach (GameObject przycisk in przyciski)
            {
                przycisk.SetActive(true);
            }
            if (col.gameObject.name == "ryba (35)" && koniecGry == false)
            {
                Time.timeScale = 0f;
                PrzyciskKoncowy.panel.SetActive(true);
                koniecGry = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col) 
    {
        zlapanaRyba = null;
        tekstRyba.SetActive(false);
        foreach (GameObject przycisk in przyciski)
        {
            przycisk.SetActive(false);
        }
    }
}
