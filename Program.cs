// See https://aka.ms/new-console-template for more information
using System.Collections;
using Newtonsoft.Json;
//TipoDatos();
//Arreglos();
//InvertirPalabra();
// LoadJson();
// RepetidoActividad();
// Contar();
NoRepetidos();

void NoRepetidos()
{
    string[] palabras = { "Hola", "Casa", "Hola", "Perro", "Casa", "Hola", "Casa", "Hola", "Gato", "Perro" };
    //Conjunto que no tiene elementos repetidos
    var noRepetidos = palabras.ToHashSet().ToList(); //se creo el array sin repetidos
    foreach (var item in noRepetidos)
        Console.WriteLine($"{item}");
}

void Contar()
{
    string[] palabras = { "Hola", "Casa", "Hola", "Perro", "Casa", "Hola", "Casa", "Hola", "Gato", "Perro" };
    Dictionary<string, int> dic = new Dictionary<string, int>();
    foreach (var palabra in palabras)
        if (dic.Keys.Contains(palabra))
            dic[palabra] += 1;
        else
            dic.Add(palabra, 1);

    foreach (var item in dic)
    {
        Console.WriteLine($"Llave: {item.Key} Valor: {item.Value}");
    }
}

void RepetidoActividad()
{
    string[] palabras = { "Hola", "Casa", "Hola", "Perro", "Casa", "Hola", "Casa", "Hola", "Gato", "Perro" };

    string[] palabra = new string[palabras.Length];
    int[] numero = new int[palabras.Length];

    for (int i = 0; i < numero.Length; i++)
    {
        numero[i] = 0;
    }

    palabra[0] = palabras[0];

    for (int j = 1; j < palabras.Length; j++)
    {
        for (int k = 0; k < palabra.Length; k++)
        {
            if (palabras[j] == palabra[k])
            {
                numero[k] += 1;
            }
            else
            {
                palabra[k] = palabras[j];
            }
        }

    }

    for (int k = 0; k < palabra.Length; k++)
    {
        Console.WriteLine($"Palabra: {palabra[k]}; cantidad: {numero[k]}");
    }

}

void LoadJson()
{
    using (StreamReader r = new StreamReader("customers.json"))
    {
        string json = r.ReadToEnd();
        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
        //var resp1 = customers.Find(it => it.city == "London");
        var resp2 = customers.FindAll(it => it.city == "London");
        //var resp3 = customers.FindAll(it => it.companyName.StartsWith("P"));
        //Console.WriteLine($"Tipo de resp es: {resp.GetType()}");
        // MostrarEmpresa(resp);
        ListarEmpresas(resp2);
        //ListarEmpresa(resp1);
    }
}

void ListarEmpresa(Customer customer)
{
    Console.WriteLine($"Empresa:     {customer.companyName}");
    Console.WriteLine($"Contacto:    {customer.contactName}");
    Console.WriteLine($"Dirección:   {customer.address}");
    Console.WriteLine($"Ciudad:      {customer.city}");
    Console.WriteLine($"País:        {customer.country}");

}
void ListarEmpresas(List<Customer> customers)
{
    foreach (var customer in customers)
    {
        Console.WriteLine($"Empresa:     {customer.companyName}");
        Console.WriteLine($"Contacto:    {customer.contactName}");
        Console.WriteLine($"Dirección:   {customer.address}");
        Console.WriteLine($"Ciudad:      {customer.city}");
        Console.WriteLine($"País:        {customer.country}");
        Console.WriteLine("-------------------------------------");
    }
}

void Arreglos()
{
    ushort size = 10;
    char[] vocales = { 'a', 'e', 'i', 'o', 'u' };
    char[] consonantes = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
    int[] digitos = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    var alfabeto = vocales.Union(consonantes).ToArray();
    string palabra = "";
    for (ushort i = 0; i < size; i++)
    {
        bool letra = new Random().Next(0, 100) <= 50 ? true : false;
        if (letra)
        {
            int k = new Random().Next(0, alfabeto.Length - 1);
            bool lower = new Random().Next(0, 100) <= 50 ? true : false;
            palabra += lower ? alfabeto[k] : alfabeto[k].ToString().ToUpper();
        }
        else
        {
            int k = new Random().Next(0, digitos.Length - 1);
            palabra += digitos[k];
        }
    }
    Console.WriteLine($"La palabra generada es: {palabra}");

    ArrayList caracteres = new ArrayList();
    caracteres.Add(vocales);
    caracteres.Add(consonantes);
    caracteres.Add(alfabeto);
    caracteres.Add(digitos);
    foreach (var item in caracteres)
    {
        Console.WriteLine($"valor: {item}");
    }


}
void InvertirPalabra()
{
    Console.WriteLine("Ingrese la palabra a invertir");
    string? palabra = Console.ReadLine();
    if (palabra is not null)
    {
        var vpalabra = palabra.ToCharArray();
        for (ushort i = 0; i < vpalabra.Length; i++)
        {
            Console.WriteLine($"letra[{i}] --> {vpalabra[i]}");
        }
    }
}
void TipoDatos()
{
    ushort minUShort = ushort.MinValue;
    ushort maxUShort = ushort.MaxValue;
    Console.WriteLine($"Rango ushort [{minUShort} {maxUShort}]");
    short minShort = short.MinValue;
    short maxShort = short.MaxValue;
    Console.WriteLine($"Rango short [{minShort} {maxShort}]");
    ulong minLong = ulong.MinValue;
    ulong maxLong = ulong.MaxValue;
    Console.WriteLine($"Rango ushort [{minLong} {maxLong}]");

}


public class Customer
{
    public string id { get; set; }
    public string companyName { get; set; }
    public string contactName { get; set; }
    public string contactTitle { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string postalCode { get; set; }
    public string country { get; set; }
    public string phone { get; set; }
    public string fax { get; set; }
}