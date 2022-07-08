using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;

namespace Ring
{
    class Program
    {
        static void Main(string[] args)
        {
            MPI.Environment.Run(ref args, comm =>
            {
                //se pregunta por el tamaño de comm 
                if (comm.Size < 2)
                {
                    //si el numero es menor a dos se imprime que sdebe tener al menos dos procesos
                    Console.WriteLine("The Ring example must be run with at least two processes.");
                    //opcion a ejecutar con un numero mas grande
                    Console.WriteLine("Try: mpiexec -np 4 ring.exe");
                }
                //pregunta por el numero de procesos en el rank
                else if (comm.Rank == 0)
                {
                    string data = "Hello, World!";
                    //envial el string data con el tamaño del comm
                    comm.Send(data, (comm.Rank + 1) % comm.Size, 0);
                    comm.Receive((comm.Rank + comm.Size - 1) % comm.Size, 0, out data);
                    data += " 0";
                    //imprime en pantalla el data
                    Console.WriteLine(data);
                }
                else
                {
                    //primero recive y agrega el numero para asignaro al data y enviarlo
                    String data;
                    comm.Receive((comm.Rank + comm.Size - 1) % comm.Size, 0, out data);
                    data = data + " " + comm.Rank.ToString() + ",";
                    comm.Send(data, (comm.Rank + 1) % comm.Size, 0);
                }
            });
        }
    }
}
