using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bigObstaclePrefab;

    [SerializeField]
    private GameObject smallObstaclePrefab;

    bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BigObstacleSpawning());
        StartCoroutine(SmallObstacleSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BigObstacleSpawning()
    {
        while (!gameOver)
        {
            float randomZ = Random.Range(35, 65);
            yield return new WaitForSeconds(3f);
            Instantiate(bigObstaclePrefab, new Vector3(52.6f, 55.7f, randomZ), Quaternion.identity);
        }
    }

    IEnumerator SmallObstacleSpawning()
    {
        while (!gameOver)
        {
            float randomZ = Random.Range(95, 125);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            Instantiate(smallObstaclePrefab, new Vector3(-55.7f, 51f, randomZ), Quaternion.identity);
        }
    }
}
