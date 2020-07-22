using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{

    static Animator anim;
    public float walkSpeed = 3.0F;
    public float rotationSpeed = 100.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * walkSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(translation != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(rotation != 0)
        {
            anim.SetBool("isTurning", true);
        }
        else
        {
            anim.SetBool("isTurning", false);
            anim.SetBool("isTurningLeft", false);
            anim.SetBool("isTurningRight", false);
        }

        if(rotation < 0)
        {
            anim.SetBool("isTurningLeft", true);
            anim.SetBool("isTurningRight", false);
        }
        else if(rotation > 0)
        {
            anim.SetBool("isTurningRight", true);
            anim.SetBool("isTurningLeft", false);
        }

        if (Input.GetButton("Run") && translation != 0)
        {
            anim.SetBool("isRunning", true);
            float translationRun = Input.GetAxis("Vertical") * 1.5F * walkSpeed;
            translationRun *= Time.deltaTime;
            transform.Translate(0, 0, translationRun);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
