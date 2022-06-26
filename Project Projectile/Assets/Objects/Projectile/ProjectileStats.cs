using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class to store the stats of each projectiles
// Including projectile speed, pierce, fork, etc.
public class ProjectileStats : MonoBehaviour
{
    #region Variables
    [Header("General")]
    public float _speed = 10f;

    [Header("Pierce")]
    [Range(0, 1)] public float _pierceProb = 0f;
    public int _pierceMax = 0;
    public int _pierceCount = 0;
    #endregion

    #region Helper Methods
    public void SetStats(ProjectileStats newStats)
    {
        this._speed = newStats._speed;
        this._pierceProb = newStats._pierceProb;
        this._pierceMax = newStats._pierceMax;
        this._pierceCount = newStats._pierceCount;
    }
    #endregion
}
