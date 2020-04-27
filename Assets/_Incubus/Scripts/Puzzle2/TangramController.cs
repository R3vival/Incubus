using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReadyToBePressed))]
public class TangramController : MonoBehaviour
{
    public Transform reticle;
    ReadyToBePressed readyToBePressed;
    private Vector3 defaultPos;
    public bool collision = false;
    public GameObject checker;
    public string nameTag;
    public int alternativeAngleCorrect = 999, alternativeAngleCorrect2 = 999;
    public PieceRotate[] pieceRotates;
    public static int piecesCompleted = 0;
    private BoxCollider myCollider;
    GameObject CubePuzzle;
    public CodeController codeController;
    public MeshRenderer[] doorToUnlock;
    public Material openedDoor;
    public Door[] door;
    public SoundsController soundsController;
    private void Start()
    {
        readyToBePressed = GetComponent<ReadyToBePressed>();
        defaultPos = transform.position;
        pieceRotates = GetComponentsInChildren<PieceRotate>();
        myCollider = GetComponent<BoxCollider>();
        CubePuzzle = transform.parent.gameObject;
    }
    private void Update()
    {
        if(readyToBePressed.IAmReadyToBePressed)
        {
            if (Input.GetKey(KeyCode.Space) || (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)))
            {
                transform.position = new Vector3(reticle.position.x, reticle.position.y, transform.position.z);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) || (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)))
        {
            if(!collision)
            {
                transform.position = defaultPos;
            }
            else
            {
                if (transform.localScale == checker.transform.localScale)
                {
                    if ((int)transform.rotation.eulerAngles.z==(int)checker.transform.rotation.eulerAngles.z || (int)transform.rotation.eulerAngles.z == alternativeAngleCorrect || (int)transform.rotation.eulerAngles.z == alternativeAngleCorrect2)
                    {        
                        transform.position = new Vector3(checker.transform.position.x, checker.transform.position.y, transform.position.z);
                        myCollider.enabled = false;
                        Destroy(checker.gameObject);

                        foreach(PieceRotate pieceRotate in pieceRotates)
                        {
                            pieceRotate.gameObject.SetActive(false);
                        }

                        if(piecesCompleted<3)
                        {
                            piecesCompleted++;
                            Debug.Log(piecesCompleted);
                        }
                        else 
                        {
                            StartCoroutine(FinishTangram());
                        }
                        this.enabled = false;
                    }
                    else
                    {
                        transform.position = defaultPos;
                    }
                }
                
            }
                
        }
    }
    IEnumerator FinishTangram()
    {
        soundsController.PlayPuzzleUnlockedSound();
        yield return new WaitForSeconds(0.5f);
        foreach (MeshRenderer mesh in doorToUnlock)
        {
            mesh.materials[1].CopyPropertiesFromMaterial(openedDoor);
        }
        foreach (Door _door in door)
            _door.Closed = false;
        yield return new WaitForSeconds(1.5f);
        codeController.SetCodeUnlocked(1, 2);
        codeController.CodeChecker();
        CubePuzzle.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {  
        if (other.gameObject.CompareTag(nameTag))
        {
            collision = true;
            checker = other.transform.gameObject;
            if (other.GetComponent<Outline>() != null)
            {
                other.GetComponent<Outline>().enabled = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Outline>() != null)
        {
            other.GetComponent<Outline>().enabled = false;
        }
        if (other.gameObject.CompareTag(nameTag))
        {
            collision = false;
            checker = null;
        }
    }
}
