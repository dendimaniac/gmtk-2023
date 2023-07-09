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
        var baseCar = other.gameObject.GetComponent<BaseCarHP>();
        if (!baseCar) return;
        if (baseCar is RobberCarHP) return;

        baseCar.takeDamage(_damage);
    }
}