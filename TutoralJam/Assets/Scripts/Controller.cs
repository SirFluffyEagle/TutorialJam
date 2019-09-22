using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    public CharacterController controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 NewPosition = new Vector2(gameObject.transform.position.x - 5, gameObject.transform.position.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 NewPosition = new Vector2(gameObject.transform.position.x + 5, gameObject.transform.position.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 NewPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 5);
        }
    }
}
