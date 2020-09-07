using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            
            SceneManager.LoadScene("Level_02");

        }
    }
}
