using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(coroutineA());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(2.0f);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}
