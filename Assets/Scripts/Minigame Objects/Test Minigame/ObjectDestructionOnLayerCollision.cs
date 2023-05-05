using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestructionOnLayerCollision : MonoBehaviour
{
    [SerializeField] bool[] collideWithLayer = new bool[32];
    [SerializeField] GameObject objectToDestroy = null;

    [SerializeField] bool DebugMode = false;

    private void OnTriggerEnter(Collider other)
    {
        if (DebugMode)
        {
            string debugString = "";
            debugString += $"Trigger: Other Collider: {other}";
            debugString += "\n";
            debugString += $"Trigger: Other Collider Layer: {other.gameObject.layer}";

            Debug.Log(debugString);
        }

        if (collideWithLayer[other.gameObject.layer])
        {
            Destroy(objectToDestroy);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (DebugMode)
        {
            string debugString = "";
            debugString += $"Collision: Other Collider: {collision.collider}";
            debugString += "\n";
            debugString += $"Collision: Other Collider Layer: {collision.collider.gameObject.layer}";

            Debug.Log(debugString);
        }

        if (collideWithLayer[collision.collider.gameObject.layer])
        {
            Destroy(objectToDestroy);
        }
    }
}
