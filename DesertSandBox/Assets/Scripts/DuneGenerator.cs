using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuneGenerator : MonoBehaviour
{
    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public int scaleDunelvl1 = 20;
    public int noisePower1 = 1;
    public int scaleDunelvl2 = 20;
    public int noisePower2 = 3;

    void Start()
    {
    }

    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateDune(terrain.terrainData); 
    }

    TerrainData GenerateDune(TerrainData terrainData){
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights(){
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y){
        float xCoord1 = (float)x / width * scaleDunelvl1;
        float yCoord1 = (float)y / height * scaleDunelvl1;

        float xCoord2 = (float)x / width * scaleDunelvl2;
        float yCoord2 = (float)y / height * scaleDunelvl2;

        return (Mathf.PerlinNoise(xCoord1, yCoord1) * noisePower1 + Mathf.PerlinNoise(xCoord2, yCoord2) * noisePower2) / (noisePower1 + noisePower2);
    }
}
