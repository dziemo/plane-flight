using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3 startPoint;

    public FloatRuntimeVariable spawnedObjectsSpeed;

    public GameObjectCollection obstacles;

    List<GameObject> spawnedObjects = new List<GameObject>();

    Camera cam;

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, 1.5f);
        cam = Camera.main;
    }

    private void Update()
    {
        MoveSpawnedObjects();
    }

    public void Spawn()
    {
        var obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)], startPoint, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        spawnedObjects.Add(obstacle);
    }
    
    private void MoveSpawnedObjects()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            var obj = spawnedObjects[i];
            var objPos = cam.WorldToViewportPoint(obj.transform.position);

            if (objPos.x < 0 || objPos.y < 0)
            {
                spawnedObjects.Remove(obj);
                Destroy(obj);
            }
            else
            {
                obj.transform.position -= new Vector3(0, 0, spawnedObjectsSpeed.RuntimeValue * Time.deltaTime);
            }
        }
    }
    
    public void OnEndGame()
    {
        CancelInvoke();
    }
}
