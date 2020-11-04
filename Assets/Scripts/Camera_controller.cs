using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
   // [SerializeField]
    private float cameraSpeed = 2.0F;

    //[SerializeField]
    private float looking = 3.5F;

    private Transform target;
    


    private void Awake()
    {
        if (!target) target = FindObjectOfType<Character>().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 position = target.position; position.z = -10.0F;



        if (target.position.y > 0.5F) position.y += (Input.GetAxis("Vertical") * looking);

        else if (Input.GetAxis("Vertical") != 0)
        {
            position.y = 0.2F + Input.GetAxis("Vertical") * (looking - 2);

           //Debug.Log("Look" + position.y + Input.GetAxis("Vertical"));
        }


        else position.y = 0.2F;
        
        

        transform.position = Vector3.Lerp(transform.position, position, cameraSpeed * Time.deltaTime);
    }
}
