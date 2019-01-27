using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject optionBox;
    public Text text;
    public TextAsset textFile;
    
    public Rigidbody2D player;
    
    public string[] textLines;
    public int currentLine;
    public int endAtLine;

    void OnTriggerEnter2D(Collider2D other)
    {
        optionBox.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        optionBox.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        player.velocity = Vector2.zero;

        dialogueBox.SetActive(true);

        if (textFile != null)
        {
            textLines = textFile.text.Split(('~'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        for (int i = 0; i < endAtLine; i++)
        {
            text.text = textLines[currentLine];

            if (Input.GetKeyDown(KeyCode.Return))
            {
                currentLine = i;
            }

            if (currentLine > endAtLine)
            {
                dialogueBox.SetActive(false);
                break;
            }

            if (currentLine != endAtLine)
            {
                player.velocity = Vector2.zero;
            }
        }
    }
}