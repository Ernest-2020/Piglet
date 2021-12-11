using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BombBase : MonoBehaviour
{
    public float _filedOfImpact;
    public float _force;
    public float TimeToExplosion;
    public LayerMask _layerToHit;
    
    public abstract void ExplosionBomb();
}
