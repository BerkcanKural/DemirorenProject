namespace DemirorenProject.API.Services
{
    public class PaginationMetadata
    {
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
        public int PageSize { get; set; }
        public int CurentPage { get; set; }
        public PaginationMetadata(int totalItemCount,int pageSize,int curentPage) {
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            CurentPage = curentPage;
            TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
             

        }
    }
}
