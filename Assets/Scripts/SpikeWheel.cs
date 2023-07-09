using UnityEngine;

public class SpikeWheel : MonoBehaviour
{
    private float _damage;
    
    public void SetUp(float damage)
    {
        _damage = damage;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var policeCar = other.gameObject.GetComponent<PoliceCarHP>();
        if (!policeCar) return;

        policeCar.takeDamage(_damage);
    }
}