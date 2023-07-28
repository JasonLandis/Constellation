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
        panel.color = new(0, 0, 0, 0);
        LeanTween.scale(gameObject, new(1, 1, 1), duration).setEase(inType);
        LeanTween.color(panel.rectTransform, new(0, 0, 0, 0.7f), duration2);
    }
}
