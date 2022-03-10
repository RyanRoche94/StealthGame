using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAnim : MonoBehaviour
{
    public Animator MouseAnima;
    public bool Running;

    // Start is called before the first frame update
    void Start()
    {
         MouseAnima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseAnima.SetBool("Running", Running);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            Running = true;
            Debug.Log("Space key was pressed.");
        }
        else
        {
            Running = false;
        }
    }
}
