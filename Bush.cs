using System.Collections;
using UnityEngine;

public class Bush : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TutorialText());        
    }

    IEnumerator TutorialText()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}