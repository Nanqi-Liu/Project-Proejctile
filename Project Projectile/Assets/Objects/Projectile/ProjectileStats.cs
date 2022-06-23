using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class to store the stats of each projectiles
// Including projectile speed, pierce, fork, etc.
public class ProjectileStats : MonoBehaviour
{
    #region Variables
    public float _speed = 10f;
    #endregion

    #region Helper Methods
    public void SetStats(ProjectileStats newStats)
    {
        this._speed = newStats._speed;
    }
    #endregion
}
