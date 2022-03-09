using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{

    public string sceneName;
    public Animator fadeSystem;
    public int animationDuration = 1;

    private void Start()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(animationDuration);
        SceneManager.LoadScene(sceneName);

    }

}
