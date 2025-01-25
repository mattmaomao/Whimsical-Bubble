using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    [SerializeField] float shootInterval;
    float timer;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Vector2 shootingDirection;

    void Update()
    {
        if (GameManager.Instance.gameRunning)
        {
            timer += Time.deltaTime;
            if (timer >= shootInterval)
            {
                shoot();
                timer = 0;
            }
        }
    }

    void shoot()
    {
        Arrow arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.init(shootingDirection, transform);
    }
}
