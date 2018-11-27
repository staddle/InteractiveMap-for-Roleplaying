using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour {

    int i = 1;
    public float time = 3.0f;
	void Start () {
        InvokeRepeating("LoadMore", 0, time);
	}
	
	void LoadMore () {
        if (i >= 100)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        GetComponentInParent<Slider>().value = i;
        i++;
	}
}
