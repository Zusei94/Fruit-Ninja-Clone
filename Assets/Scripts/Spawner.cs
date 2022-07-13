using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitToSpawnPrefabs;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform[] spawnPlaces;
    [SerializeField] private float changeToSpawnBomb = 10;
    [SerializeField] private float minWait = 0.3f;
    [SerializeField] private float maxWait = 1f;
    [SerializeField] private float minForce = 10;
    [SerializeField] private float maxForce = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject pick = null;
            float random = Random.Range(0, 100);
            if (random < changeToSpawnBomb)
            {
                pick = bombPrefab;
                if (changeToSpawnBomb < 90)
                {
                    changeToSpawnBomb += 3;
                }
            }
            else
            {
                pick = fruitToSpawnPrefabs[Random.Range(0, fruitToSpawnPrefabs.Length)];
            }

            GameObject fruit = Instantiate(pick, t.position, t.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce),ForceMode2D.Impulse);

            Destroy(fruit, 5);
        }
    }
}
