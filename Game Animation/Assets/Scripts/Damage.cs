using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    [SerializeField] private UnityEvent onDamaged;
    public void GetHit()
    {
        Debug.Log("Dañado");
        onDamaged?.Invoke();
    }
}
