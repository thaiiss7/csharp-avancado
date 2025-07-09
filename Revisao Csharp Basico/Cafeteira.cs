var maquina = new Maquina();
maquina.Compartimentos.Add(new Compartimento {
    Ingrediente = Ingrediente.Agua
});
maquina.Compartimentos.Add(new Compartimento {
    Ingrediente = Ingrediente.Cafe
});
maquina.Compartimentos.Add(new Compartimento {
    Ingrediente = Ingrediente.Morte
});

var botaoCafe = new Botao(new CafeBasico(), maquina);
maquina.Botoes.Add(botaoCafe);

botaoCafe.Pressionar();

public class Maquina
{
    public List<Botao> Botoes { get; set; } = [];
    public List<Compartimento> Compartimentos { get; set; } = [];

    public void Adicionar(Ingrediente ingrediente, int quantidade)
    {
        foreach (var compartimento in Compartimentos)
        {
            if (compartimento.Ingrediente == ingrediente)
                compartimento.Abrir(quantidade);
        }
    }

    public void Finalizar()
    {
        Console.WriteLine("Soltando cafezinho na saída...");
    }
}

public class Compartimento
{
    public Ingrediente Ingrediente { get; set; }

    public void Abrir(int quantidade)
    {
        Console.WriteLine($"Abrindo compartimento com {Ingrediente}...");
    }
}

public enum Ingrediente
{
    Agua,
    Cafe,
    Acucar,
    Achocolatado,
    Leite,
    Morte,
    Cha
}

public interface IReceita
{
    void Preparar(Maquina maquina);
}

public class CafeBasico : IReceita
{
    public void Preparar(Maquina maquina)
    {
        maquina.Adicionar(Ingrediente.Agua, 20);
        maquina.Adicionar(Ingrediente.Cafe, 80);
        maquina.Adicionar(Ingrediente.Morte, 200);
        maquina.Finalizar();
    }
}

public class Botao(IReceita receita, Maquina maquina)
{
    public void Pressionar()
    {
        receita.Preparar(maquina);
    }
}