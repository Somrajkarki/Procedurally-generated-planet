using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerateOnStart : MonoBehaviour
{
    Planet planet;

    void Start()
    {
        planet.GeneratePlanet();    
    }

}
