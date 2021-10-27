using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public bool isJumping;
    public bool doubleJump;
    public GameObject collected;

    private Rigidbody2D rig;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 andar = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += andar * Time.deltaTime * speed;

        if(Input.GetAxis("Horizontal") > 0) // se eu to me movendo para direita
        {
            anim.SetBool("walk", true); //quando eu estiver andando meu bool walk = true
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        
        if (Input.GetAxis("Horizontal") < 0) // se eu to me movendo para esquerda
        {
            anim.SetBool("walk", true); //quando eu estiver andando meu bool walk= true
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0) // to parado
        {
            anim.SetBool("walk", false); //quando eu estiver parado meu bool walk= false
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
           
            if (!isJumping) // se tiver pulando doblJump = true ,  pode pular dnv
            {
                rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse); //pula
                doubleJump = true;

                anim.SetBool("jump", true);
            }

        else
        {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse); // se for verdadeiro (estiver pulando) pula dnv
                    doubleJump = false;
                }
        }
    }
        
    
    }

    void OnCollisionEnter2D(Collision2D collision) // se ta pulando
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

}
