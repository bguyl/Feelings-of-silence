using UnityEngine;

[System.Serializable]
public class Dialogue {
    [TextArea(3, 1)]
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
}
