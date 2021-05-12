using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cookiehuman : MonoBehaviour
{
    public static cookiehuman CK;
    public static Transform CTF;
    Rigidbody2D CKR;
    public float hp = 100;
    int isjump = 2;
    public bool isdash = false;
    public int score = 0;
    public float cometome = 5f;
    Vector3 moving = new Vector3(0,0,0);
    public Animator animator;
    BoxCollider2D box;
    Vector2 offset = new Vector2(0, 0);
    Vector2 size = new Vector2(0, 0);
    public GameObject TextDash;
    public GameObject TextMeg;
    private void Awake()
    {
        CK = this;
        CTF = transform;
        CKR = CK.GetComponent<Rigidbody2D>();
        box = CK.GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        hp -= 0.005f;
        if(hp <= 0 || CTF.position.y<-5f)
        {
            hp = 0;
            Destroy(CK);
        }
        if (isdash)
        {
            moving.x = Time.deltaTime * 3.5f*3;
            CTF.Translate(moving);
        }
        if (!isdash)
        {
            moving.x = Time.deltaTime * 3.5f;
            CTF.Translate(moving);
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (isjump != 0)
            {
                animator.SetBool("Jump",true);
                CKR.AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
                isjump--;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Slide", true);
            offset.x = 0.096405f;
            offset.y = -1.6127f;
            size.x = 1.2524f;
            size.y = 0.79716f;
            box.offset = offset;
            box.size = size;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Slide", false);
            offset.x = -0.232317f;
            offset.y = -1.379382f;
            size.x = 0.5949631f;
            size.y = 1.263735f;
            box.offset = offset;
            box.size = size;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetTrigger("Land");
            animator.SetBool("Jump", false);
            isjump = 2;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Portion"))
        {
            hp += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Dash"))
        {
            GameObject text1 = Instantiate(TextDash, CTF.position + new Vector3(3f, 0.5f,0),new Quaternion(0,0,0,0));
            StartCoroutine(Willdie(text1));
            StartCoroutine(dash());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Magnet"))
        {
            GameObject text1 = Instantiate(TextMeg, CTF.position + new Vector3(3f, 0.5f, 0), new Quaternion(0, 0, 0, 0));
            StartCoroutine(Willdie(text1));
            StartCoroutine(Mag());
            Destroy(collision.gameObject);
        }
    }
    //helo
    IEnumerator dash()
    {
        animator.SetBool("Dash", true);
        isdash = true;
        yield return new WaitForSeconds(5f);
        animator.SetBool("Dash", false);
        isdash = false;
    }
    IEnumerator Mag()
    {
        cometome = 10f;
        yield return new WaitForSeconds(5f);
        cometome = 5f;
    }
    IEnumerator Willdie(GameObject game)
    {
        yield return new WaitForSeconds(2f);
        Destroy(game);
    }
}
