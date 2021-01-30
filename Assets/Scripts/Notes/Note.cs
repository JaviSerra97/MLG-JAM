using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Note", menuName = "Scriptable Objects/New Note")]
public class Note : ScriptableObject
{
    [TextArea(3,10)]
    public string englishText;
    [TextArea(3,10)]
    public string spanishText;
}
