using GestaoDeLivraria.Model;

namespace GestaoDeLivraria.Repositories;

public class LivroRepository
{
    private List<Livro> _livros = new List<Livro>(); 

    public void Adicionar(Livro livro) => _livros.Add(livro);

    public List<Livro> ObterLivros() => _livros;

    public Livro ObterLivroPorId(int id) => _livros.FirstOrDefault(l => l.Id == id);

    public void EditarLivro(int id, Livro livro)
    {
        var index = _livros.FindIndex(l => l.Id == id);
        if (index != -1) _livros[index] = livro;
    }
    public void DeletarLivro(int id) => _livros.RemoveAll(l => l.Id == id);
}
