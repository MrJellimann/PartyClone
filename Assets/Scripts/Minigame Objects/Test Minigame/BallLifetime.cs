using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLifetime : MonoBehaviour
{
    [SerializeField] [Range(1.0f, 10.0f)] float ballLifetime = 5.0f;
    float ballTimestamp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ballTimestamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ballTimestamp + ballLifetime)
            Destroy(this.gameObject);
    }
}
