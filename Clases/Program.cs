using static System.Console;
using TiposPersonalizados;
namespace Clases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre, fechaInicio;
            decimal salarioBase, descuentosMensuales;
            int horasExtras;
            Guid codigoEmpleado;

            nombre = "Carlos Interiano";
            fechaInicio = "15/01/2022";
            salarioBase = 5000;
            descuentosMensuales = 350;
            horasExtras = 10;
            codigoEmpleado = Guid.NewGuid();

            Empleado empleado = new Empleado(nombre, codigoEmpleado, fechaInicio, salarioBase, horasExtras, descuentosMensuales);

            WriteLine(empleado.ToString());

            WriteLine("INFORMACIÓN DEL EMPLEADO");
            WriteLine($"Nombre: {empleado.Nombre}");
            WriteLine($"Fecha de Inicio: {empleado.FechaInicio}");
            WriteLine ($"Horas Extras: {empleado.HorasExtras} - Monto Horas Extras: Q {empleado.GetMontoHorasExtras():N2}");
            WriteLine($"Descuentos Totales: {empleado.GetTotalEgresos():N2}");
            WriteLine($"Salario Final: {empleado.GetSalarioFinal():N2}");
            WriteLine($"Ingresos Totales: {empleado.GetTotalIngresos():N2}");

            WriteLine(empleado); // imprime la misma información, pero con el tostring en el override de empleado.cs.
        }
    }
}