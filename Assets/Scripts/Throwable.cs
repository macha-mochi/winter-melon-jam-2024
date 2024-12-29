using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    private bool isPressed;
    private Rigidbody2D rb;
    public Rigidbody2D slingRb;
    private float maxDragDistance = 2f;
    public LineRenderer lr;
    public SpringJoint2D sj;
    private float minDist = 0.3f;
    private bool flung;
    public ThrowerScript thrower;
    // Start is called before the first frame update

    public float releaseDelay;

    private void Awake()
    {

    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //lr.enabled = false;
        flung = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed && !flung)
        {
            DragBall();
        }
        //Debug.Log(lr);
        //if (lr.enabled)
        //{
        //    SetLineRendererPosition();
        //}
    }

    private void DragBall() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        float distance = Vector2.Distance(mousePos, slingRb.position);

        if (distance > maxDragDistance)
        {
            Vector2 direction = (mousePos - slingRb.position).normalized;
            rb.position = slingRb.position + direction * maxDragDistance;
        }
        else {
            rb.position = mousePos;
        }
    }

    private void SetLineRendererPosition() {
        Vector3[] positions = new Vector3[2];
        positions[0] = rb.position;
        positions[1] = slingRb.position;
        lr.SetPositions(positions);
    }

    private void OnMouseDown()
    {
        //lr.enabled = true ;
        isPressed = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePos, slingRb.position);
        isPressed = false;
        rb.isKinematic = false;
        if (distance < minDist) return;
        flung = true;
        StartCoroutine(Release());
    }

    private IEnumerator Release() {
        yield return new WaitForSeconds(releaseDelay);
        sj.connectedBody = null;
        //lr.enabled = false;
        yield return new WaitForSeconds(0.3f);
        thrower.genBlock();
    }
}
