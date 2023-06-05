using UnityEngine;
using GlobalUIEvents;

/** Пространство имён, содержащее классы-менеджеры. */
namespace Managers
{
    /** Класс-менеджер, отслеживающий действия игрока. */
    public class InteractionManager : Singleton<InteractionManager>
    {
        private Camera _mainCam; /**< Camera variable. Компонент камеры. */

        [SerializeField]
        private LayerMask _listOfInteractivity; /**< LayerMask variable. Список определяющий слои, с которыми может интерактировать игрок. */ 

        private IInteractable _selectedObject; /**< IInteractable variable. Текущий выделенный объект. */

        private int _rayDistance = 10; /**< Integer variable. Длина выпускаемого луча. */
        private bool _isButtonClick = false; /**< Bool variable. Флаг, указывающий, что тап был произведен по кнопке */

        private void Awake()
        {
            UIEvents.onButtonClick.AddListener(IsButtonClick);
        }

        private void Start()
        {
            _mainCam = Camera.main;
        }

        /** Метод, отслеживающий действия игрока каждый кадр*/
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

        /** Метод выделения объекта */
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

        /** Метод изменения флага _isButtonClick */
        private void IsButtonClick()
        {
            _isButtonClick = true;
        }
    }
}

