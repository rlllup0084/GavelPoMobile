namespace GavelPoMobile.SandBox.Models {
    public class GetOrdersInfiniteResponse {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<GetOrdersInfiniteResult>? Results { get; set; }
    }
}
