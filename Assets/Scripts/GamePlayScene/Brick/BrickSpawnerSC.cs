using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawnerSC : MonoBehaviour
{

    [SerializeField]
    GameObject[] Bricks;

    RectTransform rt;
    GameObject basicBrick;
    GameObject Brick_1, Brick_2;
    int index1, index2;

    float xPosOfBrick, yPosOfBrick;

    private int horizontalRowNum, verticalRowNum;

    int typeOfRow;

    float XbrickSize, YbrickSize;

	// Start is called before the first frame update
	void Start()
    {
        verticalRowNum = Random.Range(3, 6);
        if (horizontalRowNum % 2 == 0)
            horizontalRowNum += 1;
        //getting width and height
        //basicBrick = Bricks[0];
        //rt = (RectTransform)basicBrick.transform;
        XbrickSize = Bricks[0].GetComponent<SpriteRenderer>().bounds.size.x;
        YbrickSize = Bricks[0].GetComponent<SpriteRenderer>().bounds.size.y;

        //setting the y position of the first brick
        yPosOfBrick = transform.position.y;
        for (int i = 0; i < verticalRowNum; i++)
        {
            horizontalRowNum = Random.Range(7, 13);
            typeOfRow = Random.Range(0, 2);
            //setting the position of the first brick
            xPosOfBrick = transform.position.x;
            //For Type 1 (no space)
            if (typeOfRow == 0)
            {
                //choosing 2 bricks to spawn
                index1 = Random.Range(0, Bricks.Length);
                Brick_1 = Bricks[index1];
                index2 = Random.Range(0, Bricks.Length);
                Brick_2 = Bricks[index2];

                //spawning for the right side
                for (int j = 0; j < (horizontalRowNum / 2)+1; j++)
                {
                    
                    //for first brick spawning
                    if (j % 2 == 0)
                    {
                        Instantiate(Bricks[index1], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                        xPosOfBrick = xPosOfBrick + XbrickSize;
                    }
                    //for second brick spawning
                    else if (j % 2 != 0)
                    {
                        Instantiate(Bricks[index2], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                        xPosOfBrick = xPosOfBrick + XbrickSize;
                    }
                }

                //spawning for the left side
                for (int j = 0; j < (horizontalRowNum / 2)+1; j++)
                {
                    if (j == 0)
                    {
                        xPosOfBrick = transform.position.x;
                    }
                    //for first brick spawning
                    if (j % 2 == 0)
                    {
                        if (j == 0)
                        {
                            xPosOfBrick = xPosOfBrick - XbrickSize;
                            continue;
                        }
                        Instantiate(Bricks[index1], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                        xPosOfBrick = xPosOfBrick - XbrickSize;
                    }
                    //for second brick spawning
                    else if (j % 2 != 0)
                    {
                        Instantiate(Bricks[index2], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                        xPosOfBrick = xPosOfBrick - XbrickSize;
                    }
                }
            }

            //for type 2 (with space)
            else if (typeOfRow == 1)
            {
                //choosing 2 bricks to spawn
                index1 = Random.Range(0, Bricks.Length);
                Brick_1 = Bricks[index1];
                index2 = Random.Range(0, Bricks.Length);
                Brick_2 = Bricks[index2];

                int spaceType = Random.Range(0, 2);
                //letting space at even-numper spaces
                if (spaceType == 0)
                {
                    //spawning for the right side
                    for (int j = 0; j < (horizontalRowNum / 2)+1; j++)
                    {
                        if (j % 2 == 0)
                        {
                            xPosOfBrick = xPosOfBrick + XbrickSize;
                            continue;
                        }
                        if (j % 4 == 1)
                        {
                            Instantiate(Bricks[index1], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                            xPosOfBrick = xPosOfBrick + XbrickSize;
                        }
                        if (j % 4 == 3)
                        {
                            Instantiate(Bricks[index2], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                            xPosOfBrick = xPosOfBrick + XbrickSize;
                        }
                    }
                    //spawning for the left side
                    for (int j = 0; j < (horizontalRowNum / 2)+1; j++)
                    {
                        if (j == 0)
                        {
                            xPosOfBrick = transform.position.x;
                        }
                        if (j % 2 == 0)
                        {
                            xPosOfBrick = xPosOfBrick - XbrickSize;
                            continue;
                        }
                        if (j % 4 == 1)
                        {
                            Instantiate(Bricks[index2], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                            xPosOfBrick = xPosOfBrick - XbrickSize;
                        }
                        if (j % 4 == 3)
                        {
                            Instantiate(Bricks[index1], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                            xPosOfBrick = xPosOfBrick - XbrickSize;
                        }
                    }
                }
                //letting space at odd-numper spaces
                else if (spaceType == 1)
                {
                    //spawning for the right side
                    for (int j = 0; j < (horizontalRowNum / 2)+1; j++)
                    {
                        if (j % 2 != 0)
                        {
                            xPosOfBrick = xPosOfBrick + XbrickSize;
                            continue;
                        }
                        if (j % 4 == 0)
                        {
                            Instantiate(Bricks[index1], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                            xPosOfBrick = xPosOfBrick + XbrickSize;
                        }
                        if (j % 4 == 2)
                        {
                            Instantiate(Bricks[index2], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                            xPosOfBrick = xPosOfBrick + XbrickSize;
                        }
                    }
                    //spawning for the left side
                    for (int j = 0; j < (horizontalRowNum / 2)+1; j++)
                    {
                        if (j == 0)
                        {
                            xPosOfBrick = transform.position.x;
                        }
                        if (j % 2 != 0 || j == 0)
                        {
                            xPosOfBrick = xPosOfBrick - XbrickSize;
                            continue;
                        }
                        if (j % 4 == 0)
                        {
                            Instantiate(Bricks[index1], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                            xPosOfBrick = xPosOfBrick - XbrickSize;
                        }
                        if (j % 4 == 2)
                        {
                            Instantiate(Bricks[index2], new Vector2(xPosOfBrick, yPosOfBrick), Quaternion.identity);
                            xPosOfBrick = xPosOfBrick - XbrickSize;
                        }
                    }
                }
            }

            //updating the y position of brick
            yPosOfBrick = yPosOfBrick - YbrickSize;
        }

 
        

    }//start

    // Update is called once per frame
    void Update()
    {
        
    }
}
