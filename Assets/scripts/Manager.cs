using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour

{
   

    private int row;
    private int col;

    public ItemBehaviour itemBehaviour;

    private float gapRow = 1.5f;
    private float gapCol = 1.5f;

    public Material[] materials;
    public Material defaultMaterial;
    public Material bonusMaterial;

    public GameObject itemPrefab;

    private float timer = 0.5f;
    private float otherTimer = 5f;
    public float anotherTimer;

    public List<GameObject> gameObjects = new List<GameObject>();
    private int nbrCube = 1;

    public int score;
    private int bonusScore;






    //Start is called before the first frame update
    void Start()
    {
        anotherTimer = Random.Range(3f, 5f);
        
    }
    //    col = 50;
    //    row = 50;

    //    int x = Random.Range(0, col);
    //    int z = Random.Range(0, row);



    //    Vector3 position = new Vector3(x * gapCol, 0, z * gapRow);
    //    GameObject item = Instantiate(itemPrefab, position, Quaternion.identity);
    //    item.GetComponent<Renderer>().material = defaultMaterial;
    //    item.GetComponent<ItemBehaviour>();


    //}

    // Update is called once per frame
   
    public void CreateCube()
    {
        col = 50;
        row = 50;
        
        int x = Random.Range(0, col);
        int z = Random.Range(0, row);
        int y = Random.Range(0, 5);
        

       
            Vector3 position = new Vector3(x * gapCol, 0, z * gapRow);
            GameObject item = Instantiate(itemPrefab, position, Quaternion.identity);
            if (y >= 3)
            {
                item.GetComponent<Renderer>().material = bonusMaterial;
                bonusScore = 3; 
            }
            else
            {
                item.GetComponent<Renderer>().material = defaultMaterial;
                bonusScore = 1;
            }
            item.GetComponent<ItemBehaviour>().manager=this;
            timer = 1f;
            gameObjects.Add(item);
       
        
    }

    public void DestroyGameObject(GameObject cube)
    {
        score += bonusScore;
        PlayerPrefs.SetInt("score", score); 
        Destroy(cube);
        gameObjects.Remove(cube);
        
    }
    void Update()
    {
        timer -= Time.deltaTime;
        otherTimer -= Time.deltaTime;
        anotherTimer -= Time.deltaTime;

        if (timer <= 0f)
        {
            
            for (int a = 1; a <= nbrCube; a++)
            {
                if (gameObjects.Count <= 10)
                {
                    CreateCube();
                }
               
            }
        }


        if (otherTimer <= 0f)
        {
                        
            nbrCube++;
            otherTimer = 5f;
            
        }

        if (anotherTimer <= 0f)
        {
            Destroy(gameObjects[gameObjects.Count-1]);
            gameObjects.Remove(gameObjects[gameObjects.Count-1]);
           
            anotherTimer = Random.Range(3f, 5f);
        }

        

    }
}
