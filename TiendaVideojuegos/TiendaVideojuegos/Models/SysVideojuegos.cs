using TiendaVideojuegos.Enums;

namespace TiendaVideojuegos.Models
{
    public class SysVideojuegos
    {
        static List<Juego> CatalogoJuegos = new List<Juego>();
        static string archivoJuegos = "Catalogo.txt";

        public static void AgregarVideojuego()
        {
            Console.WriteLine("Ingrese el nombre del juego: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la cantidad de ejemplares: ");
            int stock;
            while (!int.TryParse(Console.ReadLine(), out stock))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido para el stock.");
            }

            Console.WriteLine("Ingrese el valor: ");
            double precio;
            while (!double.TryParse(Console.ReadLine(), out precio))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido para el precio.");
            }

            Console.WriteLine("Ingrese la plataforma del juego: ");
            TipoPlataforma plataforma;
            while (!Enum.TryParse(Console.ReadLine(), true, out plataforma))
            {
                Console.WriteLine("Plataforma invalida, ingrese una opcion correcta.");
            }

            CatalogoJuegos.Add(new Juego(nombre, stock, precio, plataforma));
            Console.WriteLine("Juego agregado al catalogo.");

        }

        public static void MostrarJuegos()
        {
            Console.WriteLine("Catalogo de juegos: ");
            foreach (var videojuegos in CatalogoJuegos)
            {
                Console.WriteLine(videojuegos);
            }
        }

        public static void GuardarVideojuego()
        {
            using (StreamWriter writer = new StreamWriter(archivoJuegos))
            {
                foreach (var videojuegos in CatalogoJuegos)
                {
                    Console.WriteLine($"{videojuegos.Nombre}, {videojuegos.Stock}, {videojuegos.Precio}, {videojuegos.Plataforma}");
                }
            }
            Console.WriteLine("Juego guardado correctamente.");
        }

        public static void CargarJuegos()
        {
            if (File.Exists(archivoJuegos))
            {
                using (StreamReader reader = new StreamReader(archivoJuegos))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        string[] datos = linea.Split('|');
                        string nombre = datos[0];
                        int stock = int.Parse(datos[1]);
                        double precio = double.Parse(datos[2]);
                        TipoPlataforma plataforma = (TipoPlataforma)Enum.Parse(typeof(TipoPlataforma), datos[3]); 

                        CatalogoJuegos.Add(new Juego(nombre, stock, precio, plataforma));
                    }
                }
                Console.WriteLine("Juegos cargados correctamente. ");
            }

        }
        public static void EliminarJuego()
        {
            Console.WriteLine("Ingrese el nombre del juego a eliminar: ");
            string nombre = Console.ReadLine();
            bool juegoEncontrado = false;
            foreach (var videojuegos in CatalogoJuegos)
            {
                if (videojuegos.Nombre == nombre )
                {
                    juegoEncontrado = true;
                    CatalogoJuegos.Remove(videojuegos);
                    Console.WriteLine($"Juego '{nombre}' eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el juego '{nombre}' en el catálogo.");
                }
            }
        }
    }
}
