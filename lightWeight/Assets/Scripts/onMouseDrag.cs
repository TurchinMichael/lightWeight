using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class onMouseDrag : MonoBehaviour {
    public float distance = 1f;

    public void OnMouseDrag()
    {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance/*Camera.main.gameObject.transform.localPosition.z*/);

            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
    public void OnMouseUp()
    {
        this.GetComponent<onMouseDrag>().enabled = false;
    }
}
