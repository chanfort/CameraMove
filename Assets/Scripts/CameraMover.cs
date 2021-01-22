using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Vector3 center;
    public Vector3 velocity;
	public float acceleration = 10f;

    void Start()
    {

    }

    void Update()
    {
        velocity = velocity + acceleration * (center - transform.position).normalized * Time.deltaTime;
		
		Vector3 newPosition = transform.position + velocity * Time.deltaTime;
		if(newPosition.y < 5f)
		{
			newPosition.y = 5f;
		}

        transform.position = newPosition;
        transform.LookAt(transform.position + velocity);

        MoveCenter();
    }

    void MoveCenter()
    {
        Vector2 rand = 0.5f * Random.insideUnitCircle;
        Vector3 v3 = new Vector3(rand.x, 0, rand.y);
        center = center + v3;
    }
}
