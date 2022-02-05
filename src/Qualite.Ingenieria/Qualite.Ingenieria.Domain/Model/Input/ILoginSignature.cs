namespace Qualite.Ingenieria.Domain.Model.Input
{
    public interface ILoginSignature
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
