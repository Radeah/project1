using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPostion();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPostion();
        }
    }

    Vector2 GetRandomPostion()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minX, maxY);
        return new Vector2(randomX, randomY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet");
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }










}
