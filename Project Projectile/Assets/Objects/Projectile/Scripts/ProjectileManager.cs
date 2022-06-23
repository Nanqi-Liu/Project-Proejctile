using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private LayerMask _floorLayerMask;
    [SerializeField] private GameObject _projectileObject;

    [SerializeField] private ProjectileStats stats;
    #endregion

    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Shoots an arrow
            CreateProjectile(PlayerController.instance.transform.position, PlayerController.instance.transform.forward, stats);
            stats._speed += 1;
        }
    }

    #endregion

    #region Helper Methods

    #region Projectile Constructor
    public void CreateProjectile(Vector3 startPos, Vector3 targetPos, ProjectileStats stats)
    {
        GameObject newProjObject = Instantiate(_projectileObject, startPos, Quaternion.LookRotation(targetPos, Vector3.up), transform);
        Projectile proj = newProjObject.GetComponent<Projectile>();
        proj.SetStats(stats);
        newProjObject.SetActive(true);
    }

    public void CreateProjectile(Vector3 startPos, Quaternion rotation, ProjectileStats stats)
    {
        GameObject newProjObject = Instantiate(_projectileObject, startPos, rotation, transform);
        Projectile proj = newProjObject.GetComponent<Projectile>();
        proj.SetStats(stats);
        newProjObject.SetActive(true);
    }
    #endregion

    #endregion
}
