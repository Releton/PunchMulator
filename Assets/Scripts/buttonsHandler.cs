using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class buttonsHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public string[] chilliRecipie = { "ccccc", "ss", "n" };
    public string[] answer = {"","",""};

    private void Start()
    {
        CalculateScore();
    }

    public void CalculateScore()
    {
        int difference = 0;
        int recipieLength = 0;
        for(int i = 0; i < chilliRecipie.Length; i++)
        {
            recipieLength += chilliRecipie[i].Length;
            difference += Math.Max(answer[i].Length, chilliRecipie[i].Length) - Math.Min(answer[i].Length, chilliRecipie[i].Length);
        }
        Debug.Log(difference+" "+recipieLength);
        Debug.Log(((float)((recipieLength-difference))/recipieLength)*100);
        scoreText.text = (((float)((recipieLength - difference)) / recipieLength) * 100).ToString();
    }

    public void HandleChilli()
    {
        HandleClick("c", 0);
    }

    public void HandleCoriander()
    {
        HandleClick("n", 2);
    }

    public void HandleSalt()
    {
        HandleClick("s", 1);
    }

    public void HandleClick(string spice, int index)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i <= answer[index].Length; i++)
        {
            sb.Append(spice);
        }
        answer[index] = sb.ToString();
        CalculateScore();
    }
}
