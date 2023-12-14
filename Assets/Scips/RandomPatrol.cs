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

    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;

    public GameObject restartPanel;

    // Static flag to determine if movement should stop for all planets
    static bool shouldStopAllPlanets = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPostion();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldStopAllPlanets)
        {
            if ((Vector2)transform.position != targetPosition)
            {
                speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                targetPosition = GetRandomPostion();
            }
        }
    }

    Vector2 GetRandomPostion()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet")
        {
            // Set the static flag to stop movement for all planets
            shouldStopAllPlanets = true;

            // Disable the renderer or set the game object inactive
            Renderer planetRenderer = GetComponent<Renderer>();
            if (planetRenderer != null)
            {
                planetRenderer.enabled = false;
            }
            else
            {
                gameObject.SetActive(false);
            }

            // Show the restart panel
            restartPanel.SetActive(true);
        }
    }

    float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}














