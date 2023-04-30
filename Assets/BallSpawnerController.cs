using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour
{
    public GameObject goodBallPrefab;
    public GameObject badBallPrefab;
    public Transform spawnArea;
    public float ballLifespan = 5.0f;

    int spawns = 0;
    int goodBalls = 12;
    int badBalls = 8;

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

            // Spawn a good ball
            Vector3 ballPosition = GetRandomPositionWithinBox(spawnArea.position, spawnArea.localScale);
            var gBall = Instantiate(_prefab, ballPosition, Quaternion.identity, this.transform);

            spawns--;

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
        
        return randomPos;
    }
}
