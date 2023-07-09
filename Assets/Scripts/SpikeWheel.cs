using UnityEngine;

public class SpikeWheel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var policeCar = other.gameObject.GetComponent<PoliceCarMovement>();
        if (!policeCar) return;

        Destroy(policeCar.gameObject);
    }
}