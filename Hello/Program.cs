using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPI;

// *******************************************************************************************************************************************
// Practica 05
// Javier Andrade, Laura Montalvo
// Fecha de realización: 17/06/2022
// Fecha de entrega: 01/07/2022
// ********************************************************************************************************************************************
// Resultados:

//1. Ejemplo básico de uso de MPI
//El programa HELLO se ejecuto, donde se probó con valores de 4, 8 y 16 procesos y se aseguró de que 
//los procesos se ejecutaran de 0 a n-1 en el número total de procesos y que los procesos
//no se ejecutaran en secuencia por ende el resultado será diferente porque es aleatorio.

//**********************************************************************************************************************************************
// 2. CÁLCULO DE PI
// Se pudo confirmar que  el valor de pi cambia cuando se ejecuta utilizando múltiples valores de n, y que el tiempo de ejecución
//aumenta a medida que aumenta el valor de n. Finalmente se utilizó un valor de n = 290 y el resultado fue 5,78458.
//Esto es diferente de PI porque el valor de n era tan grande que el programa no podía ejecutarse correctamente.
//**********************************************************************************************************************************************
// 3. PING PONG
// el proceso denominado de Ping-Pong donde por medio de un rango k realizaba el paso del mensaje (Ping) hacia el otro proceso que
// tendría un rango k+1 devolviendo la respuesta al proceso primario (Pong), Este mecanismo se repetía indefinidamente dependiendo
// del valor que se le aaigne a n  en el comando mpi de consola.

//*************************************************************************************************************************************************
// 4. RING
//El programa RING se ejecuta con el comando mpiexec-np1 Ring.exe, por lo que ejecutarlo con el comando mpiexec -np produce un 
//error y requiere al menos dos procesos para ejecutar el ejemplo RUN, al ejecutar con el comando  mpiexec -np 4 Ring.exe el progrma,
//luego de que se ejecuta el programa y se muestra el mensaje Hello Word, se muestran los números del 1 al n-1. Donde n es el valor
//ingresado en el comando a ejecutar,incluyendo el último cero separado por comas ,al aumentar el valor simplemente se despliegan
//mas numeros hasta el valor de n-1.

// ***********************************************************************************************************************************************

// Conclusiones:
//MPI le permite iniciar, administrar y completar varios procesos. Por esta razón, MPI le permite implementar tantos 
//procesos secuenciales como sea posible que realicen actividades programadas.Además como se pudo 
// apreciar, MPI permite realizar la gestión del orden de ejecución de los procesos, esto con la finalidad de lograr un mejor resultado
// al mandar a correr los distintos códigos. 

//*MPI resulta ser una técnica de uso común en la programación concurrente porque proporciona sincronización 
//entre procesos y permite la exclusión mutua.Además, los programas desarrollados con MPI tienen muchas opciones
//de comunicación punto a punto y son  grandes en multiproceso.

//*Se observó el comportamiento del programa PingPong a través de una aplicación de consola de Windows, 
//con una observación detallada del proceso de transferencia de mensajes entre procesos.Se definio una secuencia 
//procesos que reenvían un mensaje llamado Ping-Pong a través del randgos enumerado.

//En el programa PI, encontramos que si aumentamos el número de n a un valor superior a 290, 
//el rank permite que se ejecute cada proceso, y si el valor era grande, el resultado que mostraría el programa 
//sería diferente del valor PI, por ende al ser un valor grande estos procesos llevarán demasiado tiempo.


// *******************************************************

// Recomendaciones:
// *Al momento de ejecutar cada uno de los proyectos en Visual se recomienda utilizar las teclas Ctrl+F5 
//  dado que al momento de precionar el boton inicio el programa se ejecuta pero no se puede observar resultados
//  ya que la consola se cierra rapidamente.
// *Es recomendable instalar en todas los proyectos la biblioteca de MPI.NET para poder usar sus funciones
//  ya que sin eso no se podra ejecutar los programas y nos saldra error de compilacion.

namespace Hello
{
	class Program
	{
		static void Main(string[] args)
		{
			using (new MPI.Environment(ref args))
			{
				//Se imprime un saludo con el numero de proceso y el rank.
				Console.WriteLine("Hello, from process number "
				+ Communicator.world.Rank + " of "
			   + Communicator.world.Size);

			}
		}
	}
}
