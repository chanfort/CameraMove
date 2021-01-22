using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    public float speed = 600f;
    public Vector3 northPoleVector;
    float secondsInDay;
    Light lght;

    void Start()
    {
        secondsInDay = 24f * 60f * 60f;
        lght = GetComponent<Light>();
    }

    void Update()
    {
        Vector3 curentDirection = transform.rotation * new Vector3(0f, 0f, 1f);
        float da = 360f * Time.deltaTime / secondsInDay;
        curentDirection = RotateAround(-speed * da, curentDirection, northPoleVector);
        transform.rotation = Quaternion.LookRotation(curentDirection);

        float horizonAngle = Vector3.Angle(transform.forward, Vector3.up) - 90f;
        lght.intensity = InterpolateClamped(horizonAngle, 0f, 5f, 0f, 1f);
    }

    Vector3 RotateAround(float rotAngle, Vector3 original, Vector3 direction)
    {
        return Quaternion.AngleAxis(-rotAngle, direction.normalized) * original;
    }

    float InterpolateClamped(float x, float x0, float x1, float y0, float y1)
    {
        float y = (y0 + (y1 - y0) * (x - x0) / (x1 - x0));

        if (y0 < y1)
        {
            if (y < y0)
            {
                y = y0;
            }
            if (y > y1)
            {
                y = y1;
            }
        }
        else if (y0 > y1)
        {
            if (y > y0)
            {
                y = y0;
            }
            if (y < y1)
            {
                y = y1;
            }
        }
        
        return y;
    }
}
