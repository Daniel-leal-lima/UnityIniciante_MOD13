using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject EffectGO;
    Vector3 oldPos;
    Vector3 direction;
    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            EffectGO.transform.position = oldPos;
            direction = oldPos - ray.GetPoint(5);
            oldPos = ray.GetPoint(5);

            if (Physics.Raycast(ray, out hit, 500, layer))
            {
                Transform objectHit = hit.collider.transform;

                if (objectHit.TryGetComponent(out Fruit fruit))
                {
                    fruit.Slice(direction, oldPos, 10f);
                }
            }
        }
    }
}
