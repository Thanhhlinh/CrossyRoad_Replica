using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private TextMeshProUGUI scoreText;
    public GameObject gameOverUI;
    private Animator animator;
    private bool isHopping;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text ="Score:"+ score.ToString();
        if (Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            score++;
            float zDifference = 0;
            if (transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
            MoveCharacter(new Vector3(1, 0, zDifference));
        } 
        else if (Input.GetKeyDown(KeyCode.A))
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveCharacter(new Vector3(0,0,-1));
        }
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("Jump");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrain(false,transform.position);
    }
    public void FinishHop()
    {
        isHopping = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Vehicle>() != null)
        {
            if (collision.collider.GetComponent<Vehicle>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") || other.CompareTag("Water"))
        {
            Debug.Log("game over");
            gameOverUI.SetActive(true);
            Destroy(gameObject);
        }
    }
}
