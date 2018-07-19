using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnim : MonoBehaviour {

    private void OnEnable()
    {
        StartCoroutine(WaitTillAnimFinished(2));
    }

    IEnumerator WaitTillAnimFinished(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
