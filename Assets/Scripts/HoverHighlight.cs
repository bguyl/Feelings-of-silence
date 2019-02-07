using UnityEngine;

public class HoverHighlight : MonoBehaviour
{
    private Color startcolor;
    private new SpriteRenderer renderer;
    private DialogueTrigger diagTrig;

    void Start() {
        renderer = GetComponent<SpriteRenderer>();
        diagTrig = GetComponent<DialogueTrigger>();
    }

    void OnMouseEnter() {
        startcolor = renderer.material.color;
        renderer.material.color = Color.red;
    }

    void OnMouseDown() {
        diagTrig.TriggerDialogue();
    }

    void OnMouseExit() {
        renderer.material.color = startcolor;
    }
}
