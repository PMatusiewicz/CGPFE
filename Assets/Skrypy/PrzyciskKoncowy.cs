using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrzyciskKoncowy : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject panel;
    [SerializeField]
    private GameObject prefabKarp;
    void Start()
    {
        panel = GameObject.Find("PanelKoncowy");
        panel.SetActive(false);
    }
    public void Funckja()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(prefabKarp, new Vector2(5f, 2f), Quaternion.identity);
            Instantiate(prefabKarp, new Vector2(-6f, 2f), Quaternion.identity);
        }
    }
}
