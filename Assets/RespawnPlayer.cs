using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public float respawnTime = 3.0f;
    public GameObject spawnPoint;
    public GameObject killPlane;

    private bool isRespawning = false;
    private float respawnTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (isRespawning)
        {
            respawnTimer += Time.deltaTime;

            if (respawnTimer >= respawnTime)
            {
                Respawn();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == killPlane)
        {
            isRespawning = true;
        }
    }

    private void Respawn()
    {
        isRespawning = false;
        respawnTimer = 0.0f;
        this.gameObject.transform.position = spawnPoint.transform.position;
        this.gameObject.SetActive(true);
    }
}
