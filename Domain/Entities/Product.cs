//Admin ou User
//Somente o endpoint de criação de usuário é livre de autenticação
//Se o usuário for admin vai poder editar/excluir/listar e obter dados de todos os usuários
//Se não for admin, ele só vai poder obter dados do seu próprio usuário


namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
