using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;

    public float VerticalBoxColliderOffset => boxCollider.size.y / 2;

    private SpikeTrapManager _spikeTrapManager;

    public void SetUp(SpikeTrapManager spikeTrapManager)
    {
        _spikeTrapManager = spikeTrapManager;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var policeCar = other.gameObject.GetComponent<PoliceCarMovement>();
        if (!policeCar) return;

        Destroy(policeCar.gameObject);
        _spikeTrapManager.ReturnToPool(this);
    }
}