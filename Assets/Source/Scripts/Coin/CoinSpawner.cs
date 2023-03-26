using UnityEngine;

public class CoinSpawner : CoinPool
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField, Range(0, 2f)] private float _spawnRange = 1f;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_coinPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetCoin(out GameObject coin))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetCoin(coin, GetSpawnPosition(_spawnPoints[spawnPointNumber].position));
            }
        }
    }

    private void SetCoin(GameObject coin, Vector3 spawnPosition)
    {
        coin.SetActive(true);
        coin.transform.position = spawnPosition;
    }

    private Vector3 GetSpawnPosition(Vector3 spawnPoint)
    {
        float spawnPositionX = spawnPoint.x + Random.Range(-_spawnRange, _spawnRange);

        return new Vector3 (spawnPositionX, spawnPoint.y, spawnPoint.z);
    }
}
