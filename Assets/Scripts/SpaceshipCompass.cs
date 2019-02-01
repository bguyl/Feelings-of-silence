using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCompass : MonoBehaviour
{
    public GameObject world2;

    void FixedUpdate() {
        Vector3 direction = world2.transform.position - transform.parent.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
