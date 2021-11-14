using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    GameController gameController;
    private void Awake()
    {
        gameController = transform.parent.gameObject.GetComponent<GameController>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Upgrader")
        {
            UpgraderProperties upProp = other.gameObject.GetComponent<UpgraderProperties>();
            Debug.Log("upgraderType: " + upProp.upgraderType);
            //Debug.Log("upgraderValue: " + upProp.upgraderValue);
            //Debug.Log("other.tag: " + other.tag);
            if (!upProp.isEffected)
            {
                upProp.isEffected = true;
                GameObject thisObject = other.gameObject;
                GameObject parentOfObject = thisObject.transform.parent.gameObject;
                parentOfObject.transform.position = new Vector3(parentOfObject.transform.position.x, parentOfObject.transform.position.y-5, parentOfObject.transform.position.z);
                gameController.upgradeCandle(upProp.upgraderType, upProp.upgraderValue);
            }
        }
        if (other.tag == "DropCollider")
        {
           gameController.returnBackofObjectPoint();
        }
        if (other.tag == "GameRestarter")
        {
            gameController.startGameAgain();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // Do nothing
    }
    private void OnTriggerExit(Collider other)
    {
        // Do nothing
    }
}
