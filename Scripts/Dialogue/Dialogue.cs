using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)] // 3 is the min number of lines the text area will use, 10 being the max
    public string[] sentences;

    public Sprite picture;
}
