using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour
{
    public GameObject goodBallPrefab;
    public GameObject badBallPrefab;
    public Transform spawnArea;

    int spawns = 0;
    [SerializeField] [Range(10, 30)] int goodBalls = 12;
    [SerializeField] [Range(5, 20)] int badBalls = 8;
    [SerializeField] [Range(0.5f, 5.0f)] float timeBetweenSpawns = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        goodBalls = 12;
        badBalls = 8;
        spawns = goodBalls + badBalls;

        while (spawns > 0)
        {
            GameObject _prefab;

            if (badBalls > 0)
            {
                if (Random.value > .5f)
                {
                    _prefab = goodBallPrefab;
                    goodBalls--;
                }
                else
                {
                    _prefab = badBallPrefab;
                    badBalls--;
                }
            }
            else
            {
                _prefab = goodBallPrefab;
                goodBalls--;
            }

            // Spawn a ball with a grow animation
            Vector3 ballPosition = GetRandomPositionWithinBox(spawnArea.position, spawnArea.localScale);
            var ball = Instantiate(_prefab, ballPosition, Quaternion.identity, this.transform);

            spawns--;
            yield return new WaitForSeconds(timeBetweenSpawns); // Wait for half a second before spawning the next ball
        }
    }

    Vector3 GetRandomPositionWithinBox(Vector3 center, Vector3 size)
    {
        Vector3 randomPos = center + new Vector3(
            (Random.value - 0.5f) * size.x,
            (Random.value - 0.5f) * size.y,
            (Random.value - 0.5f) * size.z
        );

        return randomPos;
    }
}
