using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {

    }


    IEnumerator SpawnRoutine() 
    {
        while (_stopSpawning == false)
        {
            float randomX = Random.Range(-9f, 9f);
            Vector3 newPosition = new Vector3(randomX, 8f, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, newPosition, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
