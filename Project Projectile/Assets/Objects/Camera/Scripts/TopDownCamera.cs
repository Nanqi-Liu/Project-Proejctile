using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance = 20f;
    [SerializeField, Range(0, 90)] public float _angle = 45f;
    [SerializeField] private Vector3 _offset = Vector3.zero;
    [SerializeField] private float _smoothSpeed = 0.5f;

    private Vector3 refVelocity;
    private bool bLoading = true;
    #endregion

    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        HandleCamera();
        bLoading = false;
    }

    // LateUpdate is called at the end of game logic
    // This is for smoother camera movement
    void LateUpdate()
    {
        HandleCamera();
    }
    #endregion

    #region Helper Methods
    protected virtual void HandleCamera()
    {
        if(!_target)
        {
            return;
        }

        // Build world position vector
        Vector3 worldPosition = (Vector3.up * _distance);
        // Debug.DrawLine(_target.position, worldPosition, Color.red);
        

        // Build transformed position vector 
        Vector3 transformedPosition = Quaternion.AngleAxis(_angle, Vector3.left) * worldPosition + _offset;
        // Debug.Log(rotatedPosition);
        // Debug.DrawLine(_target.position + _offset, transformedPosition, Color.green);
        

        // Move position
        Vector3 flatTargetPostiion = _target.position;
        flatTargetPostiion.y = 0f;
        Vector3 finalPosition = transformedPosition + flatTargetPostiion;
        
        if(bLoading)
        {
            transform.position = finalPosition;
            transform.LookAt(_target.position + _offset);
        }
        else 
        {
            transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, _smoothSpeed);
        }
    }
    #endregion
}
