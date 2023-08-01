using UnityEngine;
using UnityEngine.UI;

public class ScaleTween : MonoBehaviour
{
    public Image panel;
    public LeanTweenType inType;
    public float duration;
    public float duration2;

    public void OnEnable()
    {
        transform.localScale = new(0.85f, 0.85f, 0.85f);
        LeanTween.scale(gameObject, new(1, 1, 1), duration).setEase(inType);
        if (panel != null)
        {
            panel.color = new(0, 0, 0, 0);
            LeanTween.color(panel.rectTransform, new(0, 0, 0, 0.7f), duration2);
        }
    }
}
