using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 150f;

    private void Start()
    {
        transform.SetParent(null);
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, speed * Time.fixedDeltaTime);
    }
}