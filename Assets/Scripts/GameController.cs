using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float scaleOfCandle = 0.5f;
    [SerializeField] float upgradeStep = 0.1f;
    float currentZPosition;

    // Start is called before the first frame update
    GameObject playerModel;
    void Awake()
    {

        playerModel = this.gameObject.transform.GetChild(2).gameObject;
        playerModel.transform.localScale = new Vector3(1f, scaleOfCandle, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        playerModel.transform.rotation = new Quaternion(0, 0, 0, 0);
        if(playerModel.transform.position == new Vector3(0, 1, currentZPosition))
        {
            this.transform.gameObject.GetComponent<CharacterController>().enabled = true;
            this.transform.gameObject.GetComponent<Movement>().enabled = true;
        }
        
    }

    public void upgradeCandle(UpgraderProperties.UpgraderTypes upgraderType, float upgraderValue)
    {
        switch (upgraderType)
        {
            case UpgraderProperties.UpgraderTypes.adder:
                scaleOfCandle += upgraderValue * upgradeStep;
                break;
            case UpgraderProperties.UpgraderTypes.multiplier:
                scaleOfCandle *= upgraderValue ;
                break;
            case UpgraderProperties.UpgraderTypes.subtractor:
                scaleOfCandle -= upgraderValue * upgradeStep;
                break;
            case UpgraderProperties.UpgraderTypes.divider:
                scaleOfCandle /= upgraderValue ;
                break;
            default:
                break;
        }
        if (scaleOfCandle > 0 && scaleOfCandle < 3)
            playerModel.transform.localScale = new Vector3(1f, scaleOfCandle, 1f);
        else
        {
            Debug.Log("Oyun bitti");
            returnBackofObjectPoint();

        }
    }

    public void returnBackofObjectPoint()
    {
        this.transform.gameObject.GetComponent<Movement>().enabled = false;
        this.transform.gameObject.GetComponent<CharacterController>().enabled = false;
        // my first try, does not work :)
        currentZPosition = this.gameObject.transform.position.z;
        if (currentZPosition - 5 > 0)
        {
            currentZPosition = currentZPosition - 5;
        } else
        {
            currentZPosition = 0;
        }
        this.gameObject.transform.position = new Vector3(0, 1f, currentZPosition);
        this.gameObject.transform.GetChild(0).position = new Vector3(0, 5, currentZPosition - 5);
        this.gameObject.transform.GetChild(1).position = new Vector3(0, 4, currentZPosition - 5.5f);
        this.gameObject.transform.GetChild(2).position = new Vector3(0, 1f, currentZPosition);
        scaleOfCandle = 0.5f;
        playerModel.transform.localScale = new Vector3(1f, scaleOfCandle, 1f);
        
    }
    public void returnBackStartPoint()
    {
        this.transform.gameObject.GetComponent<Movement>().enabled = false;
        this.transform.gameObject.GetComponent<CharacterController>().enabled = false;        
        
        currentZPosition = 0;
        this.gameObject.transform.position = new Vector3(0, 1f, currentZPosition);
        this.gameObject.transform.GetChild(0).position = new Vector3(0, 5, currentZPosition - 5);
        this.gameObject.transform.GetChild(1).position = new Vector3(0, 4, currentZPosition - 5.5f);
        this.gameObject.transform.GetChild(2).position = new Vector3(0, 1f, currentZPosition);
        scaleOfCandle = 0.5f;
        playerModel.transform.localScale = new Vector3(1f, scaleOfCandle, 1f);

    }

    public void startGameAgain()
    {
        returnBackStartPoint();
        enableAllUpgraders();
    }
    void enableAllUpgraders()
    {
        GameObject[] allUpgraderGameObjects = GameObject.FindGameObjectsWithTag("UpgraderParent");
        foreach(GameObject go in allUpgraderGameObjects)
        {
            if(go.transform.position.y < 0)
            {
                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y + 5, go.transform.position.z);
                go.transform.GetChild(0).GetComponent<UpgraderProperties>().isEffected = false;
                go.transform.GetChild(1).GetComponent<UpgraderProperties>().isEffected = false;
            }

        }
    }
}
