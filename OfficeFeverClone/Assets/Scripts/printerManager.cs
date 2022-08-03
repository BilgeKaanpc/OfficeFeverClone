using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printerManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> paperList = new List<GameObject>();
    [SerializeField]
    public GameObject paperPrefab;
    [SerializeField]
    public Transform exitPoint;
    bool isWorknig;
    int stactCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintPaper());
    }
    public void RemoveLast()
    {
        if(paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }

    IEnumerator PrintPaper()
    {
        
        while (true)
        {
            float paperCount = paperList.Count;

            int rowCount = (int)paperCount / stactCount;
            if (isWorknig)
            {

                GameObject temp = Instantiate(paperPrefab);
                temp.transform.position = new Vector3(exitPoint.position.x , (paperCount%stactCount) / 20, exitPoint.position.z + ((float)rowCount / 2f));
                paperList.Add(temp);
            }
            if(paperList.Count >= 30)
            {
                isWorknig = false;
            }else if(paperList.Count < 30)
            {
                isWorknig = true;
            }



            yield return new WaitForSeconds(1f);
        }

    }
}
