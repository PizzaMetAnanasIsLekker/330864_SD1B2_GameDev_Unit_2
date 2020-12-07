using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private const float m_spawnRangeX = 15.0f;
    private const float m_spawnPosZ = 20.0f;
    private const float m_startDelay = 1.0f;
    private const float m_spawnInterval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", m_startDelay, m_spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-m_spawnRangeX, m_spawnRangeX), 0, m_spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}