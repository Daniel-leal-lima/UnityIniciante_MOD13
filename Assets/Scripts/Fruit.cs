using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] Rigidbody fruitRigidBody;
    [SerializeField] GameObject splitedPartGO;
    public void Slice(Vector3 direction, Vector3 position, float force)
    {
        splitedPartGO.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        splitedPartGO.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = splitedPartGO.GetComponentsInChildren<Rigidbody>();

        // Add a force to each slice based on the blade direction
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitRigidBody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }
}
