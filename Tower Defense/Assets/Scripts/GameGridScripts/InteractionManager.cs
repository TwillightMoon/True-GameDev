using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private LayerMask _listOfInteractivity;


    private Camera _mainCam;
    private DefensivePosition _selectedBlock;
    private int _rayDistance = 10;


    void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_selectedBlock)
            {
                _selectedBlock.OnUnSelected();
            }

            RaycastHit2D hit = Physics2D.Raycast(_mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, _rayDistance, _listOfInteractivity);
            Debug.Log(hit.collider);
            if (hit.collider)
            {
                _selectedBlock = hit.collider.gameObject.GetComponent<DefensivePosition>();
                if (_selectedBlock)
                {
                    _selectedBlock.OnSelected();
                }
            }
        }
    }
}
