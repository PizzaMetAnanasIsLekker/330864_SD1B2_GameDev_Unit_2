using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    private Vector3 m_motion = new Vector3(0, 0, 0);
    private const float m_xRange = 17.0f;
    private const float m_yRange = 9.5f;
    private float m_speed = 20.0f;
    private bool m_leftPressed = false;
    private bool m_rightPressed = false;
    private bool m_downPressed = false;
    private bool m_upPressed = false;
    private bool m_spacePressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        SetMotion();
        if (m_spacePressed)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        Move();
    }

    private void GetInput()
    {
        m_leftPressed = false;
        m_rightPressed = false;
        m_downPressed = false;
        m_upPressed = false;
        m_spacePressed = false;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_leftPressed = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_rightPressed = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            m_downPressed = true;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_upPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_spacePressed = true;
        }
    }

    private void SetMotion()
    {
        if (m_leftPressed && m_rightPressed)
        {
            m_motion.x = 0.0f;
        }
        else if (m_leftPressed)
        {
            m_motion.x = -m_speed;
        }
        else if (m_rightPressed)
        {
            m_motion.x = m_speed;
        }
        else
        {
            m_motion.x = 0.0f;
        }

        if (m_downPressed && m_upPressed)
        {
            m_motion.z = 0.0f;
        }
        else if (m_downPressed)
        {
            m_motion.z = -m_speed;
        }
        else if (m_upPressed)
        {
            m_motion.z = m_speed;
        }
        else
        {
            m_motion.z = 0.0f;
        }
    }

    private void Move()
    {
        transform.Translate(m_motion * Time.deltaTime);
        if (transform.position.x < -m_xRange)
        {
            transform.position = new Vector3(-m_xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > m_xRange)
        {
            transform.position = new Vector3(m_xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -m_yRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -m_yRange);
        }
        else if (transform.position.z > m_yRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, m_yRange);
        }
    }
}
