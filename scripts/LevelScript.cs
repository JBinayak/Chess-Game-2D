using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("removeText", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void removeText()
    {
        Destroy(gameObject);
    }
}
