using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Rigidbody _platform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PushPlatform();
        }
    }

    private void PushPlatform()
    {
        _platform.AddForce(_platform.transform.position, ForceMode.Impulse);
    }
}
