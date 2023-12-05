using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Transform _mainCase;
    [SerializeField] private int _caseIndex;
    [SerializeField] private Material _whiteMaterial;
    [SerializeField] private Material _darkMaterial;

    private Transform _currentCase;

    private void Awake()
    {
        _currentCase = _mainCase.GetChild(_caseIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ContactCube>())
        {
            var firstValue = int.Parse(_currentCase.GetChild(0).name);
            var secondValue = int.Parse(_currentCase.GetChild(1).name);

            if (_mainCase.GetComponent<OR>())
            {
                collision.gameObject.GetComponent<MeshRenderer>().materials[0].color = 
                    firstValue + secondValue >= 1 
                    ? _whiteMaterial.color 
                    : _darkMaterial.color;

                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }


            if (_mainCase.GetComponent<AND>())
            {
                collision.gameObject.GetComponent<MeshRenderer>().materials[0].color =
                    firstValue * secondValue == 1
                    ? _whiteMaterial.color
                    : _darkMaterial.color;

                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

            if (_mainCase.GetComponent<NAND>())
            {
                collision.gameObject.GetComponent<MeshRenderer>().materials[0].color =
                    firstValue * secondValue == 1
                    ? _darkMaterial.color
                    : _whiteMaterial.color;

                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }


            if (_mainCase.GetComponent<XOR>())
            {
                collision.gameObject.GetComponent<MeshRenderer>().materials[0].color =
                    firstValue == secondValue
                    ? _darkMaterial.color
                    : _whiteMaterial.color;

                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
