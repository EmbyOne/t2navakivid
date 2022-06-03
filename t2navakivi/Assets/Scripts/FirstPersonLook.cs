using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;
    public GameObject PanelOffice;
    public GameObject PanelProduction;
    public GameObject PanelResearch;
    public GameObject PanelMarketing;
    public Button exitButtonOffice;
    public Button exitButtonProduction;
    public Button exitButtonResearch;
    public Button exitButtonMarketing;

    public bool isCanvasOpen = false;
 
    

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Button buttonOffice = exitButtonOffice.GetComponent<Button>();
        Button buttonProduction = exitButtonProduction.GetComponent<Button>();
        Button buttonResearch = exitButtonResearch.GetComponent<Button>();
        Button buttonMarketing = exitButtonMarketing.GetComponent<Button>();
        
        buttonOffice.onClick.AddListener(TaskOnClickOffice);
        buttonProduction.onClick.AddListener(TaskOnClickProduction);
        buttonResearch.onClick.AddListener(TaskOnClickResearch);
        exitButtonMarketing.onClick.AddListener(TaskOnClickMarketing);
        Cursor.lockState = CursorLockMode.Locked;
        PanelOffice.SetActive(false);
        PanelMarketing.SetActive(false);
        PanelResearch.SetActive(false);
        PanelProduction.SetActive(false);
    }

    void Update()
    {
        if (!isCanvasOpen) {
            // Get smooth velocity.
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90);

            // Rotate camera up-down and controller left-right from velocity.
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
            GameObject objectHitName = RayCastHit();
            if (objectHitName != null){
            // Debug.Log(objectHitName);
                if (Input.GetMouseButtonDown(0)){
                    if (objectHitName.name == "Office"){
                        //Debug.Log("hihihha");
                        isCanvasOpen = true;
                        OpenPanelOfficeOffice();

                    }
                    if (objectHitName.name == "Production"){
                        isCanvasOpen = true;
                        OpenPanelOfficeProduction();
                    }
                    if (objectHitName.name == "Marketing"){
                        isCanvasOpen = true;
                        OpenPanelMarketing();
                    }
                    if (objectHitName.name == "Research"){
                        isCanvasOpen = true;
                        OpenPanelResearch();
                    }
                }
                
                
            }

        }
        else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
    GameObject RayCastHit(){
        RaycastHit hit;
        if (Physics.Raycast (transform.position, transform.forward, out hit)){
            return hit.collider.gameObject;
        }
        return null;
    }
     
    
    public void OpenPanelOfficeOffice(){
        if (PanelOffice != null){
            PanelOffice.SetActive(true);
        }

    }

    public void OpenPanelOfficeProduction(){
        if (PanelProduction != null){
            PanelProduction.SetActive(true);
        }
    }

    public void OpenPanelResearch(){
        if (PanelResearch != null){
            PanelResearch.SetActive(true);
        }
    }

    public void OpenPanelMarketing(){
        if (PanelMarketing != null){
            PanelMarketing.SetActive(true);
        }
    }
    public void Screen1Exit(){
      isCanvasOpen = false;
      Cursor.lockState = CursorLockMode.Locked;
  }
  public void TaskOnClickOffice(){
      isCanvasOpen = false;
      Cursor.lockState = CursorLockMode.Locked;
      PanelOffice.SetActive(false);
  }
   public void TaskOnClickProduction(){
      isCanvasOpen = false;
      Cursor.lockState = CursorLockMode.Locked;
      PanelProduction.SetActive(false);
  }

 public void TaskOnClickResearch(){
      isCanvasOpen = false;
      Cursor.lockState = CursorLockMode.Locked;
      PanelResearch.SetActive(false);
  }

 public void TaskOnClickMarketing(){
      isCanvasOpen = false;
      Cursor.lockState = CursorLockMode.Locked;
      PanelMarketing.SetActive(false);
  }


 
}
