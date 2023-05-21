using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IKSnapper : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float proceduralInfluence;
    [SerializeField] private MultiParentConstraint[] animatedBones;
    [SerializeField] private MultiParentConstraint[] proceduralBones;

    [SerializeField] private AnimationCurve activationAnimation;
    [SerializeField] private AnimationCurve deactivationAnimation;

    private bool currentOverride;


    private void UpdateInfluence(float weight)
    {
        if (animatedBones == null) return;
        foreach (MultiParentConstraint multiParentConstraint in animatedBones)
        {
            if (multiParentConstraint == null) continue;
            multiParentConstraint.weight = weight;
        }

        if (proceduralBones == null) return;
        foreach (MultiParentConstraint proceduralConstraint in proceduralBones)
        {
            if (proceduralConstraint == null) continue;
            proceduralConstraint.weight = 1 - weight;
        }
    }

    public void OverrideIK(bool state)
    {
        if(state != currentOverride)
        {
            currentOverride = state;
            StartCoroutine(AnimateInfluence());
        }

    }
    
    IEnumerator AnimateInfluence()
    {
        AnimationCurve curve = currentOverride ? activationAnimation : deactivationAnimation;

        for(float time=0; time<1; time += Time.deltaTime)
        {
            proceduralInfluence = curve.Evaluate(time);
            UpdateInfluence(proceduralInfluence);
            yield return null;
        }
    }

}
