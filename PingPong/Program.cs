using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;
namespace PingPong
{
    class PingPong
    {
        static void Main(string[] args)
        {
            //Se pone a correr MPI
            MPI.Environment.Run(ref args, comm =>
            {
                //Revismaos si la variable Rank es 0
                if (comm.Rank == 0)
                {
                    //Obtenemos el hostname donde esta funcionando MPI
                    Console.WriteLine("Rank 0 is alive and running on " +
                   MPI.Environment.ProcessorName);
                    //Se enviara 4 veces un mensaje
                    for (int dest = 1; dest < comm.Size; ++dest)
                    {
                        //Envío de mensaje a otro proceso
                        Console.Write("Pinging process with rank " + dest + "...");
                        comm.Send("Ping!", dest, 0);
                        //Proceso recibe e imprime el mensaje
                        string destHostname = comm.Receive<string>(dest, 1);
                        Console.WriteLine(" Pong!");
                        Console.WriteLine(" Rank " + dest + " is alive and running on " +
                        destHostname);
                    }
                }
                else
                {
                    comm.Receive<string>(0, 0);
                    comm.Send(MPI.Environment.ProcessorName, 0, 1);
                }
            });
        }
    }
}
