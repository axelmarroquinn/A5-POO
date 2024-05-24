using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TiposPersonalizados
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public Guid CodigoEmpleado { get; set; }
        public string FechaInicio { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal DescuentosMensuales { get; set; } // de esta manera debería ser private. 
        public int HorasExtras { get; set; } // get set es la creación de esos elementos de manera interna.
        
        public readonly decimal Bono;

        private decimal MontoHorasExtras;

        private decimal TotalIngresos;

        // al typear ctor, se genera el constructor vacío.

        public Empleado(string nombre, Guid codigoEmpleado, string fechaInicio, decimal salarioBase, int horasExtras, decimal descuentosMensuales, decimal bono = 250) // constructor declarado.
        {
            Nombre = nombre;
            CodigoEmpleado = codigoEmpleado;
            FechaInicio = fechaInicio;
            SalarioBase = salarioBase;
            DescuentosMensuales = descuentosMensuales;
            HorasExtras = horasExtras;

            this.MontoHorasExtras = SetMontoHorasExtras();
            this.TotalIngresos = SetTotalIngresos();
        }

        private decimal GetSalarioHora() // función porque retorna un elemento.
        {
            decimal salarioHora = this.SalarioBase / 22 / 8;
            return salarioHora;
        }

        private decimal SetMontoHorasExtras() 
        {
            return this.GetSalarioHora() * (decimal)1.5 * HorasExtras;
        }

        public decimal GetMontoHorasExtras()
        {
            return this.MontoHorasExtras;
        }

        private decimal SetTotalIngresos()
        {
            return SalarioBase + Bono + SetMontoHorasExtras();
        }

        public decimal GetTotalIngresos() 
        {
            this.TotalIngresos = this.SetTotalIngresos();
            return this.TotalIngresos; 
        }

        // ** INFORMACIÓN GENERAL **
        // get es lo que el usuario necesita saberlo. set es porque se hará privado.
        // privado es para calcular, publico es para mostrar.

        private decimal CalculoCuotaIGSS() 
        {
            decimal cuota = SalarioBase * (decimal)0.0483;
            return cuota;
        }

        private decimal SetTotalEgresos()
        {
            return this.DescuentosMensuales + this.CalculoCuotaIGSS();
        }

        public decimal GetTotalEgresos()
        {
            return this.SetTotalEgresos();
        }

        public decimal GetSalarioFinal()
        {
            return this.SetTotalIngresos() - this.SetTotalEgresos();
        }

        public override string ToString()
        {
            return $"\nNombre: {Nombre}\n" +
                $"Codigo Empleado: {CodigoEmpleado}\n" +
                $"Fecha de Inicio: {FechaInicio}\n" +
                $"Horas Extras: {HorasExtras} - Monto Horas Extras: Q {GetMontoHorasExtras():N2}\n" +
                $"Descuentos Totales: {GetTotalEgresos():N2}\n" +
                $"Ingresos Totales: {GetTotalIngresos():N2}\n" +
                $"Salario Final: {GetSalarioFinal():N2}";
        }
    }
}