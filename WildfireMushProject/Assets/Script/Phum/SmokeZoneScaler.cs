using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeZoneScaler : MonoBehaviour
{
    [Header("Scale Settings")]
    [SerializeField] private float minScale = 0.2f;
    [SerializeField] private float maxScale = 1.8f;

    [Header("Step Settings")]
    [SerializeField] private float step = 0.15f;
    [SerializeField] private float interval = 0.5f;

    [Header("Behavior")]
    [SerializeField] private bool autoDisableWhenMin = true;

    private Coroutine scaleRoutine;
    private bool isExpanding;
    private bool isShrinking;

    private void Awake()
    {
        transform.localScale = Vector3.one * minScale;
    }

    public void StartExpand()
    {
        gameObject.SetActive(true);

        isShrinking = false;
        isExpanding = true;

        if (scaleRoutine != null) StopCoroutine(scaleRoutine);
        scaleRoutine = StartCoroutine(ExpandRoutine());
    }

    public void StartShrink()
    {
        isExpanding = false;
        isShrinking = true;

        if (scaleRoutine != null) StopCoroutine(scaleRoutine);
        scaleRoutine = StartCoroutine(ShrinkRoutine());
    }

    private IEnumerator ExpandRoutine()
    {
        while (isExpanding)
        {
            float current = transform.localScale.x;
            float next = Mathf.Min(current + step, maxScale);

            transform.localScale = Vector3.one * next;

            if (Mathf.Approximately(next, maxScale))
            {
                isExpanding = false;
                yield break;
            }

            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator ShrinkRoutine()
    {
        while (isShrinking)
        {
            float current = transform.localScale.x;
            float next = Mathf.Max(current - step, minScale);

            transform.localScale = Vector3.one * next;

            if (Mathf.Approximately(next, minScale))
            {
                isShrinking = false;

                if (autoDisableWhenMin)
                    gameObject.SetActive(false);

                yield break;
            }

            yield return new WaitForSeconds(interval);
        }
    }
}
