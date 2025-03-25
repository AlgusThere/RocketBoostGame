using UnityEngine;

public class Destroyer : MonoBehaviour
{

    [SerializeField] GameObject createPoint;
    [SerializeField] GameObject rocket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyable")
        {
            Debug.Log("BUM");
            //Destroy(other.gameObject);
            rocket.transform.position = createPoint.transform.position;
        }
    }
}
