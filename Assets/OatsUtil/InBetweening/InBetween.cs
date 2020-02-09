using UnityEngine;
using System.Collections;
using System;

namespace OatsUtil.InBetweening
{
    /// <summary>
    /// Generates an IEnumerator that defines a tweening animation sequence. Call methods on an instance of the class to configure it, then call ToEnumerator() and run it in a coroutine
    /// </summary>
    /// <typeparam name="T">The type of value to interpolate in the tween</typeparam>
    public class InBetween<T>
    {
        public delegate void OnFrameAction(T value);
        public delegate T LerpFunction(T from, T to, float interpolant);

        private T fromValue;
        private T toValue;
        private float duration = 1f;
        private float stepLength = 0f;
        private OnFrameAction onFrameAction;
        private LerpFunction lerpFunction;
        private InBetweenCurves.CurveFunction curveFunction = InBetweenCurves.Linear;

        /// <summary>
        /// Sets the linear interpolation function to use
        /// </summary>
        /// <param name="lerpFunction">A (T, T, float) => T function that defines a linear interpolation for the type that's being tweened</param>
        /// <returns>InBetween object with the new value set</returns>
        public InBetween<T> LerpWith(LerpFunction lerpFunction)
        {
            this.lerpFunction = lerpFunction;
            return this;
        }

        /// <summary>
        /// Set the value to start tweening from
        /// </summary>
        /// <param name="fromValue"></param>
        /// <returns>InBetween object with the new value set</returns>
        public InBetween<T> From(T fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }

        /// <summary>
        /// Set the value to end tweening at
        /// </summary>
        /// <param name="toValue"></param>
        /// <returns>InBetween object with the new value set</returns>
        public InBetween<T> To(T toValue)
        {
            this.toValue = toValue;
            return this;
        }

        /// <summary>
        /// Set the length of time in seconds for how long to tween for
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns>InBetween object with the new value set</returns>
        public InBetween<T> For(float seconds)
        {
            this.duration = seconds;
            return this;
        }

        /// <summary>
        /// Set the action to perform on each frame or step of the tween
        /// </summary>
        /// <param name="onFrameAction"></param>
        /// <returns>InBetween object with the new value set</returns>
        public InBetween<T> OnFrame(OnFrameAction onFrameAction)
        {
            this.onFrameAction = onFrameAction;
            return this;
        }

        /// <summary>
        /// Set the easing curve function for the tween
        /// </summary>
        /// <param name="curveFunction">A float => float easing function</param>
        /// <returns>InBetween object with the new value set</returns>
        public InBetween<T> Curve(InBetweenCurves.CurveFunction curveFunction)
        {
            this.curveFunction = curveFunction;
            return this;
        }

        /// <summary>
        /// Set the easing curve function for the tween
        /// </summary>
        /// <param name="animationCurve">An animation curve that defines the easing function</param>
        /// <returns><InBetween object with the new value set/returns>
        public InBetween<T> Curve(AnimationCurve animationCurve)
        {
            curveFunction = animationCurve.Evaluate;
            return this;
        }

        /// <summary>
        /// Set a step length in seconds. Makes it so a step of the tween can take longer than a frame to give a choppy look
        /// </summary>
        /// <param name="stepLength">Length of time in seconds for each step of the tween</param>
        /// <returns>InBetween object with the new value set</returns>
        public InBetween<T> Stepped(float stepLength)
        {
            this.stepLength = stepLength;
            return this;
        }

        public InBetween<T> WithConfig(InBetweenConfig config)
        {
            Curve(config.AnimationCurve);
            For(config.AnimationLength);
            return this;
        }

        /// <summary>
        /// Generates an IEnumerator for the tween that can be run in a coroutine
        /// </summary>
        /// <returns>IEnumerator of the tween</returns>
        public IEnumerator ToEnumerator()
        {
            ValidateParameters();

            WaitForSeconds stepWait = null;
            if (stepLength > 0f)
            {
                stepWait = new WaitForSeconds(stepLength);
            }

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                float curvedInterpolant = curveFunction(elapsedTime / duration);
                T lerpedValue = lerpFunction(fromValue, toValue, curvedInterpolant);
                onFrameAction(lerpedValue);

                if (stepWait == null)
                {
                    yield return null;
                    elapsedTime += Time.deltaTime;
                }
                else
                {
                    yield return stepWait;
                    elapsedTime += stepLength;
                }
            }
            onFrameAction(toValue);
        }

        private void ValidateParameters()
        {
            if (lerpFunction == null)
            {
                throw new InvalidOperationException("Must provide lerp function to InBetween");
            }
            if (fromValue == null || toValue == null)
            {
                throw new InvalidOperationException("Must provide from and to values to InBetween");
            }
        }
    }
}
