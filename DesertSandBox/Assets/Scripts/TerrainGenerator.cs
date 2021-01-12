using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    void Start()
    {
        Debug.Log("Hello World");
    }

    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);    }

    TerrainData GenerateTerrain(TerrainData terrainData){
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateDune());
        return terrainData;
    }

    float[,] GenerateDune(){
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++){
            var sand = 1.0f;
            for (int y = 0; y < height; y++){
                heights[x, y] = sand;
                sand -= 0.01f;
            }
        }
        
        Debug.Log(heights);

        return heights;
    }
}
