using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float speed = 6f;

    int keyNumber = 1; //1 - left   2 - right   3 - up    4 - down


    readonly List<string> activeButton = new List<string>();

    public GameObject originalBody;

    public GameObject food;

    public bool isMove = true;
    private bool isEat;

    [SerializeField]
    public static Text gameOverText;
    public static Button gameOverButton;

    Restart restart = new();
    Level level = new();

    public Text result;
    int resultCount = 0;

    void Start()
    {
        gameOverText = GameObject.Find("GameOver").GetComponent<Text>();
        gameOverButton = GameObject.Find("Restart").GetComponent<Button>();

        activeButton.Add("S");
        activeButton.Add("W");
        activeButton.Add("A");

        resultCount = 0;

        Mushroom mush = new Mushroom();
        mush.food = food;
        mush.FoodSpawn(mush.food);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Borders"))
        {
            isMove = false;
            level.ShowElements(gameOverText, gameOverButton);
            restart.ShowElements(gameOverText, gameOverButton);
        }
        if (col.CompareTag("Food"))
        {
            Eat();
            Mushroom mush = new Mushroom();
            Destroy(col.gameObject);
            mush.food = food;
            mush.FoodSpawn(mush.food);
            resultCount++;
            result.text = resultCount.ToString();
        }
    }

    private float timer = 0;

    void FixedUpdate()
    {
        if(timer < 0 && isMove)
        {
            MoveHead();
            timer = 1;
        }
        timer -= Time.deltaTime * speed;

        if (isMove)
        {
            if (Input.GetKey(KeyCode.W) && activeButton.Contains("W"))
            {
                keyNumber = 3;
                activeButton.Clear();
                activeButton.Add("D");
                activeButton.Add("W");
                activeButton.Add("A");
            }
            else if (Input.GetKey(KeyCode.S) && activeButton.Contains("S"))
            {
                keyNumber = 4;
                activeButton.Clear();
                activeButton.Add("S");
                activeButton.Add("D");
                activeButton.Add("A");
            }
            else if (Input.GetKey(KeyCode.A) && activeButton.Contains("A"))
            {
                keyNumber = 1;
                activeButton.Clear();
                activeButton.Add("S");
                activeButton.Add("W");
                activeButton.Add("A");
            }
            else if (Input.GetKey(KeyCode.D) && activeButton.Contains("D"))
            {
                keyNumber = 2;
                activeButton.Clear();
                activeButton.Add("S");
                activeButton.Add("W");
                activeButton.Add("D");
            }
        }
    }

    void MoveHead()
    {
        Head head = GetComponentInChildren<Head>();

        Instantiate(originalBody, head.transform.position, Quaternion.identity, transform);
        if (keyNumber == 1)
            head.transform.position = new Vector3(head.transform.position.x - 2.0f, head.transform.position.y, head.transform.position.z);
        else if (keyNumber == 2)
            head.transform.position = new Vector3(head.transform.position.x + 2.0f, head.transform.position.y, head.transform.position.z);
        else if (keyNumber == 3)
            head.transform.position = new Vector3(head.transform.position.x, head.transform.position.y + 2.0f, head.transform.position.z);
        else if (keyNumber == 4)
            head.transform.position = new Vector3(head.transform.position.x, head.transform.position.y - 2.0f, head.transform.position.z);
        MoveBody();
    }

    void MoveBody()
    {
        if (isMove && !isEat)
        {
            Body[] body = GetComponentsInChildren<Body>();

            Tail tail = GetComponentInChildren<Tail>();
            tail.transform.position = body[0].transform.position;

            Destroy(body[0].gameObject);
        }
        else
        {
            isEat = false;
        }
    }

    

    public void Eat()
    {
        isEat = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
