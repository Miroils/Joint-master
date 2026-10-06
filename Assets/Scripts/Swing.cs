using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Rigidbody _platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
