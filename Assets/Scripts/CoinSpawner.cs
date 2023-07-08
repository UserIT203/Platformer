using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform spawner = transform.GetChild(i);
            SpawnCoin(spawner);
        }
    }

    private void SpawnCoin(Transform spawner)
    {
        var coin = Instantiate(_coinTemplate, spawner.position, Quaternion.identity);
        coin.transform.SetParent(spawner);
    }
}
