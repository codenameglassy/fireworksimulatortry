using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MenuMenu : MonoBehaviour
{
    public CanvasGroup fade;

    //tween
    public RectTransform playBtn;
    public RectTransform title;
    public RectTransform hs;
    public RectTransform settings;

    public Vector2 playBtnPos;
    public Vector2 titlePos;
    public Vector2 hsPos;
    public Vector2 settingsPos;
    // Start is called before the first frame update
    void Start()
    {
        fade.alpha = 1.0f;
        fade.DOFade(0, 2);

        StartCoroutine(Enum_tween());
    }

    IEnumerator Enum_tween()
    {
        yield return new WaitForSeconds(.4f);

        playBtn.DOAnchorPos(playBtnPos, 1f);
        yield return new WaitForSeconds(.5f);
        title.DOAnchorPos(titlePos, 1f).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(.5f);
        hs.DOAnchorPos(hsPos, 1f);
        yield return new WaitForSeconds(.5f);
        settings.DOAnchorPos(settingsPos, 1f);
        yield return new WaitForSeconds(.5f);

    }

}
