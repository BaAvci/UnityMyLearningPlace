using System.Collections;
using UnityEngine;

public class Fort : Building
{
    public override IEnumerator Co_FramingStep()
    {
        buildingFrameWall.SetActive(true);
        yield return new WaitForSeconds(5);
        buildingFrameRoof.SetActive(true);
    }
}