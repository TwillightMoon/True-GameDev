using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private LayerMask _listOfInteractivity;


    private Camera _mainCam;
    private TacticalPoint _selectedBlock;


    private bool _isButtonClick = false;
    private int _rayDistance = 10;

    private void Awake()
    {
        UIEvents.onButtonClick.AddListener(IsButtonClick);
    }

    private void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_isButtonClick)
                _isButtonClick = false;
            else
                SelectBlock();
        }
    }


    private void SelectBlock()
    {
        if (_selectedBlock)
            _selectedBlock.OnDeselected();

        RaycastHit2D hit = Physics2D.Raycast(_mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, _rayDistance, _listOfInteractivity);
        if (hit.collider)
        {
            _selectedBlock = hit.collider.gameObject.GetComponent<TacticalPoint>();
            if (_selectedBlock)
                _selectedBlock.OnSelected();
        }
    }

    private void IsButtonClick()
    {
        _isButtonClick = true;
    }
}
