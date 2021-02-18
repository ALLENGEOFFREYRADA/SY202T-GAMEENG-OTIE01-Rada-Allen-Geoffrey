using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionDestroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject);
    }
}
