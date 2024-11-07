using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshPro dialogueText;
    public string[] dialogueLines;
    private int currentLine;

    private bool playerInRange;

    void Start()
    {
        dialogueBox.SetActive(false);
        currentLine = 0;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueBox.activeInHierarchy)
            {
                NextDialogueLine();
            }
            else
            {
                ShowDialogue();
            }
        }
    }

    void ShowDialogue()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = dialogueLines[currentLine];
    }

    void NextDialogueLine()
    {
        currentLine++;
        if (currentLine >= dialogueLines.Length)
        {
            dialogueBox.SetActive(false);
            currentLine = 0;
        }
        else
        {
            dialogueText.text = dialogueLines[currentLine];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
            currentLine = 0;
        }
    }
}
