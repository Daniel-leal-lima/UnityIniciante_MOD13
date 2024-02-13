using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crate : MonoBehaviour, IHitable
{
    int numberOfHitsToDestroy;
    [SerializeField] GameObject fruitPrefab;
    [SerializeField] TextMeshPro[] text;
    [SerializeField] ParticleSystem psTouch;
    private Rigidbody rb;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        numberOfHitsToDestroy = Random.Range(1, 4);
        UpdateText();
    }
    private void Update()
    {
        if (transform.position.y < GameManager.limitY)
        {
            gameManager.Error();
            Destroy(transform.gameObject);
        }
    }
    public void TakeHit()
    {
        if (numberOfHitsToDestroy > 1)
        {
            numberOfHitsToDestroy--;
            UpdateText();
            psTouch.Play();
        }
        else
        {
            AudioManager.instance.PlayAudio(AudioManager.IDBOXBREAK);
            GameObject fruit = Instantiate(fruitPrefab, transform.position, transform.localRotation ,Spawner.spawnerContainer);
            if (fruit.gameObject.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
            }
            Destroy(gameObject);
        }
    }
    void UpdateText()
    {
        foreach (var item in text)
        {
            item.text = numberOfHitsToDestroy.ToString();
        }
    }
}
