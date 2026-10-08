using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _ballReloadTimer;
    [SerializeField] private Rigidbody _spoon;
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _ballPosition;

    private bool _isCharging;
    private bool _isBallLoaded;
    private bool _isLoading;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChargeSpoon();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (_isBallLoaded)
            {
                Launch();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isCharging)
        {
            _spoon.AddForce(-_spoon.transform.position * _force, ForceMode.Force);
            
            if (_hingeJoint.angle < _hingeJoint.limits.min || Mathf.Approximately(_hingeJoint.angle, _hingeJoint.limits.min))
            {
                if (_isBallLoaded == false && _isLoading == false)
                {
                    _isLoading = true;
                    StartCoroutine(LoadBall());
                }                
            }
        }        
    }

    private IEnumerator LoadBall()
    {
        yield return new WaitForSeconds(_ballReloadTimer);
        Instantiate(_ballPrefab, _ballPosition.transform);
        _isBallLoaded = true;
        _isLoading = false;
    }

    private void Launch()
    {
        _isCharging = false;
        _isBallLoaded = false;
    }

    private void ChargeSpoon()
    {
        _isCharging = true;
    }
}
