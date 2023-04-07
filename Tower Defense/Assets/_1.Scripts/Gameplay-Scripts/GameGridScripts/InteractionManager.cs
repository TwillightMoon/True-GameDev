using UnityEngine;
using GlobalUIEvents;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private LayerMask _listOfInteractivity;


    private Camera _mainCam;
    private IInteractable _selectedObject;

    private int _rayDistance = 10;
    private bool _isButtonClick = false; 

    private void Awake()
    {
        UIEvents.onButtonClick.AddListener(IsButtonClick);
    }

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_isButtonClick)
                _isButtonClick = false;
            else
                SelectObject();
        }
    }

    private void SelectObject()
    {
        if (_selectedObject != null)
            _selectedObject.OnDeselected();

        RaycastHit2D hit = Physics2D.Raycast(_mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, _rayDistance, _listOfInteractivity);
        if (!hit.collider) return;
        
        _selectedObject = hit.collider.gameObject.GetComponent<IInteractable>();
        if (_selectedObject != null)
            _selectedObject.OnSelected();
        
    }

    private void IsButtonClick()
    {
        _isButtonClick = true;
    }
}
