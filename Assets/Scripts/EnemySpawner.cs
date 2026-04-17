using System.Collections;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración de Spawner")]
    [SerializeField] private GameObject[] prefabstoSpawn;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private GameObject pointB;

    [Header("Estado")]
    [SerializeField] private bool isSpawning = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (prefabstoSpawn != null && prefabstoSpawn.Length > 0)
            {
                int randomIndex = Random.Range(0, prefabstoSpawn.Length);
                GameObject randomPrefab = prefabstoSpawn[randomIndex];
                GameObject spawnedObject = Instantiate(randomPrefab, transform.position, Quaternion.identity);
                MoveEnemy moveScript = spawnedObject.GetComponent<MoveEnemy>();
                if (moveScript != null) {
                    moveScript.SetDestination(pointB.transform.position);
                }
                else {
                    Debug.LogWarning("El prefab no tiene el script");
                }
            }
            else
            {
                Debug.LogWarning("Hay erores en el Spawner");
            }
        }
    }

    // Update is called once per frame
    void StopSpawning()
    {
        isSpawning = false;
    }
}
