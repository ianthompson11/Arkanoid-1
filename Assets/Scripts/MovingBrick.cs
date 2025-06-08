using UnityEngine;

public class MovingBrick : StrongBrick
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        base.Start(); // Esto llama al Start de StrongBrick
        target = pointB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            // Cambia de dirección
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
