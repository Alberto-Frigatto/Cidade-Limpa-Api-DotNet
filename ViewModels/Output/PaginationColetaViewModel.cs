namespace CidadeLimpa.ViewModels.Output
{
    public class PaginationColetaViewModel
    {
        public IEnumerable<DisplayColetaViewModel> Coletas { get; set; }
        public int CurrentPage { get; set; }
        public readonly int PageSize = 20;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Coletas.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Coleta?page={CurrentPage - 1}" : "";
        public string NextPageUrl => HasNextPage ? $"/Coleta?page={CurrentPage + 1}" : "";
    }
}
