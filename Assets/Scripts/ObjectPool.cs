using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public float spawnPositionX;
    public float spawnPositionY;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            List<GameObject> objectList = new List<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, gameObject.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

    
        Vector2 spawnPosition = new Vector2(spawnPositionX, spawnPositionY);

        Obstacle obstacle = objectToSpawn.GetComponent<Obstacle>();
        obstacle.Reposition(spawnPosition);

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}