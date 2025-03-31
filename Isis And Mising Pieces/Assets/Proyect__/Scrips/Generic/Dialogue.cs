using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    
    [SerializeField] private GameObject dialoguepanel;
    [SerializeField] private TMP_Text dialoguetext;
    [SerializeField] public GameObject portraits;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLine;
    
    public bool Isplayernear;
    public bool DidStartDialogue;
    private int lineIndex;

    private float TypingTime = .05f;
    void Update()
    {
        if (Isplayernear && Input.GetButtonDown("Fire1"))
        {
            if (!DidStartDialogue)
            { 
                StartDialogue();
            }
            else if (dialoguetext.text == dialogueLine[lineIndex]) 
            {
                nextDialogue();
            }
        }
    }

    private void StartDialogue()
    {
        DidStartDialogue = true;
        dialoguepanel.SetActive(true);
        portraits.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
        
    }

    private void nextDialogue()
    {
        lineIndex++;
        if(lineIndex < dialogueLine.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            DidStartDialogue = false;   
            dialoguepanel.SetActive(false);

        }
    }

    private IEnumerator ShowLine()
    {
       dialoguetext.text = string.Empty;

        foreach (char ch in dialogueLine[lineIndex])
        {
            dialoguetext.text += ch;
            yield return new WaitForSeconds(TypingTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Isplayernear = true;
            Debug.Log("dialogo :D");
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Isplayernear = false;
            Debug.Log("No dialogo >:c");
        }
       
    }
}
