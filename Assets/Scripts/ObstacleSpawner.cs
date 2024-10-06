using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public ObjectPool objectPool;
    public float spawnInterval = 2f;
    public int maxSpawnInterval;
    public int minSpawnInterval;

    private float timer;
    private int lastNum;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            int num = Random.Range(0, 3);

            if (num == 0)
            {
                if (lastNum == 0) return;
                else
                {
                    objectPool.SpawnFromPool("Obstacle0");
                    lastNum = 0;
                }
            }
            else if (num == 1)
            {
                if (lastNum == 1) return;
                else
                {
                    objectPool.SpawnFromPool("Obstacle1");
                    lastNum = 1;
                }
            }
            else if (num == 2)
            {
                if (lastNum == 2) return;
                else
                {
                    objectPool.SpawnFromPool("Obstacle2");
                    lastNum = 2;
                }
            }            

            timer = 0f;
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }
}