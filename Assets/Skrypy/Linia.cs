using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linia : MonoBehaviour
{
    [SerializeField]
    LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, new Vector3(-0.31f, 1.27f));
    }
}
