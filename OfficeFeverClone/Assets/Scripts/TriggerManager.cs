using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnPaperCollect;
    public static printerManager printerMan;

    public delegate void OnDeskArea();
    public static event OnDeskArea OnPaperGive;
    public static WorkerManager workerManager;
    bool isCollecting,isGiving;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CollectEnum());
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "CollectArea")
        {
            isCollecting = true;
            printerMan = other.gameObject.GetComponent<printerManager>();
        }
        if (other.gameObject.tag == "WorkArea")
        {
            isGiving = true;
            workerManager = other.gameObject.GetComponent<WorkerManager>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CollectArea")
        {
            isCollecting = false;
            printerMan = null;

        }
        if (other.gameObject.tag == "WorkArea")
        {
            isGiving = false;
            workerManager = null;
        }
    }
    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting)
            {
                OnPaperCollect();
            }
            if (isGiving)
            {
                OnPaperGive();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
