using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Variables
    public string _name;
    [SerializeField] Rigidbody _rb;

    public float currSpeed;

    private ProjectileStats stats;
    #endregion

    #region Main Methods
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        // Sanity check, make sure there is a ProectileStat component and stats is not null
        ProjectileStats stats = gameObject.GetComponent<ProjectileStats>();
        if(stats == null)
        {
            Debug.LogError("Projectile " + gameObject.name + " at " + transform.position +  " has no ProjectileStats component!!");
            gameObject.SetActive(false);
        }
        else if (this.stats == null)
        {
            Debug.LogWarning("Warning: Projectile " + gameObject.name + " at " + transform.position + " has ProjectileStats component but not assigned to Projectile! Auto assigned!");
            this.stats = stats;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (stats != null)
        {
            currSpeed = stats._speed;
            Move();
        }
    }

    // Destory the object when it leaves the camera
    void OnBecameInvisible()
    {
        // Debug.Log("Projectile Left");
        Destroy(gameObject);
    }

    #endregion

    #region Helper Methods
    void Move()
    {   
        _rb.MovePosition(transform.position + transform.forward * stats._speed * Time.deltaTime);
    }

    public void SetStats(ProjectileStats newStats)
    {
        if(stats == null)
        {
            stats = gameObject.AddComponent<ProjectileStats>() as ProjectileStats;
        }

        stats.SetStats(newStats);
    }
    #endregion
}
