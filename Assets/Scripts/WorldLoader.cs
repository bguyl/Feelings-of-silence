using UnityEngine;

public class WorldLoader : MonoBehaviour
{
    public int sceneId;

    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player") {
            GameManager.instance.SpaceshipPosition = collider.attachedRigidbody.position;
            collider.GetComponent<SpaceshipController>().GoTo(transform.position);
            LevelManager.instance.FadeToLevel(sceneId);
        }
    }
}
