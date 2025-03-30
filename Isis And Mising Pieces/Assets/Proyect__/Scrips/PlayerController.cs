using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject interactionCollider;
    public bool facingUp;
    public bool facingDown;
    public bool facingLeft;
    public bool facingRight;

    [HideInInspector]
    public Rigidbody2D rigidBody;
    [HideInInspector]
    public Animator animator;
    public float moveSpeed;

    //Make instance of this script to be able reference from other scripts!
    public static PlayerController instance;

    //[HideInInspector]
    //public string areaTransitionName;
    //private Vector3 boundary1;
    //private Vector3 boundary2;

    [HideInInspector]
    public bool canMove = true;

    // Use this for initialization
    void Awake()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        animator.SetFloat("lastMoveY", -1f);
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (animator.GetFloat("lastMoveY") > 0)
        {
            facingUp = true;

            facingDown = false;
            facingLeft = false;
            facingRight = false;
        }

        if (animator.GetFloat("lastMoveY") < 0)
        {
            facingDown = true;

            facingUp = false;
            facingLeft = false;
            facingRight = false;
        }

        if (animator.GetFloat("lastMoveX") < 0)
        {
            facingLeft = true;

            facingUp = false;
            facingDown = false;
            facingRight = false;
        }

        if (animator.GetFloat("lastMoveX") > 0)
        {
            facingRight = true;

            facingUp = false;
            facingDown = false;
            facingLeft = false;
        }


    }

   


}
