using UnityEngine;


public class MovingObject : MonoBehaviour
{
    public Transform pointA;    // Punto A (inicio del movimiento)
    public Transform pointB;    // Punto B (fin del movimiento)
    public float speed = 2.0f;  // Velocidad de movimiento
    public bool reverseScale = true; // Indica si se invierte la escala al cambiar de dirección

    private Vector3 target;     // Punto objetivo actual
    private bool movingTowardsB = true; // Indica si el objeto se mueve hacia B (true) o hacia A (false)

    void Start()
    {
        // Comenzamos moviéndonos hacia el punto B desde el punto A
        target = pointB.position;
    }

    void Update()
    {
        // Movimiento suave hacia el punto objetivo
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Verificamos si hemos llegado al punto objetivo y cambiamos el target según corresponda
        if (transform.position == pointB.position && movingTowardsB)
        {
            target = pointA.position;
            if (reverseScale)
            {
                // Invertir la escala
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            movingTowardsB = false;
        }
        else if (transform.position == pointA.position && !movingTowardsB)
        {
            target = pointB.position;
            if (reverseScale)
            {
                // Invertir la escala
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            movingTowardsB = true;
        }
    }
}
