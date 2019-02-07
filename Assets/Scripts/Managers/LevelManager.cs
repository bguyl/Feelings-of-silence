using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance = null;
    private Animator animator;
    private int levelToLoad;

    void Awake() {
        if (instance == null) { instance = this; }
        else if (instance != this) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }

    // void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void FadeToLevel(int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fade");
    }

    public void OnFadeComplete() => SceneManager.LoadScene(levelToLoad);

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode) => animator.SetTrigger("Fade");

    // void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;
}
