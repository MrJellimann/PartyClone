using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour
{
    public GameObject goodBallPrefab;
    public GameObject badBallPrefab;
    public Transform spawnArea;
    public float goodBallLifespan = 5.0f;
    public float badBallLifespan = 5.0f;
    public float spawnAnimationDuration = 1.0f;

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
                    StartCoroutine(DestroyAfterTime(_prefab, goodBallLifespan));
                }
                else
                {
                    _prefab = badBallPrefab;
                    badBalls--;
                    StartCoroutine(DestroyAfterTime(_prefab, badBallLifespan));
                }
            }
            else
            {
                _prefab = goodBallPrefab;
                goodBalls--;
                StartCoroutine(DestroyAfterTime(_prefab, goodBallLifespan));
            }

            // Spawn a ball with a grow animation
            Vector3 ballPosition = GetRandomPositionWithinBox(spawnArea.position, spawnArea.localScale);
            var ball = Instantiate(_prefab, ballPosition, Quaternion.identity, this.transform);

            float animationTime = 0.0f;
            while (animationTime < spawnAnimationDuration)
            {
                float scale = Mathf.Lerp(0, 1, animationTime / spawnAnimationDuration);
                ball.transform.localScale = new Vector3(scale, scale, scale);
                animationTime += Time.deltaTime;
                yield return null;
            }
            ball.transform.localScale = Vector3.one;

            spawns--;
            yield return new WaitForSeconds(0.5f); // Wait for half a second before spawning the next ball
        }
    }

    IEnumerator DestroyAfterTime(GameObject ball, float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        if (ball != null)
            Destroy(ball.gameObject);
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
