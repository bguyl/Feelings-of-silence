using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float angularSpeed = 1f;

    // Update is called once per frame
    void FixedUpdate() => transform.Rotate(new Vector3(0, 0, 1), angularSpeed * Time.deltaTime);
}
