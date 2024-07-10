using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private int minTimeSpawner;
    [SerializeField] private int maxTimeSpawner;
    [SerializeField] private bool isRightSide;
    private void Start()
    {
        StartCoroutine(SpawnVehicle());
    }



    IEnumerator SpawnVehicle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeSpawner, maxTimeSpawner));
            GameObject go =  Instantiate(carPrefab, spawnPos.position, Quaternion.identity);
            if (isRightSide)
            {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
        
    }
}
