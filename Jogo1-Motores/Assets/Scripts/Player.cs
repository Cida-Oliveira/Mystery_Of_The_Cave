using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;
    public float jumpForce;
    private Rigidbody2D rig;
    private Animator anim;

    public bool isJump;
    public bool doubleJump;

    
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

    //movimento do personagem
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform position so aceita vector3;
        transform.position += movement * Time.deltaTime * Speed;
        
        if(Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("andando", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if(Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("andando", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("andando", false);
        }
    }


    //puloo do personagem
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            //se ele tiver pulando...
            if(isJump == false)
            {
                rig.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump)
                {   //... e apertar novamente, ele vai pular de novo e...
                    rig.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
                    //nao vai mais poder pular
                    doubleJump = false;
                    
                }
            }
            
        }
    }

    //detectar toda vez que um personagem tocar em algo
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJump = false;
            anim.SetBool("jump", false);
        }

        if(collision.gameObject.tag == "Lava")
        {
            
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Abismo")
        {
            
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Oca")
        {
            
            GameController.instance1.ShowVitoria();
            Destroy(gameObject);
        }
    }

    //quando o personagem para de tocar algo
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJump = true;
        }
    }
    
}
