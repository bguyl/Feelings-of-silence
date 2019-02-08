using UnityEngine;

public class SamController : MonoBehaviour {
    private Rigidbody2D body;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private float targetX;
    public bool isControllable = true;
    public float maxSpeed = 1;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetX = body.position.x;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (isControllable && Input.GetButton("Fire1")) {
            targetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        }
        float speed = Mathf.Clamp(targetX - body.position.x, -maxSpeed, maxSpeed) * Time.deltaTime;
        if (-0.01 < speed && speed < 0.01) { speed = 0; }
        if (speed == 0) { animator.SetBool("isMoving", false); }
        else if (speed > 0) { animator.SetBool("isMoving", true); spriteRenderer.flipX = false; }
        else { animator.SetBool("isMoving", true); spriteRenderer.flipX = true; }
        animator.speed = Mathf.Abs(speed) / (maxSpeed * Time.deltaTime);
        body.position += new Vector2(speed, 0);
    }
}
