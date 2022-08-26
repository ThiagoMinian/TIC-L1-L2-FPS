using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontrarElemento : MonoBehaviour
{
    public GameObject[] arrayDeMesas;
    // Start is called before the first frame update
    void Start()
    {
        arrayDeMesas = GameObject.FindGameObjectsWithTag("Mesa");
        AddMesaScriptAndSetDestructible();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //DesactivateObjectsInArray();
            DestroytDestructible();
        }
        
    }

    void DesactivateObjectsInArray()
    {
        for(int i = 0; i < arrayDeMesas.Length; i++)
        {
            arrayDeMesas[i].SetActive(false);
        }
    }

    void AddMesaScriptAndSetDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {
            go.AddComponent<Mesa>();
            int rnd = Random.Range(0, 2);
            go.GetComponent<Mesa>().destructible = rnd == 0;
            
        }

    }

    void DestroytDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {
            if (go.GetComponent<Mesa>().destructible)
            {
                Destroy(go);
            }
        }

    }
}
