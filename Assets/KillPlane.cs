using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public float respawnTime = 3.0f;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Invoke("RespawnPlayer", respawnTime);
        }
    }

    private void RespawnPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawnPoint.position;
        player.SetActive(true);
    }
}
