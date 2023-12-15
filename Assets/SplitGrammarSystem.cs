using UnityEngine;

public class SplitGrammarSystem : MonoBehaviour
{
    public GameObject skyscraperPrefab;
    public GameObject roadPrefab;

    public int gridSize = 10;
    public int roadWidth = 3;
    public int maxSplitDepth = 3;
    public float maxSkyscraperHeight = 30f; 
    public int skyscrapersPerCell = 3;

    void Start()
    {
        GenerateCity();
    }

    void GenerateCity()
    {
        // Generate roads in a grid pattern
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Instantiate(roadPrefab, new Vector3(x * roadWidth, 0.1f, y * roadWidth), Quaternion.identity); 

                // Connect roads horizontal
                if (x < gridSize - 1)
                {
                    Instantiate(roadPrefab, new Vector3((x + 0.5f) * roadWidth, 0.1f, y * roadWidth), Quaternion.Euler(0, 90, 0)); 
                }

                // Connect roads vertically
                if (y < gridSize - 1)
                {
                    Instantiate(roadPrefab, new Vector3(x * roadWidth, 0.1f, (y + 0.5f) * roadWidth), Quaternion.identity); 
                }
                // Generate skyscrapers
                for (int i = 0; i < skyscrapersPerCell; i++)
                {
                    float height = Random.Range(1f, maxSkyscraperHeight);
                    Instantiate(skyscraperPrefab, new Vector3(x * roadWidth, height / 2f, y * roadWidth), Quaternion.identity)
                        .transform.localScale = new Vector3(1f, height, 1f);
                }
            }
        }
    }   
}