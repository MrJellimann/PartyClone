using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour
{
    public GameObject goodBallPrefab;
    public GameObject badBallPrefab;
    public Transform spawnArea;
    public float ballLifespan = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            // Spawn a good ball
            Vector3 goodBallPosition = GetRandomPositionWithinBox(spawnArea.position, spawnArea.localScale);
            Instantiate(goodBallPrefab, goodBallPosition, Quaternion.identity);

            // Spawn a bad ball
            Vector3 badBallPosition = GetRandomPositionWithinBox(spawnArea.position, spawnArea.localScale);
            Instantiate(badBallPrefab, badBallPosition, Quaternion.identity);

            yield return new WaitForSeconds(ballLifespan);
        }
    }

    Vector3 GetRandomPositionWithinBox(Vector3 center, Vector3 size)
    {
        Vector3 randomPos = center + new Vector3(
            (Random.value - 0.5f) * size.x,
            (Random.value - 0.5f) * size.y,
            (Random.value - 0.5f) * size.z
        );
        randomPos = spawnArea.InverseTransformPoint(randomPos);
        return randomPos;
    }
}
