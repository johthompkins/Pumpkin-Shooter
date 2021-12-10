using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _highScore = null;
    [SerializeField] private Text _title = null;
    [SerializeField] private Text _version = null;
    // Start is called before the first frame update
    void Start()
    {
        string file = Application.dataPath + "/Resources/HUDFile.txt";
        readTextFile(file);

        //read in highscore
        _highScore.text = PlayerPrefs.HasKey("highScore") ? PlayerPrefs.GetInt("highScore").ToString() : 0.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Read in info from any file in the Resource folder
    void readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path, Encoding.Default);

        while (!inp_stm.EndOfStream)
        {
            //reads in Title
            string inp_ln = inp_stm.ReadLine();
            _title.text = inp_ln;

            //read in  Version (0.9)
            inp_ln = inp_stm.ReadLine();
            _version.text = inp_ln;
        }

        inp_stm.Close();
    }

    public void startGame()
    {
        SceneManager.LoadSceneAsync(1);//load index scene 1 which is set in build which is set in buildsettigns as main scene
    }
}
