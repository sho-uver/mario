﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear : MonoBehaviour
{
// Update is called once per frame
void Update()
{ if (Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("SampleScene"); }
        
        
    }
}
