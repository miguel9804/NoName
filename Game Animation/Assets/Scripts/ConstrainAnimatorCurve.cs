using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(Animator))]

public class ConstrainAnimatorCurve : MonoBehaviour
{

    private Animator anim;
    [SerializeField] private string curveName;
    [SerializeField] private MultiParentConstraint[] positivaConstrains;
    [SerializeField] private MultiParentConstraint[] invertedConstrains;

    [SerializeField] private float value;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        value = anim.GetFloat(curveName);

        foreach(MultiParentConstraint positiveCons in positivaConstrains)
        {
            positiveCons.weight = value;
        }
        foreach (MultiParentConstraint multiParent in invertedConstrains)
        {
            multiParent.weight = 1-value;
        }
    }
}
