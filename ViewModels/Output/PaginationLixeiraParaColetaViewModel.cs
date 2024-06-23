namespace CidadeLimpa.ViewModels.Output
{
    public class PaginationLixeiraParaColetaViewModel
    {
        public IEnumerable<DisplayLixeiraParaColetaViewModel> LixeirasParaColeta { get; set; }
        public int CurrentPage { get; set; }
        public readonly int PageSize = 20;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => LixeirasParaColeta.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/LixeiraParaColeta?page={CurrentPage - 1}" : "";
        public string NextPageUrl => HasNextPage ? $"/LixeiraParaColeta?page={CurrentPage + 1}" : "";
    }
}
