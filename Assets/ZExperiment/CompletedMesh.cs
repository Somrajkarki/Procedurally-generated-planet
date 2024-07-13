using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedMesh : MonoBehaviour
{
    [Range(2, 256)] public int resolution = 10;

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    Meshface[] terrainFaces;


    private void OnValidate()
    {
        Initialize();
        GenerateMesh();
    }

    private void Initialize()
    {
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[7];
        }

        terrainFaces = new Meshface[7];

        Vector3[] directions = 
        { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back, 
            
            (Vector3.up + Vector3.left + Vector3.forward).normalized,
        };
            
        for (int i = 0; i < 7; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            terrainFaces[i] = new Meshface(meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    void GenerateMesh()
    {
        foreach (Meshface face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }
}
