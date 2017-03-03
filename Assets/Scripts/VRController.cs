using UnityEngine;
using System.Collections;

public class VRController : MonoBehaviour {

    int buttonLayerMask;

    public Animator animator;
    public GameObject limb;

    private SteamVR_TrackedObject controller;
    private float rotationIncrement = 10.0f;

    Vector3 pivotTransVector;

    // Use this for initialization
    void Start () {

        string[] layers = { "Button" };
        buttonLayerMask = LayerMask.GetMask(layers);
        animator.speed = 0;
        if (limb == null)
            Debug.Log("Set public limb variable in vr controller!");
    }
	
	// Update is called once per frame
	void Update () {
        RayCastToButton();
        controller = GetComponent<SteamVR_TrackedObject>();
    }

    void RayCastToButton()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            SteamVR_Controller.Device input = SteamVR_Controller.Input((int)controller.index);
            if (input.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {

                string buttonName = hit.collider.gameObject.name;
                Debug.Log("Hit " + buttonName);
                if (buttonName.Equals("play_button"))
                {
                    Debug.Log("Hit play Button");
                    animator.speed = 1;

                }
                else if (buttonName.Equals("pause_button"))
                {
                    Debug.Log("Hit pause");
                    animator.speed = 0;
                }
                else if (buttonName.Equals("slow_speed_button"))
                {
                    Debug.Log("Hit pause");
                    animator.speed = 0.25f;
                }
                else if (buttonName.Equals("rotate_left_button"))
                {
                    Debug.Log("Hit rotate left");
                    Vector3 eulerAngles = limb.transform.rotation.eulerAngles;
                    limb.transform.rotation = Quaternion.AngleAxis(eulerAngles.y + rotationIncrement, Vector3.up);
                }
                else if (buttonName.Equals("rotate_right_button"))
                {
                    Debug.Log("Hit rotate right");
                    Vector3 eulerAngles = limb.transform.rotation.eulerAngles;
                    limb.transform.rotation = Quaternion.AngleAxis(eulerAngles.y - rotationIncrement, Vector3.up);
                }
            }


        }
    }
}
