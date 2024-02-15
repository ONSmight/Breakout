using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject[] Arrows;

    [SerializeField]
    GameObject[] Player;

    GameObject selectedPlayer, leftArrow, rightArrow;
    
    int Pn = 0;


    // Start is called before the first frame update
    void Start()
    {
        //arrow setting
        rightArrow = Arrows[0];
        leftArrow = Arrows[1];

        rightArrow.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        leftArrow.GetComponent<Image>().color = new Color32(97, 97, 97, 200);

        selectedPlayer = Instantiate(Player[Pn], transform.position, Quaternion.identity);
        selectedPlayer.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Selected();

        SelectedPlayer();
    }
	private void LateUpdate()
	{
        ArrowControl();
	}

	private void Selected()
	{
        //right arrow selecting
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

           // Debug.Log("rigt");
            Pn += 1;
            if  (Pn > 3)
            {
                //Debug.Log("Cant right");
                Pn = 3;
                return;
            }
            
            Destroy(gameObject.transform.GetChild(0).gameObject);
            selectedPlayer = Instantiate(Player[Pn], transform.position, Quaternion.identity);
            selectedPlayer.transform.parent = gameObject.transform;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           // Debug.Log("left");
            Pn -= 1;
            if (Pn < 0)
            {
                // Debug.Log("cant left");
                Pn = 0;
                return;
            }
           
            Destroy(gameObject.transform.GetChild(0).gameObject);
            selectedPlayer = Instantiate(Player[Pn], transform.position, Quaternion.identity);
            selectedPlayer.transform.parent = gameObject.transform;

        }


    }

    void ArrowControl()
    {
        if (Pn > 0 && Pn < 3)
        {
            rightArrow.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
            leftArrow.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
        else if (Pn == 0)
        {
            leftArrow.GetComponent<Image>().color = new Color32(97, 97, 97, 200);
        }
        else if (Pn == 3)
        {
            rightArrow.GetComponent<Image>().color = new Color32(97, 97, 97, 200);
        }
    }

    void SelectedPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.GM.selectedPlayer = Pn;
            SceneManager.LoadScene("GamePlay");
        }
    }

}
