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
        if (Input.touchCount > 0)
        {
            Raycast(
                (hitable) =>
                {
                    if (hitable is Fruit)
                    {
                        Fruit fruit = hitable as Fruit;
                        fruit.Slice(direction, oldPos, 10f);
                    }
                });
        }
        if (Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Raycast(
               (hitable) =>
               {
                   if (hitable is Crate)
                   {
                       Crate crate = hitable as Crate;
                       crate.TakeHit();
                   }
               });
        }
    }
    public void Raycast(System.Action<IHitable> callback)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        EffectGO.transform.position = oldPos;
        direction = oldPos - ray.GetPoint(5);
        oldPos = ray.GetPoint(5);

        if (Physics.Raycast(ray, out hit, 500, layer))
        {
            Transform objectHit = hit.collider.transform;
            IHitable hitable;
            objectHit.TryGetComponent(out hitable);
            callback(hitable);
        }
    }
}
