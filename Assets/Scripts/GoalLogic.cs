using UnityEngine;

public class GoalLogic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameObject manager = GameObject.Find("Game Manager");
        manager.GetComponent<GameManager>().GameEnd();
    }
}
