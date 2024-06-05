using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class AimStateManager : MonoBehaviour
{
    AimBaseState currentState;
    public HipFireState hip=new HipFireState();
    public  AimState aim=new AimState();
    [SerializeField] float mouseSense = 1;
    float xAxis, yAxis;
    [SerializeField] Transform camFollowPos;
    [HideInInspector] public Animator anim;
    [HideInInspector] public CinemachineVirtualCamera vCam;
    public float adsFov = 40;
    [HideInInspector] public float hipFov;
    [HideInInspector] public float currentFov;
    public float fovSmoothSpeed=10;


    public Transform aimPos;
    [HideInInspector] public Vector3 actualAimPos;
    [SerializeField] float aimSmoothSpeed=20;
    [SerializeField] LayerMask aimMask;
    void Start()
    {
        vCam= GetComponentInChildren<CinemachineVirtualCamera>();
        hipFov = vCam.m_Lens.FieldOfView;
        anim=GetComponent<Animator>();
        SwitchState(hip);
    }

  
    void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSense;
        yAxis =Mathf.Clamp(yAxis, -80, 80);
        currentState.UpdateState(this);
        vCam.m_Lens.FieldOfView=Mathf.Lerp(vCam.m_Lens.FieldOfView,currentFov,fovSmoothSpeed*Time.deltaTime);

        Vector2 screenCentre=new Vector2(Screen.width/2, Screen.height/2);
        Ray ray = Camera.main.ScreenPointToRay(screenCentre);

        if(Physics.Raycast(ray,out RaycastHit hit,Mathf.Infinity,aimMask) ) {

            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
           
        }
    }
    private void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }
    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
