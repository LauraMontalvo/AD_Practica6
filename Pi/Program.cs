using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;


namespace Pi
{
	class Program
	{
		static void Main(string[] args)
		{
			//Numero de procesos 
			int dartsPerProcessor = 10000000;
			MPI.Environment.Run(ref args, comm =>
			{
				if (args.Length > 0)
					//Convierte ese argumento en un Entero.
					dartsPerProcessor = Convert.ToInt32(args[0]);
				Random random = new Random(5 * comm.Rank);
				//Se declara el valor alrededor del circulo
				int dartsInCircle = 0;
				for (int i = 0; i < dartsPerProcessor; ++i)
				{
					
					double x = (random.NextDouble() - 0.5) * 2;
					double y = (random.NextDouble() - 0.5) * 2;
					//Se incrementa el valor de los dardos a lanzar
					if (x * x + y * y <= 1.0)
						++dartsInCircle;
				}
				//Se reduce esos valores de los circulos.
				int totalDartsInCircle = comm.Reduce(dartsInCircle, Operation<int>.Add, 0);
				if (comm.Rank == 0)
				{
					//Se imprime el valor aproximado de PI
					Console.WriteLine("Pi is approximately {0:F15}.",
					4.0 * totalDartsInCircle / (comm.Size * dartsPerProcessor));
				}
			});

		}
	}
}
