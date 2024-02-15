using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    int _SelectedPlayer;
    public int selectedPlayer
    {
        get { return _SelectedPlayer; }
        set { _SelectedPlayer = value; }
        
    }

	private void Awake()
	{
        if (GM == null)
            GM = this;
	}


	// Start is called before the first frame update
	void Start()
    {
        Object.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //print(selectedPlayer);
    }
    public void LoadPlayerSelectScene()
    {
        SceneManager.LoadScene("PlayerSelect");
    }



}
