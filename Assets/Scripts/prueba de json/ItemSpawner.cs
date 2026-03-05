using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform contenedor;

    public GameObject circuloPrefab;
    public GameObject cuadradoPrefab;
    public GameObject cilindroPrefab;

    public Transform contenedor3D; 
    public float espacioEntreObjetos = 3.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        TextAsset jsonFile = Resources.Load<TextAsset>("items");
        if(jsonFile == null)
        {
            Debug.LogError("No se encontró el archivo JSON");
            return;
        }

        ItemList lista = JsonUtility.FromJson<ItemList>(jsonFile.text);

        int index = 0;

        foreach (Item item in lista.items)
        {
            GameObject nuevoItem = Instantiate(itemPrefab, contenedor);
            nuevoItem.GetComponent<ItemView>().Configurar(item);

            for (int i = 0; i < item.cantidad; i++)
            {
                GameObject modelo = ObtenerPrefab(item.tipo);
                if (modelo == null) continue;
                GameObject nuevoModelo = Instantiate(modelo, contenedor3D);

                nuevoModelo.transform.localScale = Vector3.one * item.tamaño;

                nuevoModelo.transform.localPosition = 
                    new Vector3(index * espacioEntreObjetos, 0, 0);

                Renderer renderer = nuevoModelo.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Color nuevoColor;
                    if (ColorUtility.TryParseHtmlString(item.color, out nuevoColor))
                    {
                        renderer.material.color = nuevoColor;
                    }
                }
                index++;
            }

        }
    }
    GameObject ObtenerPrefab(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "circulo": return circuloPrefab;
            case "cuadrado": return cuadradoPrefab;
            case "cilindro": return cilindroPrefab;
            default: return null;
        }
    }
}
