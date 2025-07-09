var predio = new Predio();
var controlador = new Controlador();

var andarUm = new Andar {
    Numeracao = 1,
};
predio.Andares.Add(andarUm);
var painelUm = new PainelSimples(controlador, andarUm);
andarUm.Painel = painelUm;

var andarDois = new Andar {
    Numeracao = 2,
};
predio.Andares.Add(andarDois);
var painelDois = new PainelSimples(controlador, andarDois);
andarDois.Painel = painelDois;


painelDois.Apertar("chamar");

public interface IPainel
{
    void Apertar(string botao);
}

public class PainelSimples(Controlador controlador, Andar andar) : IPainel
{
    public void Apertar(string botao)
    {
        if (botao == "chamar")
        {
            controlador.Pedidos.Add(new Pedido {
                Andar = andar,
                Elevador = null,
                Tag = "chamar"
            });
        }
    }
}

public interface IAlgoritmo
{
    Dictionary<Elevador, Andar> CalcularRota(
        List<Pedido> pedidos,
        Predio predio
    );
}

public class Andar
{
    public int Numeracao { get; set; }
    public IPainel Painel { get; set; }
}

public class Pedido
{
    public Andar? Andar { get; set; }
    public Elevador? Elevador { get; set; }
    public string Tag { get; set; }
}

public class Controlador
{
    public Predio Predio { get; set; }
    public List<Pedido> Pedidos { get; set; } = [];
    public IAlgoritmo Algoritmo { get; set; }

    public void Solicitar(Pedido pedido)
    {
        Pedidos.Add(pedido);

        var rotas = Algoritmo.CalcularRota(Pedidos, Predio);
        foreach (var (elevador, andar) in rotas)
        {
            elevador.MovimentarPara(andar);
        }
    }
}

public class Predio
{
    public List<Andar> Andares { get; set; } = [];
    public List<Elevador> Elevadores { get; set; } = [];
}

public class Elevador
{
    Queue<Andar> proximos = [];
    public Andar Andar { get; set; }
    public int Capacidade { get; set; }
    public IPainel Painel { get; set; }
    public Controlador Controlador { get; set; }

    public bool MovimentarPara(Andar alvo)
    {
        proximos.Enqueue(alvo);
        return true;
    }
}