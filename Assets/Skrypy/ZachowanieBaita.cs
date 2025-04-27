using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZachowanieBaita : MonoBehaviour
{
    
    // Update is called once per frame
    public float speed;
    public SpriteRenderer srBaita;
    public Sprite[] sprites;
    public int indexBaita = 0;
    public bool rybaZlowiona = false;
    private GameObject[] graniceRybow;

    void Start()
    {
        graniceRybow = GameObject.FindGameObjectsWithTag("granicerybow");
        foreach (GameObject granica in graniceRybow)
        {
            Physics2D.IgnoreCollision(granica.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            
        }
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "ryba")
        {
            if (rybaZlowiona == false)
            {
                if (indexBaita == 3 && PrzyciskiRybowe.hakKupiony == false && col.name == "ryba (35)")
                {
                    
                }
                else if (indexBaita >= col.gameObject.GetComponent<RybaBehaviour>().baitLevel)
                {
                    col.gameObject.transform.parent = transform;
                    //col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    col.gameObject.GetComponent<RybaBehaviour>().enabled = false;
                    col.gameObject.GetComponent<RybaBehaviour>().isEnabled = false;
                    col.gameObject.transform.position = transform.position;
                    col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    rybaZlowiona = true;
                }
            }
        }
    }
}
