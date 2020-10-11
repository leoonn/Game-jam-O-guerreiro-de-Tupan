using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{

    powersState power;
    int index = 4;
    void Start()
    {
        power = powersState.noneSelected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PowerUpSelect()
    {
        for (int i = 0; i < index; i++)
        {
            if (index <= 0)
            {
                index = 4;
            }

        }
    }
}
enum powersState { shock, fireball, healing, shield, noneSelected }