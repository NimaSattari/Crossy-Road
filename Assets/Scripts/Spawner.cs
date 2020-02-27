using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform startPos;

    public float DelayMin = 1.5f;
    public float DelayMax = 5;
    public float SpeedMin = 1;
    public float SpeedMax = 4;

    public bool useSpawnPlacement = false;
    public int SpawnCountMin = 4;
    public int SpawnCountMax = 20;

    private float lastTime = 0;
    private float delayTime = 0;
    private float speed = 0;

    [HideInInspector] public GameObject item;
    [HideInInspector] public bool goLeft = false;
    [HideInInspector] public float spawnLeftPos = 0;
    [HideInInspector] public float spawnRightPos = 0;

    private void Start()
    {
        if (useSpawnPlacement)
        {
            int spawnCount = Random.Range(SpawnCountMin, SpawnCountMax);
            for(int i = 0; i < spawnCount; i++)
            {
                SpawnItem();
            }
        }
        else
        {
            speed = Random.Range(SpeedMin, SpeedMax);
        }
    }
    private void Update()
    {
        if (useSpawnPlacement) return;
        if(Time.time>lastTime + delayTime)
        {
            lastTime = Time.time;
            delayTime = Random.Range(DelayMin, DelayMax);
            SpawnItem();
        }
    }
    void SpawnItem()
    {
        Debug.Log("Spawn Item");
        GameObject obj = Instantiate(item) as GameObject;
        obj.transform.position = GetSpawnPosition();
        float direction = 0; if (goLeft) direction = 180;
        if (!useSpawnPlacement)
        {
            obj.GetComponent<Mover>().speed = speed;
            obj.transform.rotation = obj.transform.rotation * Quaternion.Euler(0, direction, 0);
        }
    }
    Vector3 GetSpawnPosition()
    {
        if (useSpawnPlacement)
        {
            int x = (int)Random.Range(spawnLeftPos, spawnRightPos);
            Vector3 pos = new Vector3(x, startPos.position.y, startPos.position.z);
            return pos;
        }
        else
        {
            return startPos.position;
        }
    }
}
