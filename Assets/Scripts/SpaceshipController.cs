using UnityEngine;

public class SpaceshipController : MonoBehaviour {
    private Rigidbody2D body;
    private ParticleSystem particle;
    private Vector2 velocity = new Vector2(0, 0);
    private Vector2 desired_velocity;
    private Vector2 steering;
    private Vector2 target = new Vector2(0, 0);
    public float angularSpeed = 1;
    public float max_force = 1f;
    public float max_speed = 1f;
    public float max_velocity = 1f;
    public float mass = 1f;
    public float slowingRadius = 1f;
    private float distance = 0f;
    public float slowingRate = 1;
    public bool isControllable = true;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        body.position = GameManager.instance.SpaceshipPosition;
        particle = GetComponent<ParticleSystem>();
    }

    void FixedUpdate() {
        if (isControllable && Input.GetButton("Fire1")) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        desired_velocity = target - body.position;
        distance = desired_velocity.magnitude;
        if (distance < slowingRadius) {
            desired_velocity = desired_velocity.normalized * max_velocity * (distance / Mathf.Pow(slowingRadius, slowingRate)) * Time.deltaTime;
        } else {
            desired_velocity = desired_velocity.normalized * max_velocity * Time.deltaTime;
        }
        steering = desired_velocity - velocity;
        steering = Vector2.ClampMagnitude(steering, max_force);
        steering = steering / mass;
        
        velocity = Vector2.ClampMagnitude(velocity + steering , max_speed);
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        ParticleSystem.VelocityOverLifetimeModule vel = particle.velocityOverLifetime;
        vel.x = -velocity.magnitude;
        body.position += velocity;
        body.rotation = Mathf.Lerp(body.rotation, angle, angularSpeed * Time.deltaTime);
    }

    public void GoTo(Vector2 position) {
        isControllable = false;
        target = position;
    }
}
