using UnityEngine;

public class WorldController : MonoBehaviour
{
    public static WorldController instance;

    private void Start()
    {
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}