using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
        public float delay = 3f; // tiempo
        public string nextScene = "LoadScreen"; // carga la siguiente scene

        void Start()
        {
            Invoke("LoadNextScene", delay); 
        }

        void LoadNextScene()
        {
            SceneManager.LoadScene(nextScene);
        }
    

}
