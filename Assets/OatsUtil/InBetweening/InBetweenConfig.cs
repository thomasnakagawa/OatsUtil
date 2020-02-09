using System;
using UnityEngine;

namespace OatsUtil.InBetweening
{
    /// <summary>
    /// Class with serializable fields for configuring certain variables of an InBetween object
    /// </summary>
    [Serializable]
    public class InBetweenConfig
    {
        [SerializeField] private AnimationCurve animationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        public AnimationCurve AnimationCurve {
            get { return animationCurve; }
        }

        [SerializeField] private float animationLength = 1;
        public float AnimationLength
        {
            get { return animationLength; }
        }

        [SerializeField] private float stepLength = 0;
        public float StepLength
        {
            get { return stepLength; }
        }

        public InBetweenConfig(float animationLength = 1f, AnimationCurve animationCurve = null, float stepLength = 0f)
        {
            this.animationLength = animationLength;

            if (animationCurve != null)
            {
                this.animationCurve = animationCurve;
            }

            this.stepLength = stepLength;
        }
    }
}
