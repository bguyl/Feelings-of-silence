using UnityEngine;

public class ActivateCamera : MonoBehaviour {
    public GameObject vcam;
    void OnTriggerEnter2D() => vcam.gameObject.SetActive(true);
    void OnTriggerExit2D() => vcam.gameObject.SetActive(false);
}
