using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    [HideInInspector]
    private Vector2 spaceshipPosition = new Vector2(0, 0);

    void Awake() {
        if (instance == null) { instance = this; }
        else if (instance != this) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }

    public Vector2 SpaceshipPosition { get => spaceshipPosition; set => spaceshipPosition = value; }
}
