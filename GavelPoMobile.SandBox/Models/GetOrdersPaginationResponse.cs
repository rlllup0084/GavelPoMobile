namespace GavelPoMobile.SandBox.Models {
    public class GetOrdersPaginationResponse {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<GetOrdersPaginationResult>? Results { get; set; }
    }
}
