using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LastStageZombies : MonoBehaviour
{

    [SerializeField] private AIChase aiChase;
    [SerializeField] private GameObject[] _LastStageZombies;

    private AIChase _Chase;

    private bool _zombieActive = false;
    // Start is called before the first frame update
    void Start()
    {
        //_Chase.ZombieDistance();
        //switchCase();
    }

    // Update is called once per frame
    void Update()
    {

        if (aiChase.InFinalRange() && !_zombieActive)
        {
            
            _zombieActive = true;


            FindZombie();

            _LastStageZombies[FindZombie()].SetActive(true);
        }
    }

    public void switchCase()
    {
        switch (_Chase._zombieDistance)
        {
            case "Close Range":
                Debug.Log("Close Range");
                break;

            case "Farthest Range":
                Debug.Log("Farthest Range");
                break;

            case "Far Range":
                Debug.Log("Far Range");
                break;

            case "Mid Range":
                Debug.Log("Mid Range");
                break;

            case "Deadzone Range":
                Debug.Log("Deadzone Range");
                break;

            default: break;
        }
    }

    private int FindZombie()
    {
        foreach (GameObject value in _LastStageZombies)
        {
            value.SetActive(true);
        }
        return 0;
    }
}
