using UnityEngine;
using TMPro;

public class ItemView : MonoBehaviour
{
    public TextMeshProUGUI nombreText;
    public void Configurar(Item item)
    {
        nombreText.text = item.nombre;
    }


}
