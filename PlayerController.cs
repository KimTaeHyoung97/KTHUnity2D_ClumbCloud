using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator ani;
    Collider col;
    const float jumpForce = 700f;
    const float walkForce = 40f;
    const float maxwalkForce = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = FindObjectOfType<Rigidbody2D>();
        ani = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& rb2D.velocity.y == 0)
        {
            rb2D.AddForce(transform.up * jumpForce);
            ani.SetTrigger("JumpTrigger");
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;


        float speedx = Mathf.Abs(rb2D.velocity.x);
        if(speedx < maxwalkForce)
        {
            rb2D.AddForce(transform.right * key * walkForce);
        }
        if(key!=0)
        {
            transform.localScale = new Vector3(key * Mathf.Abs(transform.localScale.x),
                transform.localScale.y, transform.localScale.z);
        }
        if(transform.position.y < -7f)
        {
            SceneManager.LoadScene(0);
        }
        if (col.name == "flag")
            ani.speed = speedx / 2.0f;
        else
            ani.speed = 1f;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(1);
    }
    public void OnRightButton()
    {
        rb2D.transform.Translate(1, 0, 0);
    }
    public void OnLeftButton()
    {
        rb2D.transform.Translate(-1, 0, 0);
    }
}
