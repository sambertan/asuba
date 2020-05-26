using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Script : MonoBehaviour
{

    public GameObject loading;
    public Slider slider;
    public Text text;
    public void Loadlevel(int Index)
    {
        StartCoroutine(LoadSync(Index));

    }

    IEnumerator LoadSync(int Index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Index);

        loading.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
