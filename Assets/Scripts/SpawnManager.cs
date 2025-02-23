using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;

    bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ObstacleSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ObstacleSpawning()
    {
        while (!gameOver)
        {
            float randomZ = Random.Range(35, 65);
            yield return new WaitForSeconds(Random.Range(3f, 5f));
            Instantiate(obstaclePrefab, new Vector3(transform.position.x, transform.position.y, randomZ), Quaternion.identity);
        }
    }
}
