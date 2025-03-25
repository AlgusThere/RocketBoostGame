using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float timeToWait;
    [SerializeField] float speed;
    //[SerializeField] Vector3 movementVector;

    Vector3 startPosition;
    Vector3 endPosition;


    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
