using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    // Enemy Stats
    public float _hp;
    public float _speed;


    #endregion

    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            // Hit by projectile
            Debug.Log("Enemy " + gameObject.name + " at " + transform.position + " got hit by " + other.name);
            Destroy(other.gameObject);
        }
    }
    #endregion

    #region Helper Methods
    #endregion
}
