using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    #region Events

    public static UnityAction OnTouchpadUp = null;
    public static UnityAction OnTouchpadDown = null;
    public static UnityAction OnTriggerDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null;

    #endregion

    #region Anchors

    public GameObject m_LeftAnchor;
    public GameObject m_RightAnchor;
    public GameObject m_HeadAnchor;

    #endregion

    #region Inputs

    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    private OVRInput.Controller m_InputSource = OVRInput.Controller.None;
    private OVRInput.Controller m_Controller = OVRInput.Controller.None;
    private bool m_InputActive = true;

    #endregion

    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        m_ControllerSets = CreateControllerSets();
    }
    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;
    }
    private void Update()
    {
        if (!m_InputActive)
            return;
        CheckForController();

        CheckInputSource();
        _Input();
    }

    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = m_Controller;

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.RTrackedRemote;

        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.LTrackedRemote;

        if (!OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote)
             && !OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.Touchpad;
        m_Controller = UpdateSource(controllerCheck, m_Controller);
    }

    private void CheckInputSource()
    {
        m_InputSource = UpdateSource(OVRInput.GetActiveController(), m_InputSource);
    }

    private void _Input()
    {
        //Touchpad Up
        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad) || (Input.GetKeyUp(KeyCode.Space)))
        {
            if (OnTouchpadUp != null)
                OnTouchpadUp();
        }
        //Touchpad Down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)) 
        {
            if (OnTouchpadDown != null)
                OnTouchpadDown();
        }
        //Controller Trigger
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || (Input.GetKeyDown(KeyCode.Space)))
            if (OnTriggerDown != null)
                OnTriggerDown();
    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous)
    {
        // Si los valores sin iguales, return
        if (check == previous)
            return previous;

        //Obtiene el controller
        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);

        //Si no existe control, aplicarlo al headset
        if (controllerObject == null)
            controllerObject = m_HeadAnchor;

        if (OnControllerSource != null)
            OnControllerSource(check,controllerObject);

        return check;
    }

    private void PlayerFound()
    {

    }

    private void PlayerLost()
    {

    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            {OVRInput.Controller.LTrackedRemote, m_LeftAnchor},
            {OVRInput.Controller.RTrackedRemote, m_RightAnchor},
            {OVRInput.Controller.Touchpad, m_HeadAnchor}
        };
        return newSets;
    }
}
