using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragableObject : MonoBehaviour
{
    private bool isDrag;
    private Vector2 originPosition;
    private bool isGoal;
    private Vector2 goalPosition;

    [SerializeField]
    private GameManager gameManager;

    void Start()
    {
        originPosition = transform.position;
    }

    void Update()
    {
        



        if (isDrag)
        {
            transform.position = Input.mousePosition;
        }
    }


    public void Drag()
    {
        isDrag = true;
    }

    public void Drop()
    {
        isDrag = false;
        if (isGoal)
        {
            // IF Collision
            if (gameManager.correctAnswer(GetComponentInChildren<Text>().text))
            {
                gameManager.ShowResult(true);
                Debug.Log("Correct");
                gameManager.increasePoint();



            }
            else
            {
                gameManager.ShowResult(false);

                Debug.Log("Not Correct");

            }


            transform.position = originPosition;
            gameManager.resetAll();

        }
        else
        {
            // IF Not Collision

            transform.position = originPosition;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GoalTag"))
        {
            isGoal = true;
            goalPosition = collision.transform.position;

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GoalTag"))
        {

            isGoal = false;
        }
    }
}
