using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] Obstacles;
    public GameObject[] SpawnPoints;
    public float ObstacleGenerationTime = 2f;

    void Start()
    {
        // Generate Obstacles
        InvokeRepeating(nameof(Generate), 0f, ObstacleGenerationTime);
    }

    // Update is called once per frame
    public void Generate()
    {
        // Random Object
        int random = Random.Range(0, Obstacles.Length - 1);
        GameObject RandomObject = Obstacles[random];

        // Instantiate 
        GameObject Generated = Instantiate(RandomObject, SpawnPoints[random].transform.position, RandomObject.transform.rotation);
        Debug.Log(Generated.name);
    }
}
