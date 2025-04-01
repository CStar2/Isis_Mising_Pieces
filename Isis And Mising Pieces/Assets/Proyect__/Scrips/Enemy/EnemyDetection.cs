using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool Isplayernear;

    void Update()
    {
        if (Isplayernear)
        {
            StartBattle();
        }
    }

    public void StartBattle()
    {


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Isplayernear = true;
            Debug.Log("Golpe :D");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Isplayernear = false;
            Debug.Log("Golpe no >:c");
        }

    }

}
