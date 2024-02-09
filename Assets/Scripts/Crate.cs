using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IHitable
{
    int numberOfHitsToDestroy;
    [SerializeField] GameObject fruitPrefab;

    private void Awake()
    {
        numberOfHitsToDestroy = Random.Range(1, 4);
    }
    public void TakeHit()
    {
        if (numberOfHitsToDestroy > 0)
        {
            numberOfHitsToDestroy--;
        }
        else if (numberOfHitsToDestroy == 0)
        {
            GameObject fruit = Instantiate(fruitPrefab, transform.position, transform.localRotation ,Spawner.spawnerContainer);
            if (fruit.gameObject.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
            }
            Destroy(gameObject);
        }
    }
}
