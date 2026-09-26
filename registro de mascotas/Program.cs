using System;
using System.Collections.Generic;
using System.IO;

namespace RegistroMascotas
{
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public decimal Peso { get; set; }

        public override string ToString()
        {
            string raza = Peso > 25 ? "Raza grande" : "Raza pequeña/mediana";

            return $"{Nombre} ({Especie}) - {Peso} kg - {raza}";
        }
    }

    class Program
    {
        static List<Mascota> mascotas = new List<Mascota>();
        static string archivo = "mascotas.csv";

        static void Main(string[] args)
        {
            int contador = 1;

            CargarMascotas(ref contador);

            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== REGISTRO DE MASCOTAS ===");
                Console.WriteLine("1. Agregar mascota");
                Console.WriteLine("2. Listar mascotas");
                Console.WriteLine("3. Buscar por especie");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarMascota(ref contador);
                        break;

                    case "2":
                        ListarMascotas();
                        break;

                    case "3":
                        BuscarPorEspecie();
                        break;

                    case "4":
                        GuardarMascotas();
                        Console.WriteLine("Datos guardados.");
                        break;

                    default:
                        Console.WriteLine("Opcion invalida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != "4");
        }

        static void AgregarMascota(ref int contador)
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR MASCOTA ===");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("Error: el nombre no puede estar vacio.");
                Console.ReadKey();
                return;
            }

            Console.Write("Especie: ");
            string especie = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(especie))
            {
                Console.WriteLine("Error: la especie no puede estar vacia.");
                Console.ReadKey();
                return;
            }

            Console.Write("Peso: ");
            decimal peso;

            if (!decimal.TryParse(Console.ReadLine(), out peso) || peso <= 0)
            {
                Console.WriteLine("Error: el peso debe ser un numero mayor que 0.");
                Console.ReadKey();
                return;
            }

            Mascota mascota = new Mascota();

            mascota.Id = contador;
            mascota.Nombre = nombre;
            mascota.Especie = especie;
            mascota.Peso = peso;

            mascotas.Add(mascota);
            contador++;

            Console.WriteLine("Mascota agregada correctamente.");
            Console.ReadKey();
        }

        static void ListarMascotas()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE MASCOTAS ===");

            if (mascotas.Count == 0)
            {
                Console.WriteLine("No hay mascotas registradas.");
            }
            else
            {
                for (int i = 0; i < mascotas.Count; i++)
                {
                    Console.WriteLine($"Mascota {i + 1}: {mascotas[i]}");
                }
            }

            Console.ReadKey();
        }

        static void BuscarPorEspecie()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR POR ESPECIE ===");
            Console.Write("Ingrese la especie a buscar: ");
            string busqueda = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < mascotas.Count; i++)
            {
                if (mascotas[i].Especie.ToLower().Contains(busqueda.ToLower()))
                {
                    Console.WriteLine($"Mascota {i + 1}: {mascotas[i]}");
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron mascotas.");
            }

            Console.ReadKey();
        }

        static void GuardarMascotas()
        {
            using (StreamWriter escritor = new StreamWriter(archivo))
            {
                for (int i = 0; i < mascotas.Count; i++)
                {
                    escritor.WriteLine(
                        $"{mascotas[i].Id},{mascotas[i].Nombre},{mascotas[i].Especie},{mascotas[i].Peso}"
                    );
                }
            }
        }

        static void CargarMascotas(ref int contador)
        {
            if (!File.Exists(archivo))
            {
                return;
            }

            using (StreamReader lector = new StreamReader(archivo))
            {
                string linea;

                while ((linea = lector.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length == 4)
                    {
                        int id;
                        decimal peso;

                        if (int.TryParse(datos[0], out id) &&
                            decimal.TryParse(datos[3], out peso))
                        {
                            Mascota mascota = new Mascota();

                            mascota.Id = id;
                            mascota.Nombre = datos[1];
                            mascota.Especie = datos[2];
                            mascota.Peso = peso;

                            mascotas.Add(mascota);

                            if (id >= contador)
                            {
                                contador = id + 1;
                            }
                        }
                    }
                }
            }
        }
    }
}