
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{
    [SerializeField] Transform player;

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player.transform.parent = null;
        }
    }


}
