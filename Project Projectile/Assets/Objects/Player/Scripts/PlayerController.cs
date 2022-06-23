using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public static PlayerController instance;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 2f;

    [SerializeField] private LayerMask _floorLayerMask;

    private Vector3 inputDirection;
    private Quaternion inputRotation;
    private Vector3 mousePosition;
    #endregion

    #region Main Methods
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GatherInput();
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void OnDrawGizmosSelected()
    {
        if(mousePosition != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(mousePosition, 0.25f);
        }
    }
    #endregion

    #region Helper Methods
    private void GatherInput()
    {
        // Get horizontal and vertical input direction from the input manager
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        inputDirection = new Vector3(x, 0, z);
        if(inputDirection.sqrMagnitude > 1)
        {
            inputDirection.Normalize();
        }

        // Calculate the rotation angle that the player is facing
        // Cast a ray to floor to detect collision for world position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _floorLayerMask))
        {
            mousePosition = hit.point;

            Vector3 mouseToPlayerPosition = mousePosition - transform.position;
            float angle = Mathf.Atan2(mouseToPlayerPosition.x, mouseToPlayerPosition.z) * Mathf.Rad2Deg;
            inputRotation = Quaternion.Euler(0, angle, 0);
            // Debug.Log(mousePosition);
        }
        
        // if (x != 0 || z != 0)
        // {
        //     float angle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
        //     inputRotation = Quaternion.Euler(0, angle, 0);
        // }
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, inputRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + inputDirection * _speed * Time.deltaTime);
    }
    #endregion
}
