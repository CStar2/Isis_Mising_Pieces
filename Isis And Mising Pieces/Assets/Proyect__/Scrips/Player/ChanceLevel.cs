using TMPro;
//using UnityEditor.Rendering;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;

public class ChanceLevel : MonoBehaviour
{
    [SerializeField] public GameObject nextlevel;
    [SerializeField] private GameObject Player;
    [SerializeField] private Rigidbody2D Player01;
    
    [SerializeField] private GameObject message;
    [SerializeField] private GameObject MessageYes;
    [SerializeField] private GameObject MessageNo;

    [SerializeField] private GameObject boat;
    //SerializeField] private GameObject clickhere;

    [SerializeField] private int si;
    [SerializeField] private int no;

    private int score = 0;
    public int Score => score;

    public bool isPlayerNear; 

    private void Update()
    {
        if (isPlayerNear)
        {
            boat.SetActive(true);
            //clickhere.SetActive(true);

        }
        else if (!isPlayerNear)
        {
            boat.SetActive(false);
            //clickhere.SetActive(false);
        }

        
        if (isPlayerNear && Input.GetButtonDown("Fire1"))
        {
            wadodo();
        }
        else if (isPlayerNear && Input.GetButtonDown("Fire2"))
        {
            transport();
        }
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

   private void wadodo()
    {
        
        if (score == si)
        {
            message.SetActive(true);   
            MessageYes.SetActive(true);
            MessageNo.SetActive(false);
            Debug.Log("detecto");
        }
        else if (score !=si )
        {
            message.SetActive(true);
            MessageYes.SetActive(false);
            MessageNo.SetActive(true);
            Debug.Log("no detecto");
        }
        
        
    }
    
    private void transport()
    {
        Player.transform.position = nextlevel.transform.position;
        MessageNo.SetActive(false);
        MessageYes.SetActive(false);
        message.SetActive(false);
        Debug.Log("movemento");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerNear = true;
        Debug.Log("si jalo");
        //playerGo.transform.position = nextlevel.transform.position;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerNear = false;
    }


    }
