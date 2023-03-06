namespace Estacionamento
{
    public class Ticket
    {
        public DateTime Entrada {get; set;}
        public DateTime Saida {get; set;}
        public bool Ativo {get; set;}

        public Ticket()
        {
            Entrada = DateTime.Now;
            Ativo = true;
        }
        
        public double CalcularTempo()
        {
            var tempo = Saida - Entrada;
            return tempo.TotalMinutes;
        }

        public double CalcularValor()
        {
            return CalcularTempo() * 0.09;
        }

        public void FecharTicket() {
            Saida = DateTime.Now;
            Ativo = false;
            Console.WriteLine($"O veículo ficou {CalcularTempo()} minutos\nO valor cobrado será de R$ {CalcularValor}");
        }
    }
}