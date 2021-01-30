using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform whereTheKeyCyclerIs;
    [SerializeField]
    private float sensitivity = 1;
    [SerializeField]
    private float maxY = 50;
    [SerializeField]
    private float minY = -50;

    [SerializeField] GameObject player;

    private float xMove;
    private float yMove;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        print(yMove);

        if (!(yMove - Input.GetAxis("Mouse Y") * sensitivity > maxY) && !(yMove - Input.GetAxis("Mouse Y") * sensitivity < minY))
        {
            yMove -= Input.GetAxis("Mouse Y") * sensitivity;
        }
        
        xMove += Input.GetAxis("Mouse X") * sensitivity;

        transform.rotation = Quaternion.Euler(yMove, xMove, 0);

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.7f, player.transform.position.z + 0.4f);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void Interact()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.transform.GetComponent<Flip>())
            {
                hitInfo.transform.GetComponent<Flip>().DoAFlip();

                //flip noise
            }

            else if (hitInfo.transform.GetComponent<Key>())
            {
                hitInfo.transform.gameObject.SetActive(false);
                whereTheKeyCyclerIs.GetComponent<KeyCycler>().AddKey(hitInfo.transform);

                //Pickup key noise
            }

            else if (hitInfo.transform.GetComponent<Lock>())
            {
                Transform currentKey = whereTheKeyCyclerIs.GetComponent<KeyCycler>().GetEquippedKey();

                if (currentKey.GetComponent<Key>().GetID() == hitInfo.transform.GetComponent<Lock>().GetID())
                {
                    hitInfo.transform.GetComponent<Lock>().Unlock();
                    //unlock noise
                }

                else
                {
                    //wrong key noise
                }
            }
        }
    }
}
