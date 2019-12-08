using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainGame");
    }
}
