using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

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

    // FMOD
    [EventRef] private string ePickUpKey = "{c9d462fa-1f97-417e-ab0c-55a19477b52d}";
    [EventRef] private string eUnlockDoor = "{040935d6-dcf6-4a57-9877-08913652e1bb}";
    [EventRef] private string eLockedDoor = "{ca98f70c-e3db-4e78-9e32-dd7349aefd23}";

    void FixedUpdate()
    {
        if (!(yMove - Input.GetAxis("Mouse Y") * sensitivity > maxY) && !(yMove - Input.GetAxis("Mouse Y") * sensitivity < minY))
        {
            yMove -= Input.GetAxis("Mouse Y") * sensitivity;
        }
        
        xMove += Input.GetAxis("Mouse X") * sensitivity;

        transform.rotation = Quaternion.Euler(yMove, xMove, 0);

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.7f, player.transform.position.z);

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
            }

            else if (hitInfo.transform.GetComponent<Key>())
            {
                hitInfo.transform.gameObject.SetActive(false);
                whereTheKeyCyclerIs.GetComponent<KeyCycler>().AddKey(hitInfo.transform);

                // Pickup key SFX
                RuntimeManager.PlayOneShot(ePickUpKey);
            }

            else if (hitInfo.transform.GetComponent<Lock>())
            {
                Transform currentKey = whereTheKeyCyclerIs.GetComponent<KeyCycler>().GetEquippedKey();

                if (currentKey.GetComponent<Key>().GetID() == hitInfo.transform.GetComponent<Lock>().GetID())
                {
                    hitInfo.transform.GetComponent<Lock>().Unlock();

                    // Unlock Door SFX
                    RuntimeManager.PlayOneShot(eUnlockDoor, hitInfo.transform.position);
                }

                else
                {
                    Debug.Log("locked");
                    // Locked Door SFX
                    RuntimeManager.PlayOneShot(eLockedDoor, hitInfo.transform.position);
                }
            }
        }
    }
}
