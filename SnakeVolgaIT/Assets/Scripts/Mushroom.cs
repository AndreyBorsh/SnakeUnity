using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private float posX;
    private float posY;

    public GameObject food;
    
    void Start()
    {
        FoodSpawn(food);
    }

    public GameObject Food => food;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Borders")
            FoodSpawn(food);
    }

    public void FoodSpawn(GameObject food)
    {
        posX = Random.Range(-15f, 15.5f);
        posY = Random.Range(-8f, 7f);

        //food.transform.position = new Vector3(posX, posY, -1f);
        Instantiate(food, new Vector3(posX, posY, -1f), Quaternion.identity, food.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
