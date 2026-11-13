using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
[SerializeField] GameObject platformPrefab;
[SerializeField]GameObject firstPlatform;

[SerializeField] float distanceY =5f;

Vector3 lastInstancePlatform;

 Camera cameraMain;
 float screenEdgeX;
 float indet = 8f;
    void Awake()
    {
        cameraMain =Camera.main;
        
    }
    void Start()
    {
        lastInstancePlatform = firstPlatform.transform.position;
        screenEdgeX = (Camera.main.orthographicSize * Camera.main.aspect);

    }

    void Update()
    {
        if (cameraMain.transform.position.y > lastInstancePlatform.y - indet)
        {
            float randomX = Random.Range(-screenEdgeX,screenEdgeX);
            while(Mathf.Abs(randomX - lastInstancePlatform.x) < 2.5f )
            {
               randomX = Random.Range(-screenEdgeX,screenEdgeX);
            }
          
            Vector3 newPlatformPos = new Vector3(randomX,lastInstancePlatform.y + distanceY,0);
            Instantiate(platformPrefab,newPlatformPos,Quaternion.identity);
            lastInstancePlatform = newPlatformPos;
        }
    }
}
