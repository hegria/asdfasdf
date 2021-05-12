using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int Obstacletype; // 0 ¹Ø ÃâÇö
    float position;
    Vector3 goward = new Vector3(0, 0, 0);
    public int movingdir;
    Rigidbody2D obstrb;
    // Start is called before the first frame update
    void Start()
    {
        obstrb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position.x - cookiehuman.CTF.position.x;
        switch (movingdir)
        {
            case 0:
                break;
            case 1:
                StartCoroutine(mov(4f));
                break;
            case 2:
                StartCoroutine(mov(-6.78f));
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cookie"))
        {
            if (cookiehuman.CK.isdash)
            {
                StartCoroutine(Goodbye());
            }
            else
            {
                cookiehuman.CK.hp -= 10;
            }
        }
    }
    IEnumerator mov(float amount)
    {
        movingdir = 0;
        goward.y = 0.01f * amount;
        yield return new WaitUntil(() => position <= 2f);
        
        Debug.Log(position);
        Debug.Log("I'm down");
        StartCoroutine(GetUp());
        yield break;
    }
    IEnumerator GetUp()
    {
        if (cookiehuman.CK.isdash)
        {
            for (int i = 0; i < 50; i++)
            {
                transform.Translate(goward * 2);
                
                yield return null;
            }
        }
        else
        {
            for (int i = 0; i < 100; i++)
            {
                transform.Translate(goward);
                yield return null;
            }
        }
    }
    IEnumerator Goodbye()
    {
        for (int i = 0; i < 100; i++)
        {
            goward = new Vector2(0.05f, 0.05f);
            transform.Translate(goward);
            obstrb.MoveRotation(obstrb.rotation + 10f);
            yield return null;
        }
        Destroy(gameObject);
    }
}
