using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private Vector3 currentPosition = new Vector3(0,0,0);
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int startTerrain;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHoder;
    [SerializeField] private List<GameObject> currentTerrain = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < startTerrain; i++)
        {
            SpawnTerrain(true, new Vector3(0,0,0));
        }
        startTerrain = currentTerrain.Count;
    }

    // Update is called once per frame
    

    public void SpawnTerrain(bool isStart , Vector3 playerPos)
    {

        if(currentPosition.x - playerPos.x < minDistanceFromPlayer || isStart)
        {
            int terrainIndex = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(1, terrainDatas[terrainIndex].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                int index = Random.Range(0, terrainDatas[terrainIndex].possibleTerrain.Count);
                GameObject terrain = Instantiate(terrainDatas[terrainIndex].possibleTerrain[index], currentPosition, Quaternion.identity, terrainHoder);

                currentTerrain.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrain.Count > startTerrain)
                    {
                        Destroy(currentTerrain[0]);
                        currentTerrain.RemoveAt(0);
                    }
                }
                currentPosition.x++;
            }
        }         
    }
}
