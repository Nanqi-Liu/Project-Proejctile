using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    #region Variables
    // Singleton
    public static ProjectileManager instance;

    [SerializeField] private LayerMask _floorLayerMask;
    [SerializeField] private GameObject _projectileObject;

    [SerializeField] private ProjectileStats stats;
    #endregion

    #region Main Methods
    void Awake()
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
        
    }

    #endregion

    #region Helper Methods

    #region Projectile Constructor
    public void CreateProjectile(Vector3 startPos, Vector3 targetPos, ProjectileStats stats)
    {
        Quaternion rotation = Quaternion.LookRotation(targetPos, Vector3.up);
        CreateProjectile(startPos, rotation, stats);
    }

    public void CreateProjectile(Vector3 startPos, Quaternion rotation, ProjectileStats stats)
    {
        GameObject newProjObject = Instantiate(_projectileObject, startPos, rotation, transform);
        Projectile proj = newProjObject.GetComponent<Projectile>();
        proj.SetStats(stats);
        newProjObject.SetActive(true);
    }

    public void CreateMultiProjectile(Vector3 startPos, Vector3 targetPos, ProjectileStats stats, int projectileCount, float spreadAngle)
    {
        Quaternion rotation = Quaternion.LookRotation(targetPos, Vector3.up);
        CreateMultiProjectile(startPos, rotation, stats, projectileCount, spreadAngle);
    }

    public void CreateMultiProjectile(Vector3 startPos, Quaternion rotation, ProjectileStats stats, int projectileCount, float spreadAngle)
    {
        Quaternion[] rotations = CalculateMultiProjectileSpread(projectileCount, spreadAngle, rotation);
        foreach (Quaternion rot in rotations)
        {
            CreateProjectile(startPos, rot, stats);
        }
    }
    #endregion

    public Quaternion[] CalculateMultiProjectileSpread(int projectileCount, float spreadAngle, Quaternion rotation)
    {
        Quaternion[] degrees = new Quaternion[projectileCount];
        if (projectileCount < 1)
        {
            return degrees;
        }

        if(projectileCount == 1)
        {
            degrees[0] = rotation;
            return degrees;
        }

        for(int i = 0; i < projectileCount; i++)
        {
            float angle = spreadAngle - (spreadAngle * 2 / (projectileCount - 1) * i);
            Debug.Log(angle);
            degrees[i] = rotation * Quaternion.Euler(0, angle, 0);
        }

        return degrees;
    }

    #endregion
}
