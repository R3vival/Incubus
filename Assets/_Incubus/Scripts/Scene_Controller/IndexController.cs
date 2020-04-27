using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class IndexController : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Lobby");
    }
}
