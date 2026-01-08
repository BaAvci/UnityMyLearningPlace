using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IBuildingBuilder
{
    [SerializeField] protected GameObject foundation;
    [SerializeField] protected GameObject buildingFrameRoof;
    [SerializeField] protected GameObject buildingFrameWall;
    [SerializeField] protected GameObject enclosingWall;
    [SerializeField] protected GameObject enclosingRoof;
    [SerializeField] protected GameObject finishedWall;
    [SerializeField] protected GameObject finishedRoof;
    [SerializeField] private float defaultSecondsToWait = 1.5f;
    protected WaitForSeconds waitForSeconds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        waitForSeconds = new WaitForSeconds(defaultSecondsToWait);
        StartCoroutine(Co_Start());
    }

    protected virtual IEnumerator Co_Start()
    {
        yield return StartCoroutine(Co_FoundationStep());
        yield return waitForSeconds;
        yield return StartCoroutine(Co_FramingStep());
        yield return waitForSeconds;
        yield return StartCoroutine(Co_EnclosingStep());
        yield return waitForSeconds;
        yield return StartCoroutine(Co_FinishingTouchStep());
    }

    public virtual IEnumerator Co_FoundationStep()
    {
        foundation.SetActive(true);
        yield return null;
    }

    public virtual IEnumerator Co_FramingStep()
    {
        buildingFrameWall.SetActive(true);
        yield return waitForSeconds;
        buildingFrameRoof.SetActive(true);
    }

    public virtual IEnumerator Co_EnclosingStep()
    {
        enclosingWall.SetActive(true);
        yield return waitForSeconds;
        finishedWall.SetActive(true);
        enclosingWall.SetActive(false);
        buildingFrameWall.SetActive(false);
        yield return waitForSeconds;
        enclosingRoof.SetActive(true);
    }

    public virtual IEnumerator Co_FinishingTouchStep()
    {
        finishedRoof.SetActive(true);
        enclosingRoof.SetActive(false);
        buildingFrameRoof.SetActive(false);
        yield return null;
    }
}