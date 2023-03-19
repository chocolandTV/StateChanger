using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    public float maxTime = 1;
    private float timer = 0.0f;
    private float height;
    public float maxHeight;
    public float destroyTime;

    private void SpawnObstacle(float height)
    {
        GameObject _newObstacle =  Instantiate(obstacle);
        _newObstacle.transform.position = transform.position + new Vector3(0, height,0);
        Destroy(_newObstacle, destroyTime);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(timer > maxTime)
        {
            SpawnObstacle(Random.Range(height, maxHeight));
            timer =0;
        }
        timer+= Time.deltaTime;
    }
}
