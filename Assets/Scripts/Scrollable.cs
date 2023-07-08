using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollable : MonoBehaviour
{
    public float scrollSpeed;

    protected bool WillDestroy;
    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * scrollSpeed * Vector3.down;
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bound"))
        {
            WillDestroy = true;
            Destroy(gameObject);
        }
    }
}
