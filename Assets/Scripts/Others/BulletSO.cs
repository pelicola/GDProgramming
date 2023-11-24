using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    public enum EProjectileType{

        Water,
        Poison, 
        Fire

    }



    [CreateAssetMenu(menuName = "ShootDemo/BulletSO", fileName = "BulletSO", order = 1)]
    public class BulletSO : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Scale { get; private set; } 
        [field: SerializeField] public EProjectileType BulletType { get; private set; }
        
    }
}
