using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHorizontalBillboardEffect : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;

    public float rotationSpeed = 5f; // Velocidad de rotación

    void Update()
    {
        if (playerCamera != null)
        {
            // Obtener la dirección hacia el objetivo
            Vector3 direction = playerCamera.position - transform.position;
            direction.y = 0; // Mantener la rotación en el eje Y

            if (direction != Vector3.zero) // Asegurarse de que la dirección no sea cero
            {
                // Calcular la rotación deseada
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Rotar suavemente hacia la rotación deseada
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
