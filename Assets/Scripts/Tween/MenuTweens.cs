using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuTweens : MonoBehaviour
{
    public Transform mainPanel;
    public Transform creditsPanel;
    public Transform settingsPanel;

    public float transitionDuration = .5f;

    public void MainPanelTween()
    {
        transform.DOMove(mainPanel.position, transitionDuration)
            .SetEase(Ease.InQuad)
            .Play();
    }

    public void CreditsPanelTween()
    {
        transform.DOMove(creditsPanel.position, transitionDuration)
            .SetEase(Ease.InQuad)
            .Play();
    }

    public void SettingsPanelTween()
    {
        transform.DOMove(settingsPanel.position, transitionDuration)
            .SetEase(Ease.InQuad)
            .Play();
    }
}
