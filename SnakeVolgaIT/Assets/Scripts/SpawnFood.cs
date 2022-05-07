using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    private int height = 0;
    private int width = 0;

    private int sizeHeight = 30;

    // Start is called before the first frame update
    
    void Start()
    {
        height = (int)(sizeHeight / 3.4f) - 1;
        width = (int)((Screen.width / (Screen.height / sizeHeight) - 1.7f) / 3.4f) - 1;

        FoodSpaw();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
            FoodSpaw();
    }

    private void FoodSpaw()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
