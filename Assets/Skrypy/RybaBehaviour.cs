using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RybaBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    SpriteRenderer sr;
    GameObject bait;
    Vector2 lastVelocity;
    public bool isEnabled = true;
    public int baitLevel;
    public int kasaRyba;
    [SerializeField]
    private int ktoraRyba;
    [SerializeField]
    private Sprite[] sprites;
    public Vector2 miejsceSpawnu;
    public string tekstRyba;
    public struct ZasiegiSpawnu
    {
        public Vector2 pozycja1;
        public Vector2 pozycja2;
    }
    public ZasiegiSpawnu zasiegiSpawnu;
    void Start()
    {
        switch(ktoraRyba)
        {
            //TODO
            default:
                tekstRyba = "Karp";
                miejsceSpawnu = new Vector2(5f, 2f);
                
                sr.sprite = sprites[0];
                kasaRyba = 50;
                baitLevel = 0;
                break;
            case 1:
                tekstRyba = "50zł";
                miejsceSpawnu = new Vector2(2f, -4f);
                zasiegiSpawnu.pozycja1 = new Vector2(-1f, -8f);
                zasiegiSpawnu.pozycja2 = new Vector2(7f, -17f);
                sr.sprite = sprites[1];
                kasaRyba = 50;
                baitLevel = 0;
                Physics2D.IgnoreCollision(GameObject.Find("licencja").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                break;
            case 2:
                tekstRyba = "Licencja na fotoshopa";
                miejsceSpawnu = new Vector2(-4f, -12f);
                zasiegiSpawnu.pozycja1 = new Vector2(-3f, -12f);
                zasiegiSpawnu.pozycja2 = new Vector2(6f, -22f);
                sr.sprite = sprites[2];
                kasaRyba = 150;
                baitLevel = 0;
                Physics2D.IgnoreCollision(GameObject.Find("50zl").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("karta").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("konto").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("bitcoin").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("licencja_winrar").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                break;
            case 3:
                tekstRyba = "Karta kredytowa";
                miejsceSpawnu = new Vector2(-5f, -19f);
                zasiegiSpawnu.pozycja1 = new Vector2(-5f, -17f);
                zasiegiSpawnu.pozycja2 = new Vector2(7f, -20f);
                sr.sprite = sprites[3];
                kasaRyba = 600;
                baitLevel = 1;
                Physics2D.IgnoreCollision(GameObject.Find("licencja").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("konto").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("50zl").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                break;
            case 4:
                tekstRyba = "Konto steam";
                miejsceSpawnu = new Vector2(7f, -25f);
                zasiegiSpawnu.pozycja1 = new Vector2(-5f, -20f);
                zasiegiSpawnu.pozycja2 = new Vector2(6f, -25f);
                sr.sprite = sprites[4];
                kasaRyba = 1000;
                baitLevel = 1;
                Physics2D.IgnoreCollision(GameObject.Find("licencja").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("karta").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("bitcoin").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("licencja_winrar").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                break;
            case 5:
                tekstRyba = "Bitcoin";
                miejsceSpawnu = new Vector2(-1f, -29f);
                zasiegiSpawnu.pozycja1 = new Vector2(-7f, -27f);
                zasiegiSpawnu.pozycja2 = new Vector2(7f, -29f);
                sr.sprite = sprites[5];
                kasaRyba = 3200;
                baitLevel = 2;
                Physics2D.IgnoreCollision(GameObject.Find("konto").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("licencja_winrar").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                break;
            case 6:
                tekstRyba = "Broń atomowa";
                miejsceSpawnu = new Vector2(-6f, -36f);
                zasiegiSpawnu.pozycja1 = new Vector2(-6f, -36f);
                zasiegiSpawnu.pozycja2 = new Vector2(-6f, -36f);
                sr.sprite = sprites[6];
                kasaRyba = 9999999;
                baitLevel = 3;
                Physics2D.IgnoreCollision(GameObject.Find("bitcoin").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("licencja_winrar").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                break;
            case 7:
                tekstRyba = "Licencja na winrara";
                miejsceSpawnu = new Vector2(-1f, -29f);
                zasiegiSpawnu.pozycja1 = new Vector2(-7f, -27f);
                zasiegiSpawnu.pozycja2 = new Vector2(7f, -32f);
                sr.sprite = sprites[7];
                kasaRyba = 200;
                baitLevel = 0;
                Physics2D.IgnoreCollision(GameObject.Find("konto").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("bitcoin").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("nuke").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                Physics2D.IgnoreCollision(GameObject.Find("licencja").GetComponent<Collider2D>(), GetComponent<Collider2D>());
                break;
        }
        GameObject bait = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(bait.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        GameObject[] rybowie = GameObject.FindGameObjectsWithTag("ryba");
        foreach (GameObject ryb in rybowie)
        {
            Physics2D.IgnoreCollision(ryb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        GameObject[] granice = GameObject.FindGameObjectsWithTag("upgradegranice");
        foreach (GameObject granica in granice)
        {
            Physics2D.IgnoreCollision(granica.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        StartCoroutine("RybaRandomRuch");
    }


    void FixedUpdate() 
    {
        lastVelocity = rb.velocity;
    }
    void Ruch(bool kolizja)
    {
        if (isEnabled == true)
        {
            if (kolizja == false)
            {
                transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(-rb.velocity.y, -rb.velocity.x)* Mathf.Rad2Deg, Vector3.forward);
            }
            rb.velocity = Vector2.zero;
            rb.AddForce(-transform.right*3, ForceMode2D.Impulse);
            if (transform.localEulerAngles.z > 90f && transform.localEulerAngles.z < 270f)
            {
                sr.flipY = true;
            }
            else 
            {
                sr.flipY = false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col) 
    {
        lastVelocity=Vector2.Reflect(lastVelocity, col.contacts[0].normal);
        rb.velocity = lastVelocity;
        Ruch(true);
    }

    IEnumerator RybaRandomRuch()
    {
        for(;;)
        {
            Ruch(false);
            yield return new WaitForSeconds(Random.Range(3f, 4.5f));
        }
    }
}
