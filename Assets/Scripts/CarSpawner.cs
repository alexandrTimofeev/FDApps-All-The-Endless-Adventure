using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private List<Car> _cars;

    private void Awake()
    {
        StartCoroutine(StartSpawn());
    }

    public void SpawnCar()
    {
        if (_cars == null || _cars.Count == 0)
        {
            Debug.LogWarning("Список машин пуст!");
            return;
        }

        int randomIndex = Random.Range(0, _cars.Count);
        Car carPrefab = _cars[randomIndex];

        Quaternion rotation = Quaternion.Euler(0f, -90f, 0f);

        Car newCar = Instantiate(carPrefab, startPoint.position, rotation);

        newCar.Move(endPoint);
    }

    private IEnumerator StartSpawn()
    {
        while (true)
        {
            SpawnCar();
            yield return new WaitForSeconds(8f);
        }
    }
}