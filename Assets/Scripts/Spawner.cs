using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnItems;
    [SerializeField] BoxCollider boxCol;
    [SerializeField] GameObject SpawnedItemsContainer;
    [SerializeField] float force;

    public static Transform spawnerContainer;

    private bool _canSpawn;
    public bool CanSpawn
    {
        get { return _canSpawn; }
        set
        {
            _canSpawn = value;
            if (value) StartWave();
            else EndWave();
        }
    }
    public static int itensToSpawn;
    private static IEnumerator _coroutine;

    private void OnEnable()
    {
        spawnerContainer = SpawnedItemsContainer.transform;
    }
    public void StartWave()
    {
        _coroutine = SpawnLogic();
        itensToSpawn = Random.Range(8, 15);
        StartCoroutine(_coroutine);
        StartCoroutine(nameof(CheckEndWave));
    }
    public void EndWave()
    {
        StopCoroutine(_coroutine);
    }
    private IEnumerator SpawnLogic()
    {
        while (_canSpawn && itensToSpawn > 0)
        {
            float probability = Time.deltaTime * Random.Range(0, 3);
            if (probability < 3)
            {
                Spawn();
                itensToSpawn--;
            }
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        }
    }
    private void Spawn()
    {
        int random = Random.Range(0, spawnItems.Length);

        //float randomX = Random.Range(boxCol.bounds.min.x, boxCol.bounds.max.x);

        Vector3 randomPoint = new(Random.Range(0f, 1f), Random.Range(0f, 1f));
        randomPoint.z = 10f; 
        Vector3 worldPoint = Camera.main.ViewportToWorldPoint(randomPoint);

        Vector3 rndPos = new Vector3(worldPoint.x, boxCol.transform.position.y, 0f);
        GameObject spawned = Instantiate(spawnItems[random], rndPos, Quaternion.identity, spawnerContainer);
        if (spawned.gameObject.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

    IEnumerator CheckEndWave()
    {
        yield return new WaitUntil(
            () => itensToSpawn == 0 && SpawnedItemsContainer.transform.childCount == 0
            );
        GameManager.GameFinished = true;
    }
}
