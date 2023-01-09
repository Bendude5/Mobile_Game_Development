using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Loads specific level
    public void loadlevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
