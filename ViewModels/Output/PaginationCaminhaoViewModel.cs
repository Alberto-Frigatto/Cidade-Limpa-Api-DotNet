namespace CidadeLimpa.ViewModels.Output
{
    public class PaginationCaminhaoViewModel
    {
        public IEnumerable<DisplayCaminhaoViewModel> Caminhoes { get; set; }
        public int CurrentPage { get; set; }
        public readonly int PageSize = 20;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Caminhoes.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Caminhao?page={CurrentPage - 1}" : "";
        public string NextPageUrl => HasNextPage ? $"/Caminhao?page={CurrentPage + 1}" : "";
    }
}
