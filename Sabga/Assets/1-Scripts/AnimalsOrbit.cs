using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsOrbit : MonoBehaviour
{
    public List<Transform> fishList; // Lista de objetos peces
    [Range(0.1f, 1f)]
    public float radius = 1f; // Radio de la órbita
    public float speed = 2f; // Velocidad de rotación

    private List<float> heightOffsets; // Lista de alturas para cada pez
    private List<float> speedOffsets;  // Lista de velocidades para cada pez

    void Start()
    {
        // Inicializa las listas de offset con valores aleatorios
        heightOffsets = new List<float>();
        speedOffsets = new List<float>();

        foreach (var fish in fishList)
        {
            heightOffsets.Add(Random.Range(-1f, 1f)); // Offset de altura aleatorio
            speedOffsets.Add(Random.Range(0.5f, 1f)); // Offset de velocidad aleatorio
        }
    }

    void Update()
    {
        // Recorrer cada pez en la lista
        for (int i = 0; i < fishList.Count; i++)
        {
            if (fishList[i] == null) continue; // Verifica que el pez exista

            float angle = Time.time * speed * speedOffsets[i]; // Ángulo en función del tiempo y la velocidad
            Vector3 offset = new Vector3(Mathf.Cos(angle), heightOffsets[i], Mathf.Sin(angle)) * radius;

            // Posicionar el pez alrededor del jugador
            fishList[i].position = transform.position + offset;
        }
    }

}
