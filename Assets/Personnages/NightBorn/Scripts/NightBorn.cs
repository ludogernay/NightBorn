using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorn : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;
    private bool isJumping = false;
    // Start is called before the first frame update

    void Update(){

        if(Input.GetButtonDown("Jump")){
            isJumping = true;
        }
        PlayerJump();
    }
    void PlayerJump(){
        if(isJumping){
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
