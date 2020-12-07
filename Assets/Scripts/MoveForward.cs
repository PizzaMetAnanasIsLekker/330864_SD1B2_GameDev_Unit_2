using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float m_speed;
    private const float m_topBound = 20.0f;
    private const float m_lowerBound = -20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
        if (transform.position.z > m_topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < m_lowerBound)
        {
            Debug.Log("GAME OVER!");
            Destroy(gameObject);

        }
    }
}
