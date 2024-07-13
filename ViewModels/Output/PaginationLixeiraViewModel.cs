namespace CidadeLimpa.ViewModels.Output
{
    public class PaginationLixeiraViewModel
    {
        public IEnumerable<DisplayLixeiraViewModel> Lixeiras { get; set; }
        public int CurrentPage { get; set; }
        public readonly int PageSize = 20;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Lixeiras.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Lixeira?page={CurrentPage - 1}" : "";
        public string NextPageUrl => HasNextPage ? $"/Lixeira?page={CurrentPage + 1}" : "";
    }
}
