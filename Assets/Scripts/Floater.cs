// Floater v0.0.2
// by Donovan Keith
//
// [MIT License](https://opensource.org/licenses/MIT)

using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class Floater : MonoBehaviour
{
    [SerializeField] private Transform thisTransform;

    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public float amplitudeRotation = 0.5f;
    public float frequencyRotation = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Mathf.Sin(Time.time * Mathf.PI * frequencyRotation) * amplitudeRotation * Time.deltaTime, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = transform.position;
        tempPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude * Time.deltaTime;

        transform.position = tempPos;
    }
}
