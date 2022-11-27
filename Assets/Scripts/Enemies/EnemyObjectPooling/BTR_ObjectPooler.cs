using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class BTR_ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    [Tooltip("create pools of a specified prefabs")]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size; //size of the pool not the object
    }
    
    #region "Singleton"
    public static BTR_ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("the object trying to be pooled = " + tag + " does not exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        if (!objectToSpawn.activeInHierarchy)// si no esta activo en la escena
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            poolDictionary[tag].Enqueue(objectToSpawn);
            return objectToSpawn;
        }

        poolDictionary[tag].Enqueue(objectToSpawn);
        return null;
    }
     
}
