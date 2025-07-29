using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public List<Personajes> personajes;
   

    private void Awake()
    {
        if(Manager.Instance == null) 
        {
            Manager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}


