using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Car>())
        {
            Destroy(other.gameObject); 
        }
    }
}