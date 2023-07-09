using UnityEngine;

public class BaseCarHP : MonoBehaviour
{
    protected float maxHealthPoint;
    protected float currentHealthPoint;
    public GameObject explosionPrefab;

    public void takeDamage(float dmg)
    {
        currentHealthPoint -= dmg;
        if (currentHealthPoint < 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            SoundManager.Instance.PlaySound("Explosion2");
            Destroy(gameObject);
        }
        else
        {
            SoundManager.Instance.PlaySound("Crash_metal1");
        }
    }
}
