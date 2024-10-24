using TiendaVideojuegos.Models;

class Program
{
    static void Main()
    {
        SysVideojuegos.CargarJuegos();

        int opcion;

        do
        {
            Console.WriteLine("\n ===== Menú =====\n" +
                "1. Agregar Juego\n" +
                "2. Mostrar Catalogo\n" +
                "3. Actualizar juego\n" +
                "4. Eliminar videojuego\n" +
                "5. Guardar y salir...");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    SysVideojuegos.AgregarVideojuego();
                    break;
                case 2:
                    SysVideojuegos.MostrarJuegos();
                    break;
                case 3:
                    SysVideojuegos.CargarJuegos();
                    break;
                case 4:
                    SysVideojuegos.EliminarJuego();
                    break;
                case 5:
                    SysVideojuegos.GuardarVideojuego();
                    break;
            }

        } while (opcion != 5);
    }
}