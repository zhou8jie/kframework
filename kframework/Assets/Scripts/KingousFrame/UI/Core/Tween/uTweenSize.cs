using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnityEngine.UI.Extensions
{
    [AddComponentMenu("UI/Tween/Tween Size")]
    public class uTweenSize : uTweener
    {

        public Vector2 from;
        public Vector2 to;

        RectTransform mRectTransform;
        LayoutElement mLayoutElement;

        public RectTransform cachedRectTransform { get { if (mRectTransform == null) mRectTransform = GetComponent<RectTransform>(); return mRectTransform; } }
        public LayoutElement cachedLayoutElement { get { if (mLayoutElement == null) mLayoutElement = GetComponent<LayoutElement>(); return mLayoutElement; } }

        public Vector2 value
        {
            get { return RectTransformUtility.CalculateRelativeRectTransformBounds(cachedRectTransform).size; }
            set
            {
                if (cachedLayoutElement == null)
                {
                    cachedRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value.x);
                    cachedRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value.y);
                }
                else
                {
                    cachedLayoutElement.preferredWidth = value.x;
                    cachedLayoutElement.preferredHeight = value.y;
                }
            }
        }

        protected override void OnUpdate(float factor, bool isFinished)
        {
            value = from + factor * (to - from);
        }

        public override void SampleCurrentAsStart()
        {
            from = value;
        }

        public static uTweenSize Begin(GameObject go, Vector2 from, Vector2 to, float duration = 1f, float delay = 0f)
        {
            uTweenSize comp = uTweener.Begin<uTweenSize>(go, duration);
            comp.from = from;
            comp.to = to;
            comp.duration = duration;
            comp.delay = delay;
            if (duration <= 0)
            {
                comp.Sample(1, true);
                comp.enabled = false;
            }
            return comp;
        }

        [ContextMenu("Set 'From' to current value")]
        public override void SetStartToCurrentValue() { from = value; }

        [ContextMenu("Set 'To' to current value")]
        public override void SetEndToCurrentValue() { to = value; }

        [ContextMenu("Assume value of 'From'")]
        public override void SetCurrentValueToStart() { value = from; }

        [ContextMenu("Assume value of 'To'")]
        public override void SetCurrentValueToEnd() { value = to; }

    }
}
