using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;

    public float VerticalBoxColliderOffset => boxCollider.size.y / 2;

    private SpikeTrapManager _spikeTrapManager;
    private float _damage;

    public void SetUp(SpikeTrapManager spikeTrapManager, float damageToDeal)
    {
        _spikeTrapManager = spikeTrapManager;
        _damage = damageToDeal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var policeCar = other.gameObject.GetComponent<PoliceCarHP>();
        if (!policeCar) return;

        policeCar.takeDamage(_damage);
        _spikeTrapManager.ReturnToPool(this);
    }
}