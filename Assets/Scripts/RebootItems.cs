using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebootItems : MonoBehaviour
{
    [SerializeField] Transform[] inicialPos;
    [SerializeField] List<Vector3> inicialPosList;
    [SerializeField] bool valid01 = false;
    [SerializeField] Transform objetcSearch;
    [SerializeField] GameObject findObject;
    [SerializeField] int orderPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetListPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(valid01)
        {
            for (int i = 0; i < inicialPos.Length; i++)
            {
                if(objetcSearch.position == inicialPos[i].position)
                {
                    Debug.Log(inicialPos[i].position.x + "" + objetcSearch.position.x);

                    objetcSearch.position = inicialPosList[i];
                }
            }
        }
    }

    private void GetListPos()
    {
        for(int i = 0; i < inicialPos.Length; i++)
        {
            inicialPosList.Add(inicialPos[i].position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform)
        {
            valid01 = true;
            objetcSearch = collision.gameObject.GetComponent<Transform>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.activeInHierarchy)
        {
            valid01 = false;
        }
    }
}
