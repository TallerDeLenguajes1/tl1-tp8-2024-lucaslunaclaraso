
using System;
using Tarea;
Tareas nTarea = new Tareas();

List<Tareas> tareasPendientes = new List<Tareas>();
List<Tareas> tareasRealizadas = new List<Tareas>();




// Número de tareas a generar
int n = 20; // Puedes cambiar este valor según tus necesidades

// Generar la lista de tareas
tareasPendientes = GenerarTareasPendientes(n);

// Mostrar las tareas generadas
foreach (var tarea in tareasPendientes)
{
    Console.WriteLine($"ID: {tarea.Id}, Descripción: {tarea.Descripcion}, Duracion: {tarea.Duracion}");
}


MostrarMenu();




void MostrarMenu()
{
    while (true)
    {
        Console.WriteLine("\nMenú:");
        Console.WriteLine("1. Ver tareas pendientes");
        Console.WriteLine("2. Ver tareas realizadas");
        Console.WriteLine("3. Mover tarea a realizadas");
        Console.WriteLine("4. Buscar tarea pendiente por descripción");
        Console.WriteLine("5. Salir");
        Console.Write("Selecciona una opción: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                VerTareas(tareasPendientes, "pendientes");
                break;
            case "2":
                VerTareas(tareasRealizadas, "realizadas");
                break;
            case "3":
                MoverTareaARealizadas();
                break;
            case "4":
                BuscarTareaPorDescripcion();
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                break;
        }
    }
}

    void VerTareas(List<Tareas> tareas, string tipo)
    {
        Console.WriteLine($"\nTareas {tipo}:");
        if (tareas.Count == 0)
        {
            Console.WriteLine($"No hay tareas {tipo}.");
        }
        else
        {
            foreach (var tarea in tareas)
            {
                Console.WriteLine($"ID: {tarea.Id}, Descripción: {tarea.Descripcion}, Duración: {tarea.Duracion} minutos");
            }
        }
    }



    List<Tareas> GenerarTareasPendientes(int n)
    {
        List<Tareas> tareas = new List<Tareas>();
        Random random = new Random();

        for (int i = 1; i <= n; i++)
        {
            Tareas tarea = new Tareas
            {
                Id = i,
                Descripcion = $"Tarea {i}",
                Duracion = random.Next(10, 101) // Generar una fecha aleatoria en los próximos 30 días
            };

            tareas.Add(tarea);
        }

        return tareas;
    }



    void MoverTareaARealizadas()
    {
        Console.Write("Ingresa el ID de la tarea que deseas mover a realizadas: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Tareas tarea = tareasPendientes.Find(t => t.Id == id);
            if (tarea != null)
            {
                tareasPendientes.Remove(tarea);
                tareasRealizadas.Add(tarea);
                Console.WriteLine($"Tarea {id} movida a realizadas.");
            }
            else
            {
                Console.WriteLine("Tarea no encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID no válido.");
        }
    }



    void BuscarTareaPorDescripcion()
    {
        Console.Write("Ingresa la descripción o parte de la descripción de la tarea a buscar: ");
        string descripcion = Console.ReadLine();

        var tareasEncontradas = tareasPendientes
            .Where(t => t.Descripcion.IndexOf(descripcion, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();

        if (tareasEncontradas.Count > 0)
        {
            Console.WriteLine("\nTareas encontradas:");
            foreach (var tarea in tareasEncontradas)
            {
                Console.WriteLine($"ID: {tarea.Id}, Descripción: {tarea.Descripcion}, Duración: {tarea.Duracion} minutos");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron tareas con esa descripción.");
        }
    }


