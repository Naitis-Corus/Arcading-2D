using UnityEngine;

public class CameraMoveUp : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float speedMoveUp = 1.5f;
    [SerializeField] float cameraDelayTime = 2f;
  
   //This function is executed after the Update (within a frame)
    void LateUpdate()
    {

        float posY = transform.position.y;
        if (player.transform.position.y > transform.position.y)
        {
            
                float newPosY = Mathf.Lerp(transform.position.y, player.transform.position.y, cameraDelayTime * Time.deltaTime);
                posY = newPosY;
            
        }
        else{

      
        posY = posY + (speedMoveUp * Time.deltaTime);}
        
        transform.position = new Vector3(transform.position.x,posY,transform.position.z);

    }

}

