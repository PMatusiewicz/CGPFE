using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform bait;
    private float offset;
    
    void Start()
    {
        offset = bait.transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, bait.position.y - offset, transform.position.z);
    }
}
