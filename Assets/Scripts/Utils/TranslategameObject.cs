using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslategameObject : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
