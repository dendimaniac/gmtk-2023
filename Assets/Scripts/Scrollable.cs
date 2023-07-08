using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollable : MonoBehaviour
{
    public float scrollSpeed;
    public float outOfBoundThreshold;
    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * scrollSpeed * Vector3.down;
        if (transform.position.y < outOfBoundThreshold)
        {
            Destroy(gameObject);
        }
    }
}
