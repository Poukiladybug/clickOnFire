using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour

{

    public UnityEvent whenWin;
    public UnityEvent whenLose;
    public int scoreMax = 100;

    private int row;
    private int col;
    private int depth;

    public ItemBehaviour itemBehaviour;

    private float gapRow = 1.5f;
    private float gapCol = 1.5f;

    public Material[] materials;
    public Material defaultMaterial;
    public Material bonusMaterial;

    public GameObject itemPrefab;

    private float timer = 0.5f;
    private float otherTimer = 5f;


    public List<GameObject> gameObjects = new List<GameObject>();
    private int nbrCube = 1;

    public int score = 0;


    private void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        
    }


    public void CreateCube()
    {
        if (gameObjects.Count >= 10) return;
        col = 50;
        row = 50;
        depth = 50;
        
        int x = Random.Range(0, col);
        int z = Random.Range(0, row);
        int w = Random.Range(0, depth);
        int y = Random.Range(0, 5);
        

       
            Vector3 position = new Vector3(x * gapCol, w*gapCol, z * gapRow);
            GameObject item = Instantiate(itemPrefab, position, Quaternion.identity);
            if (y >= 4)
            {
                item.GetComponent<Renderer>().material = bonusMaterial;
               
                item.GetComponent<ItemBehaviour>().isBlue = true;
        }
            else
            {
                item.GetComponent<Renderer>().material = defaultMaterial;
                

            }
            item.GetComponent<ItemBehaviour>().manager=this;
            timer = 1f;
            gameObjects.Add(item);
       
        
    }

    public void DestroyGameObject(GameObject cube)
    {
        int value = 1;
        if (cube.GetComponent<ItemBehaviour>().isBlue) value = 3;
        score += value;
        PlayerPrefs.SetInt("score", score); 
        Destroy(cube);
        gameObjects.Remove(cube);
        if (score >= scoreMax)
        {
            whenWin?.Invoke();
        }
        
    }

    public void TimeDestroyGameObject(GameObject cube)
    {
        int value = -1;
        if (cube.GetComponent<ItemBehaviour>().isBlue) value = -3;
        score += value;
        PlayerPrefs.SetInt("score", score);
        Destroy(cube);
        gameObjects.Remove(cube);

        if (score <= 0)
        {
            whenLose?.Invoke();
        }

    }
    void Update()
    {
        timer -= Time.deltaTime;
        otherTimer -= Time.deltaTime;


        if (timer <= 0f)
        {
            
            for (int a = 1; a <= nbrCube; a++)
            {
                
                
                CreateCube();
                
               
            }
        }


        if (otherTimer <= 0f)
        {
                        
            nbrCube++;
            otherTimer = 5f;
            
        }


    }
}
