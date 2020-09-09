using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform enemy;

    public float speed = 150f;

    private void Start()
    {
        transform.SetParent(null);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (enemy == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = enemy.position;
        transform.Rotate(0f, 0f, speed * Time.fixedDeltaTime);
    }
}