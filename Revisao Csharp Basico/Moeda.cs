while (true)
{
    Mundo.Rodada();
}

public static class Mundo
{
    public static List<IPessoa> Pessoas { get; set; } = [];

    public static void Rodada()
    {
        Maquina.Interacao(Pessoas[0], Pessoas[1]);
    }
}

public static class Maquina
{
    public static void Interacao(IPessoa pessoa1, IPessoa pessoa2)
    {
        var colaborou1 = pessoa1.Colaborar();
        var colaborou2 = pessoa2.Colaborar();
        if (colaborou1 && !colaborou2)
            pessoa1.FoiTrapaceado();
        
        if (colaborou2 && !colaborou1)
            pessoa2.FoiTrapaceado();
    }
}

public interface IPessoa
{
    bool Colaborar();

    void FoiTrapaceado();
}

public class Rabugento : IPessoa
{
    bool estaColaborando = true;
    public bool Colaborar()
        => estaColaborando;
    public void FoiTrapaceado()
        => estaColaborando = false;
}