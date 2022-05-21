using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3DViewer : MonoBehaviour
{
    GameObject objSpawn = null;
    public void SpawnObject(GameObject obj)
    {
        if(obj != null)
            Destroy(objSpawn);
        objSpawn = Instantiate(obj, new Vector3(1000, 1000, 1000), obj.transform.rotation);
        objSpawn.AddComponent<Item3DRotate>();
    }
}
