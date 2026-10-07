using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//07 10 левая
        {
            ChargeSpoon();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))//07 10 правая
        {
            if (_isBallLoaded)
            {
                Launch();
            }
        }
        if (_isCharging) //07 11 првоерка на угол
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
