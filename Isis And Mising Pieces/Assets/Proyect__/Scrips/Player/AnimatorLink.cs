using UnityEngine;

public class AnimatorLink : MonoBehaviour
{
    Animator anima;
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anima.SetBool("MoveL", true);
        }

        if (!Input.GetKey(KeyCode.LeftArrow))
        {
            anima.SetBool("MoveL", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anima.SetBool("MoveR", true);
        }

        if (!Input.GetKey(KeyCode.RightArrow))
        {
            anima.SetBool("MoveR", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anima.SetBool("Spell", true);
        }

        if (!Input.GetKey(KeyCode.Space))
        {
            anima.SetBool("Spell", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            anima.SetBool("MoveU", true);
        }

        if (!Input.GetKey(KeyCode.UpArrow))
        {
            anima.SetBool("MoveU", false);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anima.SetBool("MoveD", true);
        }

        if (!Input.GetKey(KeyCode.DownArrow))
        { 
            anima.SetBool("MoveD", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anima.SetBool("Sword", true);
        }

        if (!Input.GetButtonDown("Fire1"))
        {
            anima.SetBool("Sword", false);
        }
    }
}


