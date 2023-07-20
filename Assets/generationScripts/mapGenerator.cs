using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public TerrainType[] regions;

    public void GenerateMap() {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                
            }
        }

        mapDisplay display = FindObjectOfType<mapDisplay>();
        display.DrawNoiseMap(noiseMap);

    }

    void OnValidate() {
        if (mapWidth < 1) {
            mapWidth = 1;
        }
         if (mapHeight < 1) {
            mapHeight = 1;
        }
         if (lacunarity < 1) {
            lacunarity = 1;
        }
         if (octaves < 0) {
            octaves = 0;
        }
    }
}

[System.Serializable]
public struct TerrainType {
    public string name;
    public string height;
    public Color color;
}