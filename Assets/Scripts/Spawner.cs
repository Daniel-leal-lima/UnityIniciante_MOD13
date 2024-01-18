using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnItems;
    [SerializeField] BoxCollider boxCol;
    public bool canSpawn = true;


    private void Start()
    {
        StartCoroutine(nameof(SpawnCoroutine));
    }


    public void Spawn()
    {
        int random = Random.Range(0, spawnItems.Length);

        float randomX = Random.Range(boxCol.bounds.min.x, boxCol.bounds.max.x);

        Vector3 rndPos = new Vector3(randomX, boxCol.transform.position.y, 0f);
        GameObject spawned = Instantiate(spawnItems[random],rndPos,Quaternion.identity, null);
        //if (spawned.gameObject.TryGetComponent(out Rigidbody rb))
        //{
        //    //rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
        //}
    }


    IEnumerator SpawnCoroutine()
    {
        while (canSpawn)
        {
            Spawn();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
