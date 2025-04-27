using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuchFal : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 pozycjaStartowa;
    private float czestotliwosc = 0.3f;
    private float amplituda = 2f;
    void Start()
    {
        pozycjaStartowa = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pozycjaStartowa + transform.right * Mathf.Sin(Time.time * czestotliwosc) * amplituda;
    }
}
