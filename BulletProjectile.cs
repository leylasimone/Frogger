using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public const float TTL = 5;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = TTL;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount -= Time.deltaTime * 1.0f;
        if(timeCount <= 0)
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
