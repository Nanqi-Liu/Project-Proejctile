using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileStats : ProjectileStats
{
    #region Variables
    [Header("Multi-Projectile")]
    public int _projectileCount = 1;
    [Range(0, 90)] public float _multiProjectileDegree = 30f;
    #endregion

    #region Helper Methods
    
    #endregion
}
