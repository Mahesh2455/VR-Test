using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _gameMenu;
    [SerializeField] InputActionProperty _menuButton;
    [SerializeField] Transform _head;
    float spawnDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        _menuButton.action.performed += DisplayMenu;
    }

    void OnDisable()
    {
         _menuButton.action.performed -= DisplayMenu;
    }

    private void DisplayMenu(InputAction.CallbackContext obj)
    {
        _gameMenu.SetActive(!_gameMenu.activeSelf);
        _gameMenu.transform.position = _head.position + new Vector3(_head.transform.forward.x,0 , _head.transform.forward.z).normalized * spawnDistance;
    }

    // Update is called once per frame
    void Update()
    {
        _gameMenu.transform.LookAt(new Vector3(_head.position.x, _gameMenu.transform.position.y,_head.position.z));
        _gameMenu.transform.forward *= -1;
    }
}
