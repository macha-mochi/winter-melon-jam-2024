using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlock : MonoBehaviour
{
    [SerializeField] GameObject[] spawns;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Camera cam;

    private float delayBetweenPieces = 1f;
    GameObject currentPiece;
    // Start is called before the first frame update
    void Start()
    {
        genNewPiece();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            freezeChildRigidbodies(currentPiece, false);
            setAllChildMagnet(currentPiece, true);
            currentPiece = null;
            StartCoroutine(nextPiece());
        }
        else
        {
            Vector3 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPiece.transform.position = new Vector3(worldPos.x, currentPiece.transform.position.y, currentPiece.transform.position.z);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentPiece.transform.Rotate(new Vector3(0, 0, 90));
            }
        }
    }
    void genNewPiece()
    {
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
