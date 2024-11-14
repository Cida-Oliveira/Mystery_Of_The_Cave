using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;
    public float jumpForce;
    private Rigidbody2D rig;

    public bool isJump;
    public bool doubleJump;

    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
            }
            else
            {
                if(doubleJump)
                {   //... e apertar novamente, ele vai pular de novo e...
                    rig.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
                    //nao vai mas poder pular
                    doubleJump = false;
                }
            }
            
        }
    }

    //detectar toda vez que um personagem tocar em algo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJump = false;
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
