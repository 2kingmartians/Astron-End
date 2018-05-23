using System.Collections;
using UnityEngine;

public class colideFadeToScene : MonoBehaviour {
    public string sceneIndex;
    public Animation anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        anim.Play("FadeDown");
        yield return new WaitForSeconds(anim.GetClip("FadeDown").length);
        loadScene.LoadScene(sceneIndex);
    }
}
