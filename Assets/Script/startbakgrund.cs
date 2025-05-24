using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 10f, 0); // Rotera runt Y-axeln (v�nster-h�ger)

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
