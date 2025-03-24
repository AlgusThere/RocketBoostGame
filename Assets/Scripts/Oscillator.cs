using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] float startPosition;
    [SerializeField] float endPosition;
    [SerializeField] float speed;

    float movementVector;
    float movementFactor;
}
