using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    [SerializeField]
    GameObject[] points;
    [SerializeField]
    int Enemy_count;
    [SerializeField]
    GameObject panel;

    [SerializeField]
    List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        for (int i = 0; i < Enemy_count; i++)
        {
            int num = Random.Range(0, points.Length);

            enemy = Instantiate(enemy, new Vector3(points[num].transform.position.x,
                points[num].transform.position.y,
                points[num].transform.position.z), Quaternion.identity);

            enemies.Add(enemy);
        }
    }

    void FixedUpdate()
    {

        enemies.RemoveAll(item => item == null);
        if (!enemies.Any())
        {

            GameEnd();

        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button4)) Exit(); // для геймпада
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) ||       // для геймпада
           (Input.GetKeyDown(KeyCode.R))) Restart();            // для клавиатуры
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
    public void GameEnd()
    {
        panel.SetActive(!panel.activeSelf);
        Time.timeScale = 0;
    }
}
