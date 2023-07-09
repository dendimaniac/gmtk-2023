using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float healAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerCar = other.GetComponent<PlayerCarHP>();
        if (!playerCar) return;
        
        playerCar.Heal(healAmount);
        Destroy(gameObject);
    }
}