namespace GavelPoMobile.SandBox.Models {
    public class GetPOPastApprovalsResponse {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<GetPOPastApprovalsResult>? Results { get; set; }
    }
}