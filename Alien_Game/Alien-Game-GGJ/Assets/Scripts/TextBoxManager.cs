using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public Text text;
    public TextAsset textFile;
    public Rigidbody2D player;
    
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    
    void Start()
    {
        player.velocity = Vector2.zero;
        
        if (textFile != null)
        {
            textLines = textFile.text.Split(('~'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    void FixedUpdate()
    {
        text.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine += 1;
        }

        if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
        }

        if (currentLine != endAtLine)
        {
            player.velocity = Vector2.zero;
        }
    }
}