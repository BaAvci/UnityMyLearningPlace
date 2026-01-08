using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingBuilder
{
    public IEnumerator Co_FoundationStep();
    public IEnumerator Co_FramingStep();
    public IEnumerator Co_EnclosingStep();
    public IEnumerator Co_FinishingTouchStep();
    
}
