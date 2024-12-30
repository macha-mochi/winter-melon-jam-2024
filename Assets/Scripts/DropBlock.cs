using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlock : MonoBehaviour
{
    [SerializeField] AudioClip pop;
    [SerializeField] GameObject[] spawns;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Camera cam;
    [SerializeField] Transform heightbar;
    float r;
    float targetAngle = 0;
    [SerializeField] float delayBetweenPieces = 1f;
    GameObject currentPiece;
    public GameLevelManager gml;
    // Start is called before the first frame update
    void Start()
    {
        /*if (gml == null) { 
            genNewPiece();
        }*/ //commented out bc an extra piece was spawning
    }

    // Update is called once per frame
    void Update()
    {
        if (gml!= null && gml.gameRunning == false) {
            return;
        }
        if (currentPiece != null)
        {
            float angle = Mathf.SmoothDampAngle(currentPiece.transform.eulerAngles.z, targetAngle, ref r, 0.1f);
            currentPiece.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (currentPiece != null) {
                dropPiece();
            }

        }
        else
        {
            if (currentPiece != null) {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentPiece.transform.position = new Vector3(worldPos.x, currentPiece.transform.position.y, currentPiece.transform.position.z);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rotatePiece();
                }

                currentPiece.transform.position = Vector3.MoveTowards(currentPiece.transform.position,heightbar.position,Time.deltaTime*((spawnPoint.position.y - heightbar.position.y)/5));

                if (currentPiece.transform.position.y <= heightbar.position.y+0.05f) { 
                    dropPiece();
                }

            }
        }
    }

    void rotatePiece() {
        targetAngle += 90;
        targetAngle %= 360;
    }

    void dropPiece() {
        freezeChildRigidbodies(currentPiece, false);
        setAllChildMagnet(currentPiece, true);
        currentPiece = null;
        StartCoroutine(nextPiece());
    }

    public void genNewPiece()
    {
        AudioSource.PlayClipAtPoint(pop, transform.position, 1.0f);
        currentPiece = Instantiate(spawns[Random.Range(0, spawns.Length)], spawnPoint.position, Quaternion.identity);
        freezeChildRigidbodies(currentPiece, true);
        setAllChildMagnet(currentPiece, false);
    }
    void freezeChildRigidbodies(GameObject o, bool freeze)
    {
        Rigidbody2D[] rbs = o.GetComponentsInChildren<Rigidbody2D>();
        for (int j = 0; j < rbs.Length; j++)
        {
            if (freeze) rbs[j].constraints = RigidbodyConstraints2D.FreezeAll;
            else rbs[j].constraints = RigidbodyConstraints2D.None;
        }
    }
    void setAllChildMagnet(GameObject o, bool b)
    {
        MagnetBehaviour[] mbs = o.GetComponentsInChildren<MagnetBehaviour>();
        for (int j = 0; j < mbs.Length; j++)
        {
            mbs[j].enabled = b;
        }
    }
    private IEnumerator nextPiece()
    {
        yield return new WaitForSeconds(delayBetweenPieces);
        genNewPiece();
    }
}
