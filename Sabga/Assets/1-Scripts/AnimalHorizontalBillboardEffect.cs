using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHorizontalBillboardEffect : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;

    public float rotationSpeed = 5f; // Velocidad de rotaci�n

    void Update()
    {
        if (playerCamera != null)
        {
            // Obtener la direcci�n hacia el objetivo
            Vector3 direction = playerCamera.position - transform.position;
            direction.y = 0; // Mantener la rotaci�n en el eje Y

            if (direction != Vector3.zero) // Asegurarse de que la direcci�n no sea cero
            {
                // Calcular la rotaci�n deseada
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Rotar suavemente hacia la rotaci�n deseada
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
