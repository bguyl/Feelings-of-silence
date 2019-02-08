using UnityEngine;
using Yarn.Unity;

public class HoverHighlight : MonoBehaviour
{
    private Color startcolor;
    private new SpriteRenderer renderer;
    public string dialogueNode;

    void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter() {
        startcolor = renderer.material.color;
        renderer.material.color = Color.red;
    }

    void OnMouseDown() {
        DialogueRunner diag = FindObjectOfType<DialogueRunner>();
        if(diag.isDialogueRunning) { return; }
        diag.StartDialogue(dialogueNode);
        SamController sam = FindObjectOfType<SamController>();
        sam.isControllable = false;
        sam.animator.SetBool("isStaring", true);
    }

    void OnMouseExit() {
        renderer.material.color = startcolor;
    }
}
