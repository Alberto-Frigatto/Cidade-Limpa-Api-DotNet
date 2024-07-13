namespace CidadeLimpa.ViewModels.Output
{
    public class PaginationRotaViewModel
    {
        public IEnumerable<DisplayRotaViewModel> Rotas { get; set; }
        public int CurrentPage { get; set; }
        public readonly int PageSize = 20;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Rotas.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Rota?page={CurrentPage - 1}" : "";
        public string NextPageUrl => HasNextPage ? $"/Rota?page={CurrentPage + 1}" : "";
    }
}
